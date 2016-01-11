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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            // Close
            this.Close();
        }
    }
}
