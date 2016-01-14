using System;
using System.Reflection;
using System.Windows.Forms;
using SpryCoder.Camever.Helpers;

namespace SpryCoder.Camever
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Text = $"About {ProductInfoHelper.AssemblyTitle}";
            this.ProductNameLabel.Text = ProductInfoHelper.AssemblyProduct;
            this.ProductVersionLabel.Text = $"Version {ProductInfoHelper.AssemblyVersion(3)}";
            this.CopyrightLabel.Text = ProductInfoHelper.AssemblyCopyright;
            this.ProductCompanyLabel.Text = "Developed by " + ProductInfoHelper.AssemblyCompany + ".";
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
