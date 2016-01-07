using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SpryCoder.WebcamCaptureTool
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
