using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SpryCoder.WebcamCaptureTool
{
    public static class Logger
    {
        private static readonly string logFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "log.txt");
        public enum LogEntryType { Error, Information }

        public static void WriteLogEntry(string logText, LogEntryType logType)
        {
            string logLine = $"{DateTime.Now.ToString()}\t{logType}\t{logText}";
            File.AppendAllText(logFile, logLine);
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
