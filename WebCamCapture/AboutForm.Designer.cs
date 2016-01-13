namespace SpryCoder.WebcamCaptureTool
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.ProductVersionLabel = new System.Windows.Forms.Label();
            this.ProductCompanyLabel = new System.Windows.Forms.Label();
            this.CopyrightLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameLabel.Location = new System.Drawing.Point(147, 13);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(59, 19);
            this.ProductNameLabel.TabIndex = 1;
            this.ProductNameLabel.Text = "label1";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(348, 210);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ProductVersionLabel
            // 
            this.ProductVersionLabel.AutoSize = true;
            this.ProductVersionLabel.Location = new System.Drawing.Point(148, 36);
            this.ProductVersionLabel.Name = "ProductVersionLabel";
            this.ProductVersionLabel.Size = new System.Drawing.Size(104, 13);
            this.ProductVersionLabel.TabIndex = 3;
            this.ProductVersionLabel.Text = "ProductVersionLabel";
            // 
            // ProductCompanyLabel
            // 
            this.ProductCompanyLabel.AutoSize = true;
            this.ProductCompanyLabel.Location = new System.Drawing.Point(148, 90);
            this.ProductCompanyLabel.Name = "ProductCompanyLabel";
            this.ProductCompanyLabel.Size = new System.Drawing.Size(114, 13);
            this.ProductCompanyLabel.TabIndex = 5;
            this.ProductCompanyLabel.Text = "ProductCompanyLabel";
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.AutoSize = true;
            this.CopyrightLabel.Location = new System.Drawing.Point(148, 107);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(79, 13);
            this.CopyrightLabel.TabIndex = 6;
            this.CopyrightLabel.Text = "CopyrightLabel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(13, 159);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(269, 74);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Portions of this software may utilize the following material, the use of which is" +
    " hereby acknowledged.\r\n\r\nAForge.NET Framework libraries for video processing pub" +
    "lished under the GPL v3 License.";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 245);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.ProductCompanyLabel);
            this.Controls.Add(this.ProductVersionLabel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ProductNameLabel);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label ProductVersionLabel;
        private System.Windows.Forms.Label ProductCompanyLabel;
        private System.Windows.Forms.Label CopyrightLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}
