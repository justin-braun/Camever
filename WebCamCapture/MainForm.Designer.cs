namespace SpryCoder.WebcamCaptureTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.NextCaptureTimeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SchedulerStatusLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LastStatusLabel = new System.Windows.Forms.Label();
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureSnapshotNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTimelapseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Next Capture Time";
            // 
            // NextCaptureTimeLabel
            // 
            this.NextCaptureTimeLabel.AutoSize = true;
            this.NextCaptureTimeLabel.Location = new System.Drawing.Point(12, 60);
            this.NextCaptureTimeLabel.Name = "NextCaptureTimeLabel";
            this.NextCaptureTimeLabel.Size = new System.Drawing.Size(178, 21);
            this.NextCaptureTimeLabel.TabIndex = 5;
            this.NextCaptureTimeLabel.Text = "NextCaptureTimeLabel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Scheduler";
            // 
            // SchedulerStatusLabel
            // 
            this.SchedulerStatusLabel.AutoSize = true;
            this.SchedulerStatusLabel.Location = new System.Drawing.Point(277, 60);
            this.SchedulerStatusLabel.Name = "SchedulerStatusLabel";
            this.SchedulerStatusLabel.Size = new System.Drawing.Size(168, 21);
            this.SchedulerStatusLabel.TabIndex = 7;
            this.SchedulerStatusLabel.Text = "SchedulerStatusLabel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Last Status";
            // 
            // LastStatusLabel
            // 
            this.LastStatusLabel.AutoSize = true;
            this.LastStatusLabel.Location = new System.Drawing.Point(159, 60);
            this.LastStatusLabel.Name = "LastStatusLabel";
            this.LastStatusLabel.Size = new System.Drawing.Size(127, 21);
            this.LastStatusLabel.TabIndex = 10;
            this.LastStatusLabel.Text = "LastStatusLabel";
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(400, 33);
            this.MainFormMenuStrip.TabIndex = 11;
            this.MainFormMenuStrip.Text = "MainFormMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureSnapshotNowToolStripMenuItem,
            this.previewCameraToolStripMenuItem,
            this.createTimelapseToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // captureSnapshotNowToolStripMenuItem
            // 
            this.captureSnapshotNowToolStripMenuItem.Name = "captureSnapshotNowToolStripMenuItem";
            this.captureSnapshotNowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.captureSnapshotNowToolStripMenuItem.Size = new System.Drawing.Size(391, 30);
            this.captureSnapshotNowToolStripMenuItem.Text = "Capture Snapshot &Now";
            this.captureSnapshotNowToolStripMenuItem.Click += new System.EventHandler(this.captureSnapshotNowToolStripMenuItem_Click);
            // 
            // previewCameraToolStripMenuItem
            // 
            this.previewCameraToolStripMenuItem.Name = "previewCameraToolStripMenuItem";
            this.previewCameraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.previewCameraToolStripMenuItem.Size = new System.Drawing.Size(391, 30);
            this.previewCameraToolStripMenuItem.Text = "&Preview Camera Image";
            this.previewCameraToolStripMenuItem.Click += new System.EventHandler(this.previewCameraToolStripMenuItem_Click);
            // 
            // createTimelapseToolStripMenuItem
            // 
            this.createTimelapseToolStripMenuItem.Name = "createTimelapseToolStripMenuItem";
            this.createTimelapseToolStripMenuItem.Size = new System.Drawing.Size(391, 30);
            this.createTimelapseToolStripMenuItem.Text = "Create &Timelapse...";
            this.createTimelapseToolStripMenuItem.Click += new System.EventHandler(this.createTimelapseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(388, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(391, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(326, 30);
            this.aboutToolStripMenuItem.Text = "&About Webcam Capture Tool";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 90);
            this.Controls.Add(this.LastStatusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SchedulerStatusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NextCaptureTimeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainFormMenuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainFormMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Webcam Capture Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NextCaptureTimeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SchedulerStatusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LastStatusLabel;
        private System.Windows.Forms.MenuStrip MainFormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureSnapshotNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTimelapseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

