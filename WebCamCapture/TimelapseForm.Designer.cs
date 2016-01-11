namespace SpryCoder.WebcamCaptureTool
{
    partial class TimelapseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ListBox();
            this.buttonAddImage = new System.Windows.Forms.Button();
            this.buttonRemoveImage = new System.Windows.Forms.Button();
            this.buttonClearImages = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imageCountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.frameRate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(417, 298);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "&Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(498, 298);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // imageList
            // 
            this.imageList.FormattingEnabled = true;
            this.imageList.HorizontalScrollbar = true;
            this.imageList.Location = new System.Drawing.Point(13, 43);
            this.imageList.Name = "imageList";
            this.imageList.Size = new System.Drawing.Size(298, 212);
            this.imageList.TabIndex = 2;
            // 
            // buttonAddImage
            // 
            this.buttonAddImage.Location = new System.Drawing.Point(13, 261);
            this.buttonAddImage.Name = "buttonAddImage";
            this.buttonAddImage.Size = new System.Drawing.Size(75, 23);
            this.buttonAddImage.TabIndex = 3;
            this.buttonAddImage.Text = "&Add";
            this.buttonAddImage.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveImage
            // 
            this.buttonRemoveImage.Location = new System.Drawing.Point(95, 261);
            this.buttonRemoveImage.Name = "buttonRemoveImage";
            this.buttonRemoveImage.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveImage.TabIndex = 4;
            this.buttonRemoveImage.Text = "&Remove Image";
            this.buttonRemoveImage.UseVisualStyleBackColor = true;
            // 
            // buttonClearImages
            // 
            this.buttonClearImages.Location = new System.Drawing.Point(236, 261);
            this.buttonClearImages.Name = "buttonClearImages";
            this.buttonClearImages.Size = new System.Drawing.Size(75, 23);
            this.buttonClearImages.TabIndex = 5;
            this.buttonClearImages.Text = "&C&lear";
            this.buttonClearImages.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selected Images";
            // 
            // imageCountLabel
            // 
            this.imageCountLabel.AutoSize = true;
            this.imageCountLabel.Location = new System.Drawing.Point(16, 303);
            this.imageCountLabel.Name = "imageCountLabel";
            this.imageCountLabel.Size = new System.Drawing.Size(99, 13);
            this.imageCountLabel.TabIndex = 7;
            this.imageCountLabel.Text = "No images selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Frame rate";
            // 
            // frameRate
            // 
            this.frameRate.Location = new System.Drawing.Point(331, 60);
            this.frameRate.Name = "frameRate";
            this.frameRate.Size = new System.Drawing.Size(39, 21);
            this.frameRate.TabIndex = 9;
            this.frameRate.Text = "5";
            // 
            // TimelapseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 332);
            this.Controls.Add(this.frameRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClearImages);
            this.Controls.Add(this.buttonRemoveImage);
            this.Controls.Add(this.buttonAddImage);
            this.Controls.Add(this.imageList);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimelapseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Lapse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ListBox imageList;
        private System.Windows.Forms.Button buttonAddImage;
        private System.Windows.Forms.Button buttonRemoveImage;
        private System.Windows.Forms.Button buttonClearImages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label imageCountLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox frameRate;
    }
}