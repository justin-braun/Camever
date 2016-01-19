using System.ComponentModel;
using System.Windows.Forms;

namespace SpryCoder.Camever
{
    partial class OptionsForm
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
            this.OptionsTabs = new System.Windows.Forms.TabControl();
            this.CameraTab = new System.Windows.Forms.TabPage();
            this.TestConnectionButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CameraMfgSelector = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CameraUrlPreview = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SnapshotUrlPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CameraHostName = new System.Windows.Forms.TextBox();
            this.OverlayTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.OverlayTransparencyBar = new System.Windows.Forms.TrackBar();
            this.OverlayPreviewButton = new System.Windows.Forms.Button();
            this.bottomRightText = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.bottomLeftText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.topRightText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.topLeftText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ImageFileTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ImageFileNamingFormat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BrowseLocationButton = new System.Windows.Forms.Button();
            this.ImageSavePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SchedulingTab = new System.Windows.Forms.TabPage();
            this.CapturesEnabled = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.UpdateInterval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ServicesTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.UploadWundercamButton = new System.Windows.Forms.Button();
            this.WundergroundPassword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.WundergroundCameraID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.WundercamEnabled = new System.Windows.Forms.CheckBox();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RestoreSettingsButton = new System.Windows.Forms.Button();
            this.BackupSettingsButton = new System.Windows.Forms.Button();
            this.WindowLocationGroup = new System.Windows.Forms.GroupBox();
            this.TopRightRadio = new System.Windows.Forms.RadioButton();
            this.KeepOnTopCheckbox = new System.Windows.Forms.CheckBox();
            this.BottomRightRadio = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OptionsTabs.SuspendLayout();
            this.CameraTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.OverlayTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayTransparencyBar)).BeginInit();
            this.ImageFileTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SchedulingTab.SuspendLayout();
            this.ServicesTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.WindowLocationGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsTabs
            // 
            this.OptionsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.OptionsTabs.Controls.Add(this.CameraTab);
            this.OptionsTabs.Controls.Add(this.OverlayTab);
            this.OptionsTabs.Controls.Add(this.ImageFileTab);
            this.OptionsTabs.Controls.Add(this.SchedulingTab);
            this.OptionsTabs.Controls.Add(this.ServicesTab);
            this.OptionsTabs.Controls.Add(this.GeneralTab);
            this.OptionsTabs.Location = new System.Drawing.Point(12, 12);
            this.OptionsTabs.Name = "OptionsTabs";
            this.OptionsTabs.SelectedIndex = 0;
            this.OptionsTabs.Size = new System.Drawing.Size(673, 330);
            this.OptionsTabs.TabIndex = 0;
            // 
            // CameraTab
            // 
            this.CameraTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CameraTab.Controls.Add(this.TestConnectionButton);
            this.CameraTab.Controls.Add(this.groupBox2);
            this.CameraTab.Controls.Add(this.groupBox1);
            this.CameraTab.Location = new System.Drawing.Point(4, 25);
            this.CameraTab.Name = "CameraTab";
            this.CameraTab.Padding = new System.Windows.Forms.Padding(3);
            this.CameraTab.Size = new System.Drawing.Size(665, 301);
            this.CameraTab.TabIndex = 0;
            this.CameraTab.Text = "Camera";
            this.CameraTab.UseVisualStyleBackColor = true;
            // 
            // TestConnectionButton
            // 
            this.TestConnectionButton.AutoSize = true;
            this.TestConnectionButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestConnectionButton.Location = new System.Drawing.Point(524, 214);
            this.TestConnectionButton.Name = "TestConnectionButton";
            this.TestConnectionButton.Size = new System.Drawing.Size(106, 23);
            this.TestConnectionButton.TabIndex = 6;
            this.TestConnectionButton.Text = "Test Connection";
            this.TestConnectionButton.UseVisualStyleBackColor = true;
            this.TestConnectionButton.Click += new System.EventHandler(this.TestConnectionButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Password);
            this.groupBox2.Controls.Add(this.Username);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(343, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 187);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credentials";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(6, 85);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '•';
            this.Password.Size = new System.Drawing.Size(136, 21);
            this.Password.TabIndex = 5;
            // 
            // Username
            // 
            this.Username.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(6, 41);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(136, 21);
            this.Username.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CameraMfgSelector);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CameraUrlPreview);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SnapshotUrlPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CameraHostName);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 187);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Information";
            // 
            // CameraMfgSelector
            // 
            this.CameraMfgSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CameraMfgSelector.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraMfgSelector.FormattingEnabled = true;
            this.CameraMfgSelector.Items.AddRange(new object[] {
            "Amcrest",
            "Foscam"});
            this.CameraMfgSelector.Location = new System.Drawing.Point(9, 41);
            this.CameraMfgSelector.Name = "CameraMfgSelector";
            this.CameraMfgSelector.Size = new System.Drawing.Size(133, 21);
            this.CameraMfgSelector.TabIndex = 1;
            this.CameraMfgSelector.SelectedIndexChanged += new System.EventHandler(this.CameraMfgCombo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Manufacturer";
            // 
            // CameraUrlPreview
            // 
            this.CameraUrlPreview.AutoSize = true;
            this.CameraUrlPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraUrlPreview.Location = new System.Drawing.Point(9, 159);
            this.CameraUrlPreview.Name = "CameraUrlPreview";
            this.CameraUrlPreview.Size = new System.Drawing.Size(39, 13);
            this.CameraUrlPreview.TabIndex = 4;
            this.CameraUrlPreview.Text = "http://";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Snapshot URL Path";
            // 
            // SnapshotUrlPath
            // 
            this.SnapshotUrlPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SnapshotUrlPath.Location = new System.Drawing.Point(9, 129);
            this.SnapshotUrlPath.Name = "SnapshotUrlPath";
            this.SnapshotUrlPath.Size = new System.Drawing.Size(261, 21);
            this.SnapshotUrlPath.TabIndex = 3;
            this.SnapshotUrlPath.TextChanged += new System.EventHandler(this.SnapshotUrlPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address or Hostname";
            // 
            // CameraHostName
            // 
            this.CameraHostName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraHostName.Location = new System.Drawing.Point(9, 85);
            this.CameraHostName.Name = "CameraHostName";
            this.CameraHostName.Size = new System.Drawing.Size(136, 21);
            this.CameraHostName.TabIndex = 2;
            this.CameraHostName.TextChanged += new System.EventHandler(this.CameraHostname_TextChanged);
            // 
            // OverlayTab
            // 
            this.OverlayTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OverlayTab.Controls.Add(this.tableLayoutPanel1);
            this.OverlayTab.Controls.Add(this.label18);
            this.OverlayTab.Controls.Add(this.label17);
            this.OverlayTab.Controls.Add(this.OverlayTransparencyBar);
            this.OverlayTab.Controls.Add(this.OverlayPreviewButton);
            this.OverlayTab.Controls.Add(this.bottomRightText);
            this.OverlayTab.Controls.Add(this.label16);
            this.OverlayTab.Controls.Add(this.bottomLeftText);
            this.OverlayTab.Controls.Add(this.label15);
            this.OverlayTab.Controls.Add(this.topRightText);
            this.OverlayTab.Controls.Add(this.label14);
            this.OverlayTab.Controls.Add(this.topLeftText);
            this.OverlayTab.Controls.Add(this.label13);
            this.OverlayTab.Location = new System.Drawing.Point(4, 25);
            this.OverlayTab.Name = "OverlayTab";
            this.OverlayTab.Padding = new System.Windows.Forms.Padding(3);
            this.OverlayTab.Size = new System.Drawing.Size(665, 301);
            this.OverlayTab.TabIndex = 1;
            this.OverlayTab.Text = "Overlays";
            this.OverlayTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label38, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label37, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label22, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label20, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label25, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label24, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label26, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label28, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label30, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label32, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label33, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label36, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label23, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label27, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label29, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label31, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label34, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label35, 0, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(494, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(151, 204);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(3, 180);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(45, 13);
            this.label38.TabIndex = 19;
            this.label38.Text = "{ampm}";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(68, 180);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 13);
            this.label37.TabIndex = 18;
            this.label37.Text = "AM/PM";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "{24hour}";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(68, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "24 Hour Clock";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "{12hour}";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(68, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "12 Hour Clock";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "{min}";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(68, 40);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 5;
            this.label24.Text = "Minute";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(68, 60);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(42, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "Second";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(68, 80);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(67, 13);
            this.label28.TabIndex = 9;
            this.label28.Text = "Month Name";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(68, 100);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(78, 13);
            this.label30.TabIndex = 11;
            this.label30.Text = "Month Numeric";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(68, 120);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(26, 13);
            this.label32.TabIndex = 13;
            this.label32.Text = "Day";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(68, 140);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 13);
            this.label33.TabIndex = 14;
            this.label33.Text = "4-Digit Year";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(68, 160);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 13);
            this.label36.TabIndex = 17;
            this.label36.Text = "2-Digit Year";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 60);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 13);
            this.label23.TabIndex = 4;
            this.label23.Text = "{sec}";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 80);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "{month}";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 100);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 13);
            this.label29.TabIndex = 10;
            this.label29.Text = "{monthno}";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(3, 120);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 13);
            this.label31.TabIndex = 12;
            this.label31.Text = "{day}";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(3, 140);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(45, 13);
            this.label34.TabIndex = 15;
            this.label34.Text = "{year4}";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(3, 160);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(45, 13);
            this.label35.TabIndex = 16;
            this.label35.Text = "{year2}";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(491, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Template Fields";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(284, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Overlay Transparency";
            // 
            // OverlayTransparencyBar
            // 
            this.OverlayTransparencyBar.Location = new System.Drawing.Point(281, 20);
            this.OverlayTransparencyBar.Name = "OverlayTransparencyBar";
            this.OverlayTransparencyBar.Size = new System.Drawing.Size(121, 45);
            this.OverlayTransparencyBar.TabIndex = 10;
            this.OverlayTransparencyBar.Value = 5;
            // 
            // OverlayPreviewButton
            // 
            this.OverlayPreviewButton.Location = new System.Drawing.Point(189, 240);
            this.OverlayPreviewButton.Name = "OverlayPreviewButton";
            this.OverlayPreviewButton.Size = new System.Drawing.Size(75, 23);
            this.OverlayPreviewButton.TabIndex = 9;
            this.OverlayPreviewButton.Text = "Preview";
            this.OverlayPreviewButton.UseVisualStyleBackColor = true;
            this.OverlayPreviewButton.Click += new System.EventHandler(this.OverlayPreviewButton_Click);
            // 
            // bottomRightText
            // 
            this.bottomRightText.Location = new System.Drawing.Point(23, 200);
            this.bottomRightText.Name = "bottomRightText";
            this.bottomRightText.Size = new System.Drawing.Size(241, 21);
            this.bottomRightText.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 183);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Bottom Right Text";
            // 
            // bottomLeftText
            // 
            this.bottomLeftText.Location = new System.Drawing.Point(23, 145);
            this.bottomLeftText.Name = "bottomLeftText";
            this.bottomLeftText.Size = new System.Drawing.Size(241, 21);
            this.bottomLeftText.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Bottom Left Text";
            // 
            // topRightText
            // 
            this.topRightText.Location = new System.Drawing.Point(23, 90);
            this.topRightText.Name = "topRightText";
            this.topRightText.Size = new System.Drawing.Size(241, 21);
            this.topRightText.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Top Right Text";
            // 
            // topLeftText
            // 
            this.topLeftText.Location = new System.Drawing.Point(23, 37);
            this.topLeftText.Name = "topLeftText";
            this.topLeftText.Size = new System.Drawing.Size(241, 21);
            this.topLeftText.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Top Left Text";
            // 
            // ImageFileTab
            // 
            this.ImageFileTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageFileTab.Controls.Add(this.tableLayoutPanel2);
            this.ImageFileTab.Controls.Add(this.label59);
            this.ImageFileTab.Controls.Add(this.label9);
            this.ImageFileTab.Controls.Add(this.ImageFileNamingFormat);
            this.ImageFileTab.Controls.Add(this.label8);
            this.ImageFileTab.Controls.Add(this.BrowseLocationButton);
            this.ImageFileTab.Controls.Add(this.ImageSavePath);
            this.ImageFileTab.Controls.Add(this.label7);
            this.ImageFileTab.Location = new System.Drawing.Point(4, 25);
            this.ImageFileTab.Name = "ImageFileTab";
            this.ImageFileTab.Padding = new System.Windows.Forms.Padding(3);
            this.ImageFileTab.Size = new System.Drawing.Size(665, 301);
            this.ImageFileTab.TabIndex = 3;
            this.ImageFileTab.Text = "Image File";
            this.ImageFileTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label39, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label40, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label41, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label42, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label43, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label44, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label45, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label46, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label47, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label48, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label49, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label50, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label51, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label52, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label53, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label54, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label55, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label56, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label57, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label58, 0, 8);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(494, 79);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 204);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(3, 180);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(45, 13);
            this.label39.TabIndex = 19;
            this.label39.Text = "{ampm}";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(68, 180);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(40, 13);
            this.label40.TabIndex = 18;
            this.label40.Text = "AM/PM";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 20);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(51, 13);
            this.label41.TabIndex = 2;
            this.label41.Text = "{24hour}";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(68, 20);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(73, 13);
            this.label42.TabIndex = 3;
            this.label42.Text = "24 Hour Clock";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(3, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(51, 13);
            this.label43.TabIndex = 0;
            this.label43.Text = "{12hour}";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(68, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(73, 13);
            this.label44.TabIndex = 1;
            this.label44.Text = "12 Hour Clock";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(3, 40);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(33, 13);
            this.label45.TabIndex = 6;
            this.label45.Text = "{min}";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(68, 40);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(39, 13);
            this.label46.TabIndex = 5;
            this.label46.Text = "Minute";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(68, 60);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(42, 13);
            this.label47.TabIndex = 7;
            this.label47.Text = "Second";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(68, 80);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(67, 13);
            this.label48.TabIndex = 9;
            this.label48.Text = "Month Name";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(68, 100);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(78, 13);
            this.label49.TabIndex = 11;
            this.label49.Text = "Month Numeric";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(68, 120);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(26, 13);
            this.label50.TabIndex = 13;
            this.label50.Text = "Day";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(68, 140);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 13);
            this.label51.TabIndex = 14;
            this.label51.Text = "4-Digit Year";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(68, 160);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 13);
            this.label52.TabIndex = 17;
            this.label52.Text = "2-Digit Year";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(3, 60);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(33, 13);
            this.label53.TabIndex = 4;
            this.label53.Text = "{sec}";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(3, 80);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(47, 13);
            this.label54.TabIndex = 8;
            this.label54.Text = "{month}";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(3, 100);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(59, 13);
            this.label55.TabIndex = 10;
            this.label55.Text = "{monthno}";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(3, 120);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(35, 13);
            this.label56.TabIndex = 12;
            this.label56.Text = "{day}";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(3, 140);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(45, 13);
            this.label57.TabIndex = 15;
            this.label57.Text = "{year4}";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(3, 160);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(45, 13);
            this.label58.TabIndex = 16;
            this.label58.Text = "{year2}";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(491, 58);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(96, 13);
            this.label59.TabIndex = 14;
            this.label59.Text = "Template Fields";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(289, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = ".jpg";
            // 
            // ImageFileNamingFormat
            // 
            this.ImageFileNamingFormat.Location = new System.Drawing.Point(25, 85);
            this.ImageFileNamingFormat.Name = "ImageFileNamingFormat";
            this.ImageFileNamingFormat.Size = new System.Drawing.Size(258, 21);
            this.ImageFileNamingFormat.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Image File Naming Format";
            // 
            // BrowseLocationButton
            // 
            this.BrowseLocationButton.AutoSize = true;
            this.BrowseLocationButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BrowseLocationButton.Location = new System.Drawing.Point(377, 34);
            this.BrowseLocationButton.Name = "BrowseLocationButton";
            this.BrowseLocationButton.Size = new System.Drawing.Size(29, 23);
            this.BrowseLocationButton.TabIndex = 2;
            this.BrowseLocationButton.Text = "...";
            this.BrowseLocationButton.UseVisualStyleBackColor = true;
            this.BrowseLocationButton.Click += new System.EventHandler(this.BrowseLocationButton_Click);
            // 
            // ImageSavePath
            // 
            this.ImageSavePath.Location = new System.Drawing.Point(25, 34);
            this.ImageSavePath.Name = "ImageSavePath";
            this.ImageSavePath.Size = new System.Drawing.Size(346, 21);
            this.ImageSavePath.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Image Save Path";
            // 
            // SchedulingTab
            // 
            this.SchedulingTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SchedulingTab.Controls.Add(this.CapturesEnabled);
            this.SchedulingTab.Controls.Add(this.label6);
            this.SchedulingTab.Controls.Add(this.UpdateInterval);
            this.SchedulingTab.Controls.Add(this.label5);
            this.SchedulingTab.Location = new System.Drawing.Point(4, 25);
            this.SchedulingTab.Name = "SchedulingTab";
            this.SchedulingTab.Padding = new System.Windows.Forms.Padding(3);
            this.SchedulingTab.Size = new System.Drawing.Size(665, 301);
            this.SchedulingTab.TabIndex = 2;
            this.SchedulingTab.Text = "Scheduling";
            this.SchedulingTab.UseVisualStyleBackColor = true;
            // 
            // CapturesEnabled
            // 
            this.CapturesEnabled.AutoSize = true;
            this.CapturesEnabled.Enabled = false;
            this.CapturesEnabled.Location = new System.Drawing.Point(593, 6);
            this.CapturesEnabled.Name = "CapturesEnabled";
            this.CapturesEnabled.Size = new System.Drawing.Size(64, 17);
            this.CapturesEnabled.TabIndex = 6;
            this.CapturesEnabled.Text = "&Enabled";
            this.CapturesEnabled.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "minutes";
            // 
            // UpdateInterval
            // 
            this.UpdateInterval.Location = new System.Drawing.Point(28, 39);
            this.UpdateInterval.Name = "UpdateInterval";
            this.UpdateInterval.Size = new System.Drawing.Size(41, 21);
            this.UpdateInterval.TabIndex = 1;
            this.UpdateInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpdateInterval.TextChanged += new System.EventHandler(this.UpdateInterval_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Update every";
            // 
            // ServicesTab
            // 
            this.ServicesTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServicesTab.Controls.Add(this.groupBox3);
            this.ServicesTab.Location = new System.Drawing.Point(4, 25);
            this.ServicesTab.Name = "ServicesTab";
            this.ServicesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ServicesTab.Size = new System.Drawing.Size(665, 301);
            this.ServicesTab.TabIndex = 4;
            this.ServicesTab.Text = "Services";
            this.ServicesTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UploadWundercamButton);
            this.groupBox3.Controls.Add(this.WundergroundPassword);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.WundergroundCameraID);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.WundercamEnabled);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 159);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Weather Underground Wundercam";
            // 
            // UploadWundercamButton
            // 
            this.UploadWundercamButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadWundercamButton.Location = new System.Drawing.Point(208, 121);
            this.UploadWundercamButton.Name = "UploadWundercamButton";
            this.UploadWundercamButton.Size = new System.Drawing.Size(75, 23);
            this.UploadWundercamButton.TabIndex = 5;
            this.UploadWundercamButton.Text = "&Upload Now";
            this.UploadWundercamButton.UseVisualStyleBackColor = true;
            this.UploadWundercamButton.Click += new System.EventHandler(this.UploadWundercamButton_Click);
            // 
            // WundergroundPassword
            // 
            this.WundergroundPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WundergroundPassword.Location = new System.Drawing.Point(7, 105);
            this.WundergroundPassword.Name = "WundergroundPassword";
            this.WundergroundPassword.PasswordChar = '•';
            this.WundergroundPassword.Size = new System.Drawing.Size(174, 21);
            this.WundergroundPassword.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Password";
            // 
            // WundergroundCameraID
            // 
            this.WundergroundCameraID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WundergroundCameraID.Location = new System.Drawing.Point(7, 57);
            this.WundergroundCameraID.Name = "WundergroundCameraID";
            this.WundergroundCameraID.Size = new System.Drawing.Size(174, 21);
            this.WundergroundCameraID.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Camera ID";
            // 
            // WundercamEnabled
            // 
            this.WundercamEnabled.AutoSize = true;
            this.WundercamEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WundercamEnabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WundercamEnabled.Location = new System.Drawing.Point(173, 20);
            this.WundercamEnabled.Name = "WundercamEnabled";
            this.WundercamEnabled.Size = new System.Drawing.Size(119, 17);
            this.WundercamEnabled.TabIndex = 0;
            this.WundercamEnabled.Text = "Upload on schedule";
            this.WundercamEnabled.UseVisualStyleBackColor = true;
            // 
            // GeneralTab
            // 
            this.GeneralTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GeneralTab.Controls.Add(this.groupBox4);
            this.GeneralTab.Controls.Add(this.WindowLocationGroup);
            this.GeneralTab.Location = new System.Drawing.Point(4, 25);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTab.Size = new System.Drawing.Size(665, 301);
            this.GeneralTab.TabIndex = 5;
            this.GeneralTab.Text = "General";
            this.GeneralTab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RestoreSettingsButton);
            this.groupBox4.Controls.Add(this.BackupSettingsButton);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 129);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(249, 100);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Backup && Restore Settings";
            // 
            // RestoreSettingsButton
            // 
            this.RestoreSettingsButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreSettingsButton.Location = new System.Drawing.Point(125, 44);
            this.RestoreSettingsButton.Name = "RestoreSettingsButton";
            this.RestoreSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.RestoreSettingsButton.TabIndex = 1;
            this.RestoreSettingsButton.Text = "&Restore";
            this.RestoreSettingsButton.UseVisualStyleBackColor = true;
            this.RestoreSettingsButton.Click += new System.EventHandler(this.RestoreSettingsButton_Click);
            // 
            // BackupSettingsButton
            // 
            this.BackupSettingsButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupSettingsButton.Location = new System.Drawing.Point(44, 44);
            this.BackupSettingsButton.Name = "BackupSettingsButton";
            this.BackupSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.BackupSettingsButton.TabIndex = 0;
            this.BackupSettingsButton.Text = "&Backup";
            this.BackupSettingsButton.UseVisualStyleBackColor = true;
            this.BackupSettingsButton.Click += new System.EventHandler(this.BackupSettingsButton_Click);
            // 
            // WindowLocationGroup
            // 
            this.WindowLocationGroup.Controls.Add(this.TopRightRadio);
            this.WindowLocationGroup.Controls.Add(this.KeepOnTopCheckbox);
            this.WindowLocationGroup.Controls.Add(this.BottomRightRadio);
            this.WindowLocationGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowLocationGroup.Location = new System.Drawing.Point(16, 16);
            this.WindowLocationGroup.Name = "WindowLocationGroup";
            this.WindowLocationGroup.Size = new System.Drawing.Size(249, 107);
            this.WindowLocationGroup.TabIndex = 1;
            this.WindowLocationGroup.TabStop = false;
            this.WindowLocationGroup.Text = "Window Location";
            // 
            // TopRightRadio
            // 
            this.TopRightRadio.AutoSize = true;
            this.TopRightRadio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopRightRadio.Location = new System.Drawing.Point(7, 45);
            this.TopRightRadio.Name = "TopRightRadio";
            this.TopRightRadio.Size = new System.Drawing.Size(71, 17);
            this.TopRightRadio.TabIndex = 1;
            this.TopRightRadio.Tag = "TopRight";
            this.TopRightRadio.Text = "Top Right";
            this.TopRightRadio.UseVisualStyleBackColor = true;
            // 
            // KeepOnTopCheckbox
            // 
            this.KeepOnTopCheckbox.AutoSize = true;
            this.KeepOnTopCheckbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeepOnTopCheckbox.Location = new System.Drawing.Point(6, 79);
            this.KeepOnTopCheckbox.Name = "KeepOnTopCheckbox";
            this.KeepOnTopCheckbox.Size = new System.Drawing.Size(177, 17);
            this.KeepOnTopCheckbox.TabIndex = 0;
            this.KeepOnTopCheckbox.Text = "&Keep application window on top";
            this.KeepOnTopCheckbox.UseVisualStyleBackColor = true;
            // 
            // BottomRightRadio
            // 
            this.BottomRightRadio.AutoSize = true;
            this.BottomRightRadio.Checked = true;
            this.BottomRightRadio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BottomRightRadio.Location = new System.Drawing.Point(7, 21);
            this.BottomRightRadio.Name = "BottomRightRadio";
            this.BottomRightRadio.Size = new System.Drawing.Size(87, 17);
            this.BottomRightRadio.TabIndex = 0;
            this.BottomRightRadio.TabStop = true;
            this.BottomRightRadio.Tag = "BottomRight";
            this.BottomRightRadio.Text = "Bottom Right";
            this.BottomRightRadio.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(525, 348);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(606, 348);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 381);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.OptionsTabs);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.OptionsTabs.ResumeLayout(false);
            this.CameraTab.ResumeLayout(false);
            this.CameraTab.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.OverlayTab.ResumeLayout(false);
            this.OverlayTab.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayTransparencyBar)).EndInit();
            this.ImageFileTab.ResumeLayout(false);
            this.ImageFileTab.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.SchedulingTab.ResumeLayout(false);
            this.SchedulingTab.PerformLayout();
            this.ServicesTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GeneralTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.WindowLocationGroup.ResumeLayout(false);
            this.WindowLocationGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl OptionsTabs;
        private TabPage CameraTab;
        private TabPage OverlayTab;
        private TabPage ImageFileTab;
        private TabPage SchedulingTab;
        private TextBox Password;
        private Label label3;
        private TextBox Username;
        private Label label2;
        private TextBox CameraHostName;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label4;
        private TextBox SnapshotUrlPath;
        private Label CameraUrlPreview;
        private Button OKButton;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        private Button CancelButton;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        private Button TestConnectionButton;
        private Label label6;
        private TextBox UpdateInterval;
        private Label label5;
        private TextBox ImageFileNamingFormat;
        private Label label8;
        private Button BrowseLocationButton;
        private TextBox ImageSavePath;
        private Label label7;
        private Label label9;
        private CheckBox CapturesEnabled;
        private TabPage ServicesTab;
        private GroupBox groupBox3;
        private Button UploadWundercamButton;
        private TextBox WundergroundPassword;
        private Label label12;
        private TextBox WundergroundCameraID;
        private Label label11;
        private CheckBox WundercamEnabled;
        private TabPage GeneralTab;
        private CheckBox KeepOnTopCheckbox;
        private GroupBox WindowLocationGroup;
        private RadioButton TopRightRadio;
        private RadioButton BottomRightRadio;
        private TextBox bottomRightText;
        private Label label16;
        private TextBox bottomLeftText;
        private Label label15;
        private TextBox topRightText;
        private Label label14;
        private TextBox topLeftText;
        private Label label13;
        private Label label17;
        private TrackBar OverlayTransparencyBar;
        private Button OverlayPreviewButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label19;
        private Label label20;
        private Label label18;
        private Label label33;
        private Label label34;
        private Label label21;
        private Label label22;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label36;
        private Label label35;
        private Label label38;
        private Label label37;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label39;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private GroupBox groupBox4;
        private Button RestoreSettingsButton;
        private Button BackupSettingsButton;
        private ComboBox CameraMfgSelector;
        private Label label10;
    }
}