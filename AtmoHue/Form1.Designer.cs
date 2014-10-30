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
      this.lbOutputlog = new System.Windows.Forms.ListBox();
      this.btnStartAtmowinHue = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.lblBrightness = new System.Windows.Forms.Label();
      this.lblHueSaturation = new System.Windows.Forms.Label();
      this.lblHueTransTime = new System.Windows.Forms.Label();
      this.lblHueHue = new System.Windows.Forms.Label();
      this.btnHueColorClear = new System.Windows.Forms.Button();
      this.lblHueCustomColorTest = new System.Windows.Forms.Label();
      this.btnHueSendCustomColor = new System.Windows.Forms.Button();
      this.btnHueColorRotateTestStart = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.btnHueColorRotateTestStop = new System.Windows.Forms.Button();
      this.cbEnableDebuglog = new System.Windows.Forms.CheckBox();
      this.lblAtmoinPresetColor = new System.Windows.Forms.Label();
      this.tbAtmowinStaticColor = new System.Windows.Forms.TextBox();
      this.btnStopAtmowinHue = new System.Windows.Forms.Button();
      this.llQ42 = new System.Windows.Forms.LinkLabel();
      this.lCopyright = new System.Windows.Forms.Label();
      this.gbBridgeTools = new System.Windows.Forms.GroupBox();
      this.cbRunningWindows8 = new System.Windows.Forms.CheckBox();
      this.cbAutoConnectBridge = new System.Windows.Forms.CheckBox();
      this.grpAtmowin = new System.Windows.Forms.GroupBox();
      this.tbAtmowinScanInterval = new System.Windows.Forms.TextBox();
      this.cbLogRemoteApiCalls = new System.Windows.Forms.CheckBox();
      this.grpRemoteAPI = new System.Windows.Forms.GroupBox();
      this.tbRemoteAPIsendDelay = new System.Windows.Forms.TextBox();
      this.lblHintRestart = new System.Windows.Forms.Label();
      this.lblApiScanInterval = new System.Windows.Forms.Label();
      this.lblAPIport = new System.Windows.Forms.Label();
      this.lblAPIip = new System.Windows.Forms.Label();
      this.tbRemoteApiPort = new System.Windows.Forms.TextBox();
      this.tbRemoteAPIip = new System.Windows.Forms.TextBox();
      this.cbRemoteAPIEnabled = new System.Windows.Forms.CheckBox();
      this.tbRotateTestDelay = new System.Windows.Forms.TextBox();
      this.tbHueCustomColor = new System.Windows.Forms.TextBox();
      this.tbHueHue = new System.Windows.Forms.TextBox();
      this.tbHueTransitionTime = new System.Windows.Forms.TextBox();
      this.tbHueSaturation = new System.Windows.Forms.TextBox();
      this.cbHueBrightness = new System.Windows.Forms.ComboBox();
      this.tbHueAppKey = new System.Windows.Forms.TextBox();
      this.tbHueAppName = new System.Windows.Forms.TextBox();
      this.cbOutputHueDevicesRange = new System.Windows.Forms.ComboBox();
      this.tbAtmowinLocation = new System.Windows.Forms.TextBox();
      this.tbHueBridgeIP = new System.Windows.Forms.TextBox();
      this.btnRefreshSettings = new System.Windows.Forms.Button();
      this.gbBridgeTools.SuspendLayout();
      this.grpAtmowin.SuspendLayout();
      this.grpRemoteAPI.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnLocateHueBridge
      // 
      this.btnLocateHueBridge.Location = new System.Drawing.Point(13, 69);
      this.btnLocateHueBridge.Name = "btnLocateHueBridge";
      this.btnLocateHueBridge.Size = new System.Drawing.Size(253, 56);
      this.btnLocateHueBridge.TabIndex = 1;
      this.btnLocateHueBridge.Text = "Locate and register to Hue Bridge";
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
      this.lblAtmoWinFolder.Location = new System.Drawing.Point(20, 16);
      this.lblAtmoWinFolder.Name = "lblAtmoWinFolder";
      this.lblAtmoWinFolder.Size = new System.Drawing.Size(103, 13);
      this.lblAtmoWinFolder.TabIndex = 3;
      this.lblAtmoWinFolder.Text = "Atmowin location";
      // 
      // lblOutputHueDevices
      // 
      this.lblOutputHueDevices.AutoSize = true;
      this.lblOutputHueDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblOutputHueDevices.Location = new System.Drawing.Point(13, 57);
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
      this.label3.Location = new System.Drawing.Point(13, 89);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(89, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Hue app name";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(13, 117);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 13);
      this.label4.TabIndex = 14;
      this.label4.Text = "Hue app key";
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
      this.btnStartAtmowinHue.Location = new System.Drawing.Point(23, 63);
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
      this.label5.Location = new System.Drawing.Point(346, 137);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(89, 13);
      this.label5.TabIndex = 20;
      this.label5.Text = "scan interval (ms)";
      // 
      // lblBrightness
      // 
      this.lblBrightness.AutoSize = true;
      this.lblBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblBrightness.Location = new System.Drawing.Point(12, 150);
      this.lblBrightness.Name = "lblBrightness";
      this.lblBrightness.Size = new System.Drawing.Size(87, 13);
      this.lblBrightness.TabIndex = 21;
      this.lblBrightness.Text = "Brightness (%)";
      // 
      // lblHueSaturation
      // 
      this.lblHueSaturation.AutoSize = true;
      this.lblHueSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueSaturation.Location = new System.Drawing.Point(15, 195);
      this.lblHueSaturation.Name = "lblHueSaturation";
      this.lblHueSaturation.Size = new System.Drawing.Size(65, 13);
      this.lblHueSaturation.TabIndex = 25;
      this.lblHueSaturation.Text = "Saturation";
      // 
      // lblHueTransTime
      // 
      this.lblHueTransTime.AutoSize = true;
      this.lblHueTransTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueTransTime.Location = new System.Drawing.Point(15, 223);
      this.lblHueTransTime.Name = "lblHueTransTime";
      this.lblHueTransTime.Size = new System.Drawing.Size(117, 13);
      this.lblHueTransTime.TabIndex = 26;
      this.lblHueTransTime.Text = "Transition time (ms)";
      // 
      // lblHueHue
      // 
      this.lblHueHue.AutoSize = true;
      this.lblHueHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueHue.Location = new System.Drawing.Point(15, 255);
      this.lblHueHue.Name = "lblHueHue";
      this.lblHueHue.Size = new System.Drawing.Size(30, 13);
      this.lblHueHue.TabIndex = 28;
      this.lblHueHue.Text = "Hue";
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
      this.lblHueCustomColorTest.Location = new System.Drawing.Point(441, 254);
      this.lblHueCustomColorTest.Name = "lblHueCustomColorTest";
      this.lblHueCustomColorTest.Size = new System.Drawing.Size(117, 13);
      this.lblHueCustomColorTest.TabIndex = 31;
      this.lblHueCustomColorTest.Text = "Custom color(HEX):";
      // 
      // btnHueSendCustomColor
      // 
      this.btnHueSendCustomColor.Location = new System.Drawing.Point(667, 250);
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
      this.cbEnableDebuglog.Location = new System.Drawing.Point(692, 590);
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
      this.lblAtmoinPresetColor.Location = new System.Drawing.Point(20, 137);
      this.lblAtmoinPresetColor.Name = "lblAtmoinPresetColor";
      this.lblAtmoinPresetColor.Size = new System.Drawing.Size(199, 13);
      this.lblAtmoinPresetColor.TabIndex = 39;
      this.lblAtmoinPresetColor.Text = "Color when atmowin disconnects: (HEX):";
      // 
      // tbAtmowinStaticColor
      // 
      this.tbAtmowinStaticColor.Location = new System.Drawing.Point(225, 134);
      this.tbAtmowinStaticColor.Name = "tbAtmowinStaticColor";
      this.tbAtmowinStaticColor.Size = new System.Drawing.Size(77, 20);
      this.tbAtmowinStaticColor.TabIndex = 40;
      // 
      // btnStopAtmowinHue
      // 
      this.btnStopAtmowinHue.Location = new System.Drawing.Point(380, 63);
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
      this.llQ42.Location = new System.Drawing.Point(98, 784);
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
      this.lCopyright.Location = new System.Drawing.Point(9, 784);
      this.lCopyright.Name = "lCopyright";
      this.lCopyright.Size = new System.Drawing.Size(92, 13);
      this.lCopyright.TabIndex = 43;
      this.lCopyright.Text = "Made possible by:";
      // 
      // gbBridgeTools
      // 
      this.gbBridgeTools.Controls.Add(this.cbRunningWindows8);
      this.gbBridgeTools.Controls.Add(this.cbAutoConnectBridge);
      this.gbBridgeTools.Controls.Add(this.btnLocateHueBridge);
      this.gbBridgeTools.Location = new System.Drawing.Point(527, 12);
      this.gbBridgeTools.Name = "gbBridgeTools";
      this.gbBridgeTools.Size = new System.Drawing.Size(275, 142);
      this.gbBridgeTools.TabIndex = 45;
      this.gbBridgeTools.TabStop = false;
      this.gbBridgeTools.Text = "Hue Bridge";
      // 
      // cbRunningWindows8
      // 
      this.cbRunningWindows8.AutoSize = true;
      this.cbRunningWindows8.Checked = global::AtmoHue.Properties.Settings.Default.hueBridgeMode;
      this.cbRunningWindows8.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AtmoHue.Properties.Settings.Default, "hueBridgeMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbRunningWindows8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbRunningWindows8.Location = new System.Drawing.Point(13, 22);
      this.cbRunningWindows8.Name = "cbRunningWindows8";
      this.cbRunningWindows8.Size = new System.Drawing.Size(159, 17);
      this.cbRunningWindows8.TabIndex = 6;
      this.cbRunningWindows8.Text = "Running Windows 8.* ?";
      this.cbRunningWindows8.UseVisualStyleBackColor = true;
      // 
      // cbAutoConnectBridge
      // 
      this.cbAutoConnectBridge.AutoSize = true;
      this.cbAutoConnectBridge.Checked = global::AtmoHue.Properties.Settings.Default.HueAutoConnectonDetection;
      this.cbAutoConnectBridge.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AtmoHue.Properties.Settings.Default, "HueAutoConnectonDetection", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbAutoConnectBridge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbAutoConnectBridge.Location = new System.Drawing.Point(13, 45);
      this.cbAutoConnectBridge.Name = "cbAutoConnectBridge";
      this.cbAutoConnectBridge.Size = new System.Drawing.Size(188, 17);
      this.cbAutoConnectBridge.TabIndex = 44;
      this.cbAutoConnectBridge.Text = "Auto connect if bridge found";
      this.cbAutoConnectBridge.UseVisualStyleBackColor = true;
      // 
      // grpAtmowin
      // 
      this.grpAtmowin.Controls.Add(this.btnStopAtmowinHue);
      this.grpAtmowin.Controls.Add(this.btnStartAtmowinHue);
      this.grpAtmowin.Controls.Add(this.tbAtmowinScanInterval);
      this.grpAtmowin.Controls.Add(this.label5);
      this.grpAtmowin.Controls.Add(this.lblAtmoinPresetColor);
      this.grpAtmowin.Controls.Add(this.tbAtmowinStaticColor);
      this.grpAtmowin.Controls.Add(this.lblAtmoWinFolder);
      this.grpAtmowin.Controls.Add(this.tbAtmowinLocation);
      this.grpAtmowin.Location = new System.Drawing.Point(263, 613);
      this.grpAtmowin.Name = "grpAtmowin";
      this.grpAtmowin.Size = new System.Drawing.Size(543, 193);
      this.grpAtmowin.TabIndex = 46;
      this.grpAtmowin.TabStop = false;
      this.grpAtmowin.Text = "Atmowin (Experimental)";
      // 
      // tbAtmowinScanInterval
      // 
      this.tbAtmowinScanInterval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "atmowinScanInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbAtmowinScanInterval.Location = new System.Drawing.Point(447, 134);
      this.tbAtmowinScanInterval.Name = "tbAtmowinScanInterval";
      this.tbAtmowinScanInterval.Size = new System.Drawing.Size(68, 20);
      this.tbAtmowinScanInterval.TabIndex = 19;
      this.tbAtmowinScanInterval.Text = global::AtmoHue.Properties.Settings.Default.atmowinScanInterval;
      // 
      // cbLogRemoteApiCalls
      // 
      this.cbLogRemoteApiCalls.AutoSize = true;
      this.cbLogRemoteApiCalls.Location = new System.Drawing.Point(561, 590);
      this.cbLogRemoteApiCalls.Name = "cbLogRemoteApiCalls";
      this.cbLogRemoteApiCalls.Size = new System.Drawing.Size(123, 17);
      this.cbLogRemoteApiCalls.TabIndex = 47;
      this.cbLogRemoteApiCalls.Text = "Log remote API calls";
      this.cbLogRemoteApiCalls.UseVisualStyleBackColor = true;
      // 
      // grpRemoteAPI
      // 
      this.grpRemoteAPI.Controls.Add(this.tbRemoteAPIsendDelay);
      this.grpRemoteAPI.Controls.Add(this.lblHintRestart);
      this.grpRemoteAPI.Controls.Add(this.lblApiScanInterval);
      this.grpRemoteAPI.Controls.Add(this.lblAPIport);
      this.grpRemoteAPI.Controls.Add(this.lblAPIip);
      this.grpRemoteAPI.Controls.Add(this.tbRemoteApiPort);
      this.grpRemoteAPI.Controls.Add(this.tbRemoteAPIip);
      this.grpRemoteAPI.Controls.Add(this.cbRemoteAPIEnabled);
      this.grpRemoteAPI.Location = new System.Drawing.Point(12, 592);
      this.grpRemoteAPI.Name = "grpRemoteAPI";
      this.grpRemoteAPI.Size = new System.Drawing.Size(245, 183);
      this.grpRemoteAPI.TabIndex = 48;
      this.grpRemoteAPI.TabStop = false;
      this.grpRemoteAPI.Text = "Remote API";
      // 
      // tbRemoteAPIsendDelay
      // 
      this.tbRemoteAPIsendDelay.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "RemoteApiSendDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbRemoteAPIsendDelay.Location = new System.Drawing.Point(127, 133);
      this.tbRemoteAPIsendDelay.Name = "tbRemoteAPIsendDelay";
      this.tbRemoteAPIsendDelay.Size = new System.Drawing.Size(68, 20);
      this.tbRemoteAPIsendDelay.TabIndex = 42;
      this.tbRemoteAPIsendDelay.Text = global::AtmoHue.Properties.Settings.Default.RemoteApiSendDelay;
      // 
      // lblHintRestart
      // 
      this.lblHintRestart.AutoSize = true;
      this.lblHintRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHintRestart.Location = new System.Drawing.Point(15, 53);
      this.lblHintRestart.Name = "lblHintRestart";
      this.lblHintRestart.Size = new System.Drawing.Size(158, 13);
      this.lblHintRestart.TabIndex = 5;
      this.lblHintRestart.Text = "* Changes requiring restart";
      // 
      // lblApiScanInterval
      // 
      this.lblApiScanInterval.AutoSize = true;
      this.lblApiScanInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblApiScanInterval.Location = new System.Drawing.Point(15, 136);
      this.lblApiScanInterval.Name = "lblApiScanInterval";
      this.lblApiScanInterval.Size = new System.Drawing.Size(95, 13);
      this.lblApiScanInterval.TabIndex = 43;
      this.lblApiScanInterval.Text = "Hue send delay";
      // 
      // lblAPIport
      // 
      this.lblAPIport.AutoSize = true;
      this.lblAPIport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAPIport.Location = new System.Drawing.Point(15, 104);
      this.lblAPIport.Name = "lblAPIport";
      this.lblAPIport.Size = new System.Drawing.Size(39, 13);
      this.lblAPIport.TabIndex = 4;
      this.lblAPIport.Text = "Port *";
      // 
      // lblAPIip
      // 
      this.lblAPIip.AutoSize = true;
      this.lblAPIip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAPIip.Location = new System.Drawing.Point(15, 78);
      this.lblAPIip.Name = "lblAPIip";
      this.lblAPIip.Size = new System.Drawing.Size(28, 13);
      this.lblAPIip.TabIndex = 3;
      this.lblAPIip.Text = "IP *";
      // 
      // tbRemoteApiPort
      // 
      this.tbRemoteApiPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "RemoteAPIport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbRemoteApiPort.Location = new System.Drawing.Point(127, 101);
      this.tbRemoteApiPort.Name = "tbRemoteApiPort";
      this.tbRemoteApiPort.Size = new System.Drawing.Size(100, 20);
      this.tbRemoteApiPort.TabIndex = 2;
      this.tbRemoteApiPort.Text = global::AtmoHue.Properties.Settings.Default.RemoteAPIport;
      // 
      // tbRemoteAPIip
      // 
      this.tbRemoteAPIip.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "remoteAPIip", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbRemoteAPIip.Location = new System.Drawing.Point(127, 75);
      this.tbRemoteAPIip.Name = "tbRemoteAPIip";
      this.tbRemoteAPIip.Size = new System.Drawing.Size(100, 20);
      this.tbRemoteAPIip.TabIndex = 1;
      this.tbRemoteAPIip.Text = global::AtmoHue.Properties.Settings.Default.remoteAPIip;
      // 
      // cbRemoteAPIEnabled
      // 
      this.cbRemoteAPIEnabled.AutoSize = true;
      this.cbRemoteAPIEnabled.Checked = global::AtmoHue.Properties.Settings.Default.RemoteApiEnabled;
      this.cbRemoteAPIEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AtmoHue.Properties.Settings.Default, "RemoteApiEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbRemoteAPIEnabled.Location = new System.Drawing.Point(6, 19);
      this.cbRemoteAPIEnabled.Name = "cbRemoteAPIEnabled";
      this.cbRemoteAPIEnabled.Size = new System.Drawing.Size(121, 17);
      this.cbRemoteAPIEnabled.TabIndex = 0;
      this.cbRemoteAPIEnabled.Text = "Enable remote API *";
      this.cbRemoteAPIEnabled.UseVisualStyleBackColor = true;
      // 
      // tbRotateTestDelay
      // 
      this.tbRotateTestDelay.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueRotateDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbRotateTestDelay.Location = new System.Drawing.Point(561, 291);
      this.tbRotateTestDelay.Name = "tbRotateTestDelay";
      this.tbRotateTestDelay.Size = new System.Drawing.Size(100, 20);
      this.tbRotateTestDelay.TabIndex = 36;
      this.tbRotateTestDelay.Text = global::AtmoHue.Properties.Settings.Default.HueRotateDelay;
      // 
      // tbHueCustomColor
      // 
      this.tbHueCustomColor.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "testCustomColorHex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueCustomColor.Location = new System.Drawing.Point(561, 252);
      this.tbHueCustomColor.Name = "tbHueCustomColor";
      this.tbHueCustomColor.Size = new System.Drawing.Size(100, 20);
      this.tbHueCustomColor.TabIndex = 32;
      this.tbHueCustomColor.Text = global::AtmoHue.Properties.Settings.Default.testCustomColorHex;
      // 
      // tbHueHue
      // 
      this.tbHueHue.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueHue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueHue.Location = new System.Drawing.Point(140, 252);
      this.tbHueHue.Name = "tbHueHue";
      this.tbHueHue.Size = new System.Drawing.Size(100, 20);
      this.tbHueHue.TabIndex = 29;
      this.tbHueHue.Text = global::AtmoHue.Properties.Settings.Default.HueHue;
      // 
      // tbHueTransitionTime
      // 
      this.tbHueTransitionTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueTransitionTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueTransitionTime.Location = new System.Drawing.Point(140, 220);
      this.tbHueTransitionTime.Name = "tbHueTransitionTime";
      this.tbHueTransitionTime.Size = new System.Drawing.Size(100, 20);
      this.tbHueTransitionTime.TabIndex = 24;
      this.tbHueTransitionTime.Text = global::AtmoHue.Properties.Settings.Default.HueTransitionTime;
      // 
      // tbHueSaturation
      // 
      this.tbHueSaturation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueSaturation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueSaturation.Location = new System.Drawing.Point(140, 192);
      this.tbHueSaturation.Name = "tbHueSaturation";
      this.tbHueSaturation.Size = new System.Drawing.Size(100, 20);
      this.tbHueSaturation.TabIndex = 23;
      this.tbHueSaturation.Text = global::AtmoHue.Properties.Settings.Default.HueSaturation;
      // 
      // cbHueBrightness
      // 
      this.cbHueBrightness.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueBrightness", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbHueBrightness.FormattingEnabled = true;
      this.cbHueBrightness.Location = new System.Drawing.Point(140, 147);
      this.cbHueBrightness.Name = "cbHueBrightness";
      this.cbHueBrightness.Size = new System.Drawing.Size(75, 21);
      this.cbHueBrightness.TabIndex = 22;
      this.cbHueBrightness.Text = global::AtmoHue.Properties.Settings.Default.HueBrightness;
      // 
      // tbHueAppKey
      // 
      this.tbHueAppKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueAppKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueAppKey.Location = new System.Drawing.Point(140, 114);
      this.tbHueAppKey.Name = "tbHueAppKey";
      this.tbHueAppKey.Size = new System.Drawing.Size(329, 20);
      this.tbHueAppKey.TabIndex = 16;
      this.tbHueAppKey.Text = global::AtmoHue.Properties.Settings.Default.HueAppKey;
      // 
      // tbHueAppName
      // 
      this.tbHueAppName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueAppName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueAppName.Location = new System.Drawing.Point(140, 86);
      this.tbHueAppName.Name = "tbHueAppName";
      this.tbHueAppName.Size = new System.Drawing.Size(173, 20);
      this.tbHueAppName.TabIndex = 15;
      this.tbHueAppName.Text = global::AtmoHue.Properties.Settings.Default.HueAppName;
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
      this.cbOutputHueDevicesRange.Location = new System.Drawing.Point(140, 54);
      this.cbOutputHueDevicesRange.Name = "cbOutputHueDevicesRange";
      this.cbOutputHueDevicesRange.Size = new System.Drawing.Size(121, 21);
      this.cbOutputHueDevicesRange.TabIndex = 7;
      this.cbOutputHueDevicesRange.Text = global::AtmoHue.Properties.Settings.Default.hueLightsActive;
      // 
      // tbAtmowinLocation
      // 
      this.tbAtmowinLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "atmowinLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbAtmowinLocation.Location = new System.Drawing.Point(147, 13);
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
      // btnRefreshSettings
      // 
      this.btnRefreshSettings.Location = new System.Drawing.Point(381, 19);
      this.btnRefreshSettings.Name = "btnRefreshSettings";
      this.btnRefreshSettings.Size = new System.Drawing.Size(140, 45);
      this.btnRefreshSettings.TabIndex = 49;
      this.btnRefreshSettings.Text = "Refresh settings";
      this.btnRefreshSettings.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(818, 818);
      this.Controls.Add(this.btnRefreshSettings);
      this.Controls.Add(this.grpRemoteAPI);
      this.Controls.Add(this.cbLogRemoteApiCalls);
      this.Controls.Add(this.grpAtmowin);
      this.Controls.Add(this.gbBridgeTools);
      this.Controls.Add(this.lCopyright);
      this.Controls.Add(this.llQ42);
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
      this.Controls.Add(this.tbHueBridgeIP);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "Atmo Hue";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.gbBridgeTools.ResumeLayout(false);
      this.gbBridgeTools.PerformLayout();
      this.grpAtmowin.ResumeLayout(false);
      this.grpAtmowin.PerformLayout();
      this.grpRemoteAPI.ResumeLayout(false);
      this.grpRemoteAPI.PerformLayout();
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
        private System.Windows.Forms.CheckBox cbAutoConnectBridge;
        private System.Windows.Forms.GroupBox gbBridgeTools;
        private System.Windows.Forms.GroupBox grpAtmowin;
        private System.Windows.Forms.CheckBox cbLogRemoteApiCalls;
        private System.Windows.Forms.GroupBox grpRemoteAPI;
        private System.Windows.Forms.TextBox tbRemoteApiPort;
        private System.Windows.Forms.TextBox tbRemoteAPIip;
        private System.Windows.Forms.CheckBox cbRemoteAPIEnabled;
        private System.Windows.Forms.Label lblAPIport;
        private System.Windows.Forms.Label lblAPIip;
        private System.Windows.Forms.Label lblHintRestart;
        private System.Windows.Forms.TextBox tbRemoteAPIsendDelay;
        private System.Windows.Forms.Label lblApiScanInterval;
        private System.Windows.Forms.Button btnRefreshSettings;
    }
}

