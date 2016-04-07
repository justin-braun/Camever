using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using ArmchairCoder.Camever.Helpers;
using ArmchairCoder.Camever.Properties;
using Timer = System.Timers.Timer;

namespace ArmchairCoder.Camever
{
    public partial class MainForm : Form
    {
        private Timer _captureTimer;
        private readonly EventListViewHelper _eventList;

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

            // StatusStrip padding/margins
            statusStripMain.Padding = new Padding(statusStripMain.Padding.Left,
                                        statusStripMain.Padding.Top, statusStripMain.Padding.Left, statusStripMain.Padding.Bottom);

            // Look for settings changes
            Settings.Default.PropertyChanged += Settings_PropertyChanged;

            // Check for First Run
            // First Run, force the Options window
            if (Settings.Default.FirstRun)
            {
                MessageBox.Show("This is the first time that this application has been started.  We'll take you to the Options so you can configure the required settings.", 
                                    "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OptionsForm options = new OptionsForm();
                options.ShowDialog();
            }

            // Log Helper
            _eventList = new EventListViewHelper(this);
            

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
                StartCaptureTimer(TimeDiff.TotalMilliseconds);
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
                    StartCaptureTimer(TimeDiff.TotalMilliseconds);
                }
                else
                {
                    StopCaptureTimer();
                }
            }

            // Update labels in the UI
            UpdateLabels();
        }

        /// <summary>
        /// Runs when background task is triggered
        /// </summary>
        private void StartCapture()
        {
            // Capture Image and then save it
            try
            {
                var imageFile = Path.Combine(Settings.Default.ImageSavePath, ImageFileName);

                // Save Capture
                SaveCapturedImage(CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage),imageFile);

                // Update on the UI thread
                BeginInvoke((MethodInvoker)delegate
                {
                    _eventList.AddEvent($"Scheduled snapshot successful. ({imageFile})", EventListViewHelper.LogEntryType.Information);
                });
                

                // Check for Services enabled on schedule
                if (Settings.Default.WundergroundUploadEnabled)
                {
                    try
                    {
                       CameraHelper.UploadWuCamImage(
                            Settings.Default.WundergroundCameraID,
                            PasswordHelper.DecryptString(Settings.Default.WundergroundPassword),
                            CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage)
                        );

                        // Update on the UI thread
                        BeginInvoke((MethodInvoker)delegate
                        {
                            _eventList.AddEvent("Weather Underground webcam snapshot upload successful.", EventListViewHelper.LogEntryType.Information);
                        });
                        
                    }
                    catch (Exception wuex)
                    {
                        // Update on the UI thread
                        BeginInvoke((MethodInvoker)delegate
                        {
                            _eventList.AddEvent("Weather Underground webcam snapshot upload failed. " + wuex.Message, EventListViewHelper.LogEntryType.Error);

                        });
                    }
                }

            }
            catch (Exception ex)
            {
                // Update on the UI thread
                BeginInvoke((MethodInvoker)delegate
                {
                    _eventList.AddEvent("Scheduled snapshot failed. " + ex.Message, EventListViewHelper.LogEntryType.Error);
                });
            }
        }

        /// CUSTOM METHODS ///

        private void SaveCapturedImage(Image image, string imageFileFullPath)
        {
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

        private void previewCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // Instantiate Preview Form with Image
                PreviewForm preview = new PreviewForm(CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage));
                Cursor = Cursors.Default;
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;

                MessageBox.Show("We ran into a problem generating the preview image. " + ex.Message + ".",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }

        }

        private void captureSnapshotNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check for beta expiration
            //if (BetaHelper.BetaExpired())
            //{
            //    MessageBox.Show("Sorry, this beta version has expired and can no longer be used.  Please uninstall or download an updated version.",
            //        "Beta Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Close();
            //}

            try
            {
                // Capture Image and then save it
                //Image image = CaptureImage();
                Cursor = Cursors.WaitCursor;
                string imageFile = Path.Combine(Settings.Default.ImageSavePath, ImageFileName);

                SaveCapturedImage(CameraHelper.CaptureImage(CameraHelper.CaptureType.FinalImage),imageFile);

                Cursor = Cursors.Default;

                BeginInvoke((MethodInvoker)delegate
                {
                    //LastStatusLabel.Text = "Error";
                    _eventList.AddEvent($"Manual snapshot successful. ({imageFile})", EventListViewHelper.LogEntryType.Information);
                });
                

                MessageBox.Show("Snapshot completed successfully!",
                    "Snapshot Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;

                BeginInvoke((MethodInvoker)delegate
                {
                    _eventList.AddEvent("Manual snapshot error has occurred. " + ex.Message, EventListViewHelper.LogEntryType.Error);
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

        private void StartCaptureTimer(double timeNeededMs)
        {
            // Instantiate
            StopCaptureTimer();
            
            _captureTimer = new Timer();
            _captureTimer.AutoReset = false;
            _captureTimer.Interval = timeNeededMs;

            // Rewire Events
            _captureTimer.Elapsed += CaptureTimer_Elapsed;

            // Start
            _captureTimer.Start();

        }

        private void CaptureTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Start capture process
            StartCapture();
            UpdateLabels();
            // Restart Time
            StartCaptureTimer(TimeDiff.TotalMilliseconds);
            
        }

        private void StopCaptureTimer()
        {
            if (_captureTimer != null)
            {
                _captureTimer.Stop();
                _captureTimer.Elapsed += CaptureTimer_Elapsed;
                _captureTimer.Dispose();
            }
        }
    }
}
