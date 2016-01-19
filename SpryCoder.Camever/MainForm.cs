using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using SpryCoder.Camever.Helpers;
using SpryCoder.Camever.Properties;
using Timer = System.Timers.Timer;

namespace SpryCoder.Camever
{
    public partial class MainForm : Form
    {
        readonly BackgroundWorker _backgroundCaptureTask = new BackgroundWorker();
        readonly Timer _captureTimer = new Timer();

        private EventListViewHelper eventList;

        // PROPERTIES
        private DateTime NextHitTime => CameraHelper.NextCaptureTime(DateTime.Now, double.Parse(Settings.Default.UpdateInterval));
        private TimeSpan TimeDiff => NextHitTime.Subtract(DateTime.Now);
        private string ImageFileName => CameraHelper.TemplateReplace(Settings.Default.ImageFileNamingFormat) + ".jpg";

        /// <summary>
        /// Main Form 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();


            //Debug log
            TextWriterTraceListener[] listeners = new TextWriterTraceListener[] {
            new TextWriterTraceListener("c:\\temp\\debug.txt"),
          new TextWriterTraceListener(Console.Out)};
            Debug.Listeners.AddRange(listeners);



            // StatusStrip padding/margins
            statusStripMain.Padding = new Padding(statusStripMain.Padding.Left,
                                        statusStripMain.Padding.Top, statusStripMain.Padding.Left, statusStripMain.Padding.Bottom);

            // Look for settings changes
            Settings.Default.PropertyChanged += Settings_PropertyChanged;


            // Check for First Run
            // First Run, force the Options window
            if (Settings.Default.FirstRun)
            {
                MessageBox.Show("This is the first time that this application has been executed.  We'll take you to the Options so you can configure the required settings.", 
                                    "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OptionsForm options = new OptionsForm();
                options.ShowDialog();
                Settings.Default.FirstRun = false;
                Settings.Default.Save();
            }

            // Setup events
            
            _captureTimer.Elapsed += Timer_Elapsed;
            _backgroundCaptureTask.DoWork += Task_DoWork;
            _backgroundCaptureTask.RunWorkerCompleted += Task_RunWorkerCompleted;

            // Log Helper
            eventList = new EventListViewHelper(this);
            

        }

        /// <summary>
        /// Main Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Form title
            Text = ProductInfoHelper.AssemblyTitle;

            // Check for general settings
            TopMost = Settings.Default.KeepOnTop;

            // Set window location
            SetWindowLocation();

            // Check if capture enabled
            if (Settings.Default.CapturesEnabled)
            {
                LaunchTimer();
            }

            // Update labels
            UpdateLabels();

        }

        /// <summary>
        /// Watch for setting changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Set window location
            if (e.PropertyName == "WindowLocation") SetWindowLocation();

            // Check for Keep on top option change
            if (e.PropertyName == "KeepOnTop")
            {
                // Check if capture enabled
                TopMost = Settings.Default.KeepOnTop;
            }

            // Check for schedule change
            if (e.PropertyName == "CapturesEnabled" || e.PropertyName == "UpdateInterval")
            {
                // Reset scheduling task
                // Check if capture enabled
                if (Settings.Default.CapturesEnabled)
                {
                    //_captureTimer.Stop();
                    LaunchTimer();
                }
                else
                {
                    _captureTimer.Stop();
                }
            }

            // Update labels in the UI
            UpdateLabels();
        }

        /// <summary>
        /// Start timer with background task
        /// </summary>
        private void LaunchTimer()
        {
            Debug.WriteLine($"{DateTime.Now.ToString()} - LaunchTimer called. " + Thread.CurrentThread.ManagedThreadId);
            Debug.Flush();
            // Backgroundwork events teardown and build up
            //_backgroundCaptureTask.DoWork -= Task_DoWork;
            //_backgroundCaptureTask.RunWorkerCompleted -= Task_RunWorkerCompleted;
            //_backgroundCaptureTask.DoWork += Task_DoWork;
            //_backgroundCaptureTask.RunWorkerCompleted += Task_RunWorkerCompleted;

            // Start timer


            //captureTimer.Elapsed += Timer_Elapsed;
            _captureTimer.Stop();
            _captureTimer.Interval = TimeDiff.TotalMilliseconds;
            _captureTimer.AutoReset = false;
            _captureTimer.Start();
            
        }

        /// <summary>
        /// Runs when timer has elapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Debug.WriteLine($"{DateTime.Now.ToString()} - Timer elapsed. " + Thread.CurrentThread.ManagedThreadId);
            Debug.Flush();

            // Check for beta expiration
            if (BetaHelper.BetaExpired())
            {
                MessageBox.Show("Sorry, this beta version has expired and can no longer be used.  Please uninstall or download an updated version.",
                    "Beta Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            _backgroundCaptureTask.RunWorkerAsync();
            //captureTimer.Stop();

            //LaunchTimer();
            //captureTimer.Interval = TimeDiff.TotalMilliseconds;
            //captureTimer.Start();

        }

        /// <summary>
        /// Runs when background task is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Task_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine($"{DateTime.Now.ToString()} - Task_RunWorkerCompleted called ." + Thread.CurrentThread.ManagedThreadId);
            Debug.Flush();

            // Reset task schedule
            //_captureTimer.Stop();

            // Restart timer
            LaunchTimer();

            // Update UI on UI thread
            BeginInvoke((MethodInvoker)UpdateLabels);
        }

        /// <summary>
        /// Runs when background task is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Task_DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine($"{DateTime.Now.ToString()} - Task_DoWork called. " + Thread.CurrentThread.ManagedThreadId);
            Debug.Flush();


            // Capture Image and then save it
            try
            {
                var imageFile = Path.Combine(Settings.Default.ImageSavePath, ImageFileName);

                // Save Capture
                Debug.WriteLine($"{DateTime.Now.ToString()} - SaveCapturedImage (inside Task_DoWork) called. " + Thread.CurrentThread.ManagedThreadId);
                Debug.Flush();

                SaveCapturedImage(await CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage),imageFile);
                //LogHelper.WriteLogEntry($"Scheduled snapshot taken successfully. ({imageFile})", LogHelper.LogEntryType.Information);

                // Update on the UI thread
                BeginInvoke((MethodInvoker)delegate
                {
                    eventList.AddEvent($"Scheduled snapshot successful. ({imageFile})", EventListViewHelper.LogEntryType.Information);
                });
                

                // Check for Services enabled on schedule
                if (Settings.Default.WundergroundUploadEnabled)
                {
                    try
                    {
                        await CameraHelper.UploadWuCamImage(
                            Settings.Default.WundergroundCameraID,
                            PasswordHelper.DecryptString(Settings.Default.WundergroundPassword),
                            await CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage)
                        );

                        //LogHelper.WriteLogEntry("Weather Underground webcam snapshot upload successful.", LogHelper.LogEntryType.Information);

                        // Update on the UI thread
                        BeginInvoke((MethodInvoker)delegate
                        {
                            eventList.AddEvent("Weather Underground webcam snapshot upload successful.", EventListViewHelper.LogEntryType.Information);
                        });
                        
                    }
                    catch (Exception wuex)
                    {

                        // Update on the UI thread
                        //LogHelper.WriteLogEntry("Weather Underground webcam snapshot upload failed. " + wuex.Message, LogHelper.LogEntryType.Error);
                        

                        BeginInvoke((MethodInvoker)delegate
                        {
                            //LastStatusLabel.Text = "Upload Failure";
                            eventList.AddEvent("Weather Underground webcam snapshot upload failed. " + wuex.Message, EventListViewHelper.LogEntryType.Error);

                        });
                    }
                }

            }
            catch (Exception ex)
            {
                // Update on the UI thread
                //LogHelper.WriteLogEntry($"Scheduled snapshot failed. " + ex.Message, LogHelper.LogEntryType.Error);
                

                BeginInvoke((MethodInvoker)delegate
                {
                    //LastStatusLabel.Text = "Error";
                    eventList.AddEvent($"Scheduled snapshot failed. " + ex.Message, EventListViewHelper.LogEntryType.Error);
                });

            }

        }

        /// CUSTOM METHODS ///

        private void SaveCapturedImage(Image image, string imageFileFullPath)
        {
            Debug.WriteLine($"{DateTime.Now.ToString()} - SaveCapturedImage called. " + Thread.CurrentThread.ManagedThreadId);
            Debug.Flush();

            //Image newimage = image;
            image.Save(imageFileFullPath, ImageFormat.Jpeg);
        }

        private void SetWindowLocation()
        {
            // Check for preferred window location
            switch (Settings.Default.WindowLocation)
            {
                case "BottomRight":
                    // Place form in lower right
                    PlaceLowerRight();
                    break;
                case "TopRight":
                    // Place form in top right
                    PlaceUpperRight();
                    break;
                default:
                    // Place form in lower right
                    PlaceLowerRight();
                    break;
            }
        }

        private void PlaceLowerRight()
        {

            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            Left = rightmost.WorkingArea.Right - Width - 50;
            Top = rightmost.WorkingArea.Bottom - Height - 50;

        }

        private void PlaceUpperRight()
        {

            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            Left = rightmost.WorkingArea.Right - Width - 50;
            Top = rightmost.WorkingArea.Top + 50;

        }

        private void UpdateLabels()
        {
            // Update Labels
            stripStatusScheduler.Text = Settings.Default.CapturesEnabled ? "Scheduler: Enabled" : "Scheduler: Disabled";
            stripStatusNextCaptureTime.Text = Settings.Default.CapturesEnabled ?
                $"Next Run: {NextHitTime.ToShortDateString()} {NextHitTime.ToShortTimeString()}"
                : "Next Run: Not scheduled";
        }


        /// MENU ITEMS ///
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit Program
            Close();
        }

        private async void previewCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // Instantiate Preview Form with Image
                PreviewForm preview = new PreviewForm(await CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage));
                Cursor = Cursors.Default;
                //LogHelper.WriteLogEntry("Preview snapshot loaded successfully.", LogHelper.LogEntryType.Information);
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                //LogHelper.WriteLogEntry("Preview snapshot error has occurred. " + ex.Message, LogHelper.LogEntryType.Error);

                MessageBox.Show("We ran into a problem generating the preview image. " + ex.Message + ".",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }

        }

        private async void captureSnapshotNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check for beta expiration
            if (BetaHelper.BetaExpired())
            {
                MessageBox.Show("Sorry, this beta version has expired and can no longer be used.  Please uninstall or download an updated version.",
                    "Beta Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            try
            {
                // Capture Image and then save it
                //Image image = CaptureImage();
                Cursor = Cursors.WaitCursor;
                string imageFile = Path.Combine(Settings.Default.ImageSavePath, ImageFileName);

                SaveCapturedImage(await CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage),imageFile);

                Cursor = Cursors.Default;

                //LogHelper.WriteLogEntry($"Manual snapshot taken successfully. ({imageFile})", LogHelper.LogEntryType.Information);

                BeginInvoke((MethodInvoker)delegate
                {
                    //LastStatusLabel.Text = "Error";
                    eventList.AddEvent($"Manual snapshot successful. ({imageFile})", EventListViewHelper.LogEntryType.Information);
                });
                

                MessageBox.Show("Snapshot completed successfully!",
                    "Snapshot Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                //LogHelper.WriteLogEntry("Manual snapshot error has occurred. " + ex.Message, LogHelper.LogEntryType.Error);

                BeginInvoke((MethodInvoker)delegate
                {
                    eventList.AddEvent("Manual snapshot error has occurred. " + ex.Message, EventListViewHelper.LogEntryType.Error);
                });

                MessageBox.Show("We ran into a problem generating the snapshot image.  " + ex.Message + ".",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm options = new OptionsForm();
            options.ShowDialog();
            UpdateLabels();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void errorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogHelper.ViewLogFile();
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear the log
            LogHelper.ClearLog();
        }
    }
}
