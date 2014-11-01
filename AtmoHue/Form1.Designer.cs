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
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lbOutputlog = new System.Windows.Forms.ListBox();
      this.btnStartAtmowinHue = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.lblBrightness = new System.Windows.Forms.Label();
      this.lblHueSaturation = new System.Windows.Forms.Label();
      this.lblHueTransTime = new System.Windows.Forms.Label();
      this.lblHueHue = new System.Windows.Forms.Label();
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
      this.grpAtmowin = new System.Windows.Forms.GroupBox();
      this.cbLogRemoteApiCalls = new System.Windows.Forms.CheckBox();
      this.grpRemoteAPI = new System.Windows.Forms.GroupBox();
      this.lblHintRestart = new System.Windows.Forms.Label();
      this.lblApiScanInterval = new System.Windows.Forms.Label();
      this.lblAPIport = new System.Windows.Forms.Label();
      this.lblAPIip = new System.Windows.Forms.Label();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPageGeneral = new System.Windows.Forms.TabPage();
      this.lblHueColorTemperature = new System.Windows.Forms.Label();
      this.tabPageTesting = new System.Windows.Forms.TabPage();
      this.label2 = new System.Windows.Forms.Label();
      this.btnTestRed = new System.Windows.Forms.Button();
      this.btnTestGreen = new System.Windows.Forms.Button();
      this.btnTestBlue = new System.Windows.Forms.Button();
      this.btnHueColorClear = new System.Windows.Forms.Button();
      this.btnRefreshSettings = new System.Windows.Forms.Button();
      this.tabPageExperimental = new System.Windows.Forms.TabPage();
      this.gbColorCalibration = new System.Windows.Forms.GroupBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.label12 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.tbHueColorTemperature = new System.Windows.Forms.TextBox();
      this.cbRunningWindows8 = new System.Windows.Forms.CheckBox();
      this.cbAutoConnectBridge = new System.Windows.Forms.CheckBox();
      this.tbRemoteAPIsendDelay = new System.Windows.Forms.TextBox();
      this.tbRemoteApiPort = new System.Windows.Forms.TextBox();
      this.tbRemoteAPIip = new System.Windows.Forms.TextBox();
      this.cbRemoteAPIEnabled = new System.Windows.Forms.CheckBox();
      this.tbHueBridgeIP = new System.Windows.Forms.TextBox();
      this.cbOutputHueDevicesRange = new System.Windows.Forms.ComboBox();
      this.tbHueAppName = new System.Windows.Forms.TextBox();
      this.tbHueAppKey = new System.Windows.Forms.TextBox();
      this.cbHueBrightness = new System.Windows.Forms.ComboBox();
      this.tbHueSaturation = new System.Windows.Forms.TextBox();
      this.tbHueTransitionTime = new System.Windows.Forms.TextBox();
      this.tbHueHue = new System.Windows.Forms.TextBox();
      this.tbHueCustomColor = new System.Windows.Forms.TextBox();
      this.tbRotateTestDelay = new System.Windows.Forms.TextBox();
      this.tbZBlue = new System.Windows.Forms.TextBox();
      this.tbZGreen = new System.Windows.Forms.TextBox();
      this.tbZRed = new System.Windows.Forms.TextBox();
      this.tbYBlue = new System.Windows.Forms.TextBox();
      this.tbYGreen = new System.Windows.Forms.TextBox();
      this.tbYRed = new System.Windows.Forms.TextBox();
      this.tbXBlue = new System.Windows.Forms.TextBox();
      this.tbXGreen = new System.Windows.Forms.TextBox();
      this.tbXRed = new System.Windows.Forms.TextBox();
      this.tbAtmowinScanInterval = new System.Windows.Forms.TextBox();
      this.tbAtmowinLocation = new System.Windows.Forms.TextBox();
      this.gbBridgeTools.SuspendLayout();
      this.grpAtmowin.SuspendLayout();
      this.grpRemoteAPI.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPageGeneral.SuspendLayout();
      this.tabPageTesting.SuspendLayout();
      this.tabPageExperimental.SuspendLayout();
      this.gbColorCalibration.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnLocateHueBridge
      // 
      this.btnLocateHueBridge.Location = new System.Drawing.Point(13, 69);
      this.btnLocateHueBridge.Name = "btnLocateHueBridge";
      this.btnLocateHueBridge.Size = new System.Drawing.Size(281, 67);
      this.btnLocateHueBridge.TabIndex = 1;
      this.btnLocateHueBridge.Text = "Locate and register to Hue Bridge";
      this.btnLocateHueBridge.UseVisualStyleBackColor = true;
      this.btnLocateHueBridge.Click += new System.EventHandler(this.btnLocateHueBridge_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(20, 19);
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
      this.lblOutputHueDevices.Location = new System.Drawing.Point(20, 63);
      this.lblOutputHueDevices.Name = "lblOutputHueDevices";
      this.lblOutputHueDevices.Size = new System.Drawing.Size(92, 13);
      this.lblOutputHueDevices.TabIndex = 8;
      this.lblOutputHueDevices.Text = "Hue Lights use";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(20, 95);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(89, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Hue app name";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(20, 123);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 13);
      this.label4.TabIndex = 14;
      this.label4.Text = "Hue app key";
      // 
      // lbOutputlog
      // 
      this.lbOutputlog.FormattingEnabled = true;
      this.lbOutputlog.Location = new System.Drawing.Point(6, 357);
      this.lbOutputlog.Name = "lbOutputlog";
      this.lbOutputlog.Size = new System.Drawing.Size(778, 264);
      this.lbOutputlog.TabIndex = 17;
      // 
      // btnStartAtmowinHue
      // 
      this.btnStartAtmowinHue.Location = new System.Drawing.Point(622, 50);
      this.btnStartAtmowinHue.Name = "btnStartAtmowinHue";
      this.btnStartAtmowinHue.Size = new System.Drawing.Size(135, 71);
      this.btnStartAtmowinHue.TabIndex = 18;
      this.btnStartAtmowinHue.Text = "Start monitoring Atmowin";
      this.btnStartAtmowinHue.UseVisualStyleBackColor = true;
      this.btnStartAtmowinHue.Click += new System.EventHandler(this.btnStartAtmowinHue_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(20, 53);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(91, 13);
      this.label5.TabIndex = 20;
      this.label5.Text = "Scan interval (ms)";
      // 
      // lblBrightness
      // 
      this.lblBrightness.AutoSize = true;
      this.lblBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblBrightness.Location = new System.Drawing.Point(20, 163);
      this.lblBrightness.Name = "lblBrightness";
      this.lblBrightness.Size = new System.Drawing.Size(87, 13);
      this.lblBrightness.TabIndex = 21;
      this.lblBrightness.Text = "Brightness (%)";
      // 
      // lblHueSaturation
      // 
      this.lblHueSaturation.AutoSize = true;
      this.lblHueSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueSaturation.Location = new System.Drawing.Point(20, 200);
      this.lblHueSaturation.Name = "lblHueSaturation";
      this.lblHueSaturation.Size = new System.Drawing.Size(65, 13);
      this.lblHueSaturation.TabIndex = 25;
      this.lblHueSaturation.Text = "Saturation";
      // 
      // lblHueTransTime
      // 
      this.lblHueTransTime.AutoSize = true;
      this.lblHueTransTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueTransTime.Location = new System.Drawing.Point(20, 228);
      this.lblHueTransTime.Name = "lblHueTransTime";
      this.lblHueTransTime.Size = new System.Drawing.Size(117, 13);
      this.lblHueTransTime.TabIndex = 26;
      this.lblHueTransTime.Text = "Transition time (ms)";
      // 
      // lblHueHue
      // 
      this.lblHueHue.AutoSize = true;
      this.lblHueHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueHue.Location = new System.Drawing.Point(20, 295);
      this.lblHueHue.Name = "lblHueHue";
      this.lblHueHue.Size = new System.Drawing.Size(30, 13);
      this.lblHueHue.TabIndex = 28;
      this.lblHueHue.Text = "Hue";
      // 
      // lblHueCustomColorTest
      // 
      this.lblHueCustomColorTest.AutoSize = true;
      this.lblHueCustomColorTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueCustomColorTest.Location = new System.Drawing.Point(12, 118);
      this.lblHueCustomColorTest.Name = "lblHueCustomColorTest";
      this.lblHueCustomColorTest.Size = new System.Drawing.Size(117, 13);
      this.lblHueCustomColorTest.TabIndex = 31;
      this.lblHueCustomColorTest.Text = "Custom color(HEX):";
      // 
      // btnHueSendCustomColor
      // 
      this.btnHueSendCustomColor.Location = new System.Drawing.Point(274, 113);
      this.btnHueSendCustomColor.Name = "btnHueSendCustomColor";
      this.btnHueSendCustomColor.Size = new System.Drawing.Size(64, 23);
      this.btnHueSendCustomColor.TabIndex = 33;
      this.btnHueSendCustomColor.Text = "Test";
      this.btnHueSendCustomColor.UseVisualStyleBackColor = true;
      this.btnHueSendCustomColor.Click += new System.EventHandler(this.btnHueSendCustomColor_Click);
      // 
      // btnHueColorRotateTestStart
      // 
      this.btnHueColorRotateTestStart.Location = new System.Drawing.Point(274, 181);
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
      this.label6.Location = new System.Drawing.Point(12, 186);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(153, 13);
      this.label6.TabIndex = 35;
      this.label6.Text = "Rotate R/G/B every (ms):";
      // 
      // btnHueColorRotateTestStop
      // 
      this.btnHueColorRotateTestStop.Location = new System.Drawing.Point(333, 181);
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
      this.cbEnableDebuglog.Location = new System.Drawing.Point(138, 334);
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
      this.lblAtmoinPresetColor.Location = new System.Drawing.Point(20, 88);
      this.lblAtmoinPresetColor.Name = "lblAtmoinPresetColor";
      this.lblAtmoinPresetColor.Size = new System.Drawing.Size(199, 13);
      this.lblAtmoinPresetColor.TabIndex = 39;
      this.lblAtmoinPresetColor.Text = "Color when atmowin disconnects: (HEX):";
      // 
      // tbAtmowinStaticColor
      // 
      this.tbAtmowinStaticColor.Location = new System.Drawing.Point(225, 85);
      this.tbAtmowinStaticColor.Name = "tbAtmowinStaticColor";
      this.tbAtmowinStaticColor.Size = new System.Drawing.Size(77, 20);
      this.tbAtmowinStaticColor.TabIndex = 40;
      // 
      // btnStopAtmowinHue
      // 
      this.btnStopAtmowinHue.Location = new System.Drawing.Point(622, 154);
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
      this.llQ42.Location = new System.Drawing.Point(743, 668);
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
      this.lCopyright.Location = new System.Drawing.Point(654, 668);
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
      this.gbBridgeTools.Location = new System.Drawing.Point(458, 14);
      this.gbBridgeTools.Name = "gbBridgeTools";
      this.gbBridgeTools.Size = new System.Drawing.Size(311, 142);
      this.gbBridgeTools.TabIndex = 45;
      this.gbBridgeTools.TabStop = false;
      this.gbBridgeTools.Text = "Hue Bridge";
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
      this.grpAtmowin.Location = new System.Drawing.Point(3, 18);
      this.grpAtmowin.Name = "grpAtmowin";
      this.grpAtmowin.Size = new System.Drawing.Size(774, 193);
      this.grpAtmowin.TabIndex = 46;
      this.grpAtmowin.TabStop = false;
      this.grpAtmowin.Text = "Atmowin monitoring";
      // 
      // cbLogRemoteApiCalls
      // 
      this.cbLogRemoteApiCalls.AutoSize = true;
      this.cbLogRemoteApiCalls.Location = new System.Drawing.Point(7, 334);
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
      this.grpRemoteAPI.Location = new System.Drawing.Point(458, 163);
      this.grpRemoteAPI.Name = "grpRemoteAPI";
      this.grpRemoteAPI.Size = new System.Drawing.Size(311, 183);
      this.grpRemoteAPI.TabIndex = 48;
      this.grpRemoteAPI.TabStop = false;
      this.grpRemoteAPI.Text = "Remote API";
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
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPageGeneral);
      this.tabControl1.Controls.Add(this.tabPageTesting);
      this.tabControl1.Controls.Add(this.tabPageExperimental);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(798, 653);
      this.tabControl1.TabIndex = 50;
      // 
      // tabPageGeneral
      // 
      this.tabPageGeneral.BackColor = System.Drawing.SystemColors.Control;
      this.tabPageGeneral.Controls.Add(this.tbHueColorTemperature);
      this.tabPageGeneral.Controls.Add(this.lblHueColorTemperature);
      this.tabPageGeneral.Controls.Add(this.gbBridgeTools);
      this.tabPageGeneral.Controls.Add(this.label1);
      this.tabPageGeneral.Controls.Add(this.cbLogRemoteApiCalls);
      this.tabPageGeneral.Controls.Add(this.grpRemoteAPI);
      this.tabPageGeneral.Controls.Add(this.tbHueBridgeIP);
      this.tabPageGeneral.Controls.Add(this.cbOutputHueDevicesRange);
      this.tabPageGeneral.Controls.Add(this.cbEnableDebuglog);
      this.tabPageGeneral.Controls.Add(this.lblOutputHueDevices);
      this.tabPageGeneral.Controls.Add(this.label3);
      this.tabPageGeneral.Controls.Add(this.label4);
      this.tabPageGeneral.Controls.Add(this.tbHueAppName);
      this.tabPageGeneral.Controls.Add(this.tbHueAppKey);
      this.tabPageGeneral.Controls.Add(this.lbOutputlog);
      this.tabPageGeneral.Controls.Add(this.lblBrightness);
      this.tabPageGeneral.Controls.Add(this.cbHueBrightness);
      this.tabPageGeneral.Controls.Add(this.tbHueSaturation);
      this.tabPageGeneral.Controls.Add(this.tbHueTransitionTime);
      this.tabPageGeneral.Controls.Add(this.lblHueSaturation);
      this.tabPageGeneral.Controls.Add(this.lblHueTransTime);
      this.tabPageGeneral.Controls.Add(this.tbHueHue);
      this.tabPageGeneral.Controls.Add(this.lblHueHue);
      this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
      this.tabPageGeneral.Name = "tabPageGeneral";
      this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageGeneral.Size = new System.Drawing.Size(790, 627);
      this.tabPageGeneral.TabIndex = 0;
      this.tabPageGeneral.Text = "General";
      // 
      // lblHueColorTemperature
      // 
      this.lblHueColorTemperature.AutoSize = true;
      this.lblHueColorTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueColorTemperature.Location = new System.Drawing.Point(20, 264);
      this.lblHueColorTemperature.Name = "lblHueColorTemperature";
      this.lblHueColorTemperature.Size = new System.Drawing.Size(107, 13);
      this.lblHueColorTemperature.TabIndex = 50;
      this.lblHueColorTemperature.Text = "Color temperature";
      // 
      // tabPageTesting
      // 
      this.tabPageTesting.BackColor = System.Drawing.SystemColors.Control;
      this.tabPageTesting.Controls.Add(this.label2);
      this.tabPageTesting.Controls.Add(this.btnTestRed);
      this.tabPageTesting.Controls.Add(this.btnTestGreen);
      this.tabPageTesting.Controls.Add(this.btnTestBlue);
      this.tabPageTesting.Controls.Add(this.btnHueColorClear);
      this.tabPageTesting.Controls.Add(this.btnRefreshSettings);
      this.tabPageTesting.Controls.Add(this.lblHueCustomColorTest);
      this.tabPageTesting.Controls.Add(this.btnHueSendCustomColor);
      this.tabPageTesting.Controls.Add(this.btnHueColorRotateTestStop);
      this.tabPageTesting.Controls.Add(this.btnHueColorRotateTestStart);
      this.tabPageTesting.Controls.Add(this.label6);
      this.tabPageTesting.Controls.Add(this.tbHueCustomColor);
      this.tabPageTesting.Controls.Add(this.tbRotateTestDelay);
      this.tabPageTesting.Location = new System.Drawing.Point(4, 22);
      this.tabPageTesting.Name = "tabPageTesting";
      this.tabPageTesting.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageTesting.Size = new System.Drawing.Size(790, 627);
      this.tabPageTesting.TabIndex = 1;
      this.tabPageTesting.Text = "Testing";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(19, 34);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 13);
      this.label2.TabIndex = 68;
      this.label2.Text = "Color test:";
      // 
      // btnTestRed
      // 
      this.btnTestRed.Location = new System.Drawing.Point(90, 29);
      this.btnTestRed.Name = "btnTestRed";
      this.btnTestRed.Size = new System.Drawing.Size(75, 23);
      this.btnTestRed.TabIndex = 65;
      this.btnTestRed.Text = "RED";
      this.btnTestRed.UseVisualStyleBackColor = true;
      this.btnTestRed.Click += new System.EventHandler(this.btnTestRed_Click);
      // 
      // btnTestGreen
      // 
      this.btnTestGreen.Location = new System.Drawing.Point(171, 29);
      this.btnTestGreen.Name = "btnTestGreen";
      this.btnTestGreen.Size = new System.Drawing.Size(75, 23);
      this.btnTestGreen.TabIndex = 66;
      this.btnTestGreen.Text = "GREEN";
      this.btnTestGreen.UseVisualStyleBackColor = true;
      this.btnTestGreen.Click += new System.EventHandler(this.btnTestGreen_Click);
      // 
      // btnTestBlue
      // 
      this.btnTestBlue.Location = new System.Drawing.Point(252, 29);
      this.btnTestBlue.Name = "btnTestBlue";
      this.btnTestBlue.Size = new System.Drawing.Size(75, 23);
      this.btnTestBlue.TabIndex = 67;
      this.btnTestBlue.Text = "BLUE";
      this.btnTestBlue.UseVisualStyleBackColor = true;
      this.btnTestBlue.Click += new System.EventHandler(this.btnTestBlue_Click);
      // 
      // btnHueColorClear
      // 
      this.btnHueColorClear.Location = new System.Drawing.Point(348, 29);
      this.btnHueColorClear.Name = "btnHueColorClear";
      this.btnHueColorClear.Size = new System.Drawing.Size(92, 23);
      this.btnHueColorClear.TabIndex = 69;
      this.btnHueColorClear.Text = "CLEAR/RESET";
      this.btnHueColorClear.UseVisualStyleBackColor = true;
      this.btnHueColorClear.Click += new System.EventHandler(this.btnHueColorClear_Click);
      // 
      // btnRefreshSettings
      // 
      this.btnRefreshSettings.Location = new System.Drawing.Point(15, 242);
      this.btnRefreshSettings.Name = "btnRefreshSettings";
      this.btnRefreshSettings.Size = new System.Drawing.Size(112, 45);
      this.btnRefreshSettings.TabIndex = 50;
      this.btnRefreshSettings.Text = "Refresh settings";
      this.btnRefreshSettings.UseVisualStyleBackColor = true;
      // 
      // tabPageExperimental
      // 
      this.tabPageExperimental.BackColor = System.Drawing.SystemColors.Control;
      this.tabPageExperimental.Controls.Add(this.gbColorCalibration);
      this.tabPageExperimental.Controls.Add(this.grpAtmowin);
      this.tabPageExperimental.Location = new System.Drawing.Point(4, 22);
      this.tabPageExperimental.Name = "tabPageExperimental";
      this.tabPageExperimental.Size = new System.Drawing.Size(790, 627);
      this.tabPageExperimental.TabIndex = 2;
      this.tabPageExperimental.Text = "Experimental";
      // 
      // gbColorCalibration
      // 
      this.gbColorCalibration.Controls.Add(this.label20);
      this.gbColorCalibration.Controls.Add(this.label19);
      this.gbColorCalibration.Controls.Add(this.label18);
      this.gbColorCalibration.Controls.Add(this.label17);
      this.gbColorCalibration.Controls.Add(this.label16);
      this.gbColorCalibration.Controls.Add(this.label15);
      this.gbColorCalibration.Controls.Add(this.label14);
      this.gbColorCalibration.Controls.Add(this.label13);
      this.gbColorCalibration.Controls.Add(this.label12);
      this.gbColorCalibration.Controls.Add(this.label11);
      this.gbColorCalibration.Controls.Add(this.button1);
      this.gbColorCalibration.Controls.Add(this.button2);
      this.gbColorCalibration.Controls.Add(this.button3);
      this.gbColorCalibration.Controls.Add(this.button4);
      this.gbColorCalibration.Controls.Add(this.tbZBlue);
      this.gbColorCalibration.Controls.Add(this.tbZGreen);
      this.gbColorCalibration.Controls.Add(this.tbZRed);
      this.gbColorCalibration.Controls.Add(this.tbYBlue);
      this.gbColorCalibration.Controls.Add(this.tbYGreen);
      this.gbColorCalibration.Controls.Add(this.tbYRed);
      this.gbColorCalibration.Controls.Add(this.tbXBlue);
      this.gbColorCalibration.Controls.Add(this.tbXGreen);
      this.gbColorCalibration.Controls.Add(this.tbXRed);
      this.gbColorCalibration.Controls.Add(this.label10);
      this.gbColorCalibration.Controls.Add(this.label9);
      this.gbColorCalibration.Controls.Add(this.label8);
      this.gbColorCalibration.Controls.Add(this.label7);
      this.gbColorCalibration.Location = new System.Drawing.Point(4, 248);
      this.gbColorCalibration.Name = "gbColorCalibration";
      this.gbColorCalibration.Size = new System.Drawing.Size(756, 342);
      this.gbColorCalibration.TabIndex = 48;
      this.gbColorCalibration.TabStop = false;
      this.gbColorCalibration.Text = "Color Calibrations";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(10, 197);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(89, 13);
      this.label10.TabIndex = 50;
      this.label10.Text = "Z (BLUE TOTAL)";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(10, 158);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(99, 13);
      this.label9.TabIndex = 49;
      this.label9.Text = "Y (GREEN TOTAL)";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(10, 117);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(84, 13);
      this.label8.TabIndex = 48;
      this.label8.Text = "X (RED TOTAL)";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(476, 16);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(274, 65);
      this.label7.TabIndex = 47;
      this.label7.Text = "Defaults:\r\n\r\nX = Red 0.649926 / Green  0.103455 / Blue  0.197109\r\nY = Red 0.23432" +
    "7 / Green  0.743075 / Blue  0.022598\r\nZ = Red 0.0000000 / Green  0.053077 / Blue" +
    "  1.035763\r\n";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label11.Location = new System.Drawing.Point(14, 267);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(65, 13);
      this.label11.TabIndex = 68;
      this.label11.Text = "Color test:";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(102, 253);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 40);
      this.button1.TabIndex = 65;
      this.button1.Text = "RED";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.btnTestRed_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(189, 253);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 40);
      this.button2.TabIndex = 66;
      this.button2.Text = "GREEN";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.btnTestGreen_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(273, 253);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(75, 40);
      this.button3.TabIndex = 67;
      this.button3.Text = "BLUE";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.btnTestBlue_Click);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(387, 262);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(92, 23);
      this.button4.TabIndex = 69;
      this.button4.Text = "CLEAR/RESET";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.btnHueColorClear_Click);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label12.Location = new System.Drawing.Point(129, 117);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(16, 13);
      this.label12.TabIndex = 70;
      this.label12.Text = "R";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(129, 158);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(16, 13);
      this.label13.TabIndex = 71;
      this.label13.Text = "R";
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.Location = new System.Drawing.Point(129, 197);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(16, 13);
      this.label14.TabIndex = 72;
      this.label14.Text = "R";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label15.Location = new System.Drawing.Point(226, 117);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(16, 13);
      this.label15.TabIndex = 73;
      this.label15.Text = "G";
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label16.Location = new System.Drawing.Point(226, 158);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(16, 13);
      this.label16.TabIndex = 74;
      this.label16.Text = "G";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label17.Location = new System.Drawing.Point(226, 197);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(16, 13);
      this.label17.TabIndex = 75;
      this.label17.Text = "G";
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label18.Location = new System.Drawing.Point(328, 117);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(15, 13);
      this.label18.TabIndex = 76;
      this.label18.Text = "B";
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label19.Location = new System.Drawing.Point(328, 158);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(15, 13);
      this.label19.TabIndex = 77;
      this.label19.Text = "B";
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label20.Location = new System.Drawing.Point(328, 197);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(15, 13);
      this.label20.TabIndex = 78;
      this.label20.Text = "B";
      // 
      // tbHueColorTemperature
      // 
      this.tbHueColorTemperature.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueColorTemperature", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueColorTemperature.Location = new System.Drawing.Point(153, 261);
      this.tbHueColorTemperature.Name = "tbHueColorTemperature";
      this.tbHueColorTemperature.Size = new System.Drawing.Size(100, 20);
      this.tbHueColorTemperature.TabIndex = 49;
      this.tbHueColorTemperature.Text = global::AtmoHue.Properties.Settings.Default.HueColorTemperature;
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
      // tbRemoteAPIsendDelay
      // 
      this.tbRemoteAPIsendDelay.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "RemoteApiSendDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbRemoteAPIsendDelay.Location = new System.Drawing.Point(127, 133);
      this.tbRemoteAPIsendDelay.Name = "tbRemoteAPIsendDelay";
      this.tbRemoteAPIsendDelay.Size = new System.Drawing.Size(68, 20);
      this.tbRemoteAPIsendDelay.TabIndex = 42;
      this.tbRemoteAPIsendDelay.Text = global::AtmoHue.Properties.Settings.Default.RemoteApiSendDelay;
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
      // tbHueBridgeIP
      // 
      this.tbHueBridgeIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "hueBridgeIP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueBridgeIP.Location = new System.Drawing.Point(153, 16);
      this.tbHueBridgeIP.Name = "tbHueBridgeIP";
      this.tbHueBridgeIP.Size = new System.Drawing.Size(100, 20);
      this.tbHueBridgeIP.TabIndex = 4;
      this.tbHueBridgeIP.Text = global::AtmoHue.Properties.Settings.Default.hueBridgeIP;
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
      this.cbOutputHueDevicesRange.Location = new System.Drawing.Point(153, 60);
      this.cbOutputHueDevicesRange.Name = "cbOutputHueDevicesRange";
      this.cbOutputHueDevicesRange.Size = new System.Drawing.Size(121, 21);
      this.cbOutputHueDevicesRange.TabIndex = 7;
      this.cbOutputHueDevicesRange.Text = global::AtmoHue.Properties.Settings.Default.hueLightsActive;
      // 
      // tbHueAppName
      // 
      this.tbHueAppName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueAppName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueAppName.Location = new System.Drawing.Point(153, 92);
      this.tbHueAppName.Name = "tbHueAppName";
      this.tbHueAppName.Size = new System.Drawing.Size(173, 20);
      this.tbHueAppName.TabIndex = 15;
      this.tbHueAppName.Text = global::AtmoHue.Properties.Settings.Default.HueAppName;
      // 
      // tbHueAppKey
      // 
      this.tbHueAppKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueAppKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueAppKey.Location = new System.Drawing.Point(153, 120);
      this.tbHueAppKey.Name = "tbHueAppKey";
      this.tbHueAppKey.Size = new System.Drawing.Size(223, 20);
      this.tbHueAppKey.TabIndex = 16;
      this.tbHueAppKey.Text = global::AtmoHue.Properties.Settings.Default.HueAppKey;
      // 
      // cbHueBrightness
      // 
      this.cbHueBrightness.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueBrightness", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbHueBrightness.FormattingEnabled = true;
      this.cbHueBrightness.Location = new System.Drawing.Point(153, 160);
      this.cbHueBrightness.Name = "cbHueBrightness";
      this.cbHueBrightness.Size = new System.Drawing.Size(75, 21);
      this.cbHueBrightness.TabIndex = 22;
      this.cbHueBrightness.Text = global::AtmoHue.Properties.Settings.Default.HueBrightness;
      // 
      // tbHueSaturation
      // 
      this.tbHueSaturation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueSaturation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueSaturation.Location = new System.Drawing.Point(153, 197);
      this.tbHueSaturation.Name = "tbHueSaturation";
      this.tbHueSaturation.Size = new System.Drawing.Size(100, 20);
      this.tbHueSaturation.TabIndex = 23;
      this.tbHueSaturation.Text = global::AtmoHue.Properties.Settings.Default.HueSaturation;
      // 
      // tbHueTransitionTime
      // 
      this.tbHueTransitionTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueTransitionTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueTransitionTime.Location = new System.Drawing.Point(153, 225);
      this.tbHueTransitionTime.Name = "tbHueTransitionTime";
      this.tbHueTransitionTime.Size = new System.Drawing.Size(100, 20);
      this.tbHueTransitionTime.TabIndex = 24;
      this.tbHueTransitionTime.Text = global::AtmoHue.Properties.Settings.Default.HueTransitionTime;
      // 
      // tbHueHue
      // 
      this.tbHueHue.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueHue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueHue.Location = new System.Drawing.Point(153, 292);
      this.tbHueHue.Name = "tbHueHue";
      this.tbHueHue.Size = new System.Drawing.Size(100, 20);
      this.tbHueHue.TabIndex = 29;
      this.tbHueHue.Text = global::AtmoHue.Properties.Settings.Default.HueHue;
      // 
      // tbHueCustomColor
      // 
      this.tbHueCustomColor.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "testCustomColorHex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbHueCustomColor.Location = new System.Drawing.Point(168, 115);
      this.tbHueCustomColor.Name = "tbHueCustomColor";
      this.tbHueCustomColor.Size = new System.Drawing.Size(100, 20);
      this.tbHueCustomColor.TabIndex = 32;
      this.tbHueCustomColor.Text = global::AtmoHue.Properties.Settings.Default.testCustomColorHex;
      // 
      // tbRotateTestDelay
      // 
      this.tbRotateTestDelay.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueRotateDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbRotateTestDelay.Location = new System.Drawing.Point(168, 183);
      this.tbRotateTestDelay.Name = "tbRotateTestDelay";
      this.tbRotateTestDelay.Size = new System.Drawing.Size(100, 20);
      this.tbRotateTestDelay.TabIndex = 36;
      this.tbRotateTestDelay.Text = global::AtmoHue.Properties.Settings.Default.HueRotateDelay;
      // 
      // tbZBlue
      // 
      this.tbZBlue.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "ZBlue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbZBlue.Location = new System.Drawing.Point(346, 194);
      this.tbZBlue.Name = "tbZBlue";
      this.tbZBlue.Size = new System.Drawing.Size(74, 20);
      this.tbZBlue.TabIndex = 59;
      this.tbZBlue.Text = global::AtmoHue.Properties.Settings.Default.ZBlue;
      // 
      // tbZGreen
      // 
      this.tbZGreen.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "ZGreen", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbZGreen.Location = new System.Drawing.Point(243, 194);
      this.tbZGreen.Name = "tbZGreen";
      this.tbZGreen.Size = new System.Drawing.Size(74, 20);
      this.tbZGreen.TabIndex = 58;
      this.tbZGreen.Text = global::AtmoHue.Properties.Settings.Default.ZGreen;
      // 
      // tbZRed
      // 
      this.tbZRed.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "ZRed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbZRed.Location = new System.Drawing.Point(148, 194);
      this.tbZRed.Name = "tbZRed";
      this.tbZRed.Size = new System.Drawing.Size(74, 20);
      this.tbZRed.TabIndex = 57;
      this.tbZRed.Text = global::AtmoHue.Properties.Settings.Default.ZRed;
      // 
      // tbYBlue
      // 
      this.tbYBlue.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "YBlue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbYBlue.Location = new System.Drawing.Point(346, 155);
      this.tbYBlue.Name = "tbYBlue";
      this.tbYBlue.Size = new System.Drawing.Size(74, 20);
      this.tbYBlue.TabIndex = 56;
      this.tbYBlue.Text = global::AtmoHue.Properties.Settings.Default.YBlue;
      // 
      // tbYGreen
      // 
      this.tbYGreen.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "YGreen", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbYGreen.Location = new System.Drawing.Point(243, 155);
      this.tbYGreen.Name = "tbYGreen";
      this.tbYGreen.Size = new System.Drawing.Size(74, 20);
      this.tbYGreen.TabIndex = 55;
      this.tbYGreen.Text = global::AtmoHue.Properties.Settings.Default.YGreen;
      // 
      // tbYRed
      // 
      this.tbYRed.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "YRed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbYRed.Location = new System.Drawing.Point(148, 155);
      this.tbYRed.Name = "tbYRed";
      this.tbYRed.Size = new System.Drawing.Size(74, 20);
      this.tbYRed.TabIndex = 54;
      this.tbYRed.Text = global::AtmoHue.Properties.Settings.Default.YRed;
      // 
      // tbXBlue
      // 
      this.tbXBlue.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "XBlue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbXBlue.Location = new System.Drawing.Point(346, 114);
      this.tbXBlue.Name = "tbXBlue";
      this.tbXBlue.Size = new System.Drawing.Size(74, 20);
      this.tbXBlue.TabIndex = 53;
      this.tbXBlue.Text = global::AtmoHue.Properties.Settings.Default.XBlue;
      // 
      // tbXGreen
      // 
      this.tbXGreen.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "XGreen", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbXGreen.Location = new System.Drawing.Point(243, 114);
      this.tbXGreen.Name = "tbXGreen";
      this.tbXGreen.Size = new System.Drawing.Size(74, 20);
      this.tbXGreen.TabIndex = 52;
      this.tbXGreen.Text = global::AtmoHue.Properties.Settings.Default.XGreen;
      // 
      // tbXRed
      // 
      this.tbXRed.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "XRed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbXRed.Location = new System.Drawing.Point(148, 114);
      this.tbXRed.Name = "tbXRed";
      this.tbXRed.Size = new System.Drawing.Size(74, 20);
      this.tbXRed.TabIndex = 51;
      this.tbXRed.Text = global::AtmoHue.Properties.Settings.Default.XRed;
      // 
      // tbAtmowinScanInterval
      // 
      this.tbAtmowinScanInterval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "atmowinScanInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbAtmowinScanInterval.Location = new System.Drawing.Point(225, 50);
      this.tbAtmowinScanInterval.Name = "tbAtmowinScanInterval";
      this.tbAtmowinScanInterval.Size = new System.Drawing.Size(68, 20);
      this.tbAtmowinScanInterval.TabIndex = 19;
      this.tbAtmowinScanInterval.Text = global::AtmoHue.Properties.Settings.Default.atmowinScanInterval;
      // 
      // tbAtmowinLocation
      // 
      this.tbAtmowinLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "atmowinLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbAtmowinLocation.Location = new System.Drawing.Point(147, 13);
      this.tbAtmowinLocation.Name = "tbAtmowinLocation";
      this.tbAtmowinLocation.Size = new System.Drawing.Size(442, 20);
      this.tbAtmowinLocation.TabIndex = 5;
      this.tbAtmowinLocation.Text = global::AtmoHue.Properties.Settings.Default.atmowinLocation;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(816, 687);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.lCopyright);
      this.Controls.Add(this.llQ42);
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
      this.tabControl1.ResumeLayout(false);
      this.tabPageGeneral.ResumeLayout(false);
      this.tabPageGeneral.PerformLayout();
      this.tabPageTesting.ResumeLayout(false);
      this.tabPageTesting.PerformLayout();
      this.tabPageExperimental.ResumeLayout(false);
      this.gbColorCalibration.ResumeLayout(false);
      this.gbColorCalibration.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageTesting;
        private System.Windows.Forms.TabPage tabPageExperimental;
        private System.Windows.Forms.Button btnRefreshSettings;
        private System.Windows.Forms.TextBox tbHueColorTemperature;
        private System.Windows.Forms.Label lblHueColorTemperature;
        private System.Windows.Forms.GroupBox gbColorCalibration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbZBlue;
        private System.Windows.Forms.TextBox tbZGreen;
        private System.Windows.Forms.TextBox tbZRed;
        private System.Windows.Forms.TextBox tbYBlue;
        private System.Windows.Forms.TextBox tbYGreen;
        private System.Windows.Forms.TextBox tbYRed;
        private System.Windows.Forms.TextBox tbXBlue;
        private System.Windows.Forms.TextBox tbXGreen;
        private System.Windows.Forms.TextBox tbXRed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestRed;
        private System.Windows.Forms.Button btnTestGreen;
        private System.Windows.Forms.Button btnTestBlue;
        private System.Windows.Forms.Button btnHueColorClear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}

