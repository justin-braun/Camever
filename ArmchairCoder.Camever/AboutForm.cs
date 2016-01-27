using System;
using System.Diagnostics;
using System.Windows.Forms;
using ArmchairCoder.Camever.Helpers;

namespace ArmchairCoder.Camever
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

        private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://armchaircoder.com");
        }
    }
}
