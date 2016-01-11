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
    public partial class TimelapseForm : Form
    {
        public TimelapseForm()
        {
            InitializeComponent();
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "Jpeg images (*.jpg)|*.jpg";
            ofDialog.Multiselect = true;
            ofDialog.ShowDialog();

            if (ofDialog.FileNames.Length > 0)
            {
                foreach (string file in ofDialog.FileNames)
                {
                    imageList.Items.Add(file.ToString());
                }

                clearImageButton.Enabled = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void removeImageButton_Click(object sender, EventArgs e)
        {
            imageList.Items.Remove(imageList.SelectedItem);

            if (imageList.Items.Count > 0)
                imageList.SelectedIndex = imageList.Items.Count - 1;
        }

        private void clearImageButton_Click(object sender, EventArgs e)
        {
            // Clear image list
            imageList.Items.Clear();

            if (imageList.Items.Count == 0)
            { 
                clearImageButton.Enabled = false;
                removeImageButton.Enabled = false;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close
            this.Close();
        }

        private void imageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update count label
            if (imageList.Items.Count == 0)
            {
                // no images in the list
                imageCountLabel.Text = "No images selected";
                removeImageButton.Enabled = false;
                clearImageButton.Enabled = false;
            }
            else
            {
                // there are images in the list
                imageCountLabel.Text = imageList.Items.Count + " image(s) selected";
                removeImageButton.Enabled = true;
                clearImageButton.Enabled = true;
            }

        }
    }
}
