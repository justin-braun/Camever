using System.ComponentModel;
using System.Windows.Forms;

namespace SpryCoder.Camever
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureSnapshotNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.stripStatusScheduler = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripStatusNextCaptureTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.listViewEvents = new System.Windows.Forms.ListView();
            this.eventListColumnEventDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eventListColumnEventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.eventListColumnEventDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.MainFormMenuStrip.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(625, 24);
            this.MainFormMenuStrip.TabIndex = 11;
            this.MainFormMenuStrip.Text = "MainFormMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureSnapshotNowToolStripMenuItem,
            this.previewCameraToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // captureSnapshotNowToolStripMenuItem
            // 
            this.captureSnapshotNowToolStripMenuItem.Name = "captureSnapshotNowToolStripMenuItem";
            this.captureSnapshotNowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.captureSnapshotNowToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.captureSnapshotNowToolStripMenuItem.Text = "Capture Snapshot &Now";
            this.captureSnapshotNowToolStripMenuItem.Click += new System.EventHandler(this.captureSnapshotNowToolStripMenuItem_Click);
            // 
            // previewCameraToolStripMenuItem
            // 
            this.previewCameraToolStripMenuItem.Name = "previewCameraToolStripMenuItem";
            this.previewCameraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.previewCameraToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.previewCameraToolStripMenuItem.Text = "&Preview Camera Image";
            this.previewCameraToolStripMenuItem.Click += new System.EventHandler(this.previewCameraToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewStripMenuItem
            // 
            this.viewStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorLogToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearLogToolStripMenuItem});
            this.viewStripMenuItem.Name = "viewStripMenuItem";
            this.viewStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewStripMenuItem.Text = "&View";
            // 
            // errorLogToolStripMenuItem
            // 
            this.errorLogToolStripMenuItem.Name = "errorLogToolStripMenuItem";
            this.errorLogToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.errorLogToolStripMenuItem.Text = "Error Lo&g File";
            this.errorLogToolStripMenuItem.Click += new System.EventHandler(this.errorLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.clearLogToolStripMenuItem.Text = "&Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "&About Camever";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.AutoSize = false;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripStatusScheduler,
            this.stripStatusNextCaptureTime});
            this.statusStripMain.Location = new System.Drawing.Point(0, 242);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(625, 30);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 12;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // stripStatusScheduler
            // 
            this.stripStatusScheduler.AutoSize = false;
            this.stripStatusScheduler.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stripStatusScheduler.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.stripStatusScheduler.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.stripStatusScheduler.Name = "stripStatusScheduler";
            this.stripStatusScheduler.Padding = new System.Windows.Forms.Padding(5);
            this.stripStatusScheduler.Size = new System.Drawing.Size(125, 25);
            this.stripStatusScheduler.Text = "stripStatusScheduler";
            this.stripStatusScheduler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stripStatusNextCaptureTime
            // 
            this.stripStatusNextCaptureTime.AutoSize = false;
            this.stripStatusNextCaptureTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stripStatusNextCaptureTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.stripStatusNextCaptureTime.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.stripStatusNextCaptureTime.Name = "stripStatusNextCaptureTime";
            this.stripStatusNextCaptureTime.Padding = new System.Windows.Forms.Padding(5);
            this.stripStatusNextCaptureTime.Size = new System.Drawing.Size(481, 25);
            this.stripStatusNextCaptureTime.Spring = true;
            this.stripStatusNextCaptureTime.Text = "stripStatusNextCaptureTime";
            this.stripStatusNextCaptureTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewEvents
            // 
            this.listViewEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.eventListColumnEventDate,
            this.eventListColumnEventType,
            this.eventListColumnEventDesc});
            this.listViewEvents.GridLines = true;
            this.listViewEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewEvents.Location = new System.Drawing.Point(12, 65);
            this.listViewEvents.Name = "listViewEvents";
            this.listViewEvents.Size = new System.Drawing.Size(601, 174);
            this.listViewEvents.TabIndex = 13;
            this.listViewEvents.UseCompatibleStateImageBehavior = false;
            this.listViewEvents.View = System.Windows.Forms.View.Details;
            // 
            // eventListColumnEventDate
            // 
            this.eventListColumnEventDate.Text = "Date/Time";
            this.eventListColumnEventDate.Width = 150;
            // 
            // eventListColumnEventType
            // 
            this.eventListColumnEventType.Text = "Type";
            this.eventListColumnEventType.Width = 100;
            // 
            // eventListColumnEventDesc
            // 
            this.eventListColumnEventDesc.Text = "Event";
            this.eventListColumnEventDesc.Width = 346;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Capture Log";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 272);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewEvents);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.MainFormMenuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainFormMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camever";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip MainFormMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem captureSnapshotNowToolStripMenuItem;
        private ToolStripMenuItem previewCameraToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem viewStripMenuItem;
        private ToolStripMenuItem errorLogToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem clearLogToolStripMenuItem;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel stripStatusScheduler;
        private ToolStripStatusLabel stripStatusNextCaptureTime;
        private ColumnHeader eventListColumnEventDate;
        private ColumnHeader eventListColumnEventType;
        private ColumnHeader eventListColumnEventDesc;
        public ListView listViewEvents;
        private Label label1;
    }
}

