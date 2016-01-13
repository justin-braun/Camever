using SpryCoder.Camever.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;

namespace SpryCoder.Camever
{
    public partial class MainForm : Form
    {
        BackgroundWorker backgroundCaptureTask;
        System.Timers.Timer captureTimer;

        // PROPERTIES
        public DateTime NextHitTime { get { return CamUtil.NextCaptureTime(DateTime.Now, double.Parse(Settings.Default.UpdateInterval)); } }
        public TimeSpan TimeDiff { get { return NextHitTime.Subtract(DateTime.Now); } }
        public string ImageFileName {  get { return CamUtil.TemplateReplace(Settings.Default.ImageFileNamingFormat) + ".jpg"; } }

        /// <summary>
        /// Main Form 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Clear controls/labels
            NextCaptureTimeLabel.Text = "";
            LastStatusLabel.Text = "";

            // Look for settings changes
            Settings.Default.PropertyChanged += Settings_PropertyChanged;

            // If settings are blank, force the Options window
            if (String.IsNullOrEmpty(Settings.Default.CameraHostname))
            {
                MessageBox.Show("This is the first time that this application has been executed.  We'll take you to the Options so you can configure the required settings.");
                OptionsForm options = new OptionsForm();
                options.ShowDialog();
            }
        }

        /// <summary>
        /// Main Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Check for general settings
            this.TopMost = Settings.Default.KeepOnTop;

            // Set window location
            SetWindowLocation();

            // Check if capture enabled
            if (Settings.Default.CapturesEnabled == true)
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
            if (e.PropertyName == "CapturesEnabled")
            {
                // Reset scheduling task
                // Check if capture enabled
                if (Settings.Default.CapturesEnabled)
                {
                    LaunchTimer();
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
            // Setup background worker task
            backgroundCaptureTask = new BackgroundWorker();
            backgroundCaptureTask.DoWork += Task_DoWork;
            backgroundCaptureTask.RunWorkerCompleted += Task_RunWorkerCompleted;

            // Start timer
            captureTimer = new System.Timers.Timer();
            captureTimer.Interval = TimeDiff.TotalMilliseconds;
            captureTimer.Elapsed += Timer_Elapsed;
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
            backgroundCaptureTask.RunWorkerAsync();
            captureTimer.Stop();
            captureTimer.Interval = TimeDiff.TotalMilliseconds;
            captureTimer.Start();

        }

        /// <summary>
        /// Runs when background task is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Task_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Reset task schedule
            BeginInvoke((MethodInvoker)delegate
            {
                UpdateLabels();
            });
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
                    LastStatusLabel.Text = "Capturing";
                });

                string imageFile = Path.Combine(Settings.Default.ImageSavePath, ImageFileName);

                // Save Capture
                SaveCapturedImage(await CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage),imageFile);
                //Logger.WriteLogEntry($"Scheduled snapshot taken successfully. ({imageFile})", Logger.LogEntryType.Information);

                // Check for Services enabled on schedule
                if (Settings.Default.WundergroundUploadEnabled == true)
                {
                    try
                    {
                        await CamUtil.UploadWUCamImage(
                            Settings.Default.WundergroundCameraID,
                            PasswordMgmt.DecryptString(Settings.Default.WundergroundPassword),
                            await CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage)
                        );

                        //Logger.WriteLogEntry("Weather Underground webcam snapshot uploaded successfully.", Logger.LogEntryType.Information);
                    }
                    catch (Exception wuex)
                    {

                        // Update on the UI thread
                        Logger.WriteLogEntry("Weather Underground webcam snapshot upload failed. " + wuex.Message, Logger.LogEntryType.Error);

                        BeginInvoke((MethodInvoker)delegate
                        {
                            LastStatusLabel.Text = "Upload Failure";
                        });
                    }
                }

                // Update on the UI thread
                BeginInvoke((MethodInvoker)delegate
                {
                    LastStatusLabel.Text = "Success";
                });
            }
            catch (Exception ex)
            {
                // Update on the UI thread
                Logger.WriteLogEntry("Scheduled snapshot capture failed. " + ex.Message, Logger.LogEntryType.Error);

                BeginInvoke((MethodInvoker)delegate
                {
                    LastStatusLabel.Text = "Error";
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
            SchedulerStatusLabel.Text = Settings.Default.CapturesEnabled ? "Enabled" : "Disabled";
            NextCaptureTimeLabel.Text = Settings.Default.CapturesEnabled ? string.Format("{0} {1}", NextHitTime.ToShortDateString(), NextHitTime.ToShortTimeString()) : "No captures scheduled";
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
                PreviewForm preview = new PreviewForm(await CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage));
                this.Cursor = Cursors.Default;
                //Logger.WriteLogEntry("Preview snapshot loaded successfully.", Logger.LogEntryType.Information);
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Logger.WriteLogEntry("Preview snapshot error has occurred. " + ex.Message, Logger.LogEntryType.Error);

                MessageBox.Show("We ran into a problem generating the preview image. " + ex.Message + ".",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }

        }

        private async void captureSnapshotNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Capture Image and then save it
                //Image image = CaptureImage();
                this.Cursor = Cursors.WaitCursor;
                string imageFile = Path.Combine(Settings.Default.ImageSavePath, ImageFileName);

                SaveCapturedImage(await CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage),imageFile);

                this.Cursor = Cursors.Default;

                //Logger.WriteLogEntry($"Manual snapshot taken successfully. ({imageFile})", Logger.LogEntryType.Information);

                MessageBox.Show("Snapshot completed successfully!",
                    "Snapshot Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Logger.WriteLogEntry("Manual snapshot error has occurred. " + ex.Message, Logger.LogEntryType.Error);
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

        private void createTimelapseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimelapseForm tlForm = new TimelapseForm();
            tlForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void errorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.ViewLogFile();
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.ClearLog();
        }
    }
}
