using System;
using System.Threading;
using System.Windows.Forms;
using ArmchairCoder.Camever.Helpers;
using ArmchairCoder.Camever.Properties;

namespace ArmchairCoder.Camever
{
    static class Program
    {
        // ReSharper disable once InconsistentNaming
        static readonly Mutex mutex = new Mutex(true, "<53FC12C6-7064-46B6-916B-FB97CC89137A>");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check if beta expired
            //if (BetaHelper.BetaExpired())
            //{
            //    MessageBox.Show("Sorry, this beta version has expired and can no longer be used.  Please uninstall or download an updated version.",
            //        "Beta Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            // Check if settings need to be upgraded because of file version change
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }
            
            // Blocks the current thread until the current instance receives a signal,
            // using a TimeSpan to specify the time interval and specifying whether to exit the synchronization domain before the wait.
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                // Releases the Mutex once.
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("There is already an instance of this application running.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
