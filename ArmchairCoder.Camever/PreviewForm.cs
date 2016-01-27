using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArmchairCoder.Camever
{
    public partial class PreviewForm : Form
    {
        public PreviewForm(Image pictureImage)
        {
            InitializeComponent();

            // Load Picture
            PictureFrame.Image = pictureImage;
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
