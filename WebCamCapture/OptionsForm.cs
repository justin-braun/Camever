using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using SpryCoder.Camever.Properties;

namespace SpryCoder.Camever
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            // Load Settings
            LoadSettings();

            // Check for first run settings
            if (String.IsNullOrEmpty(Settings.Default.CameraHostname)) CancelButton.Enabled = false;

            // Build Camera URL Preview Label
            BuildSnapshotUrlPreview();

        }

        private void BuildSnapshotUrlPreview()
        {
            string url = string.Format("http://{0}/{1}", CameraHostName.Text, SnapshotUrlPath.Text);
            CameraUrlPreview.Text = url;

        }

        private void CameraHostname_TextChanged(object sender, EventArgs e)
        {
            // Build Camera URL Preview Label
            BuildSnapshotUrlPreview();
        }

        private void SnapshotUrlPath_TextChanged(object sender, EventArgs e)
        {
            // Build Camera URL Preview Label
            BuildSnapshotUrlPreview();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Cancel / Close form
            this.Close();

        }

        private void OKButton_Click(object sender, EventArgs e)
        {

            // Check if required settings are filled in
            int _updateInt = 0;

            if (string.IsNullOrWhiteSpace(CameraHostName.Text))
            {
                MessageBox.Show("Please enter a value for the IP Address or hostname of the camera.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(SnapshotUrlPath.Text))
            {
                MessageBox.Show("Please enter the snapshot URL path of the camera.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(Username.Text))
            {
                MessageBox.Show("Please enter the username user to access the camera.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Please enter the password used to access the camera.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(ImageSavePath.Text))
            {
                MessageBox.Show("Please enter the default path to save image captures to.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(ImageFileNamingFormat.Text))
            {
                MessageBox.Show("Please provide the file naming format for image captures.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Scheduling
            else if (CapturesEnabled.Checked && ((String.IsNullOrWhiteSpace(UpdateInterval.Text) || (int.TryParse(UpdateInterval.Text, out _updateInt) == false))))
            {
                MessageBox.Show("Please enter the capture interval in a numeric value.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (int.TryParse(UpdateInterval.Text, out _updateInt) == false)
            {
                MessageBox.Show("Please change the update interval to a valid numeric value.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Weather Underground
            else if (WundercamEnabled.Checked == true && (string.IsNullOrWhiteSpace(WundergroundCameraID.Text) || string.IsNullOrWhiteSpace(WundergroundPassword.Text)))
            {
                MessageBox.Show("When Weather Underground camera uploads are enabled, you must provide both a Camera ID and Password.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Overlay

            // Save Settings
            SaveSettings();
            
            // Close form
            this.Close();
            
        }

        private void SaveSettings()
        {
            // Camera Information
            if (Settings.Default.CameraMfg != CameraMfgSelector.SelectedItem.ToString()) Settings.Default.CameraMfg = CameraMfgSelector.SelectedItem.ToString();
            if (Settings.Default.CameraHostname != CameraHostName.Text) Settings.Default.CameraHostname = CameraHostName.Text;
            if (Settings.Default.SnapshotUrl != SnapshotUrlPath.Text) Settings.Default.SnapshotUrl = SnapshotUrlPath.Text;
            if (Settings.Default.Username != Username.Text) Settings.Default.Username = Username.Text;
            if (Settings.Default.Password != PasswordHelper.EncryptString(Password.Text)) Settings.Default.Password = PasswordHelper.EncryptString(Password.Text);

            // Image Settings
            if (Settings.Default.ImageFileNamingFormat != ImageFileNamingFormat.Text) Settings.Default.ImageFileNamingFormat = ImageFileNamingFormat.Text;
            if (Settings.Default.ImageSavePath != ImageSavePath.Text) Settings.Default.ImageSavePath = ImageSavePath.Text;

            // Overlays
            if (Settings.Default.OverlayTransparency.ToString() != OverlayTransparencyBar.Value.ToString()) Settings.Default.OverlayTransparency = OverlayTransparencyBar.Value;
            if (Settings.Default.OverlayTopLeftText != topLeftText.Text) Settings.Default.OverlayTopLeftText = topLeftText.Text;
            if (Settings.Default.OverlayTopRightText != topRightText.Text) Settings.Default.OverlayTopRightText = topRightText.Text;
            if (Settings.Default.OverlayBottomLeftText != bottomLeftText.Text) Settings.Default.OverlayBottomLeftText = bottomLeftText.Text;
            if (Settings.Default.OverlayBottomRightText != bottomRightText.Text) Settings.Default.OverlayBottomRightText = bottomRightText.Text;

            // Scheduling
            if (Settings.Default.UpdateInterval != UpdateInterval.Text) Settings.Default.UpdateInterval = UpdateInterval.Text;
            if (Settings.Default.CapturesEnabled != CapturesEnabled.Checked) Settings.Default.CapturesEnabled = CapturesEnabled.Checked;

            // Weather Underground
            if (Settings.Default.WundergroundUploadEnabled != WundercamEnabled.Checked) Settings.Default.WundergroundUploadEnabled = WundercamEnabled.Checked;
            if (Settings.Default.WundergroundCameraID != WundergroundCameraID.Text) Settings.Default.WundergroundCameraID = WundergroundCameraID.Text;
            if (Settings.Default.WundergroundPassword != PasswordHelper.EncryptString(WundergroundPassword.Text)) Settings.Default.WundergroundPassword = PasswordHelper.EncryptString(WundergroundPassword.Text);

            // General
            if (Settings.Default.KeepOnTop != KeepOnTopCheckbox.Checked) Settings.Default.KeepOnTop = KeepOnTopCheckbox.Checked;
            if (Settings.Default.WindowLocation != (string)WindowLocationGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag) Settings.Default.WindowLocation = (string)WindowLocationGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag;

            // Save all settings
            Settings.Default.Save();
        }

        private void LoadSettings()
        {
            // Camera Information
            CameraMfgSelector.SelectedIndex = CameraMfgSelector.FindStringExact(Settings.Default.CameraMfg.ToString());
            CameraHostName.Text = Settings.Default.CameraHostname.ToString();
            SnapshotUrlPath.Text = Settings.Default.SnapshotUrl.ToString();
            Username.Text = Settings.Default.Username.ToString();
            Password.Text = String.IsNullOrEmpty(Settings.Default.Password.ToString()) ? "" : PasswordHelper.DecryptString(Settings.Default.Password.ToString());

            // Image Settings
            ImageFileNamingFormat.Text = Settings.Default.ImageFileNamingFormat.ToString();
            ImageSavePath.Text = Settings.Default.ImageSavePath.ToString();

            // Overlays
            topLeftText.Text = Settings.Default.OverlayTopLeftText;
            topRightText.Text = Settings.Default.OverlayTopRightText;
            bottomLeftText.Text = Settings.Default.OverlayBottomLeftText;
            bottomRightText.Text = Settings.Default.OverlayBottomRightText;
            OverlayTransparencyBar.Value = Settings.Default.OverlayTransparency;
               
            // Scheduling
            CapturesEnabled.Checked = Settings.Default.CapturesEnabled;
            UpdateInterval.Text = Settings.Default.UpdateInterval.ToString();

            // Weather Underground
            WundercamEnabled.Checked = Settings.Default.WundergroundUploadEnabled;
            WundergroundCameraID.Text = Settings.Default.WundergroundCameraID.ToString();
            WundergroundPassword.Text = String.IsNullOrEmpty(Settings.Default.WundergroundPassword.ToString()) ? "" : PasswordHelper.DecryptString(Settings.Default.WundergroundPassword.ToString());

            // General
            KeepOnTopCheckbox.Checked = Settings.Default.KeepOnTop; // ? true : false;
            foreach(RadioButton rb in WindowLocationGroup.Controls.OfType<RadioButton>())
            {
                if (Settings.Default.WindowLocation == rb.Tag.ToString()) rb.Checked = true;
            }
        }

        private async void TestConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                await TestCameraConnection(); //.ConfigureAwait(false);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(String.Format("Error checking the camera connection. {0}.", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseLocationButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            DialogResult result = browser.ShowDialog();

            if (result == DialogResult.OK)
            {
                ImageSavePath.Text = browser.SelectedPath;
            }

        }

        private void UpdateInterval_TextChanged(object sender, EventArgs e)
        {
            int _updateInt = 0;
            if(int.TryParse(UpdateInterval.Text,out _updateInt) == true)
            {
                CapturesEnabled.Enabled = true;
            }
            else
            {
                CapturesEnabled.Enabled = false;
            }
        }

        private async Task TestCameraConnection()
        {
            try
            {
                // Test connection to camera
                System.Net.WebRequest request = System.Net.WebRequest.Create(string.Format("http://{0}/{1}", CameraHostName.Text, SnapshotUrlPath.Text));
                System.Net.NetworkCredential creds = new System.Net.NetworkCredential(Username.Text, Password.Text);
                request.Credentials = creds;
                request.Timeout = 10000; // 10 seconds
                request.Method = "POST";

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse) await request.GetResponseAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Successfully connected to camera stream.", "Successful Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(String.Format("There was an issue connecting to the camera stream. Status Code: {0}", response.StatusCode.ToString()), "Successful Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateOverlayPreview() // FUTURE TODO: Replace with CamUtils.CaptureImage
        {
            // New bitmap the size of the picture box
            int width = 640;
            int height = 480;

            Bitmap bitmap = new Bitmap(width, height);


            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Full preview picture rectangle fill
                g.FillRectangle(Brushes.Green, new Rectangle(0, 0, width, height));

                // Brush for transparency
                Brush semiTransBrush = new SolidBrush(Color.FromArgb(CamUtil.CalculateTransparency(OverlayTransparencyBar.Value), 176, 176, 176));

                // Right alignment string format
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;

                // Top Overlay
                if (!string.IsNullOrWhiteSpace(topLeftText.Text) || !string.IsNullOrWhiteSpace(topRightText.Text))
                {
                    // Top Overlay rectangle with transparency
                    RectangleF rectfTop = new RectangleF(0, 0, width, 20);
                    g.FillRectangle(semiTransBrush, rectfTop);

                    // Top Left Text
                    g.DrawString(CamUtil.TemplateReplace(topLeftText.Text), new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, 5, 6);

                    // Top Right Text
                    g.DrawString(CamUtil.TemplateReplace(topRightText.Text), new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, width - 5, 6, sf);
                }

                // Bottom Overlay
                if (!string.IsNullOrWhiteSpace(bottomLeftText.Text) || !string.IsNullOrWhiteSpace(bottomRightText.Text))
                {
                    // Bottom Overlay rectangle with transparency
                    RectangleF rectfBottom = new RectangleF(0, height - 20, width, 20);
                    g.FillRectangle(semiTransBrush, rectfBottom);

                    // Bottom Left Text
                    g.DrawString(CamUtil.TemplateReplace(bottomLeftText.Text), new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, 5, 465);

                    // Bottom Right Text
                    g.DrawString(CamUtil.TemplateReplace(bottomRightText.Text), new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular), Brushes.White, width - 5, 465, sf);
                }
            }

            // Show bitmap in picturebox for preview
            //PreviewPictureBox.BackgroundImage = bitmap;
            PreviewForm preview = new PreviewForm(bitmap);
            preview.ShowDialog();

            // TODO: Bitmap dispose?

        }
        private void OverlayPreviewButton_Click(object sender, EventArgs e)
        {
            UpdateOverlayPreview();
        }

        private async void UploadWundercamButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                await CamUtil.UploadWUCamImage(WundergroundCameraID.Text, WundergroundPassword.Text, await CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage)).ConfigureAwait(false);
                this.Cursor = Cursors.Default;
                //Logger.WriteLogEntry("Weather Underground webcam manual snapshot uploaded successfully.", Logger.LogEntryType.Information);
                MessageBox.Show("Upload Successful!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    this.Cursor = Cursors.Default;
                });
                
                Logger.WriteLogEntry("Weather Underground webcam snapshot upload failed. " + ex.Message, Logger.LogEntryType.Error);
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackupSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfDialog = new SaveFileDialog
                {
                    Filter = "Settings (*.settings)|*.settings",
                    Title = "Backup Settings"
                };
                sfDialog.ShowDialog();

                if (sfDialog.FileName == "") return;
                BackupSettings(sfDialog.FileName);
                MessageBox.Show("Settings backup complete!", "Backup Complete", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem backing up your settings file.  " + ex.Message + ".", "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RestoreSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofDialog = new OpenFileDialog
                {
                    Filter = "Settings (*.settings)|*.settings",
                    Title = "Restore Settings"
                };
                ofDialog.ShowDialog();

                if (ofDialog.FileName == "") return;

                // Restore config file
                RestoreSettings(ofDialog.FileName);

                // Reload GUI with settings from restored config
                LoadSettings();

                MessageBox.Show("Settings restore complete!", "Restore Complete", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem restoring your settings file.  " + ex.Message + ".", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void RestoreSettings(string settingsFilePath)
        {
            if (!File.Exists(settingsFilePath))
                throw new FileNotFoundException();

            var appSettings = Settings.Default;
            try
            {
                var config =
                    ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.PerUserRoamingAndLocal);

                string appSettingsXmlName =
                    Settings.Default.Context["GroupName"].ToString();
                // returns "MyApplication.Properties.Settings";

                // Open settings file as XML
                var import = XDocument.Load(settingsFilePath);
                // Get the whole XML inside the settings node
                var settings = import.XPathSelectElements("//" + appSettingsXmlName);

                var configurationSectionGroup = config.GetSectionGroup("userSettings");
                if (configurationSectionGroup != null)
                    configurationSectionGroup
                        .Sections[appSettingsXmlName]
                        .SectionInformation
                        .SetRawXml(settings.Single().ToString());
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("userSettings");

                appSettings.Reload();
            }
            catch (Exception) // Should make this more specific
            {
                // Could not import settings.
                appSettings.Reload(); // from last set saved, not defaults
                throw;
            }
        }

        private static void BackupSettings(string settingsFilePath)
        {
            Settings.Default.Save();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            config.SaveAs(settingsFilePath);
        }

        private void CameraMfgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CameraMfgSelector.SelectedItem.ToString())
            {
                case "Amcrest":
                    SnapshotUrlPath.Text = "cgi-bin/snapshot.cgi";
                    break;
                case "Foscam":
                    SnapshotUrlPath.Text = "snapshot.cgi";
                    break;
                default:
                    SnapshotUrlPath.Text = "cgi-bin/snapshot.cgi";
                    break;
            }
        }
    }
}
