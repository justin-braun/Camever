using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SpryCoder.Camever.Helpers
{
    public static class LogHelper
    {
        private static readonly string LogFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "log.txt");
        public enum LogEntryType { Error, Information }

        public static void WriteLogEntry(string logText, LogEntryType logType)
        {
            if (!File.Exists(LogFile))
                File.CreateText(LogFile).Close();

            string oldLogEntries = File.ReadAllText(LogFile);

            string logLine = $"{DateTime.Now}\t{logType}\t{logText}" + Environment.NewLine;
            //File.AppendAllText(logFile, logLine);
            File.WriteAllText(LogFile, logLine + oldLogEntries);
        }

        public static void ClearLog()
        {
            if (File.Exists(LogFile))
            {
                File.WriteAllText(LogFile, String.Empty);
                MessageBox.Show("The log has been cleared.", "Log Cleared", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public static void ViewLogFile()
        {
            if(!File.Exists(LogFile))
            {
                MessageBox.Show("There are no log entries to view.", "Log Empty", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            // Load log file into default viewer
            Process.Start(LogFile);
        }
    }
}
