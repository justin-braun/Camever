using SpryCoder.Camever.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using SpryCoder.Camever.Helpers;
using System.Diagnostics;

namespace SpryCoder.Camever
{
    public partial class MainForm : Form
    {
        BackgroundWorker backgroundCaptureTask = new BackgroundWorker();
        System.Timers.Timer captureTimer = new System.Timers.Timer();

        // PROPERTIES
        public DateTime NextHitTime { get { return CameraHelper.NextCaptureTime(DateTime.Now, double.Parse(Settings.Default.UpdateInterval)); } }
        public TimeSpan TimeDiff { get { return NextHitTime.Subtract(DateTime.Now); } }
        public string ImageFileName {  get { return CameraHelper.TemplateReplace(Settings.Default.ImageFileNamingFormat) + ".jpg"; } }

        /// <summary>
        /// Main Form 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Clear controls/labels
            stripStatusLastStatus.Text = "Status: Ready.";

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
            
            captureTimer.Elapsed += Timer_Elapsed;
            backgroundCaptureTask.DoWork += Task_DoWork;
            backgroundCaptureTask.RunWorkerCompleted += Task_RunWorkerCompleted;
            

        }

        /// <summary>
        /// Main Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Form title
            this.Text = ProductInfoHelper.AssemblyTitle;

            // Check for general settings
            this.TopMost = Settings.Default.KeepOnTop;

            // Set window location
            SetWindowLocation();

            // Check if capture enabled
            if (Settings.Default.CapturesEnabled == true)
            {
                LaunchTimer();
                Debug.WriteLine("Timer started");
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
                if (Settings.Default.KeepOnTop == true)
                {
                    this.TopMost = true;
                }
                else
                {
                    this.TopMost = false;
                }
            }

            // Check for schedule change
            if (e.PropertyName == "CapturesEnabled" || e.PropertyName == "UpdateInterval")
            {
                // Reset scheduling task
                // Check if capture enabled
                if (Settings.Default.CapturesEnabled)
                {
                    captureTimer.Stop();
                    LaunchTimer();
                    Debug.WriteLine("Timer started after setting change.");
                }
                else
                {
                    captureTimer.Stop();
                    Debug.WriteLine("Timer stopped after setting change.");
                }
            }

            // Update labels in the UI
            UpdateLabels();
        }

        /// <summary>
        /// Start timer with background task
        /// </summary>
        public void LaunchTimer()
        {

            // Start timer

            captureTimer.Interval = TimeDiff.TotalMilliseconds;
            captureTimer.AutoReset = false;

            //captureTimer.Elapsed += Timer_Elapsed;
            captureTimer.Interval = TimeDiff.TotalMilliseconds;
            captureTimer.AutoReset = false;
            captureTimer.Start();
            
        }

        /// <summary>
        /// Runs when timer has elapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Check for beta expiration
            if (BetaHelper.BetaExpired())
            {
                MessageBox.Show("Sorry, this beta version has expired and can no longer be used.  Please uninstall or download an updated version.",
                    "Beta Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            backgroundCaptureTask.RunWorkerAsync();
            Debug.WriteLine("Timer elapsed, background task started.");
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
            // Reset task schedule
            captureTimer.Stop();
            //captureTimer.Dispose();

            LaunchTimer();

            BeginInvoke((MethodInvoker)delegate
            {
                UpdateLabels();
            });

            Debug.WriteLine("Task completed, timer stopped and relaunched.");
        }

        /// <summary>
        /// Runs when background task is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Task_DoWork(object sender, DoWorkEventArgs e)
        {
            // Capture Image and then save it
            try
            {
                // Update on the UI thread
                BeginInvoke((MethodInvoker)delegate
                {
                    stripStatusLastStatus.Text = "Status: Capture in progress...";
                });

                string imageFile = Path.Combine(Settings.Default.ImageSavePath, ImageFileName);

                // Save Capture
                SaveCapturedImage(await CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage),imageFile);
                LogHelper.WriteLogEntry($"Scheduled snapshot taken successfully. ({imageFile})", LogHelper.LogEntryType.Information);

                // Check for Services enabled on schedule
                if (Settings.Default.WundergroundUploadEnabled == true)
                {
                    try
                    {
                        await CameraHelper.UploadWUCamImage(
                            Settings.Default.WundergroundCameraID,
                            PasswordHelper.DecryptString(Settings.Default.WundergroundPassword),
                            await CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage)
                        );

                        LogHelper.WriteLogEntry("Weather Underground webcam snapshot uploaded successfully.", LogHelper.LogEntryType.Information);
                    }
                    catch (Exception wuex)
                    {

                        // Update on the UI thread
                        LogHelper.WriteLogEntry("Weather Underground webcam snapshot upload failed. " + wuex.Message, LogHelper.LogEntryType.Error);

                        BeginInvoke((MethodInvoker)delegate
                        {
                            //LastStatusLabel.Text = "Upload Failure";
                            stripStatusLastStatus.Text = $"({DateTime.Now}) Status: WU upload failed.";
                        });
                    }
                }

                // Update on the UI thread
                BeginInvoke((MethodInvoker)delegate
                {
                    //LastStatusLabel.Text = "Success";
                    stripStatusLastStatus.Text = $"Status: ({DateTime.Now}) Capture successful.";
                });
            }
            catch (Exception ex)
            {
                // Update on the UI thread
                LogHelper.WriteLogEntry($"({DateTime.Now}) Scheduled snapshot capture failed. " + ex.Message, LogHelper.LogEntryType.Error);

                BeginInvoke((MethodInvoker)delegate
                {
                    //LastStatusLabel.Text = "Error";
                    stripStatusLastStatus.Text = $"({DateTime.Now}) Status: Capture failed.";
                });

            }

        }

        /// CUSTOM METHODS ///

        private void SaveCapturedImage(Image image, string ImageFileFullPath)
        {
            //Image newimage = image;
            try
            {
                image.Save(ImageFileFullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception)
            {
                //LogHelper.WriteLogEntry("Error saving captured image file. " + ex.Message, LogHelper.LogEntryType.Error);
                throw;
            }

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

            this.Left = rightmost.WorkingArea.Right - this.Width - 50;
            this.Top = rightmost.WorkingArea.Bottom - this.Height - 50;

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

            this.Left = rightmost.WorkingArea.Right - this.Width - 50;
            this.Top = rightmost.WorkingArea.Top + 50;

        }

        private void UpdateLabels()
        {
            // Update Labels
            stripStatusScheduler.Text = Settings.Default.CapturesEnabled ? "Scheduler: Enabled" : "Scheduler: Disabled";
            stripStatusNextCaptureTime.Text = Settings.Default.CapturesEnabled ? string.Format("Next Run: {0} {1}", NextHitTime.ToShortDateString(), NextHitTime.ToShortTimeString()) : "Next Run: Not scheduled";
        }




        /// MENU ITEMS ///
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit Program
            this.Close();
        }

        private async void previewCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // Instantiate Preview Form with Image
                PreviewForm preview = new PreviewForm(await CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage));
                this.Cursor = Cursors.Default;
                //LogHelper.WriteLogEntry("Preview snapshot loaded successfully.", LogHelper.LogEntryType.Information);
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                LogHelper.WriteLogEntry("Preview snapshot error has occurred. " + ex.Message, LogHelper.LogEntryType.Error);

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
                this.Close();
            }

            try
            {
                // Capture Image and then save it
                //Image image = CaptureImage();
                this.Cursor = Cursors.WaitCursor;
                string imageFile = Path.Combine(Settings.Default.ImageSavePath, ImageFileName);

                SaveCapturedImage(await CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage),imageFile);

                this.Cursor = Cursors.Default;

                //LogHelper.WriteLogEntry($"Manual snapshot taken successfully. ({imageFile})", LogHelper.LogEntryType.Information);

                MessageBox.Show("Snapshot completed successfully!",
                    "Snapshot Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                LogHelper.WriteLogEntry("Manual snapshot error has occurred. " + ex.Message, LogHelper.LogEntryType.Error);
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
            LogHelper.ClearLog();
        }

        private void stripStatusScheduler_Click(object sender, EventArgs e)
        {

        }
    }
}
