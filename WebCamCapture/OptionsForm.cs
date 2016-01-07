using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpryCoder.WebcamCaptureTool
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
            if (String.IsNullOrEmpty(Properties.Settings.Default.IPAddress)) CancelButton.Enabled = false;

            // Build Camera URL Preview Label
            BuildSnapshotUrlPreview();

            // Overlays Tab
            /////
            //PreviewPictureBox.BackColor = Color.Gray;
        }

        private void BuildSnapshotUrlPreview()
        {
            string urlPreview = string.Format("http://{0}/{1}", IPAddress.Text, SnapshotUrlPath.Text);
            CameraUrlPreview.Text = urlPreview;

        }

        private void IPAddress_TextChanged(object sender, EventArgs e)
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

            if (string.IsNullOrWhiteSpace(IPAddress.Text))
            {
                MessageBox.Show("Please enter a value for the IP Address of the camera.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else if (CapturesEnabled.Checked && String.IsNullOrWhiteSpace(UpdateInterval.Text))
            {
                MessageBox.Show("Please enter the capture interval.", "Information Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(int.TryParse(UpdateInterval.Text, out _updateInt) == false)
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
            if (Properties.Settings.Default.IPAddress != IPAddress.Text) Properties.Settings.Default.IPAddress = IPAddress.Text;
            if (Properties.Settings.Default.SnapshotUrl != SnapshotUrlPath.Text) Properties.Settings.Default.SnapshotUrl = SnapshotUrlPath.Text;
            if (Properties.Settings.Default.Username != Username.Text) Properties.Settings.Default.Username = Username.Text;
            if (Properties.Settings.Default.Password != PasswordMgmt.EncryptString(Password.Text)) Properties.Settings.Default.Password = PasswordMgmt.EncryptString(Password.Text);

            // Image Settings
            if (Properties.Settings.Default.ImageFileNamingFormat != ImageFileNamingFormat.Text) Properties.Settings.Default.ImageFileNamingFormat = ImageFileNamingFormat.Text;
            if (Properties.Settings.Default.ImageSavePath != ImageSavePath.Text) Properties.Settings.Default.ImageSavePath = ImageSavePath.Text;

            // Overlays
            if (Properties.Settings.Default.OverlayTransparency.ToString() != OverlayTransparencyBar.Value.ToString()) Properties.Settings.Default.OverlayTransparency = OverlayTransparencyBar.Value;
            if (Properties.Settings.Default.OverlayTopLeftText != topLeftText.Text) Properties.Settings.Default.OverlayTopLeftText = topLeftText.Text;
            if (Properties.Settings.Default.OverlayTopRightText != topRightText.Text) Properties.Settings.Default.OverlayTopRightText = topRightText.Text;
            if (Properties.Settings.Default.OverlayBottomLeftText != bottomLeftText.Text) Properties.Settings.Default.OverlayBottomLeftText = bottomLeftText.Text;
            if (Properties.Settings.Default.OverlayBottomRightText != bottomRightText.Text) Properties.Settings.Default.OverlayBottomRightText = bottomRightText.Text;

            // Scheduling
            if (Properties.Settings.Default.UpdateInterval != UpdateInterval.Text) Properties.Settings.Default.UpdateInterval = UpdateInterval.Text;
            if (Properties.Settings.Default.CapturesEnabled != CapturesEnabled.Checked) Properties.Settings.Default.CapturesEnabled = CapturesEnabled.Checked;

            // Weather Underground
            if (Properties.Settings.Default.WundergroundUploadEnabled != WundercamEnabled.Checked) Properties.Settings.Default.WundergroundUploadEnabled = WundercamEnabled.Checked;
            if (Properties.Settings.Default.WundergroundCameraID != WundergroundCameraID.Text) Properties.Settings.Default.WundergroundCameraID = WundergroundCameraID.Text;
            if (Properties.Settings.Default.WundergroundPassword != PasswordMgmt.EncryptString(WundergroundPassword.Text)) Properties.Settings.Default.WundergroundPassword = PasswordMgmt.EncryptString(WundergroundPassword.Text);

            // General
            if (Properties.Settings.Default.KeepOnTop != KeepOnTopCheckbox.Checked) Properties.Settings.Default.KeepOnTop = KeepOnTopCheckbox.Checked;
            if (Properties.Settings.Default.WindowLocation != (string)WindowLocationGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag) Properties.Settings.Default.WindowLocation = (string)WindowLocationGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag;

            // Save all settings
            Properties.Settings.Default.Save();
        }

        private void LoadSettings()
        {
            // Camera Information
            IPAddress.Text = Properties.Settings.Default.IPAddress.ToString();
            SnapshotUrlPath.Text = Properties.Settings.Default.SnapshotUrl.ToString();
            Username.Text = Properties.Settings.Default.Username.ToString();
            Password.Text = String.IsNullOrEmpty(Properties.Settings.Default.Password.ToString()) ? "" : PasswordMgmt.DecryptString(Properties.Settings.Default.Password.ToString());

            // Image Settings
            ImageFileNamingFormat.Text = Properties.Settings.Default.ImageFileNamingFormat.ToString();
            ImageSavePath.Text = Properties.Settings.Default.ImageSavePath.ToString();

            // Overlays
            topLeftText.Text = Properties.Settings.Default.OverlayTopLeftText;
            topRightText.Text = Properties.Settings.Default.OverlayTopRightText;
            bottomLeftText.Text = Properties.Settings.Default.OverlayBottomLeftText;
            bottomRightText.Text = Properties.Settings.Default.OverlayBottomRightText;
            OverlayTransparencyBar.Value = Properties.Settings.Default.OverlayTransparency;
               
            // Scheduling
            CapturesEnabled.Checked = Properties.Settings.Default.CapturesEnabled;
            UpdateInterval.Text = Properties.Settings.Default.UpdateInterval.ToString();

            // Weather Underground
            WundercamEnabled.Checked = Properties.Settings.Default.WundergroundUploadEnabled;
            WundergroundCameraID.Text = Properties.Settings.Default.WundergroundCameraID.ToString();
            WundergroundPassword.Text = String.IsNullOrEmpty(Properties.Settings.Default.WundergroundPassword.ToString()) ? "" : PasswordMgmt.DecryptString(Properties.Settings.Default.WundergroundPassword.ToString());

            // General
            KeepOnTopCheckbox.Checked = Properties.Settings.Default.KeepOnTop; // ? true : false;
            foreach(RadioButton rb in WindowLocationGroup.Controls.OfType<RadioButton>())
            {
                if (Properties.Settings.Default.WindowLocation == rb.Tag.ToString()) rb.Checked = true;
            }
        }

        private void TestConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Test connection to camera
                System.Net.WebRequest request = System.Net.WebRequest.Create(string.Format("http://{0}/{1}", IPAddress.Text, SnapshotUrlPath.Text));
                System.Net.NetworkCredential creds = new System.Net.NetworkCredential(Username.Text, Password.Text);
                request.Credentials = creds;
                request.Timeout = 10000; // 10 seconds
                request.Method = "POST";

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Successfully connected to camera stream.", "Successful Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(String.Format("There was an issue connecting to the camera stream. Status Code: {0}", response.StatusCode.ToString()), "Successful Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Error checking the camera connection. Error: {0}",ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void UploadWundercamButton_Click(object sender, EventArgs e)
        {
            try
            {
                CamUtil.UploadWUCamImage(WundergroundCameraID.Text, WundergroundPassword.Text, CamUtil.CaptureImage(CamUtil.CaptureType.FinalImage));
                MessageBox.Show("Upload Successful!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
