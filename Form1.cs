using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                timer1.Interval = int.Parse(turbidity.configData[2]) * 60000;
            }
            catch (Exception)
            {

                throw;
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
            Thread.Sleep(TimeSpan.FromSeconds(1));
            
            //Read message from sc200 controller
            turbidity.ReadFromSP();
            //Error message
            if (!String.IsNullOrEmpty(turbidity.errorMessage))
            {
                MessageBox.Show("Error receiving message from Turbidity meter."
                    + Environment.NewLine + "See log file for details.", "Error Message", MessageBoxButtons.OK);
            }
            
            //Write converted Turbidity number out to file
            turbidity.WriteTurbidDataToFile();
            if (!String.IsNullOrEmpty(turbidity.errorMessage))
            {
                MessageBox.Show("Error writing turbidity number out to file."
                    + Environment.NewLine + "See log file for details.", "Error Message", MessageBoxButtons.OK);
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
            //Give user feedback that save happened
            if (turbidity.timeInterval != checkInterval || changesMade)
            {
                if (okSave)
                {
                    //Write new settings out to config file
                    turbidity.updateConfigFile();

                    //Give feedback to user that settings are saved
                    MessageBox.Show("Settings have been updated in \"config.txt\"", "Save Successful", MessageBoxButtons.OK);
                    okSave = false;

                    //reset timer1 to new input if it has changed
                    if (turbidity.timeInterval != int.Parse(turbidity.configData[2]))
                    {
                        try
                        {
                            //TODO: Need to reset timer if changed
                            timer1.Enabled = false;
                            timer1.Interval = int.Parse(turbidity.configData[2]) * 60000;
                            timer1.Enabled = true;
                        }
                        catch (Exception)
                        {

                            throw;
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

            //TODO: Make com port a drop down box like baud rate
            //Verify com port input matches correct com port form (ie. COM1)
            if (correctComPort)
            {
                txtBoxComPort.CharacterCasing = CharacterCasing.Upper;
                turbidity.configData[0] = txtBoxComPort.Text;
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
                turbidity.configData[1] = cmbBoxBaudRate.Text;
                changesMade = true;
                okSave = true;
            }

            //Verify timeInterval input is a number is not 0 and time is in minutes
            if (correctTimeInterval)
            {
                if (txtBoxTimeInterval.Text != "0")
                {
                    turbidity.configData[2] = txtBoxTimeInterval.Text;
                    if (int.TryParse(turbidity.configData[2], out int interval))
                    {
                        checkInterval = interval;
                        okSave = true;
                    }
                }
                else
                {
                    MessageBox.Show("Cannot be \"0\" \nInput must be a whole number written in minutes (ie. 1hr = 60)");
                    txtBoxTimeInterval.Clear();
                }
                
            }
            else if (string.IsNullOrWhiteSpace(txtBoxTimeInterval.Text))
            {
                //Intentionally left blank, if text box is empty don't do anything
            }
            else
            {
                MessageBox.Show("Input must be a whole number written in minutes (ie. 1hr = 60)");
                txtBoxTimeInterval.Clear();
            }
        }// end function verifyInput
    }// end class Form1
}// end namespace Turbidity