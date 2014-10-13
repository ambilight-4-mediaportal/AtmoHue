namespace AtmoHue
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLocateHueBridge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAtmoWinFolder = new System.Windows.Forms.Label();
            this.lblOutputHueDevices = new System.Windows.Forms.Label();
            this.btnTestRed = new System.Windows.Forms.Button();
            this.btnTestGreen = new System.Windows.Forms.Button();
            this.btnTestBlue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHueAppName = new System.Windows.Forms.TextBox();
            this.tbHueAppKey = new System.Windows.Forms.TextBox();
            this.lbOutputlog = new System.Windows.Forms.ListBox();
            this.btnStartAtmowinHue = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.lblHueSaturation = new System.Windows.Forms.Label();
            this.lblHueTransTime = new System.Windows.Forms.Label();
            this.lblHueHue = new System.Windows.Forms.Label();
            this.tbHueHue = new System.Windows.Forms.TextBox();
            this.tbHueTransitionTime = new System.Windows.Forms.TextBox();
            this.tbHueSaturation = new System.Windows.Forms.TextBox();
            this.cbHueBrightness = new System.Windows.Forms.ComboBox();
            this.tbAtmowinScanInterval = new System.Windows.Forms.TextBox();
            this.cbOutputHueDevicesRange = new System.Windows.Forms.ComboBox();
            this.cbRunningWindows8 = new System.Windows.Forms.CheckBox();
            this.tbAtmowinLocation = new System.Windows.Forms.TextBox();
            this.tbHueBridgeIP = new System.Windows.Forms.TextBox();
            this.btnHueColorClear = new System.Windows.Forms.Button();
            this.lblHueCustomColorTest = new System.Windows.Forms.Label();
            this.tbHueCustomColor = new System.Windows.Forms.TextBox();
            this.btnHueSendCustomColor = new System.Windows.Forms.Button();
            this.btnHueColorRotateTestStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRotateTestDelay = new System.Windows.Forms.TextBox();
            this.btnHueColorRotateTestStop = new System.Windows.Forms.Button();
            this.cbEnableDebuglog = new System.Windows.Forms.CheckBox();
            this.lblAtmoinPresetColor = new System.Windows.Forms.Label();
            this.tbAtmowinStaticColor = new System.Windows.Forms.TextBox();
            this.btnStopAtmowinHue = new System.Windows.Forms.Button();
            this.llQ42 = new System.Windows.Forms.LinkLabel();
            this.lCopyright = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLocateHueBridge
            // 
            this.btnLocateHueBridge.Location = new System.Drawing.Point(613, 45);
            this.btnLocateHueBridge.Name = "btnLocateHueBridge";
            this.btnLocateHueBridge.Size = new System.Drawing.Size(193, 56);
            this.btnLocateHueBridge.TabIndex = 1;
            this.btnLocateHueBridge.Text = "Locate Hue Bridge";
            this.btnLocateHueBridge.UseVisualStyleBackColor = true;
            this.btnLocateHueBridge.Click += new System.EventHandler(this.btnLocateHueBridge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bridge IP";
            // 
            // lblAtmoWinFolder
            // 
            this.lblAtmoWinFolder.AutoSize = true;
            this.lblAtmoWinFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtmoWinFolder.Location = new System.Drawing.Point(13, 49);
            this.lblAtmoWinFolder.Name = "lblAtmoWinFolder";
            this.lblAtmoWinFolder.Size = new System.Drawing.Size(103, 13);
            this.lblAtmoWinFolder.TabIndex = 3;
            this.lblAtmoWinFolder.Text = "Atmowin location";
            // 
            // lblOutputHueDevices
            // 
            this.lblOutputHueDevices.AutoSize = true;
            this.lblOutputHueDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputHueDevices.Location = new System.Drawing.Point(13, 83);
            this.lblOutputHueDevices.Name = "lblOutputHueDevices";
            this.lblOutputHueDevices.Size = new System.Drawing.Size(92, 13);
            this.lblOutputHueDevices.TabIndex = 8;
            this.lblOutputHueDevices.Text = "Hue Lights use";
            // 
            // btnTestRed
            // 
            this.btnTestRed.Location = new System.Drawing.Point(564, 176);
            this.btnTestRed.Name = "btnTestRed";
            this.btnTestRed.Size = new System.Drawing.Size(75, 23);
            this.btnTestRed.TabIndex = 9;
            this.btnTestRed.Text = "RED";
            this.btnTestRed.UseVisualStyleBackColor = true;
            this.btnTestRed.Click += new System.EventHandler(this.btnTestRed_Click);
            // 
            // btnTestGreen
            // 
            this.btnTestGreen.Location = new System.Drawing.Point(645, 176);
            this.btnTestGreen.Name = "btnTestGreen";
            this.btnTestGreen.Size = new System.Drawing.Size(75, 23);
            this.btnTestGreen.TabIndex = 10;
            this.btnTestGreen.Text = "GREEN";
            this.btnTestGreen.UseVisualStyleBackColor = true;
            this.btnTestGreen.Click += new System.EventHandler(this.btnTestGreen_Click);
            // 
            // btnTestBlue
            // 
            this.btnTestBlue.Location = new System.Drawing.Point(726, 176);
            this.btnTestBlue.Name = "btnTestBlue";
            this.btnTestBlue.Size = new System.Drawing.Size(75, 23);
            this.btnTestBlue.TabIndex = 11;
            this.btnTestBlue.Text = "BLUE";
            this.btnTestBlue.UseVisualStyleBackColor = true;
            this.btnTestBlue.Click += new System.EventHandler(this.btnTestBlue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(493, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Color test:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Hue app name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hue app key";
            // 
            // tbHueAppName
            // 
            this.tbHueAppName.Location = new System.Drawing.Point(140, 112);
            this.tbHueAppName.Name = "tbHueAppName";
            this.tbHueAppName.Size = new System.Drawing.Size(173, 20);
            this.tbHueAppName.TabIndex = 15;
            this.tbHueAppName.Text = "mypersonalappname";
            // 
            // tbHueAppKey
            // 
            this.tbHueAppKey.Location = new System.Drawing.Point(140, 140);
            this.tbHueAppKey.Name = "tbHueAppKey";
            this.tbHueAppKey.Size = new System.Drawing.Size(329, 20);
            this.tbHueAppKey.TabIndex = 16;
            this.tbHueAppKey.Text = "mypersonalappkey";
            // 
            // lbOutputlog
            // 
            this.lbOutputlog.FormattingEnabled = true;
            this.lbOutputlog.Location = new System.Drawing.Point(12, 322);
            this.lbOutputlog.Name = "lbOutputlog";
            this.lbOutputlog.Size = new System.Drawing.Size(790, 264);
            this.lbOutputlog.TabIndex = 17;
            // 
            // btnStartAtmowinHue
            // 
            this.btnStartAtmowinHue.Location = new System.Drawing.Point(526, 602);
            this.btnStartAtmowinHue.Name = "btnStartAtmowinHue";
            this.btnStartAtmowinHue.Size = new System.Drawing.Size(135, 33);
            this.btnStartAtmowinHue.TabIndex = 18;
            this.btnStartAtmowinHue.Text = "Start monitoring Atmowin";
            this.btnStartAtmowinHue.UseVisualStyleBackColor = true;
            this.btnStartAtmowinHue.Click += new System.EventHandler(this.btnStartAtmowinHue_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(618, 656);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "scan interval (ms)";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrightness.Location = new System.Drawing.Point(12, 176);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(87, 13);
            this.lblBrightness.TabIndex = 21;
            this.lblBrightness.Text = "Brightness (%)";
            // 
            // lblHueSaturation
            // 
            this.lblHueSaturation.AutoSize = true;
            this.lblHueSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHueSaturation.Location = new System.Drawing.Point(15, 221);
            this.lblHueSaturation.Name = "lblHueSaturation";
            this.lblHueSaturation.Size = new System.Drawing.Size(65, 13);
            this.lblHueSaturation.TabIndex = 25;
            this.lblHueSaturation.Text = "Saturation";
            // 
            // lblHueTransTime
            // 
            this.lblHueTransTime.AutoSize = true;
            this.lblHueTransTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHueTransTime.Location = new System.Drawing.Point(15, 249);
            this.lblHueTransTime.Name = "lblHueTransTime";
            this.lblHueTransTime.Size = new System.Drawing.Size(117, 13);
            this.lblHueTransTime.TabIndex = 26;
            this.lblHueTransTime.Text = "Transition time (ms)";
            // 
            // lblHueHue
            // 
            this.lblHueHue.AutoSize = true;
            this.lblHueHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHueHue.Location = new System.Drawing.Point(15, 281);
            this.lblHueHue.Name = "lblHueHue";
            this.lblHueHue.Size = new System.Drawing.Size(30, 13);
            this.lblHueHue.TabIndex = 28;
            this.lblHueHue.Text = "Hue";
            // 
            // tbHueHue
            // 
            this.tbHueHue.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueHue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbHueHue.Location = new System.Drawing.Point(140, 278);
            this.tbHueHue.Name = "tbHueHue";
            this.tbHueHue.Size = new System.Drawing.Size(100, 20);
            this.tbHueHue.TabIndex = 29;
            this.tbHueHue.Text = global::AtmoHue.Properties.Settings.Default.HueHue;
            // 
            // tbHueTransitionTime
            // 
            this.tbHueTransitionTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueTransitionTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbHueTransitionTime.Location = new System.Drawing.Point(140, 246);
            this.tbHueTransitionTime.Name = "tbHueTransitionTime";
            this.tbHueTransitionTime.Size = new System.Drawing.Size(100, 20);
            this.tbHueTransitionTime.TabIndex = 24;
            this.tbHueTransitionTime.Text = global::AtmoHue.Properties.Settings.Default.HueTransitionTime;
            // 
            // tbHueSaturation
            // 
            this.tbHueSaturation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueSaturation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbHueSaturation.Location = new System.Drawing.Point(140, 218);
            this.tbHueSaturation.Name = "tbHueSaturation";
            this.tbHueSaturation.Size = new System.Drawing.Size(100, 20);
            this.tbHueSaturation.TabIndex = 23;
            this.tbHueSaturation.Text = global::AtmoHue.Properties.Settings.Default.HueSaturation;
            // 
            // cbHueBrightness
            // 
            this.cbHueBrightness.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueBrightness", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbHueBrightness.FormattingEnabled = true;
            this.cbHueBrightness.Location = new System.Drawing.Point(140, 173);
            this.cbHueBrightness.Name = "cbHueBrightness";
            this.cbHueBrightness.Size = new System.Drawing.Size(75, 21);
            this.cbHueBrightness.TabIndex = 22;
            this.cbHueBrightness.Text = global::AtmoHue.Properties.Settings.Default.HueBrightness;
            // 
            // tbAtmowinScanInterval
            // 
            this.tbAtmowinScanInterval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "atmowinScanInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAtmowinScanInterval.Location = new System.Drawing.Point(730, 653);
            this.tbAtmowinScanInterval.Name = "tbAtmowinScanInterval";
            this.tbAtmowinScanInterval.Size = new System.Drawing.Size(68, 20);
            this.tbAtmowinScanInterval.TabIndex = 19;
            this.tbAtmowinScanInterval.Text = global::AtmoHue.Properties.Settings.Default.atmowinScanInterval;
            // 
            // cbOutputHueDevicesRange
            // 
            this.cbOutputHueDevicesRange.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "hueLightsActive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbOutputHueDevicesRange.FormattingEnabled = true;
            this.cbOutputHueDevicesRange.Items.AddRange(new object[] {
            "ALL",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbOutputHueDevicesRange.Location = new System.Drawing.Point(140, 80);
            this.cbOutputHueDevicesRange.Name = "cbOutputHueDevicesRange";
            this.cbOutputHueDevicesRange.Size = new System.Drawing.Size(121, 21);
            this.cbOutputHueDevicesRange.TabIndex = 7;
            this.cbOutputHueDevicesRange.Text = global::AtmoHue.Properties.Settings.Default.hueLightsActive;
            // 
            // cbRunningWindows8
            // 
            this.cbRunningWindows8.AutoSize = true;
            this.cbRunningWindows8.Checked = global::AtmoHue.Properties.Settings.Default.hueBridgeMode;
            this.cbRunningWindows8.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AtmoHue.Properties.Settings.Default, "hueBridgeMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbRunningWindows8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRunningWindows8.Location = new System.Drawing.Point(613, 22);
            this.cbRunningWindows8.Name = "cbRunningWindows8";
            this.cbRunningWindows8.Size = new System.Drawing.Size(159, 17);
            this.cbRunningWindows8.TabIndex = 6;
            this.cbRunningWindows8.Text = "Running Windows 8.* ?";
            this.cbRunningWindows8.UseVisualStyleBackColor = true;
            // 
            // tbAtmowinLocation
            // 
            this.tbAtmowinLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "atmowinLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbAtmowinLocation.Location = new System.Drawing.Point(140, 46);
            this.tbAtmowinLocation.Name = "tbAtmowinLocation";
            this.tbAtmowinLocation.Size = new System.Drawing.Size(368, 20);
            this.tbAtmowinLocation.TabIndex = 5;
            this.tbAtmowinLocation.Text = global::AtmoHue.Properties.Settings.Default.atmowinLocation;
            // 
            // tbHueBridgeIP
            // 
            this.tbHueBridgeIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "hueBridgeIP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbHueBridgeIP.Location = new System.Drawing.Point(140, 10);
            this.tbHueBridgeIP.Name = "tbHueBridgeIP";
            this.tbHueBridgeIP.Size = new System.Drawing.Size(100, 20);
            this.tbHueBridgeIP.TabIndex = 4;
            this.tbHueBridgeIP.Text = global::AtmoHue.Properties.Settings.Default.hueBridgeIP;
            // 
            // btnHueColorClear
            // 
            this.btnHueColorClear.Location = new System.Drawing.Point(637, 211);
            this.btnHueColorClear.Name = "btnHueColorClear";
            this.btnHueColorClear.Size = new System.Drawing.Size(92, 23);
            this.btnHueColorClear.TabIndex = 30;
            this.btnHueColorClear.Text = "CLEAR/RESET";
            this.btnHueColorClear.UseVisualStyleBackColor = true;
            this.btnHueColorClear.Click += new System.EventHandler(this.btnHueColorClear_Click);
            // 
            // lblHueCustomColorTest
            // 
            this.lblHueCustomColorTest.AutoSize = true;
            this.lblHueCustomColorTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHueCustomColorTest.Location = new System.Drawing.Point(493, 253);
            this.lblHueCustomColorTest.Name = "lblHueCustomColorTest";
            this.lblHueCustomColorTest.Size = new System.Drawing.Size(117, 13);
            this.lblHueCustomColorTest.TabIndex = 31;
            this.lblHueCustomColorTest.Text = "Custom color(HEX):";
            // 
            // tbHueCustomColor
            // 
            this.tbHueCustomColor.Location = new System.Drawing.Point(609, 251);
            this.tbHueCustomColor.Name = "tbHueCustomColor";
            this.tbHueCustomColor.Size = new System.Drawing.Size(100, 20);
            this.tbHueCustomColor.TabIndex = 32;
            // 
            // btnHueSendCustomColor
            // 
            this.btnHueSendCustomColor.Location = new System.Drawing.Point(715, 249);
            this.btnHueSendCustomColor.Name = "btnHueSendCustomColor";
            this.btnHueSendCustomColor.Size = new System.Drawing.Size(64, 23);
            this.btnHueSendCustomColor.TabIndex = 33;
            this.btnHueSendCustomColor.Text = "Test";
            this.btnHueSendCustomColor.UseVisualStyleBackColor = true;
            this.btnHueSendCustomColor.Click += new System.EventHandler(this.btnHueSendCustomColor_Click);
            // 
            // btnHueColorRotateTestStart
            // 
            this.btnHueColorRotateTestStart.Location = new System.Drawing.Point(667, 289);
            this.btnHueColorRotateTestStart.Name = "btnHueColorRotateTestStart";
            this.btnHueColorRotateTestStart.Size = new System.Drawing.Size(57, 23);
            this.btnHueColorRotateTestStart.TabIndex = 34;
            this.btnHueColorRotateTestStart.Text = "Start";
            this.btnHueColorRotateTestStart.UseVisualStyleBackColor = true;
            this.btnHueColorRotateTestStart.Click += new System.EventHandler(this.btnHueColorRotateTestStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(405, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Rotate R/G/B every (ms):";
            // 
            // tbRotateTestDelay
            // 
            this.tbRotateTestDelay.Location = new System.Drawing.Point(561, 291);
            this.tbRotateTestDelay.Name = "tbRotateTestDelay";
            this.tbRotateTestDelay.Size = new System.Drawing.Size(100, 20);
            this.tbRotateTestDelay.TabIndex = 36;
            this.tbRotateTestDelay.Text = "100";
            // 
            // btnHueColorRotateTestStop
            // 
            this.btnHueColorRotateTestStop.Location = new System.Drawing.Point(726, 289);
            this.btnHueColorRotateTestStop.Name = "btnHueColorRotateTestStop";
            this.btnHueColorRotateTestStop.Size = new System.Drawing.Size(53, 23);
            this.btnHueColorRotateTestStop.TabIndex = 37;
            this.btnHueColorRotateTestStop.Text = "Stop";
            this.btnHueColorRotateTestStop.UseVisualStyleBackColor = true;
            this.btnHueColorRotateTestStop.Click += new System.EventHandler(this.btnHueColorRotateTestStop_Click);
            // 
            // cbEnableDebuglog
            // 
            this.cbEnableDebuglog.AutoSize = true;
            this.cbEnableDebuglog.Location = new System.Drawing.Point(12, 592);
            this.cbEnableDebuglog.Name = "cbEnableDebuglog";
            this.cbEnableDebuglog.Size = new System.Drawing.Size(109, 17);
            this.cbEnableDebuglog.TabIndex = 38;
            this.cbEnableDebuglog.Text = "Enable debug log";
            this.cbEnableDebuglog.UseVisualStyleBackColor = true;
            // 
            // lblAtmoinPresetColor
            // 
            this.lblAtmoinPresetColor.AutoSize = true;
            this.lblAtmoinPresetColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtmoinPresetColor.Location = new System.Drawing.Point(292, 656);
            this.lblAtmoinPresetColor.Name = "lblAtmoinPresetColor";
            this.lblAtmoinPresetColor.Size = new System.Drawing.Size(199, 13);
            this.lblAtmoinPresetColor.TabIndex = 39;
            this.lblAtmoinPresetColor.Text = "Color when atmowin disconnects: (HEX):";
            // 
            // tbAtmowinStaticColor
            // 
            this.tbAtmowinStaticColor.Location = new System.Drawing.Point(520, 653);
            this.tbAtmowinStaticColor.Name = "tbAtmowinStaticColor";
            this.tbAtmowinStaticColor.Size = new System.Drawing.Size(77, 20);
            this.tbAtmowinStaticColor.TabIndex = 40;
            // 
            // btnStopAtmowinHue
            // 
            this.btnStopAtmowinHue.Location = new System.Drawing.Point(667, 602);
            this.btnStopAtmowinHue.Name = "btnStopAtmowinHue";
            this.btnStopAtmowinHue.Size = new System.Drawing.Size(135, 33);
            this.btnStopAtmowinHue.TabIndex = 41;
            this.btnStopAtmowinHue.Text = "Stop monitoring Atmowin";
            this.btnStopAtmowinHue.UseVisualStyleBackColor = true;
            this.btnStopAtmowinHue.Click += new System.EventHandler(this.btnStopAtmowinHue_Click);
            // 
            // llQ42
            // 
            this.llQ42.AutoSize = true;
            this.llQ42.Location = new System.Drawing.Point(98, 665);
            this.llQ42.Name = "llQ42";
            this.llQ42.Size = new System.Drawing.Size(65, 13);
            this.llQ42.TabIndex = 42;
            this.llQ42.TabStop = true;
            this.llQ42.Text = "Q42.HueApi";
            this.llQ42.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llQ42_LinkClicked);
            // 
            // lCopyright
            // 
            this.lCopyright.AutoSize = true;
            this.lCopyright.Location = new System.Drawing.Point(9, 665);
            this.lCopyright.Name = "lCopyright";
            this.lCopyright.Size = new System.Drawing.Size(92, 13);
            this.lCopyright.TabIndex = 43;
            this.lCopyright.Text = "Made possible by:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(818, 687);
            this.Controls.Add(this.lCopyright);
            this.Controls.Add(this.llQ42);
            this.Controls.Add(this.btnStopAtmowinHue);
            this.Controls.Add(this.tbAtmowinStaticColor);
            this.Controls.Add(this.lblAtmoinPresetColor);
            this.Controls.Add(this.cbEnableDebuglog);
            this.Controls.Add(this.btnHueColorRotateTestStop);
            this.Controls.Add(this.tbRotateTestDelay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnHueColorRotateTestStart);
            this.Controls.Add(this.btnHueSendCustomColor);
            this.Controls.Add(this.tbHueCustomColor);
            this.Controls.Add(this.lblHueCustomColorTest);
            this.Controls.Add(this.btnHueColorClear);
            this.Controls.Add(this.tbHueHue);
            this.Controls.Add(this.lblHueHue);
            this.Controls.Add(this.lblHueTransTime);
            this.Controls.Add(this.lblHueSaturation);
            this.Controls.Add(this.tbHueTransitionTime);
            this.Controls.Add(this.tbHueSaturation);
            this.Controls.Add(this.cbHueBrightness);
            this.Controls.Add(this.lblBrightness);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAtmowinScanInterval);
            this.Controls.Add(this.btnStartAtmowinHue);
            this.Controls.Add(this.lbOutputlog);
            this.Controls.Add(this.tbHueAppKey);
            this.Controls.Add(this.tbHueAppName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTestBlue);
            this.Controls.Add(this.btnTestGreen);
            this.Controls.Add(this.btnTestRed);
            this.Controls.Add(this.lblOutputHueDevices);
            this.Controls.Add(this.cbOutputHueDevicesRange);
            this.Controls.Add(this.cbRunningWindows8);
            this.Controls.Add(this.tbAtmowinLocation);
            this.Controls.Add(this.tbHueBridgeIP);
            this.Controls.Add(this.lblAtmoWinFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLocateHueBridge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Atmo Hue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLocateHueBridge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAtmoWinFolder;
        private System.Windows.Forms.TextBox tbHueBridgeIP;
        private System.Windows.Forms.TextBox tbAtmowinLocation;
        private System.Windows.Forms.CheckBox cbRunningWindows8;
        private System.Windows.Forms.ComboBox cbOutputHueDevicesRange;
        private System.Windows.Forms.Label lblOutputHueDevices;
        private System.Windows.Forms.Button btnTestRed;
        private System.Windows.Forms.Button btnTestGreen;
        private System.Windows.Forms.Button btnTestBlue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHueAppName;
        private System.Windows.Forms.TextBox tbHueAppKey;
        private System.Windows.Forms.ListBox lbOutputlog;
        private System.Windows.Forms.Button btnStartAtmowinHue;
        private System.Windows.Forms.TextBox tbAtmowinScanInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.ComboBox cbHueBrightness;
        private System.Windows.Forms.TextBox tbHueSaturation;
        private System.Windows.Forms.TextBox tbHueTransitionTime;
        private System.Windows.Forms.Label lblHueSaturation;
        private System.Windows.Forms.Label lblHueTransTime;
        private System.Windows.Forms.Label lblHueHue;
        private System.Windows.Forms.TextBox tbHueHue;
        private System.Windows.Forms.Button btnHueColorClear;
        private System.Windows.Forms.Label lblHueCustomColorTest;
        private System.Windows.Forms.TextBox tbHueCustomColor;
        private System.Windows.Forms.Button btnHueSendCustomColor;
        private System.Windows.Forms.Button btnHueColorRotateTestStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRotateTestDelay;
        private System.Windows.Forms.Button btnHueColorRotateTestStop;
        private System.Windows.Forms.CheckBox cbEnableDebuglog;
        private System.Windows.Forms.Label lblAtmoinPresetColor;
        private System.Windows.Forms.TextBox tbAtmowinStaticColor;
        private System.Windows.Forms.Button btnStopAtmowinHue;
        private System.Windows.Forms.LinkLabel llQ42;
        private System.Windows.Forms.Label lCopyright;
    }
}

