using System;
using System.IO;
using System.Windows.Forms;

namespace SpryCoder.Camever.Helpers
{
    public static class LogHelper
    {
        private static readonly string logFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "log.txt");
        public enum LogEntryType { Error, Information }

        public static void WriteLogEntry(string logText, LogEntryType logType)
        {
            if (!File.Exists(logFile))
                File.CreateText(logFile).Close();

            string oldLogEntries = File.ReadAllText(logFile);

            string logLine = $"{DateTime.Now.ToString()}\t{logType}\t{logText}" + Environment.NewLine;
            //File.AppendAllText(logFile, logLine);
            File.WriteAllText(logFile, logLine + oldLogEntries);
        }

        public static void ClearLog()
        {
            if (File.Exists(logFile))
            {
                File.WriteAllText(logFile, String.Empty);
                MessageBox.Show("The log has been cleared.", "Log Cleared", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public static void ViewLogFile()
        {
            if(!File.Exists(logFile))
            {
                MessageBox.Show("There are no log entries to view.", "Log Empty", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            // Load log file into default viewer
            System.Diagnostics.Process.Start(logFile);
        }
    }
}
