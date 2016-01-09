﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using AForge.Video.FFMPEG;

namespace SpryCoder.WebcamCaptureTool
{
    public partial class MainForm : Form
    {
        BackgroundWorker backgroundCaptureTask;
        System.Timers.Timer captureTimer;

        // PROPERTIES
        public DateTime NextHitTime { get { return CamUtil.NextCaptureTime(DateTime.Now, double.Parse(Properties.Settings.Default.UpdateInterval)); } }
        public TimeSpan TimeDiff { get { return NextHitTime.Subtract(DateTime.Now); } }
        public string ImageFileName {  get { return CamUtil.TemplateReplace(Properties.Settings.Default.ImageFileNamingFormat); } }

        /// <summary>
        /// Main Form 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            //Reset Settings for debugging
            //Properties.Settings.Default.Reset();

            // Clear controls/labels
            NextCaptureTimeLabel.Text = "";
            LastStatusLabel.Text = "";

            // Check if settings need to be upgraded because of file version change
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            // Look for settings changes
            Properties.Settings.Default.PropertyChanged += Settings_PropertyChanged;

            // If settings are blank, force the Options window
            if (String.IsNullOrEmpty(Properties.Settings.Default.IPAddress))
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
            this.TopMost = Properties.Settings.Default.KeepOnTop;

            // Set window location
            SetWindowLocation();

            // Check if capture enabled
            if (Properties.Settings.Default.CapturesEnabled == true)
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
                if (Properties.Settings.Default.KeepOnTop == true)
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
                if (Properties.Settings.Default.CapturesEnabled)
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
                // Save Capture
                SaveCapturedImage(await CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage),
                                    string.Format("{0}\\{1}.jpg",
                                    Properties.Settings.Default.ImageSavePath,
                                    ImageFileName)
                                    );

                // Check for Services enabled on schedule
                if (Properties.Settings.Default.WundergroundUploadEnabled == true)
                {
                    await CamUtil.UploadWUCamImage(
                                                Properties.Settings.Default.WundergroundCameraID,
                                                PasswordMgmt.DecryptString(Properties.Settings.Default.WundergroundPassword),
                                                await CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage)
                                            );
                }

                // Update on the UI thread
                BeginInvoke((MethodInvoker)delegate
                {
                    LastStatusLabel.Text = "Success";
                });
            }
            catch (Exception)
            {
                // Update on the UI thread
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
            switch (Properties.Settings.Default.WindowLocation)
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
            SchedulerStatusLabel.Text = Properties.Settings.Default.CapturesEnabled ? "Enabled" : "Disabled";
            NextCaptureTimeLabel.Text = Properties.Settings.Default.CapturesEnabled ? string.Format("{0} {1}", NextHitTime.ToShortDateString(), NextHitTime.ToShortTimeString()) : "No captures scheduled";
        }

        private void CreateTimeLapse()
        {
            const string basePath = @"C:\Users\Justin\Desktop\wc_weathernerd\";

            using (var videoWriter = new VideoFileWriter())
            {
                videoWriter.Open(basePath + "timelapse.avi", 640, 480, 15, VideoCodec.MPEG4, 1000000);

                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(basePath);
                System.IO.FileSystemInfo[] images = di.GetFileSystemInfos();
                var orderedImages = images.OrderBy(f => f.CreationTime);

                foreach (System.IO.FileSystemInfo imageFile in images)
                {
                    // Out of Memory errors are common for incomplete or corrupted images.  Skip over them and continue.
                    try
                    {
                        using (Bitmap image = Bitmap.FromFile(imageFile.FullName) as Bitmap)
                        {
                            videoWriter.WriteVideoFrame(image);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                videoWriter.Close();
            }

            MessageBox.Show("Timelapse Creation Complete!");
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
                preview.ShowDialog();
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("We ran into a problem generating the preview image.  You can try again later.",
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
                SaveCapturedImage(await CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage),
                                  string.Format("{0}\\{1}.jpg", Properties.Settings.Default.ImageSavePath, ImageFileName)
                                 );
                this.Cursor = Cursors.Default;

                MessageBox.Show("Snapshot completed successfully!",
                    "Snapshot Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("We ran into a problem generating the snapshot image.  You can try again later.",
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
            CreateTimeLapse();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }
    }
}