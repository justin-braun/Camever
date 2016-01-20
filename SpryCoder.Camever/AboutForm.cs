using System;
using System.Windows.Forms;
using SpryCoder.Camever.Helpers;

namespace SpryCoder.Camever
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Text = $"About {ProductInfoHelper.AssemblyTitle}";
            ProductNameLabel.Text = ProductInfoHelper.AssemblyProduct;
            ProductVersionLabel.Text = $"Version {ProductInfoHelper.AssemblyVersion(3)}";
            CopyrightLabel.Text = ProductInfoHelper.AssemblyCopyright;
            ProductCompanyLabel.Text = "Developed by " + ProductInfoHelper.AssemblyCompany + ".";
        }

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
