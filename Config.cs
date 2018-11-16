using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbidity_Project_Modbus_Protocol
{
    public static class Config
    {
        public static string errorMessage { get; set; } = String.Empty;
        public static string secondaryErrorMsg { get; private set; } = String.Empty;
        public static string[] configData { get; set; } = new string[4];

        /// <summary>
        /// Read data in from config file and save in configData[]
        /// </summary>

        public static void ReadFromConfigFile()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.txt");

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    // Read and store in array from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Get only line of data needed (last line of file, cannot have empty lines at end) and put in configData array
                        if (sr.Peek() == -1)
                        {
                            //Remove tabs and spaces then save in configData
                            string tempLine = line.Replace("\t", " ");
                            while (tempLine.IndexOf("  ") > 0)
                            {
                                tempLine = tempLine.Replace("  ", " ");
                            }
                            configData = tempLine.Split();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = String.Empty;
                //Log any error message
                LogError(errorMessage = ex.Message.ToString());
            }
        }// end Function readFromConfigFile

        /// <summary>
        /// Create a default config file and store settings in file
        /// </summary>
        public static void CreateConfigFile()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.txt");

            try
            {
                //If config.txt does not exist create with the following information
                if (!File.Exists(path))
                {
                    //Create default text to write to file
                    string defaultConfigFile = "Configuration Information"
                    + Environment.NewLine + "-----------------------------"
                    + Environment.NewLine + "If the com port is ever changed on the computer then it needs to be updated here (line 13) as well."
                    + Environment.NewLine + "\tIn order for the program to work the com port listed in this file must match the com port used on computer."
                    + Environment.NewLine + "\tIf not sure of which com port is being used, look in Device Manager --> Ports"
                    + Environment.NewLine + "The baud rate here (line 13), and on the Turbidity device (sc200) must match, please check both locations to verify."
                    + Environment.NewLine + "\tFrom the sc200 controller home screen, choose Network Setup --> Baud Rate"
                    + Environment.NewLine + "\tFor RS232 connection, 9600 baud rate is best, but it can also go up to 19200 baud rate."
                    + Environment.NewLine + "The time interval (line 13) is for how often you want to grab a turbidity reading from your device."
                    + Environment.NewLine + "\tThis can be anytime from 1 min up to 60 min."
                    + Environment.NewLine
                    + Environment.NewLine + "Important Notes - There cannot be an empty/blank line at the end of file. The program will not read in data correctly."
                    + Environment.NewLine + "\tPlease make sure no extra lines and/or spaces are after the \"Time Interval\""
                    + Environment.NewLine
                    + Environment.NewLine + "*********CONFIGURATION INFORMATION*********"
                    + Environment.NewLine + "COM PORT\tBAUD RATE\tTIME INTERVAL\tSAVED DATA LOCATION"
                    + Environment.NewLine + "COM3\t\t9600\t\t60\t\t";
                    //Write to file
                    using (StreamWriter file = new StreamWriter(path))
                    {
                        file.Write(defaultConfigFile);
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = String.Empty;
                //Log any error message
                LogError(errorMessage = ex.Message.ToString());
            }
        }// end Function CreateConfigFile


        /// <summary>
        /// Takes user input from configData and updates config file
        /// </summary>
        public static void updateConfigFile()
        {
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "config.txt");
            string defaultConfigFile = "Configuration Information"
                    + Environment.NewLine + "-----------------------------"
                    + Environment.NewLine + "If the com port is ever changed on the computer then it needs to be updated here (line 17) as well."
                    + Environment.NewLine + "\tIn order for the program to work the com port listed in this file must match the com port used on computer."
                    + Environment.NewLine + "\tIf not sure of which com port is being used, look in Device Manager --> Ports"
                    + Environment.NewLine + "The baud rate here (line 17), and on the Turbidity device (sc200) must match, please check both locations to verify."
                    + Environment.NewLine + "\tFrom the sc200 controller home screen, choose Network Setup --> Baud Rate"
                    + Environment.NewLine + "\tFor RS232 connection, 9600 baud rate is best, but it can also go up to 19200 baud rate."
                    + Environment.NewLine + "The time interval (line 17) is for how often you want to grab a turbidity reading from your device."
                    + Environment.NewLine + "\tThis can be anytime from 1 min up to 60 min."
                    + Environment.NewLine
                    + Environment.NewLine + "Important Notes - There cannot be an empty/blank line at the end of file. The program will not read in data correctly."
                    + Environment.NewLine + "\tPlease make sure no extra lines and/or spaces are after the time in minutes"
                    + Environment.NewLine
                    + Environment.NewLine + "*********CONFIGURATION INFORMATION*********"
                    + Environment.NewLine + "COM PORT\tBAUD RATE\tTIME INTERVAL\tSAVED DATA LOCATION"
                    + Environment.NewLine + configData[0] + "\t\t" + configData[1] + "\t\t" + configData[2] + "\t\t" + configData[3];// configData[0] is port, configData[1] is baud rate, and configData[2] is time interval
            //Would like to only write out only the last line of this file. Suggestions I've seen online all talk about reading in each line and queueing them up. Seems to be as much time and 
            // memory as just rewriting the file, so I chose to just rewrite the file
            try
            {
                //Write to file
                using (StreamWriter file = new StreamWriter(path))
                {
                    file.Write(defaultConfigFile);
                }
            }
            catch (Exception ex)
            {
                errorMessage = String.Empty;
                //Log any error message
                LogError(errorMessage = ex.Message.ToString());
            }
        }// end Function updateConfigFile

        /// <summary>
        /// Log error message out to file
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void LogError(string errorMessage)
        {
            string dateTimeStamp = DateTime.Now.ToString();
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log.txt");

            try
            {
                // Append new text to an existing file.
                // The using statement automatically flushes AND CLOSES the stream and calls 
                // IDisposable.Dispose on the stream object.
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine(dateTimeStamp + Environment.NewLine + errorMessage + Environment.NewLine + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                secondaryErrorMsg = String.Empty;
                //The following conditions may cause an exception:
                //The file exists and is read - only
                //The disk may be full
                secondaryErrorMsg = ex.Message;
            }
        }// end Function LogError

    }


}
