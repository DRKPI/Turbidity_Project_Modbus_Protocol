﻿using System;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Turbidity
{
    public partial class Form1 : Form
    {
        TurbidityCommunication turbidity = new TurbidityCommunication();
        bool changesMade = false;
        bool okSave = false;
        int checkInterval = 0;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On button click build message, send and receive message, print out message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequestMsg_Click(object sender, EventArgs e)
        {
            //Disable items
            btnRequestMsg.Enabled = false;
            timer1.Enabled = false;

            try
            {
                //Set timer interval
                timer1.Interval = int.Parse(Turbidity_Project_Modbus_Protocol.Config.configData[2]) * 60000;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Time Interval must be a whole number written in minutes (ie. 1hr = 60)");
                txtBoxTimeInterval.Clear();
                turbidity.errorMessage = String.Empty;
                turbidity.LogError(turbidity.errorMessage = Environment.NewLine + ex.ToString());
                //Error message if could not write error message out to file
                if (!String.IsNullOrEmpty(turbidity.secondaryErrorMsg))
                {
                    MessageBox.Show("Could not write error out to file." + Environment.NewLine + turbidity.secondaryErrorMsg, "Error Message", MessageBoxButtons.OK);
                }
            }

            //Call startProcess function
            StartProcess();

            //Enable items
            timer1.Enabled = true;
            btnRequestMsg.Enabled = true;
        }// end Function btnRequestMsg_Click

        /// <summary>
        /// On load of form starts a serial port and 
        /// builds message to send to turbidity device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Set GUI custom color scheme
            this.BackColor = System.Drawing.Color.FromArgb(0, 132, 61);
            this.editTabPage.BackColor = System.Drawing.Color.FromArgb(0, 132, 61);
            this.btnCancelConfigInput.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnRequestMsg.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnSaveConfigInput.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.aboutTabPage.BackColor = System.Drawing.Color.FromArgb(0, 132, 61);
            this.richTextBoxAboutInfo.BackColor = System.Drawing.Color.FromArgb(0, 132, 61);
            
            //Call Function to build Modbus request message
            turbidity.BuildMessage();

            // Open a serial port / display error
            turbidity.OpenSerialPort();
            //Error message
            if (!String.IsNullOrEmpty(turbidity.errorMessage))
            {
                MessageBox.Show("Serial Port could not be opended." + Environment.NewLine +
                    "Verify the config file is written in the correct format." + Environment.NewLine +
                    " See log file for details. ", "Error Message", MessageBoxButtons.OK);
                //this.Close();
            }
            //Error message if could not write error message out to file
            if (!String.IsNullOrEmpty(turbidity.secondaryErrorMsg))
            {
                MessageBox.Show("Could not write error out to file." + Environment.NewLine + turbidity.secondaryErrorMsg, "Error Message", MessageBoxButtons.OK);
            }
        }// end Function Form1_Load

        /// <summary>
        /// Timer to continually request new Turbidity reading
        /// Set to time interval of users choosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            StartProcess();
        }// end Function timer1_Tick
       
        /// <summary>
        /// Start the process of gathering Turbidity reading
        /// Ends with displaying Turbidity reading to txtReceivedMsg.Text
        /// I decided to create this function in FormMain instead of TurbidityPacket cause I found this
        ///     to be the easiest way to pass error messages to the user associated with the correct function calls
        /// </summary>
        private void StartProcess()
        {
            //Send message to sc200 controller
            turbidity.WriteToSP(turbidity.message);
            //Error message
            if (!String.IsNullOrEmpty(turbidity.errorMessage))
            {
                MessageBox.Show("Error sending message to Turbidity meter."
                    + Environment.NewLine + "See log file for details.", "Error Message", MessageBoxButtons.OK);
            }
            //Error message if could not write error message out to file
            if (!String.IsNullOrEmpty(turbidity.secondaryErrorMsg))
            {
                MessageBox.Show("Could not write error out to file." + Environment.NewLine + turbidity.secondaryErrorMsg, "Error Message", MessageBoxButtons.OK);
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
            
            //Read message from sc200 controller
            turbidity.ReadFromSP();
            //Error message
            if (!String.IsNullOrEmpty(turbidity.errorMessage))
            {
                MessageBox.Show("Error receiving message from Turbidity meter."
                    + Environment.NewLine + "See log file for details.", "Error Message", MessageBoxButtons.OK);
            }
            //Error message if could not write error message out to file
            if (!String.IsNullOrEmpty(turbidity.secondaryErrorMsg))
            {
                MessageBox.Show("Could not write error out to file." + Environment.NewLine + turbidity.secondaryErrorMsg, "Error Message", MessageBoxButtons.OK);
            }

            //Write converted Turbidity number out to file
            turbidity.WriteTurbidDataToFile();
            if (!String.IsNullOrEmpty(turbidity.errorMessage))
            {
                MessageBox.Show("Error writing turbidity number out to file."
                    + Environment.NewLine + "See log file for details.", "Error Message", MessageBoxButtons.OK);
            }
            //Error message if could not write error message out to file
            if (!String.IsNullOrEmpty(turbidity.secondaryErrorMsg))
            {
                MessageBox.Show("Could not write error out to file." + Environment.NewLine + turbidity.secondaryErrorMsg, "Error Message", MessageBoxButtons.OK);
            }

            //Print turbidity number to screen
            txtReceivedMsg.Text = turbidity.turbidNum;
        }// end Function StartProcess

        /// <summary>
        /// Clears fields, may have this do more later
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelConfigInput_Click(object sender, EventArgs e)
        {
            //Disable save button while clearing
            btnSaveConfigInput.Enabled = false;
            //Clear text boxes, possibly navigate to "About" page
            txtBoxComPort.Clear();
            cmbBoxBaudRate.Text = "";
            txtBoxTimeInterval.Clear();
            //Enable save button
            btnSaveConfigInput.Enabled = true;
        }// end Function btnCancelConfigInput_Click

        /// <summary>
        /// Save input to config file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveConfigInput_Click(object sender, EventArgs e)
        {
            //Disable Clear and Save button
            btnCancelConfigInput.Enabled = false;
            btnSaveConfigInput.Enabled = false;
            verifyInput();
            if (!String.IsNullOrEmpty(turbidity.errorMessage))
            {
                MessageBox.Show("Error updating config file settings."
                    + Environment.NewLine + "See log file for details.", "Error Message", MessageBoxButtons.OK);
            }
            //Error message if could not write error message out to file
            if (!String.IsNullOrEmpty(turbidity.secondaryErrorMsg))
            {
                MessageBox.Show("Could not write error out to file." + Environment.NewLine + turbidity.secondaryErrorMsg, "Error Message", MessageBoxButtons.OK);
            }

            //Give user feedback that save happened
            if (turbidity.timeInterval != checkInterval || changesMade)
            {
                if (okSave)
                {
                    //Write new settings out to config file
                    Turbidity_Project_Modbus_Protocol.Config.updateConfigFile();

                    //Give feedback to user that settings are saved
                    MessageBox.Show("Settings saved correctly", "Save Successful", MessageBoxButtons.OK);
                    okSave = false;

                    //reset timer1 to new input if it has changed
                    if (turbidity.timeInterval != int.Parse(Turbidity_Project_Modbus_Protocol.Config.configData[2]))
                    {
                        try
                        {
                            timer1.Enabled = false;
                            timer1.Interval = int.Parse(Turbidity_Project_Modbus_Protocol.Config.configData[2]) * 60000;
                            timer1.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Time Interval must be a whole number written in minutes (ie. 1hr = 60)");
                            txtBoxTimeInterval.Clear();
                            turbidity.errorMessage = String.Empty;
                            turbidity.LogError(turbidity.errorMessage = Environment.NewLine + ex.ToString());
                            //Error message if could not write error message out to file
                            if (!String.IsNullOrEmpty(turbidity.secondaryErrorMsg))
                            {
                                MessageBox.Show("Could not write error out to file." + Environment.NewLine + turbidity.secondaryErrorMsg, "Error Message", MessageBoxButtons.OK);
                            }
                        }
                    }
                }

                //call OpenSerialPort if COM port or Baud Rate are changed
                if (changesMade)
                {
                    turbidity.OpenSerialPort();
                    changesMade = false;
                }
            }
            //Clear fields after everything is saved
            txtBoxComPort.Clear();
            cmbBoxBaudRate.Text = "";
            txtBoxTimeInterval.Clear();
            //Enable Clear and Save button
            btnSaveConfigInput.Enabled = true;
            btnCancelConfigInput.Enabled = true;
        }// end Function btnSaveConfigInput_Click

        /// <summary>
        /// Verifies validity of user input so it will work with program
        /// </summary>
        private void verifyInput()
        {
            bool correctTimeInterval = Regex.IsMatch(txtBoxTimeInterval.Text, "^[0-9]+$");
            bool correctComPort = Regex.IsMatch(txtBoxComPort.Text, "^(COM[0-9]+|com[0-9]+)$");

            //Verify com port input matches correct com port form (ie. COM1)
            if (correctComPort)
            {
                txtBoxComPort.CharacterCasing = CharacterCasing.Upper;
                Turbidity_Project_Modbus_Protocol.Config.configData[0] = txtBoxComPort.Text;
                changesMade = true;
                okSave = true;
            }
            else if (string.IsNullOrWhiteSpace(txtBoxComPort.Text))
            {
                //Intentionally left blank, if text box is empty don't do anything
            }
            else
            {
                MessageBox.Show("Input must be in format of \"COM1\"");
                txtBoxComPort.Clear();
            }

            //Check if Baud Rate has been changed, if so grab changes
            if (!string.IsNullOrWhiteSpace(cmbBoxBaudRate.Text))
            {
                Turbidity_Project_Modbus_Protocol.Config.configData[1] = cmbBoxBaudRate.Text;
                changesMade = true;
                okSave = true;
            }

            //Verify timeInterval input is a number is not 0 and time is in minutes
            if (correctTimeInterval)
            {
                if (txtBoxTimeInterval.Text != "0")
                {
                    Turbidity_Project_Modbus_Protocol.Config.configData[2] = txtBoxTimeInterval.Text;
                    if (int.TryParse(Turbidity_Project_Modbus_Protocol.Config.configData[2], out int interval))
                    {
                        checkInterval = interval;
                        okSave = true;
                    }
                }
                else
                {
                    MessageBox.Show("Cannot be \"0\" \nTime Interval must be a whole number written in minutes (ie. 1hr = 60)");
                    txtBoxTimeInterval.Clear();
                }
                
            }
            else if (string.IsNullOrWhiteSpace(txtBoxTimeInterval.Text))
            {
                //Intentionally left blank, if text box is empty don't do anything
            }
            else
            {
                MessageBox.Show("Time Interval must be a whole number written in minutes (ie. 1hr = 60)");
                txtBoxTimeInterval.Clear();
            }
        }// end function verifyInput

        private void btnChangeOnlineFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    turbidity.onlineFilePath = folderBrowserDialog.SelectedPath;
                    Turbidity_Project_Modbus_Protocol.Config.configData[3] = turbidity.onlineFilePath;
                    Turbidity_Project_Modbus_Protocol.Config.updateConfigFile();
                    //TODO: output message that file path change saved correctly
                    MessageBox.Show("Saved correctly");
                }
            }
            catch (Exception ex)
            {
                turbidity.errorMessage = String.Empty;
                turbidity.LogError(turbidity.errorMessage = Environment.NewLine + ex.ToString());
            }

            //TODO call a function to check if file path has been changed and save it to the config file.
            //Let user know that config file has been updated

        }

        //private void changeOnlineFilePath_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        //        DialogResult result = folderBrowserDialog.ShowDialog();

        //        if (result == DialogResult.OK)
        //        {
        //            turbidity.onlineFilePath = folderBrowserDialog.SelectedPath;

        //            //TODO: output message that file path change saved correctly
        //            MessageBox.Show("Saved correctly");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        turbidity.errorMessage = String.Empty;
        //        turbidity.LogError(turbidity.errorMessage = Environment.NewLine + ex.ToString());
        //    }
        //}// end function btnSaveFilePath_Click
    }// end class Form1
}// end namespace Turbidity