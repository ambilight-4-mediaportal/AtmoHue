﻿namespace AtmoHue
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.btnLocateHueBridge = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.lblAtmoWinFolder = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
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
      this.lblAtmoinPresetColor = new System.Windows.Forms.Label();
      this.tbAtmowinStaticColor = new System.Windows.Forms.TextBox();
      this.btnStopAtmowinHue = new System.Windows.Forms.Button();
      this.gbBridgeTools = new System.Windows.Forms.GroupBox();
      this.cbRunningWindows8 = new System.Windows.Forms.CheckBox();
      this.cbAutoConnectBridge = new System.Windows.Forms.CheckBox();
      this.grpAtmowin = new System.Windows.Forms.GroupBox();
      this.tbAtmowinScanInterval = new System.Windows.Forms.TextBox();
      this.tbAtmowinLocation = new System.Windows.Forms.TextBox();
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPageGeneral = new System.Windows.Forms.TabPage();
      this.lblConnectionStatus = new System.Windows.Forms.Label();
      this.lCopyright = new System.Windows.Forms.Label();
      this.llQ42 = new System.Windows.Forms.LinkLabel();
      this.gbLogOutput = new System.Windows.Forms.GroupBox();
      this.lbOutputlog = new System.Windows.Forms.ListBox();
      this.cbMinimizeToTray = new System.Windows.Forms.CheckBox();
      this.cbMinimizeOnStartup = new System.Windows.Forms.CheckBox();
      this.gbHueSettings = new System.Windows.Forms.GroupBox();
      this.cbEnableIndividualLightSettings = new System.Windows.Forms.CheckBox();
      this.lblHuePowerHandling = new System.Windows.Forms.Label();
      this.cbHuePowerHandling = new System.Windows.Forms.ComboBox();
      this.cbHueHue = new System.Windows.Forms.ComboBox();
      this.cbHueColorTemperature = new System.Windows.Forms.ComboBox();
      this.cbHueTransitionTime = new System.Windows.Forms.ComboBox();
      this.cbHueSetBrightnessStartup = new System.Windows.Forms.CheckBox();
      this.cbHueSaturation = new System.Windows.Forms.ComboBox();
      this.cbHueBrightness = new System.Windows.Forms.ComboBox();
      this.lblHueColorTemperature = new System.Windows.Forms.Label();
      this.tbHueAppKey = new System.Windows.Forms.TextBox();
      this.tbHueAppName = new System.Windows.Forms.TextBox();
      this.tbHueBridgeIP = new System.Windows.Forms.TextBox();
      this.cbEnableDebuglog = new System.Windows.Forms.CheckBox();
      this.tabPageLeds = new System.Windows.Forms.TabPage();
      this.btnRemoveLedPredefinedStaticColor = new System.Windows.Forms.Button();
      this.btnRemoveLedLocation = new System.Windows.Forms.Button();
      this.label25 = new System.Windows.Forms.Label();
      this.label26 = new System.Windows.Forms.Label();
      this.label27 = new System.Windows.Forms.Label();
      this.tbPredefinedColorB = new System.Windows.Forms.TextBox();
      this.tbPredefinedColorG = new System.Windows.Forms.TextBox();
      this.label28 = new System.Windows.Forms.Label();
      this.tbPredefinedColorR = new System.Windows.Forms.TextBox();
      this.lblPredefinedStaticColorName = new System.Windows.Forms.Label();
      this.tbPredefinedStaticColorName = new System.Windows.Forms.TextBox();
      this.lblAddLedPriority = new System.Windows.Forms.Label();
      this.lblAddLedLocation = new System.Windows.Forms.Label();
      this.tbLedLocationPriority = new System.Windows.Forms.TextBox();
      this.tbLedLocation = new System.Windows.Forms.TextBox();
      this.btnAddPredefinedStaticColor = new System.Windows.Forms.Button();
      this.btnAddLedLocation = new System.Windows.Forms.Button();
      this.btnLedStaticColorDOWN = new System.Windows.Forms.Button();
      this.btnLedStaticColorUP = new System.Windows.Forms.Button();
      this.btnLedLocationDOWN = new System.Windows.Forms.Button();
      this.btnLedLocationUP = new System.Windows.Forms.Button();
      this.grpPredefinedStaticColors = new System.Windows.Forms.GroupBox();
      this.lvPredefinedStaticColors = new System.Windows.Forms.ListView();
      this.chPredefinedStaticColorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chPredefinedStaticColorRGB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.grpLedLocations = new System.Windows.Forms.GroupBox();
      this.lvLedLocations = new System.Windows.Forms.ListView();
      this.chLedLocationName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLedLocationPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnLedItemDown = new System.Windows.Forms.Button();
      this.btnLedItemUp = new System.Windows.Forms.Button();
      this.gbManageLeds = new System.Windows.Forms.GroupBox();
      this.cbLedLocation = new System.Windows.Forms.ComboBox();
      this.lblLedLocation = new System.Windows.Forms.Label();
      this.btnRemoveLeds = new System.Windows.Forms.Button();
      this.cbLedType = new System.Windows.Forms.ComboBox();
      this.gbLedOptional = new System.Windows.Forms.GroupBox();
      this.lblLedSendDelay = new System.Windows.Forms.Label();
      this.lblLedHue = new System.Windows.Forms.Label();
      this.tbLedSendDelay = new System.Windows.Forms.TextBox();
      this.tbLedHue = new System.Windows.Forms.TextBox();
      this.tbLedBrightness = new System.Windows.Forms.TextBox();
      this.lblLedColorTemperature = new System.Windows.Forms.Label();
      this.lblLedBrightness = new System.Windows.Forms.Label();
      this.lblLedB = new System.Windows.Forms.Label();
      this.tbLedColorTemperature = new System.Windows.Forms.TextBox();
      this.tbLedSaturation = new System.Windows.Forms.TextBox();
      this.lblLedG = new System.Windows.Forms.Label();
      this.lnlLedSaturation = new System.Windows.Forms.Label();
      this.tbLedB = new System.Windows.Forms.TextBox();
      this.lblLedR = new System.Windows.Forms.Label();
      this.tbLedR = new System.Windows.Forms.TextBox();
      this.lblLedStaticColor = new System.Windows.Forms.Label();
      this.tbLedG = new System.Windows.Forms.TextBox();
      this.btnAddLed = new System.Windows.Forms.Button();
      this.lblLedType = new System.Windows.Forms.Label();
      this.lblLedID = new System.Windows.Forms.Label();
      this.tbLedID = new System.Windows.Forms.TextBox();
      this.lvLedDevices = new System.Windows.Forms.ListView();
      this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLedLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLedDelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLedBrightness = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLedSaturation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLedColorTemperature = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLedHue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chLedStaticColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.tabPageTesting = new System.Windows.Forms.TabPage();
      this.gbColorTests = new System.Windows.Forms.GroupBox();
      this.lblTestHueBrightness = new System.Windows.Forms.Label();
      this.btnTestHueBrightness = new System.Windows.Forms.Button();
      this.cbTestHueBrightness = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbTestCustomColorB = new System.Windows.Forms.ComboBox();
      this.tbRotateTestDelay = new System.Windows.Forms.TextBox();
      this.cbTestCustomColorG = new System.Windows.Forms.ComboBox();
      this.cbTestCustomColorR = new System.Windows.Forms.ComboBox();
      this.label22 = new System.Windows.Forms.Label();
      this.label23 = new System.Windows.Forms.Label();
      this.label24 = new System.Windows.Forms.Label();
      this.btnHueColorClear = new System.Windows.Forms.Button();
      this.btnTestRed = new System.Windows.Forms.Button();
      this.btnTestBlue = new System.Windows.Forms.Button();
      this.btnTestGreen = new System.Windows.Forms.Button();
      this.tabPageExperimental = new System.Windows.Forms.TabPage();
      this.btnGetLedIDs = new System.Windows.Forms.Button();
      this.gbHueSceneTester = new System.Windows.Forms.GroupBox();
      this.label21 = new System.Windows.Forms.Label();
      this.lblHueSceneID = new System.Windows.Forms.Label();
      this.btnHueSetScene = new System.Windows.Forms.Button();
      this.tbHueSceneName = new System.Windows.Forms.TextBox();
      this.tbHueSceneID = new System.Windows.Forms.TextBox();
      this.btnHueLocateScenes = new System.Windows.Forms.Button();
      this.gbColorCalibration = new System.Windows.Forms.GroupBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.tbZBlue = new System.Windows.Forms.TextBox();
      this.tbZGreen = new System.Windows.Forms.TextBox();
      this.tbZRed = new System.Windows.Forms.TextBox();
      this.tbYBlue = new System.Windows.Forms.TextBox();
      this.tbYGreen = new System.Windows.Forms.TextBox();
      this.tbYRed = new System.Windows.Forms.TextBox();
      this.tbXBlue = new System.Windows.Forms.TextBox();
      this.tbXGreen = new System.Windows.Forms.TextBox();
      this.tbXRed = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.trayIconHue = new System.Windows.Forms.NotifyIcon(this.components);
      this.trayIconHueContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
      this.gbBridgeTools.SuspendLayout();
      this.grpAtmowin.SuspendLayout();
      this.grpRemoteAPI.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPageGeneral.SuspendLayout();
      this.gbLogOutput.SuspendLayout();
      this.gbHueSettings.SuspendLayout();
      this.tabPageLeds.SuspendLayout();
      this.grpPredefinedStaticColors.SuspendLayout();
      this.grpLedLocations.SuspendLayout();
      this.gbManageLeds.SuspendLayout();
      this.gbLedOptional.SuspendLayout();
      this.tabPageTesting.SuspendLayout();
      this.gbColorTests.SuspendLayout();
      this.tabPageExperimental.SuspendLayout();
      this.gbHueSceneTester.SuspendLayout();
      this.gbColorCalibration.SuspendLayout();
      this.trayIconHueContextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnLocateHueBridge
      // 
      this.btnLocateHueBridge.Location = new System.Drawing.Point(13, 69);
      this.btnLocateHueBridge.Name = "btnLocateHueBridge";
      this.btnLocateHueBridge.Size = new System.Drawing.Size(281, 67);
      this.btnLocateHueBridge.TabIndex = 12;
      this.btnLocateHueBridge.Text = "Locate and register to Hue Bridge";
      this.btnLocateHueBridge.UseVisualStyleBackColor = true;
      this.btnLocateHueBridge.Click += new System.EventHandler(this.btnLocateHueBridge_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(17, 26);
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
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(17, 60);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(89, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Hue app name";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(17, 88);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 13);
      this.label4.TabIndex = 14;
      this.label4.Text = "Hue app key";
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
      this.lblBrightness.Location = new System.Drawing.Point(17, 128);
      this.lblBrightness.Name = "lblBrightness";
      this.lblBrightness.Size = new System.Drawing.Size(87, 13);
      this.lblBrightness.TabIndex = 21;
      this.lblBrightness.Text = "Brightness (%)";
      // 
      // lblHueSaturation
      // 
      this.lblHueSaturation.AutoSize = true;
      this.lblHueSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueSaturation.Location = new System.Drawing.Point(17, 165);
      this.lblHueSaturation.Name = "lblHueSaturation";
      this.lblHueSaturation.Size = new System.Drawing.Size(65, 13);
      this.lblHueSaturation.TabIndex = 25;
      this.lblHueSaturation.Text = "Saturation";
      // 
      // lblHueTransTime
      // 
      this.lblHueTransTime.AutoSize = true;
      this.lblHueTransTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueTransTime.Location = new System.Drawing.Point(17, 268);
      this.lblHueTransTime.Name = "lblHueTransTime";
      this.lblHueTransTime.Size = new System.Drawing.Size(117, 13);
      this.lblHueTransTime.TabIndex = 26;
      this.lblHueTransTime.Text = "Transition time (ms)";
      // 
      // lblHueHue
      // 
      this.lblHueHue.AutoSize = true;
      this.lblHueHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueHue.Location = new System.Drawing.Point(17, 239);
      this.lblHueHue.Name = "lblHueHue";
      this.lblHueHue.Size = new System.Drawing.Size(30, 13);
      this.lblHueHue.TabIndex = 28;
      this.lblHueHue.Text = "Hue";
      // 
      // lblHueCustomColorTest
      // 
      this.lblHueCustomColorTest.AutoSize = true;
      this.lblHueCustomColorTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueCustomColorTest.Location = new System.Drawing.Point(23, 107);
      this.lblHueCustomColorTest.Name = "lblHueCustomColorTest";
      this.lblHueCustomColorTest.Size = new System.Drawing.Size(84, 13);
      this.lblHueCustomColorTest.TabIndex = 31;
      this.lblHueCustomColorTest.Text = "Custom color:";
      // 
      // btnHueSendCustomColor
      // 
      this.btnHueSendCustomColor.Location = new System.Drawing.Point(429, 103);
      this.btnHueSendCustomColor.Name = "btnHueSendCustomColor";
      this.btnHueSendCustomColor.Size = new System.Drawing.Size(93, 24);
      this.btnHueSendCustomColor.TabIndex = 507;
      this.btnHueSendCustomColor.Text = "Test";
      this.btnHueSendCustomColor.UseVisualStyleBackColor = true;
      this.btnHueSendCustomColor.Click += new System.EventHandler(this.btnHueSendCustomColor_Click);
      // 
      // btnHueColorRotateTestStart
      // 
      this.btnHueColorRotateTestStart.Location = new System.Drawing.Point(285, 160);
      this.btnHueColorRotateTestStart.Name = "btnHueColorRotateTestStart";
      this.btnHueColorRotateTestStart.Size = new System.Drawing.Size(57, 23);
      this.btnHueColorRotateTestStart.TabIndex = 509;
      this.btnHueColorRotateTestStart.Text = "Start";
      this.btnHueColorRotateTestStart.UseVisualStyleBackColor = true;
      this.btnHueColorRotateTestStart.Click += new System.EventHandler(this.btnHueColorRotateTestStart_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(23, 165);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(153, 13);
      this.label6.TabIndex = 35;
      this.label6.Text = "Rotate R/G/B every (ms):";
      // 
      // btnHueColorRotateTestStop
      // 
      this.btnHueColorRotateTestStop.Location = new System.Drawing.Point(362, 160);
      this.btnHueColorRotateTestStop.Name = "btnHueColorRotateTestStop";
      this.btnHueColorRotateTestStop.Size = new System.Drawing.Size(53, 23);
      this.btnHueColorRotateTestStop.TabIndex = 510;
      this.btnHueColorRotateTestStop.Text = "Stop";
      this.btnHueColorRotateTestStop.UseVisualStyleBackColor = true;
      this.btnHueColorRotateTestStop.Click += new System.EventHandler(this.btnHueColorRotateTestStop_Click);
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
      // gbBridgeTools
      // 
      this.gbBridgeTools.Controls.Add(this.cbRunningWindows8);
      this.gbBridgeTools.Controls.Add(this.cbAutoConnectBridge);
      this.gbBridgeTools.Controls.Add(this.btnLocateHueBridge);
      this.gbBridgeTools.Location = new System.Drawing.Point(754, 16);
      this.gbBridgeTools.Name = "gbBridgeTools";
      this.gbBridgeTools.Size = new System.Drawing.Size(311, 142);
      this.gbBridgeTools.TabIndex = 45;
      this.gbBridgeTools.TabStop = false;
      this.gbBridgeTools.Text = "Hue Bridge";
      // 
      // cbRunningWindows8
      // 
      this.cbRunningWindows8.AutoSize = true;
      this.cbRunningWindows8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbRunningWindows8.Location = new System.Drawing.Point(13, 22);
      this.cbRunningWindows8.Name = "cbRunningWindows8";
      this.cbRunningWindows8.Size = new System.Drawing.Size(159, 17);
      this.cbRunningWindows8.TabIndex = 10;
      this.cbRunningWindows8.Text = "Running Windows 8.* ?";
      this.cbRunningWindows8.UseVisualStyleBackColor = true;
      this.cbRunningWindows8.Validating += new System.ComponentModel.CancelEventHandler(this.cbRunningWindows8_Validating);
      // 
      // cbAutoConnectBridge
      // 
      this.cbAutoConnectBridge.AutoSize = true;
      this.cbAutoConnectBridge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbAutoConnectBridge.Location = new System.Drawing.Point(13, 45);
      this.cbAutoConnectBridge.Name = "cbAutoConnectBridge";
      this.cbAutoConnectBridge.Size = new System.Drawing.Size(188, 17);
      this.cbAutoConnectBridge.TabIndex = 11;
      this.cbAutoConnectBridge.Text = "Auto connect if bridge found";
      this.cbAutoConnectBridge.UseVisualStyleBackColor = true;
      this.cbAutoConnectBridge.Validating += new System.ComponentModel.CancelEventHandler(this.cbAutoConnectBridge_Validating);
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
      this.grpAtmowin.Size = new System.Drawing.Size(789, 193);
      this.grpAtmowin.TabIndex = 46;
      this.grpAtmowin.TabStop = false;
      this.grpAtmowin.Text = "Atmowin monitoring";
      // 
      // tbAtmowinScanInterval
      // 
      this.tbAtmowinScanInterval.Location = new System.Drawing.Point(225, 50);
      this.tbAtmowinScanInterval.Name = "tbAtmowinScanInterval";
      this.tbAtmowinScanInterval.Size = new System.Drawing.Size(68, 20);
      this.tbAtmowinScanInterval.TabIndex = 19;
      this.tbAtmowinScanInterval.Text = "300";
      // 
      // tbAtmowinLocation
      // 
      this.tbAtmowinLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.tbAtmowinLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
      this.tbAtmowinLocation.Location = new System.Drawing.Point(147, 13);
      this.tbAtmowinLocation.Name = "tbAtmowinLocation";
      this.tbAtmowinLocation.Size = new System.Drawing.Size(442, 20);
      this.tbAtmowinLocation.TabIndex = 5;
      // 
      // cbLogRemoteApiCalls
      // 
      this.cbLogRemoteApiCalls.AutoSize = true;
      this.cbLogRemoteApiCalls.Checked = global::AtmoHue.Properties.Settings.Default.logRemoteApiCalls;
      this.cbLogRemoteApiCalls.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AtmoHue.Properties.Settings.Default, "logRemoteApiCalls", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbLogRemoteApiCalls.Location = new System.Drawing.Point(14, 401);
      this.cbLogRemoteApiCalls.Name = "cbLogRemoteApiCalls";
      this.cbLogRemoteApiCalls.Size = new System.Drawing.Size(123, 17);
      this.cbLogRemoteApiCalls.TabIndex = 47;
      this.cbLogRemoteApiCalls.Text = "Log remote API calls";
      this.cbLogRemoteApiCalls.UseVisualStyleBackColor = true;
      this.cbLogRemoteApiCalls.CheckedChanged += new System.EventHandler(this.cbLogRemoteApiCalls_CheckedChanged);
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
      this.grpRemoteAPI.Location = new System.Drawing.Point(754, 174);
      this.grpRemoteAPI.Name = "grpRemoteAPI";
      this.grpRemoteAPI.Size = new System.Drawing.Size(311, 183);
      this.grpRemoteAPI.TabIndex = 48;
      this.grpRemoteAPI.TabStop = false;
      this.grpRemoteAPI.Text = "Remote API";
      // 
      // tbRemoteAPIsendDelay
      // 
      this.tbRemoteAPIsendDelay.Location = new System.Drawing.Point(127, 133);
      this.tbRemoteAPIsendDelay.Name = "tbRemoteAPIsendDelay";
      this.tbRemoteAPIsendDelay.Size = new System.Drawing.Size(68, 20);
      this.tbRemoteAPIsendDelay.TabIndex = 16;
      this.tbRemoteAPIsendDelay.Text = "300";
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
      this.tbRemoteApiPort.Location = new System.Drawing.Point(127, 101);
      this.tbRemoteApiPort.Name = "tbRemoteApiPort";
      this.tbRemoteApiPort.Size = new System.Drawing.Size(100, 20);
      this.tbRemoteApiPort.TabIndex = 15;
      this.tbRemoteApiPort.Text = "20123";
      // 
      // tbRemoteAPIip
      // 
      this.tbRemoteAPIip.Location = new System.Drawing.Point(127, 75);
      this.tbRemoteAPIip.Name = "tbRemoteAPIip";
      this.tbRemoteAPIip.Size = new System.Drawing.Size(100, 20);
      this.tbRemoteAPIip.TabIndex = 14;
      this.tbRemoteAPIip.Text = "Any";
      // 
      // cbRemoteAPIEnabled
      // 
      this.cbRemoteAPIEnabled.AutoSize = true;
      this.cbRemoteAPIEnabled.Location = new System.Drawing.Point(6, 19);
      this.cbRemoteAPIEnabled.Name = "cbRemoteAPIEnabled";
      this.cbRemoteAPIEnabled.Size = new System.Drawing.Size(121, 17);
      this.cbRemoteAPIEnabled.TabIndex = 13;
      this.cbRemoteAPIEnabled.Text = "Enable remote API *";
      this.cbRemoteAPIEnabled.UseVisualStyleBackColor = true;
      this.cbRemoteAPIEnabled.Validating += new System.ComponentModel.CancelEventHandler(this.cbRemoteAPIEnabled_Validating);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPageGeneral);
      this.tabControl1.Controls.Add(this.tabPageLeds);
      this.tabControl1.Controls.Add(this.tabPageTesting);
      this.tabControl1.Controls.Add(this.tabPageExperimental);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1108, 740);
      this.tabControl1.TabIndex = 50;
      // 
      // tabPageGeneral
      // 
      this.tabPageGeneral.BackColor = System.Drawing.SystemColors.Control;
      this.tabPageGeneral.Controls.Add(this.lblConnectionStatus);
      this.tabPageGeneral.Controls.Add(this.lCopyright);
      this.tabPageGeneral.Controls.Add(this.llQ42);
      this.tabPageGeneral.Controls.Add(this.gbLogOutput);
      this.tabPageGeneral.Controls.Add(this.cbMinimizeToTray);
      this.tabPageGeneral.Controls.Add(this.cbMinimizeOnStartup);
      this.tabPageGeneral.Controls.Add(this.gbHueSettings);
      this.tabPageGeneral.Controls.Add(this.gbBridgeTools);
      this.tabPageGeneral.Controls.Add(this.cbLogRemoteApiCalls);
      this.tabPageGeneral.Controls.Add(this.grpRemoteAPI);
      this.tabPageGeneral.Controls.Add(this.cbEnableDebuglog);
      this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
      this.tabPageGeneral.Name = "tabPageGeneral";
      this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageGeneral.Size = new System.Drawing.Size(1100, 714);
      this.tabPageGeneral.TabIndex = 0;
      this.tabPageGeneral.Text = "General";
      // 
      // lblConnectionStatus
      // 
      this.lblConnectionStatus.AutoSize = true;
      this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblConnectionStatus.Location = new System.Drawing.Point(8, 696);
      this.lblConnectionStatus.Name = "lblConnectionStatus";
      this.lblConnectionStatus.Size = new System.Drawing.Size(47, 13);
      this.lblConnectionStatus.TabIndex = 57;
      this.lblConnectionStatus.Text = "Status:";
      // 
      // lCopyright
      // 
      this.lCopyright.AutoSize = true;
      this.lCopyright.Location = new System.Drawing.Point(940, 696);
      this.lCopyright.Name = "lCopyright";
      this.lCopyright.Size = new System.Drawing.Size(92, 13);
      this.lCopyright.TabIndex = 56;
      this.lCopyright.Text = "Made possible by:";
      // 
      // llQ42
      // 
      this.llQ42.AutoSize = true;
      this.llQ42.Location = new System.Drawing.Point(1029, 696);
      this.llQ42.Name = "llQ42";
      this.llQ42.Size = new System.Drawing.Size(65, 13);
      this.llQ42.TabIndex = 55;
      this.llQ42.TabStop = true;
      this.llQ42.Text = "Q42.HueApi";
      // 
      // gbLogOutput
      // 
      this.gbLogOutput.Controls.Add(this.lbOutputlog);
      this.gbLogOutput.Location = new System.Drawing.Point(7, 424);
      this.gbLogOutput.Name = "gbLogOutput";
      this.gbLogOutput.Size = new System.Drawing.Size(1073, 246);
      this.gbLogOutput.TabIndex = 54;
      this.gbLogOutput.TabStop = false;
      this.gbLogOutput.Text = "Log";
      // 
      // lbOutputlog
      // 
      this.lbOutputlog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbOutputlog.FormattingEnabled = true;
      this.lbOutputlog.Location = new System.Drawing.Point(3, 16);
      this.lbOutputlog.Name = "lbOutputlog";
      this.lbOutputlog.Size = new System.Drawing.Size(1067, 227);
      this.lbOutputlog.TabIndex = 17;
      // 
      // cbMinimizeToTray
      // 
      this.cbMinimizeToTray.AutoSize = true;
      this.cbMinimizeToTray.Location = new System.Drawing.Point(795, 401);
      this.cbMinimizeToTray.Name = "cbMinimizeToTray";
      this.cbMinimizeToTray.Size = new System.Drawing.Size(98, 17);
      this.cbMinimizeToTray.TabIndex = 53;
      this.cbMinimizeToTray.Text = "Minimize to tray";
      this.cbMinimizeToTray.UseVisualStyleBackColor = true;
      this.cbMinimizeToTray.CheckedChanged += new System.EventHandler(this.cbMinimizeToTray_CheckedChanged);
      // 
      // cbMinimizeOnStartup
      // 
      this.cbMinimizeOnStartup.AutoSize = true;
      this.cbMinimizeOnStartup.Location = new System.Drawing.Point(929, 401);
      this.cbMinimizeOnStartup.Name = "cbMinimizeOnStartup";
      this.cbMinimizeOnStartup.Size = new System.Drawing.Size(148, 17);
      this.cbMinimizeOnStartup.TabIndex = 52;
      this.cbMinimizeOnStartup.Text = "Minimize to tray on startup";
      this.cbMinimizeOnStartup.UseVisualStyleBackColor = true;
      this.cbMinimizeOnStartup.CheckedChanged += new System.EventHandler(this.cbMinimizeOnStartup_CheckedChanged);
      // 
      // gbHueSettings
      // 
      this.gbHueSettings.Controls.Add(this.cbEnableIndividualLightSettings);
      this.gbHueSettings.Controls.Add(this.lblHuePowerHandling);
      this.gbHueSettings.Controls.Add(this.cbHuePowerHandling);
      this.gbHueSettings.Controls.Add(this.label1);
      this.gbHueSettings.Controls.Add(this.cbHueHue);
      this.gbHueSettings.Controls.Add(this.lblHueHue);
      this.gbHueSettings.Controls.Add(this.cbHueColorTemperature);
      this.gbHueSettings.Controls.Add(this.lblHueTransTime);
      this.gbHueSettings.Controls.Add(this.cbHueTransitionTime);
      this.gbHueSettings.Controls.Add(this.cbHueSetBrightnessStartup);
      this.gbHueSettings.Controls.Add(this.lblHueSaturation);
      this.gbHueSettings.Controls.Add(this.cbHueSaturation);
      this.gbHueSettings.Controls.Add(this.cbHueBrightness);
      this.gbHueSettings.Controls.Add(this.lblBrightness);
      this.gbHueSettings.Controls.Add(this.lblHueColorTemperature);
      this.gbHueSettings.Controls.Add(this.tbHueAppKey);
      this.gbHueSettings.Controls.Add(this.tbHueAppName);
      this.gbHueSettings.Controls.Add(this.label4);
      this.gbHueSettings.Controls.Add(this.label3);
      this.gbHueSettings.Controls.Add(this.tbHueBridgeIP);
      this.gbHueSettings.Location = new System.Drawing.Point(6, 6);
      this.gbHueSettings.Name = "gbHueSettings";
      this.gbHueSettings.Size = new System.Drawing.Size(473, 373);
      this.gbHueSettings.TabIndex = 51;
      this.gbHueSettings.TabStop = false;
      this.gbHueSettings.Text = "Hue overview";
      // 
      // cbEnableIndividualLightSettings
      // 
      this.cbEnableIndividualLightSettings.AutoSize = true;
      this.cbEnableIndividualLightSettings.Location = new System.Drawing.Point(20, 349);
      this.cbEnableIndividualLightSettings.Name = "cbEnableIndividualLightSettings";
      this.cbEnableIndividualLightSettings.Size = new System.Drawing.Size(291, 17);
      this.cbEnableIndividualLightSettings.TabIndex = 53;
      this.cbEnableIndividualLightSettings.Text = "Enable individual Light settings (might cause sync errors)";
      this.cbEnableIndividualLightSettings.UseVisualStyleBackColor = true;
      this.cbEnableIndividualLightSettings.CheckedChanged += new System.EventHandler(this.cbEnableIndividualLightSettings_CheckedChanged);
      // 
      // lblHuePowerHandling
      // 
      this.lblHuePowerHandling.AutoSize = true;
      this.lblHuePowerHandling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHuePowerHandling.Location = new System.Drawing.Point(17, 302);
      this.lblHuePowerHandling.Name = "lblHuePowerHandling";
      this.lblHuePowerHandling.Size = new System.Drawing.Size(94, 13);
      this.lblHuePowerHandling.TabIndex = 52;
      this.lblHuePowerHandling.Text = "Power handling";
      // 
      // cbHuePowerHandling
      // 
      this.cbHuePowerHandling.FormattingEnabled = true;
      this.cbHuePowerHandling.Items.AddRange(new object[] {
            "Power bridge ON on resume",
            "Power bridge OFF on standby",
            "Power bridge ON and OFF during power events",
            "Let Atmolight handle power events for bridge"});
      this.cbHuePowerHandling.Location = new System.Drawing.Point(150, 299);
      this.cbHuePowerHandling.Name = "cbHuePowerHandling";
      this.cbHuePowerHandling.Size = new System.Drawing.Size(317, 21);
      this.cbHuePowerHandling.TabIndex = 51;
      this.cbHuePowerHandling.SelectedIndexChanged += new System.EventHandler(this.cbHuePowerHandling_SelectedIndexChanged);
      // 
      // cbHueHue
      // 
      this.cbHueHue.FormattingEnabled = true;
      this.cbHueHue.Location = new System.Drawing.Point(150, 230);
      this.cbHueHue.Name = "cbHueHue";
      this.cbHueHue.Size = new System.Drawing.Size(98, 21);
      this.cbHueHue.TabIndex = 7;
      this.cbHueHue.Validating += new System.ComponentModel.CancelEventHandler(this.cbHueHue_Validating);
      // 
      // cbHueColorTemperature
      // 
      this.cbHueColorTemperature.FormattingEnabled = true;
      this.cbHueColorTemperature.Location = new System.Drawing.Point(150, 200);
      this.cbHueColorTemperature.Name = "cbHueColorTemperature";
      this.cbHueColorTemperature.Size = new System.Drawing.Size(98, 21);
      this.cbHueColorTemperature.TabIndex = 6;
      this.cbHueColorTemperature.Text = "500";
      this.cbHueColorTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.cbHueColorTemperature_Validating);
      // 
      // cbHueTransitionTime
      // 
      this.cbHueTransitionTime.FormattingEnabled = true;
      this.cbHueTransitionTime.Location = new System.Drawing.Point(150, 265);
      this.cbHueTransitionTime.Name = "cbHueTransitionTime";
      this.cbHueTransitionTime.Size = new System.Drawing.Size(98, 21);
      this.cbHueTransitionTime.TabIndex = 8;
      this.cbHueTransitionTime.Text = "300";
      this.cbHueTransitionTime.Validating += new System.ComponentModel.CancelEventHandler(this.cbHueTransitionTime_Validating);
      // 
      // cbHueSetBrightnessStartup
      // 
      this.cbHueSetBrightnessStartup.AutoSize = true;
      this.cbHueSetBrightnessStartup.Location = new System.Drawing.Point(20, 326);
      this.cbHueSetBrightnessStartup.Name = "cbHueSetBrightnessStartup";
      this.cbHueSetBrightnessStartup.Size = new System.Drawing.Size(289, 17);
      this.cbHueSetBrightnessStartup.TabIndex = 9;
      this.cbHueSetBrightnessStartup.Text = "Only set brightness on first color info send to Hue Bridge";
      this.cbHueSetBrightnessStartup.UseVisualStyleBackColor = true;
      this.cbHueSetBrightnessStartup.Validating += new System.ComponentModel.CancelEventHandler(this.cbHueSetBrightnessStartup_Validating);
      // 
      // cbHueSaturation
      // 
      this.cbHueSaturation.FormattingEnabled = true;
      this.cbHueSaturation.Location = new System.Drawing.Point(150, 162);
      this.cbHueSaturation.Name = "cbHueSaturation";
      this.cbHueSaturation.Size = new System.Drawing.Size(98, 21);
      this.cbHueSaturation.TabIndex = 5;
      this.cbHueSaturation.Text = "100";
      this.cbHueSaturation.Validating += new System.ComponentModel.CancelEventHandler(this.cbHueSaturation_Validating);
      // 
      // cbHueBrightness
      // 
      this.cbHueBrightness.FormattingEnabled = true;
      this.cbHueBrightness.Location = new System.Drawing.Point(150, 125);
      this.cbHueBrightness.Name = "cbHueBrightness";
      this.cbHueBrightness.Size = new System.Drawing.Size(75, 21);
      this.cbHueBrightness.TabIndex = 4;
      this.cbHueBrightness.Text = "100";
      this.cbHueBrightness.Validating += new System.ComponentModel.CancelEventHandler(this.cbHueBrightness_Validating);
      // 
      // lblHueColorTemperature
      // 
      this.lblHueColorTemperature.AutoSize = true;
      this.lblHueColorTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblHueColorTemperature.Location = new System.Drawing.Point(17, 203);
      this.lblHueColorTemperature.Name = "lblHueColorTemperature";
      this.lblHueColorTemperature.Size = new System.Drawing.Size(107, 13);
      this.lblHueColorTemperature.TabIndex = 50;
      this.lblHueColorTemperature.Text = "Color temperature";
      // 
      // tbHueAppKey
      // 
      this.tbHueAppKey.Location = new System.Drawing.Point(150, 85);
      this.tbHueAppKey.Name = "tbHueAppKey";
      this.tbHueAppKey.Size = new System.Drawing.Size(223, 20);
      this.tbHueAppKey.TabIndex = 3;
      this.tbHueAppKey.Text = "AtmoHueAppKey";
      this.tbHueAppKey.Validating += new System.ComponentModel.CancelEventHandler(this.tbHueAppKey_Validating);
      // 
      // tbHueAppName
      // 
      this.tbHueAppName.Location = new System.Drawing.Point(150, 57);
      this.tbHueAppName.Name = "tbHueAppName";
      this.tbHueAppName.Size = new System.Drawing.Size(173, 20);
      this.tbHueAppName.TabIndex = 2;
      this.tbHueAppName.Text = "AtmoHue";
      this.tbHueAppName.Validating += new System.ComponentModel.CancelEventHandler(this.tbHueAppName_Validating);
      // 
      // tbHueBridgeIP
      // 
      this.tbHueBridgeIP.Location = new System.Drawing.Point(150, 23);
      this.tbHueBridgeIP.Name = "tbHueBridgeIP";
      this.tbHueBridgeIP.Size = new System.Drawing.Size(100, 20);
      this.tbHueBridgeIP.TabIndex = 1;
      this.tbHueBridgeIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbHueBridgeIP_Validating);
      // 
      // cbEnableDebuglog
      // 
      this.cbEnableDebuglog.AutoSize = true;
      this.cbEnableDebuglog.Checked = global::AtmoHue.Properties.Settings.Default.debugModeEnabled;
      this.cbEnableDebuglog.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AtmoHue.Properties.Settings.Default, "debugModeEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.cbEnableDebuglog.Location = new System.Drawing.Point(145, 401);
      this.cbEnableDebuglog.Name = "cbEnableDebuglog";
      this.cbEnableDebuglog.Size = new System.Drawing.Size(109, 17);
      this.cbEnableDebuglog.TabIndex = 38;
      this.cbEnableDebuglog.Text = "Enable debug log";
      this.cbEnableDebuglog.UseVisualStyleBackColor = true;
      // 
      // tabPageLeds
      // 
      this.tabPageLeds.BackColor = System.Drawing.SystemColors.Control;
      this.tabPageLeds.Controls.Add(this.btnRemoveLedPredefinedStaticColor);
      this.tabPageLeds.Controls.Add(this.btnRemoveLedLocation);
      this.tabPageLeds.Controls.Add(this.label25);
      this.tabPageLeds.Controls.Add(this.label26);
      this.tabPageLeds.Controls.Add(this.label27);
      this.tabPageLeds.Controls.Add(this.tbPredefinedColorB);
      this.tabPageLeds.Controls.Add(this.tbPredefinedColorG);
      this.tabPageLeds.Controls.Add(this.label28);
      this.tabPageLeds.Controls.Add(this.tbPredefinedColorR);
      this.tabPageLeds.Controls.Add(this.lblPredefinedStaticColorName);
      this.tabPageLeds.Controls.Add(this.tbPredefinedStaticColorName);
      this.tabPageLeds.Controls.Add(this.lblAddLedPriority);
      this.tabPageLeds.Controls.Add(this.lblAddLedLocation);
      this.tabPageLeds.Controls.Add(this.tbLedLocationPriority);
      this.tabPageLeds.Controls.Add(this.tbLedLocation);
      this.tabPageLeds.Controls.Add(this.btnAddPredefinedStaticColor);
      this.tabPageLeds.Controls.Add(this.btnAddLedLocation);
      this.tabPageLeds.Controls.Add(this.btnLedStaticColorDOWN);
      this.tabPageLeds.Controls.Add(this.btnLedStaticColorUP);
      this.tabPageLeds.Controls.Add(this.btnLedLocationDOWN);
      this.tabPageLeds.Controls.Add(this.btnLedLocationUP);
      this.tabPageLeds.Controls.Add(this.grpPredefinedStaticColors);
      this.tabPageLeds.Controls.Add(this.grpLedLocations);
      this.tabPageLeds.Controls.Add(this.btnLedItemDown);
      this.tabPageLeds.Controls.Add(this.btnLedItemUp);
      this.tabPageLeds.Controls.Add(this.gbManageLeds);
      this.tabPageLeds.Controls.Add(this.lvLedDevices);
      this.tabPageLeds.Location = new System.Drawing.Point(4, 22);
      this.tabPageLeds.Name = "tabPageLeds";
      this.tabPageLeds.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageLeds.Size = new System.Drawing.Size(1100, 714);
      this.tabPageLeds.TabIndex = 3;
      this.tabPageLeds.Text = "Hue Leds";
      // 
      // btnRemoveLedPredefinedStaticColor
      // 
      this.btnRemoveLedPredefinedStaticColor.Location = new System.Drawing.Point(825, 630);
      this.btnRemoveLedPredefinedStaticColor.Name = "btnRemoveLedPredefinedStaticColor";
      this.btnRemoveLedPredefinedStaticColor.Size = new System.Drawing.Size(112, 23);
      this.btnRemoveLedPredefinedStaticColor.TabIndex = 1224;
      this.btnRemoveLedPredefinedStaticColor.Text = "remove static color";
      this.btnRemoveLedPredefinedStaticColor.UseVisualStyleBackColor = true;
      this.btnRemoveLedPredefinedStaticColor.Click += new System.EventHandler(this.btnRemoveLedPredefinedStaticColor_Click);
      // 
      // btnRemoveLedLocation
      // 
      this.btnRemoveLedLocation.Location = new System.Drawing.Point(446, 630);
      this.btnRemoveLedLocation.Name = "btnRemoveLedLocation";
      this.btnRemoveLedLocation.Size = new System.Drawing.Size(112, 23);
      this.btnRemoveLedLocation.TabIndex = 1213;
      this.btnRemoveLedLocation.Text = "remove location";
      this.btnRemoveLedLocation.UseVisualStyleBackColor = true;
      this.btnRemoveLedLocation.Click += new System.EventHandler(this.btnRemoveLedLocation_Click);
      // 
      // label25
      // 
      this.label25.AutoSize = true;
      this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label25.Location = new System.Drawing.Point(899, 436);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(15, 13);
      this.label25.TabIndex = 1220;
      this.label25.Text = "B";
      // 
      // label26
      // 
      this.label26.AutoSize = true;
      this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label26.Location = new System.Drawing.Point(831, 436);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(16, 13);
      this.label26.TabIndex = 1219;
      this.label26.Text = "G";
      // 
      // label27
      // 
      this.label27.AutoSize = true;
      this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label27.Location = new System.Drawing.Point(760, 436);
      this.label27.Name = "label27";
      this.label27.Size = new System.Drawing.Size(16, 13);
      this.label27.TabIndex = 1218;
      this.label27.Text = "R";
      // 
      // tbPredefinedColorB
      // 
      this.tbPredefinedColorB.Location = new System.Drawing.Point(917, 433);
      this.tbPredefinedColorB.Name = "tbPredefinedColorB";
      this.tbPredefinedColorB.Size = new System.Drawing.Size(48, 20);
      this.tbPredefinedColorB.TabIndex = 1223;
      // 
      // tbPredefinedColorG
      // 
      this.tbPredefinedColorG.Location = new System.Drawing.Point(850, 433);
      this.tbPredefinedColorG.Name = "tbPredefinedColorG";
      this.tbPredefinedColorG.Size = new System.Drawing.Size(48, 20);
      this.tbPredefinedColorG.TabIndex = 1222;
      // 
      // label28
      // 
      this.label28.AutoSize = true;
      this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label28.Location = new System.Drawing.Point(681, 436);
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size(77, 13);
      this.label28.TabIndex = 1217;
      this.label28.Text = "Static Color:";
      // 
      // tbPredefinedColorR
      // 
      this.tbPredefinedColorR.Location = new System.Drawing.Point(781, 433);
      this.tbPredefinedColorR.Name = "tbPredefinedColorR";
      this.tbPredefinedColorR.Size = new System.Drawing.Size(48, 20);
      this.tbPredefinedColorR.TabIndex = 1221;
      // 
      // lblPredefinedStaticColorName
      // 
      this.lblPredefinedStaticColorName.AutoSize = true;
      this.lblPredefinedStaticColorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPredefinedStaticColorName.Location = new System.Drawing.Point(681, 408);
      this.lblPredefinedStaticColorName.Name = "lblPredefinedStaticColorName";
      this.lblPredefinedStaticColorName.Size = new System.Drawing.Size(43, 13);
      this.lblPredefinedStaticColorName.TabIndex = 1215;
      this.lblPredefinedStaticColorName.Text = "Name:";
      // 
      // tbPredefinedStaticColorName
      // 
      this.tbPredefinedStaticColorName.Location = new System.Drawing.Point(781, 405);
      this.tbPredefinedStaticColorName.Name = "tbPredefinedStaticColorName";
      this.tbPredefinedStaticColorName.Size = new System.Drawing.Size(126, 20);
      this.tbPredefinedStaticColorName.TabIndex = 1216;
      // 
      // lblAddLedPriority
      // 
      this.lblAddLedPriority.AutoSize = true;
      this.lblAddLedPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAddLedPriority.Location = new System.Drawing.Point(347, 433);
      this.lblAddLedPriority.Name = "lblAddLedPriority";
      this.lblAddLedPriority.Size = new System.Drawing.Size(50, 13);
      this.lblAddLedPriority.TabIndex = 1214;
      this.lblAddLedPriority.Text = "Priority:";
      // 
      // lblAddLedLocation
      // 
      this.lblAddLedLocation.AutoSize = true;
      this.lblAddLedLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAddLedLocation.Location = new System.Drawing.Point(347, 405);
      this.lblAddLedLocation.Name = "lblAddLedLocation";
      this.lblAddLedLocation.Size = new System.Drawing.Size(60, 13);
      this.lblAddLedLocation.TabIndex = 1212;
      this.lblAddLedLocation.Text = "Location:";
      // 
      // tbLedLocationPriority
      // 
      this.tbLedLocationPriority.Location = new System.Drawing.Point(416, 430);
      this.tbLedLocationPriority.Name = "tbLedLocationPriority";
      this.tbLedLocationPriority.Size = new System.Drawing.Size(124, 20);
      this.tbLedLocationPriority.TabIndex = 1213;
      // 
      // tbLedLocation
      // 
      this.tbLedLocation.Location = new System.Drawing.Point(416, 402);
      this.tbLedLocation.Name = "tbLedLocation";
      this.tbLedLocation.Size = new System.Drawing.Size(124, 20);
      this.tbLedLocation.TabIndex = 1212;
      // 
      // btnAddPredefinedStaticColor
      // 
      this.btnAddPredefinedStaticColor.Location = new System.Drawing.Point(981, 408);
      this.btnAddPredefinedStaticColor.Name = "btnAddPredefinedStaticColor";
      this.btnAddPredefinedStaticColor.Size = new System.Drawing.Size(107, 48);
      this.btnAddPredefinedStaticColor.TabIndex = 23;
      this.btnAddPredefinedStaticColor.Text = "Add static color";
      this.btnAddPredefinedStaticColor.UseVisualStyleBackColor = true;
      this.btnAddPredefinedStaticColor.Click += new System.EventHandler(this.btnAddPredefinedStaticColor_Click);
      // 
      // btnAddLedLocation
      // 
      this.btnAddLedLocation.Location = new System.Drawing.Point(546, 401);
      this.btnAddLedLocation.Name = "btnAddLedLocation";
      this.btnAddLedLocation.Size = new System.Drawing.Size(107, 48);
      this.btnAddLedLocation.TabIndex = 22;
      this.btnAddLedLocation.Text = "Add LED location";
      this.btnAddLedLocation.UseVisualStyleBackColor = true;
      this.btnAddLedLocation.Click += new System.EventHandler(this.btnAddLedLocation_Click);
      // 
      // btnLedStaticColorDOWN
      // 
      this.btnLedStaticColorDOWN.Location = new System.Drawing.Point(1014, 630);
      this.btnLedStaticColorDOWN.Name = "btnLedStaticColorDOWN";
      this.btnLedStaticColorDOWN.Size = new System.Drawing.Size(75, 23);
      this.btnLedStaticColorDOWN.TabIndex = 21;
      this.btnLedStaticColorDOWN.Text = "DOWN";
      this.btnLedStaticColorDOWN.UseVisualStyleBackColor = true;
      this.btnLedStaticColorDOWN.Visible = false;
      this.btnLedStaticColorDOWN.Click += new System.EventHandler(this.btnLedStaticColorDOWN_Click);
      // 
      // btnLedStaticColorUP
      // 
      this.btnLedStaticColorUP.Location = new System.Drawing.Point(680, 630);
      this.btnLedStaticColorUP.Name = "btnLedStaticColorUP";
      this.btnLedStaticColorUP.Size = new System.Drawing.Size(75, 23);
      this.btnLedStaticColorUP.TabIndex = 20;
      this.btnLedStaticColorUP.Text = "UP";
      this.btnLedStaticColorUP.UseVisualStyleBackColor = true;
      this.btnLedStaticColorUP.Visible = false;
      this.btnLedStaticColorUP.Click += new System.EventHandler(this.btnLedStaticColorUP_Click);
      // 
      // btnLedLocationDOWN
      // 
      this.btnLedLocationDOWN.Location = new System.Drawing.Point(581, 630);
      this.btnLedLocationDOWN.Name = "btnLedLocationDOWN";
      this.btnLedLocationDOWN.Size = new System.Drawing.Size(75, 23);
      this.btnLedLocationDOWN.TabIndex = 19;
      this.btnLedLocationDOWN.Text = "DOWN";
      this.btnLedLocationDOWN.UseVisualStyleBackColor = true;
      this.btnLedLocationDOWN.Visible = false;
      this.btnLedLocationDOWN.Click += new System.EventHandler(this.btnLedLocationDOWN_Click);
      // 
      // btnLedLocationUP
      // 
      this.btnLedLocationUP.Location = new System.Drawing.Point(347, 630);
      this.btnLedLocationUP.Name = "btnLedLocationUP";
      this.btnLedLocationUP.Size = new System.Drawing.Size(75, 23);
      this.btnLedLocationUP.TabIndex = 18;
      this.btnLedLocationUP.Text = "UP";
      this.btnLedLocationUP.UseVisualStyleBackColor = true;
      this.btnLedLocationUP.Visible = false;
      this.btnLedLocationUP.Click += new System.EventHandler(this.btnLedLocationUP_Click);
      // 
      // grpPredefinedStaticColors
      // 
      this.grpPredefinedStaticColors.Controls.Add(this.lvPredefinedStaticColors);
      this.grpPredefinedStaticColors.Location = new System.Drawing.Point(680, 459);
      this.grpPredefinedStaticColors.Name = "grpPredefinedStaticColors";
      this.grpPredefinedStaticColors.Size = new System.Drawing.Size(412, 165);
      this.grpPredefinedStaticColors.TabIndex = 17;
      this.grpPredefinedStaticColors.TabStop = false;
      this.grpPredefinedStaticColors.Text = "Predefined statis colors (for use in group commands)";
      // 
      // lvPredefinedStaticColors
      // 
      this.lvPredefinedStaticColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPredefinedStaticColorName,
            this.chPredefinedStaticColorRGB});
      this.lvPredefinedStaticColors.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvPredefinedStaticColors.Location = new System.Drawing.Point(3, 16);
      this.lvPredefinedStaticColors.Name = "lvPredefinedStaticColors";
      this.lvPredefinedStaticColors.Size = new System.Drawing.Size(406, 146);
      this.lvPredefinedStaticColors.TabIndex = 0;
      this.lvPredefinedStaticColors.UseCompatibleStateImageBehavior = false;
      this.lvPredefinedStaticColors.View = System.Windows.Forms.View.Details;
      // 
      // chPredefinedStaticColorName
      // 
      this.chPredefinedStaticColorName.Text = "Color name";
      this.chPredefinedStaticColorName.Width = 154;
      // 
      // chPredefinedStaticColorRGB
      // 
      this.chPredefinedStaticColorRGB.Text = "RGB value";
      this.chPredefinedStaticColorRGB.Width = 191;
      // 
      // grpLedLocations
      // 
      this.grpLedLocations.Controls.Add(this.lvLedLocations);
      this.grpLedLocations.Location = new System.Drawing.Point(347, 455);
      this.grpLedLocations.Name = "grpLedLocations";
      this.grpLedLocations.Size = new System.Drawing.Size(309, 169);
      this.grpLedLocations.TabIndex = 16;
      this.grpLedLocations.TabStop = false;
      this.grpLedLocations.Text = "Led Locations";
      // 
      // lvLedLocations
      // 
      this.lvLedLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLedLocationName,
            this.chLedLocationPriority});
      this.lvLedLocations.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvLedLocations.Location = new System.Drawing.Point(3, 16);
      this.lvLedLocations.Name = "lvLedLocations";
      this.lvLedLocations.Size = new System.Drawing.Size(303, 150);
      this.lvLedLocations.TabIndex = 0;
      this.lvLedLocations.UseCompatibleStateImageBehavior = false;
      this.lvLedLocations.View = System.Windows.Forms.View.Details;
      // 
      // chLedLocationName
      // 
      this.chLedLocationName.Text = "Location";
      this.chLedLocationName.Width = 193;
      // 
      // chLedLocationPriority
      // 
      this.chLedLocationPriority.Text = "Priority";
      this.chLedLocationPriority.Width = 104;
      // 
      // btnLedItemDown
      // 
      this.btnLedItemDown.Location = new System.Drawing.Point(1014, 379);
      this.btnLedItemDown.Name = "btnLedItemDown";
      this.btnLedItemDown.Size = new System.Drawing.Size(75, 23);
      this.btnLedItemDown.TabIndex = 15;
      this.btnLedItemDown.Text = "DOWN";
      this.btnLedItemDown.UseVisualStyleBackColor = true;
      this.btnLedItemDown.Visible = false;
      this.btnLedItemDown.Click += new System.EventHandler(this.btnLedItemDown_Click);
      // 
      // btnLedItemUp
      // 
      this.btnLedItemUp.Location = new System.Drawing.Point(347, 373);
      this.btnLedItemUp.Name = "btnLedItemUp";
      this.btnLedItemUp.Size = new System.Drawing.Size(75, 23);
      this.btnLedItemUp.TabIndex = 14;
      this.btnLedItemUp.Text = "UP";
      this.btnLedItemUp.UseVisualStyleBackColor = true;
      this.btnLedItemUp.Visible = false;
      this.btnLedItemUp.Click += new System.EventHandler(this.btnLedItemUp_Click);
      // 
      // gbManageLeds
      // 
      this.gbManageLeds.Controls.Add(this.cbLedLocation);
      this.gbManageLeds.Controls.Add(this.lblLedLocation);
      this.gbManageLeds.Controls.Add(this.btnRemoveLeds);
      this.gbManageLeds.Controls.Add(this.cbLedType);
      this.gbManageLeds.Controls.Add(this.gbLedOptional);
      this.gbManageLeds.Controls.Add(this.btnAddLed);
      this.gbManageLeds.Controls.Add(this.lblLedType);
      this.gbManageLeds.Controls.Add(this.lblLedID);
      this.gbManageLeds.Controls.Add(this.tbLedID);
      this.gbManageLeds.Location = new System.Drawing.Point(19, 18);
      this.gbManageLeds.Name = "gbManageLeds";
      this.gbManageLeds.Size = new System.Drawing.Size(322, 606);
      this.gbManageLeds.TabIndex = 13;
      this.gbManageLeds.TabStop = false;
      this.gbManageLeds.Text = "Manage leds";
      // 
      // cbLedLocation
      // 
      this.cbLedLocation.FormattingEnabled = true;
      this.cbLedLocation.Location = new System.Drawing.Point(143, 104);
      this.cbLedLocation.Name = "cbLedLocation";
      this.cbLedLocation.Size = new System.Drawing.Size(121, 21);
      this.cbLedLocation.TabIndex = 1212;
      // 
      // lblLedLocation
      // 
      this.lblLedLocation.AutoSize = true;
      this.lblLedLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedLocation.Location = new System.Drawing.Point(6, 97);
      this.lblLedLocation.Name = "lblLedLocation";
      this.lblLedLocation.Size = new System.Drawing.Size(60, 13);
      this.lblLedLocation.TabIndex = 30;
      this.lblLedLocation.Text = "Location:";
      // 
      // btnRemoveLeds
      // 
      this.btnRemoveLeds.Location = new System.Drawing.Point(105, 529);
      this.btnRemoveLeds.Name = "btnRemoveLeds";
      this.btnRemoveLeds.Size = new System.Drawing.Size(112, 51);
      this.btnRemoveLeds.TabIndex = 1211;
      this.btnRemoveLeds.Text = "Remove Led";
      this.btnRemoveLeds.UseVisualStyleBackColor = true;
      this.btnRemoveLeds.Click += new System.EventHandler(this.btnRemoveLeds_Click);
      // 
      // cbLedType
      // 
      this.cbLedType.FormattingEnabled = true;
      this.cbLedType.Items.AddRange(new object[] {
            "Bloom",
            "Bulb",
            "Iris",
            "Strips"});
      this.cbLedType.Location = new System.Drawing.Point(143, 61);
      this.cbLedType.Name = "cbLedType";
      this.cbLedType.Size = new System.Drawing.Size(121, 21);
      this.cbLedType.TabIndex = 1201;
      // 
      // gbLedOptional
      // 
      this.gbLedOptional.Controls.Add(this.lblLedSendDelay);
      this.gbLedOptional.Controls.Add(this.lblLedHue);
      this.gbLedOptional.Controls.Add(this.tbLedSendDelay);
      this.gbLedOptional.Controls.Add(this.tbLedHue);
      this.gbLedOptional.Controls.Add(this.tbLedBrightness);
      this.gbLedOptional.Controls.Add(this.lblLedColorTemperature);
      this.gbLedOptional.Controls.Add(this.lblLedBrightness);
      this.gbLedOptional.Controls.Add(this.lblLedB);
      this.gbLedOptional.Controls.Add(this.tbLedColorTemperature);
      this.gbLedOptional.Controls.Add(this.tbLedSaturation);
      this.gbLedOptional.Controls.Add(this.lblLedG);
      this.gbLedOptional.Controls.Add(this.lnlLedSaturation);
      this.gbLedOptional.Controls.Add(this.tbLedB);
      this.gbLedOptional.Controls.Add(this.lblLedR);
      this.gbLedOptional.Controls.Add(this.tbLedR);
      this.gbLedOptional.Controls.Add(this.lblLedStaticColor);
      this.gbLedOptional.Controls.Add(this.tbLedG);
      this.gbLedOptional.Location = new System.Drawing.Point(9, 131);
      this.gbLedOptional.Name = "gbLedOptional";
      this.gbLedOptional.Size = new System.Drawing.Size(307, 284);
      this.gbLedOptional.TabIndex = 27;
      this.gbLedOptional.TabStop = false;
      this.gbLedOptional.Text = "Optional";
      // 
      // lblLedSendDelay
      // 
      this.lblLedSendDelay.AutoSize = true;
      this.lblLedSendDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedSendDelay.Location = new System.Drawing.Point(6, 28);
      this.lblLedSendDelay.Name = "lblLedSendDelay";
      this.lblLedSendDelay.Size = new System.Drawing.Size(92, 13);
      this.lblLedSendDelay.TabIndex = 18;
      this.lblLedSendDelay.Text = "Color transition";
      // 
      // lblLedHue
      // 
      this.lblLedHue.AutoSize = true;
      this.lblLedHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedHue.Location = new System.Drawing.Point(6, 209);
      this.lblLedHue.Name = "lblLedHue";
      this.lblLedHue.Size = new System.Drawing.Size(34, 13);
      this.lblLedHue.TabIndex = 25;
      this.lblLedHue.Text = "Hue:";
      this.lblLedHue.Visible = false;
      // 
      // tbLedSendDelay
      // 
      this.tbLedSendDelay.Location = new System.Drawing.Point(134, 25);
      this.tbLedSendDelay.Name = "tbLedSendDelay";
      this.tbLedSendDelay.Size = new System.Drawing.Size(100, 20);
      this.tbLedSendDelay.TabIndex = 304;
      // 
      // tbLedHue
      // 
      this.tbLedHue.Location = new System.Drawing.Point(134, 206);
      this.tbLedHue.Name = "tbLedHue";
      this.tbLedHue.Size = new System.Drawing.Size(100, 20);
      this.tbLedHue.TabIndex = 1206;
      this.tbLedHue.Visible = false;
      // 
      // tbLedBrightness
      // 
      this.tbLedBrightness.Location = new System.Drawing.Point(134, 70);
      this.tbLedBrightness.Name = "tbLedBrightness";
      this.tbLedBrightness.Size = new System.Drawing.Size(100, 20);
      this.tbLedBrightness.TabIndex = 1203;
      // 
      // lblLedColorTemperature
      // 
      this.lblLedColorTemperature.AutoSize = true;
      this.lblLedColorTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedColorTemperature.Location = new System.Drawing.Point(6, 165);
      this.lblLedColorTemperature.Name = "lblLedColorTemperature";
      this.lblLedColorTemperature.Size = new System.Drawing.Size(115, 13);
      this.lblLedColorTemperature.TabIndex = 23;
      this.lblLedColorTemperature.Text = "Color Temperature:";
      // 
      // lblLedBrightness
      // 
      this.lblLedBrightness.AutoSize = true;
      this.lblLedBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedBrightness.Location = new System.Drawing.Point(6, 73);
      this.lblLedBrightness.Name = "lblLedBrightness";
      this.lblLedBrightness.Size = new System.Drawing.Size(70, 13);
      this.lblLedBrightness.TabIndex = 19;
      this.lblLedBrightness.Text = "Brightness:";
      // 
      // lblLedB
      // 
      this.lblLedB.AutoSize = true;
      this.lblLedB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedB.Location = new System.Drawing.Point(225, 250);
      this.lblLedB.Name = "lblLedB";
      this.lblLedB.Size = new System.Drawing.Size(15, 13);
      this.lblLedB.TabIndex = 32;
      this.lblLedB.Text = "B";
      // 
      // tbLedColorTemperature
      // 
      this.tbLedColorTemperature.Location = new System.Drawing.Point(134, 162);
      this.tbLedColorTemperature.Name = "tbLedColorTemperature";
      this.tbLedColorTemperature.Size = new System.Drawing.Size(100, 20);
      this.tbLedColorTemperature.TabIndex = 1205;
      // 
      // tbLedSaturation
      // 
      this.tbLedSaturation.Location = new System.Drawing.Point(134, 114);
      this.tbLedSaturation.Name = "tbLedSaturation";
      this.tbLedSaturation.Size = new System.Drawing.Size(100, 20);
      this.tbLedSaturation.TabIndex = 1204;
      // 
      // lblLedG
      // 
      this.lblLedG.AutoSize = true;
      this.lblLedG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedG.Location = new System.Drawing.Point(157, 250);
      this.lblLedG.Name = "lblLedG";
      this.lblLedG.Size = new System.Drawing.Size(16, 13);
      this.lblLedG.TabIndex = 31;
      this.lblLedG.Text = "G";
      // 
      // lnlLedSaturation
      // 
      this.lnlLedSaturation.AutoSize = true;
      this.lnlLedSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lnlLedSaturation.Location = new System.Drawing.Point(6, 117);
      this.lnlLedSaturation.Name = "lnlLedSaturation";
      this.lnlLedSaturation.Size = new System.Drawing.Size(69, 13);
      this.lnlLedSaturation.TabIndex = 21;
      this.lnlLedSaturation.Text = "Saturation:";
      // 
      // tbLedB
      // 
      this.tbLedB.Location = new System.Drawing.Point(243, 247);
      this.tbLedB.Name = "tbLedB";
      this.tbLedB.Size = new System.Drawing.Size(48, 20);
      this.tbLedB.TabIndex = 1209;
      // 
      // lblLedR
      // 
      this.lblLedR.AutoSize = true;
      this.lblLedR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedR.Location = new System.Drawing.Point(86, 250);
      this.lblLedR.Name = "lblLedR";
      this.lblLedR.Size = new System.Drawing.Size(16, 13);
      this.lblLedR.TabIndex = 30;
      this.lblLedR.Text = "R";
      // 
      // tbLedR
      // 
      this.tbLedR.Location = new System.Drawing.Point(107, 247);
      this.tbLedR.Name = "tbLedR";
      this.tbLedR.Size = new System.Drawing.Size(48, 20);
      this.tbLedR.TabIndex = 1207;
      // 
      // lblLedStaticColor
      // 
      this.lblLedStaticColor.AutoSize = true;
      this.lblLedStaticColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedStaticColor.Location = new System.Drawing.Point(7, 250);
      this.lblLedStaticColor.Name = "lblLedStaticColor";
      this.lblLedStaticColor.Size = new System.Drawing.Size(73, 13);
      this.lblLedStaticColor.TabIndex = 27;
      this.lblLedStaticColor.Text = "Static Color";
      // 
      // tbLedG
      // 
      this.tbLedG.Location = new System.Drawing.Point(176, 247);
      this.tbLedG.Name = "tbLedG";
      this.tbLedG.Size = new System.Drawing.Size(48, 20);
      this.tbLedG.TabIndex = 1208;
      // 
      // btnAddLed
      // 
      this.btnAddLed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnAddLed.Location = new System.Drawing.Point(52, 441);
      this.btnAddLed.Name = "btnAddLed";
      this.btnAddLed.Size = new System.Drawing.Size(225, 59);
      this.btnAddLed.TabIndex = 1210;
      this.btnAddLed.Text = "Add Led";
      this.btnAddLed.UseVisualStyleBackColor = true;
      this.btnAddLed.Click += new System.EventHandler(this.btnAddLed_Click);
      // 
      // lblLedType
      // 
      this.lblLedType.AutoSize = true;
      this.lblLedType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedType.Location = new System.Drawing.Point(6, 61);
      this.lblLedType.Name = "lblLedType";
      this.lblLedType.Size = new System.Drawing.Size(39, 13);
      this.lblLedType.TabIndex = 17;
      this.lblLedType.Text = "Type:";
      // 
      // lblLedID
      // 
      this.lblLedID.AutoSize = true;
      this.lblLedID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLedID.Location = new System.Drawing.Point(7, 25);
      this.lblLedID.Name = "lblLedID";
      this.lblLedID.Size = new System.Drawing.Size(24, 13);
      this.lblLedID.TabIndex = 16;
      this.lblLedID.Text = "ID:";
      // 
      // tbLedID
      // 
      this.tbLedID.Location = new System.Drawing.Point(143, 25);
      this.tbLedID.Name = "tbLedID";
      this.tbLedID.Size = new System.Drawing.Size(100, 20);
      this.tbLedID.TabIndex = 1200;
      // 
      // lvLedDevices
      // 
      this.lvLedDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chType,
            this.chLedLocation,
            this.chLedDelay,
            this.chLedBrightness,
            this.chLedSaturation,
            this.chLedColorTemperature,
            this.chLedHue,
            this.chLedStaticColor});
      this.lvLedDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lvLedDevices.Location = new System.Drawing.Point(347, 19);
      this.lvLedDevices.Name = "lvLedDevices";
      this.lvLedDevices.Size = new System.Drawing.Size(745, 348);
      this.lvLedDevices.TabIndex = 11;
      this.lvLedDevices.UseCompatibleStateImageBehavior = false;
      this.lvLedDevices.View = System.Windows.Forms.View.Details;
      // 
      // chID
      // 
      this.chID.Text = "ID";
      this.chID.Width = 66;
      // 
      // chType
      // 
      this.chType.Text = "Type";
      this.chType.Width = 88;
      // 
      // chLedLocation
      // 
      this.chLedLocation.Text = "Location";
      this.chLedLocation.Width = 76;
      // 
      // chLedDelay
      // 
      this.chLedDelay.Text = "Send delay";
      this.chLedDelay.Width = 71;
      // 
      // chLedBrightness
      // 
      this.chLedBrightness.Text = "Brightness";
      this.chLedBrightness.Width = 75;
      // 
      // chLedSaturation
      // 
      this.chLedSaturation.Text = "Saturation";
      this.chLedSaturation.Width = 80;
      // 
      // chLedColorTemperature
      // 
      this.chLedColorTemperature.Text = "Color Temperature";
      this.chLedColorTemperature.Width = 105;
      // 
      // chLedHue
      // 
      this.chLedHue.Text = "Hue";
      this.chLedHue.Width = 56;
      // 
      // chLedStaticColor
      // 
      this.chLedStaticColor.Text = "Static Color";
      this.chLedStaticColor.Width = 100;
      // 
      // tabPageTesting
      // 
      this.tabPageTesting.BackColor = System.Drawing.SystemColors.Control;
      this.tabPageTesting.Controls.Add(this.gbColorTests);
      this.tabPageTesting.Location = new System.Drawing.Point(4, 22);
      this.tabPageTesting.Name = "tabPageTesting";
      this.tabPageTesting.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageTesting.Size = new System.Drawing.Size(1100, 714);
      this.tabPageTesting.TabIndex = 1;
      this.tabPageTesting.Text = "Testing";
      // 
      // gbColorTests
      // 
      this.gbColorTests.Controls.Add(this.lblTestHueBrightness);
      this.gbColorTests.Controls.Add(this.btnTestHueBrightness);
      this.gbColorTests.Controls.Add(this.cbTestHueBrightness);
      this.gbColorTests.Controls.Add(this.label2);
      this.gbColorTests.Controls.Add(this.cbTestCustomColorB);
      this.gbColorTests.Controls.Add(this.tbRotateTestDelay);
      this.gbColorTests.Controls.Add(this.cbTestCustomColorG);
      this.gbColorTests.Controls.Add(this.label6);
      this.gbColorTests.Controls.Add(this.cbTestCustomColorR);
      this.gbColorTests.Controls.Add(this.btnHueColorRotateTestStart);
      this.gbColorTests.Controls.Add(this.label22);
      this.gbColorTests.Controls.Add(this.btnHueColorRotateTestStop);
      this.gbColorTests.Controls.Add(this.label23);
      this.gbColorTests.Controls.Add(this.btnHueSendCustomColor);
      this.gbColorTests.Controls.Add(this.label24);
      this.gbColorTests.Controls.Add(this.lblHueCustomColorTest);
      this.gbColorTests.Controls.Add(this.btnHueColorClear);
      this.gbColorTests.Controls.Add(this.btnTestRed);
      this.gbColorTests.Controls.Add(this.btnTestBlue);
      this.gbColorTests.Controls.Add(this.btnTestGreen);
      this.gbColorTests.Location = new System.Drawing.Point(17, 21);
      this.gbColorTests.Name = "gbColorTests";
      this.gbColorTests.Size = new System.Drawing.Size(619, 304);
      this.gbColorTests.TabIndex = 511;
      this.gbColorTests.TabStop = false;
      this.gbColorTests.Text = "Color tests";
      // 
      // lblTestHueBrightness
      // 
      this.lblTestHueBrightness.AutoSize = true;
      this.lblTestHueBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTestHueBrightness.Location = new System.Drawing.Point(23, 220);
      this.lblTestHueBrightness.Name = "lblTestHueBrightness";
      this.lblTestHueBrightness.Size = new System.Drawing.Size(97, 13);
      this.lblTestHueBrightness.TabIndex = 513;
      this.lblTestHueBrightness.Text = "Hue Brightness:";
      // 
      // btnTestHueBrightness
      // 
      this.btnTestHueBrightness.Location = new System.Drawing.Point(285, 217);
      this.btnTestHueBrightness.Name = "btnTestHueBrightness";
      this.btnTestHueBrightness.Size = new System.Drawing.Size(75, 23);
      this.btnTestHueBrightness.TabIndex = 512;
      this.btnTestHueBrightness.Text = "Test";
      this.btnTestHueBrightness.UseVisualStyleBackColor = true;
      this.btnTestHueBrightness.Click += new System.EventHandler(this.btnTestHueBrightness_Click);
      // 
      // cbTestHueBrightness
      // 
      this.cbTestHueBrightness.FormattingEnabled = true;
      this.cbTestHueBrightness.Location = new System.Drawing.Point(179, 217);
      this.cbTestHueBrightness.Name = "cbTestHueBrightness";
      this.cbTestHueBrightness.Size = new System.Drawing.Size(100, 21);
      this.cbTestHueBrightness.TabIndex = 511;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(23, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 13);
      this.label2.TabIndex = 68;
      this.label2.Text = "Color test:";
      // 
      // cbTestCustomColorB
      // 
      this.cbTestCustomColorB.FormattingEnabled = true;
      this.cbTestCustomColorB.Location = new System.Drawing.Point(352, 104);
      this.cbTestCustomColorB.Name = "cbTestCustomColorB";
      this.cbTestCustomColorB.Size = new System.Drawing.Size(62, 21);
      this.cbTestCustomColorB.Sorted = true;
      this.cbTestCustomColorB.TabIndex = 506;
      this.cbTestCustomColorB.Validating += new System.ComponentModel.CancelEventHandler(this.cbTestCustomColorB_Validating);
      // 
      // tbRotateTestDelay
      // 
      this.tbRotateTestDelay.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AtmoHue.Properties.Settings.Default, "HueRotateDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbRotateTestDelay.Location = new System.Drawing.Point(179, 162);
      this.tbRotateTestDelay.Name = "tbRotateTestDelay";
      this.tbRotateTestDelay.Size = new System.Drawing.Size(100, 20);
      this.tbRotateTestDelay.TabIndex = 508;
      this.tbRotateTestDelay.Text = global::AtmoHue.Properties.Settings.Default.HueRotateDelay;
      // 
      // cbTestCustomColorG
      // 
      this.cbTestCustomColorG.FormattingEnabled = true;
      this.cbTestCustomColorG.Location = new System.Drawing.Point(263, 104);
      this.cbTestCustomColorG.Name = "cbTestCustomColorG";
      this.cbTestCustomColorG.Size = new System.Drawing.Size(62, 21);
      this.cbTestCustomColorG.TabIndex = 505;
      this.cbTestCustomColorG.Validating += new System.ComponentModel.CancelEventHandler(this.cbTestCustomColorG_Validating);
      // 
      // cbTestCustomColorR
      // 
      this.cbTestCustomColorR.FormattingEnabled = true;
      this.cbTestCustomColorR.Location = new System.Drawing.Point(179, 104);
      this.cbTestCustomColorR.Name = "cbTestCustomColorR";
      this.cbTestCustomColorR.Size = new System.Drawing.Size(62, 21);
      this.cbTestCustomColorR.TabIndex = 504;
      this.cbTestCustomColorR.Validating += new System.ComponentModel.CancelEventHandler(this.cbTestCustomColorR_Validating);
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label22.Location = new System.Drawing.Point(331, 107);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(15, 13);
      this.label22.TabIndex = 509;
      this.label22.Text = "B";
      // 
      // label23
      // 
      this.label23.AutoSize = true;
      this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label23.Location = new System.Drawing.Point(245, 107);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(16, 13);
      this.label23.TabIndex = 508;
      this.label23.Text = "G";
      // 
      // label24
      // 
      this.label24.AutoSize = true;
      this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label24.Location = new System.Drawing.Point(157, 107);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(16, 13);
      this.label24.TabIndex = 507;
      this.label24.Text = "R";
      // 
      // btnHueColorClear
      // 
      this.btnHueColorClear.Location = new System.Drawing.Point(352, 36);
      this.btnHueColorClear.Name = "btnHueColorClear";
      this.btnHueColorClear.Size = new System.Drawing.Size(92, 23);
      this.btnHueColorClear.TabIndex = 503;
      this.btnHueColorClear.Text = "CLEAR/RESET";
      this.btnHueColorClear.UseVisualStyleBackColor = true;
      this.btnHueColorClear.Click += new System.EventHandler(this.btnHueColorClear_Click);
      // 
      // btnTestRed
      // 
      this.btnTestRed.Location = new System.Drawing.Point(94, 36);
      this.btnTestRed.Name = "btnTestRed";
      this.btnTestRed.Size = new System.Drawing.Size(75, 23);
      this.btnTestRed.TabIndex = 500;
      this.btnTestRed.Text = "RED";
      this.btnTestRed.UseVisualStyleBackColor = true;
      this.btnTestRed.Click += new System.EventHandler(this.btnTestRed_Click);
      // 
      // btnTestBlue
      // 
      this.btnTestBlue.Location = new System.Drawing.Point(256, 36);
      this.btnTestBlue.Name = "btnTestBlue";
      this.btnTestBlue.Size = new System.Drawing.Size(75, 23);
      this.btnTestBlue.TabIndex = 502;
      this.btnTestBlue.Text = "BLUE";
      this.btnTestBlue.UseVisualStyleBackColor = true;
      this.btnTestBlue.Click += new System.EventHandler(this.btnTestBlue_Click);
      // 
      // btnTestGreen
      // 
      this.btnTestGreen.Location = new System.Drawing.Point(175, 36);
      this.btnTestGreen.Name = "btnTestGreen";
      this.btnTestGreen.Size = new System.Drawing.Size(75, 23);
      this.btnTestGreen.TabIndex = 501;
      this.btnTestGreen.Text = "GREEN";
      this.btnTestGreen.UseVisualStyleBackColor = true;
      this.btnTestGreen.Click += new System.EventHandler(this.btnTestGreen_Click);
      // 
      // tabPageExperimental
      // 
      this.tabPageExperimental.BackColor = System.Drawing.SystemColors.Control;
      this.tabPageExperimental.Controls.Add(this.btnGetLedIDs);
      this.tabPageExperimental.Controls.Add(this.gbHueSceneTester);
      this.tabPageExperimental.Controls.Add(this.gbColorCalibration);
      this.tabPageExperimental.Controls.Add(this.grpAtmowin);
      this.tabPageExperimental.Location = new System.Drawing.Point(4, 22);
      this.tabPageExperimental.Name = "tabPageExperimental";
      this.tabPageExperimental.Size = new System.Drawing.Size(1100, 714);
      this.tabPageExperimental.TabIndex = 2;
      this.tabPageExperimental.Text = "Experimental";
      // 
      // btnGetLedIDs
      // 
      this.btnGetLedIDs.Location = new System.Drawing.Point(808, 244);
      this.btnGetLedIDs.Name = "btnGetLedIDs";
      this.btnGetLedIDs.Size = new System.Drawing.Size(242, 65);
      this.btnGetLedIDs.TabIndex = 50;
      this.btnGetLedIDs.Text = "Get LED Ids";
      this.btnGetLedIDs.UseVisualStyleBackColor = true;
      this.btnGetLedIDs.Click += new System.EventHandler(this.btnGetLedIDs_Click);
      // 
      // gbHueSceneTester
      // 
      this.gbHueSceneTester.Controls.Add(this.label21);
      this.gbHueSceneTester.Controls.Add(this.lblHueSceneID);
      this.gbHueSceneTester.Controls.Add(this.btnHueSetScene);
      this.gbHueSceneTester.Controls.Add(this.tbHueSceneName);
      this.gbHueSceneTester.Controls.Add(this.tbHueSceneID);
      this.gbHueSceneTester.Controls.Add(this.btnHueLocateScenes);
      this.gbHueSceneTester.Location = new System.Drawing.Point(808, 23);
      this.gbHueSceneTester.Name = "gbHueSceneTester";
      this.gbHueSceneTester.Size = new System.Drawing.Size(261, 188);
      this.gbHueSceneTester.TabIndex = 49;
      this.gbHueSceneTester.TabStop = false;
      this.gbHueSceneTester.Text = "Scene debug";
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Location = new System.Drawing.Point(7, 136);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(67, 13);
      this.label21.TabIndex = 5;
      this.label21.Text = "Scene name";
      // 
      // lblHueSceneID
      // 
      this.lblHueSceneID.AutoSize = true;
      this.lblHueSceneID.Location = new System.Drawing.Point(7, 99);
      this.lblHueSceneID.Name = "lblHueSceneID";
      this.lblHueSceneID.Size = new System.Drawing.Size(52, 13);
      this.lblHueSceneID.TabIndex = 4;
      this.lblHueSceneID.Text = "Scene ID";
      // 
      // btnHueSetScene
      // 
      this.btnHueSetScene.Location = new System.Drawing.Point(176, 96);
      this.btnHueSetScene.Name = "btnHueSetScene";
      this.btnHueSetScene.Size = new System.Drawing.Size(79, 57);
      this.btnHueSetScene.TabIndex = 3;
      this.btnHueSetScene.Text = "Set Scene";
      this.btnHueSetScene.UseVisualStyleBackColor = true;
      this.btnHueSetScene.Click += new System.EventHandler(this.btnHueSetScene_Click);
      // 
      // tbHueSceneName
      // 
      this.tbHueSceneName.Location = new System.Drawing.Point(76, 133);
      this.tbHueSceneName.Name = "tbHueSceneName";
      this.tbHueSceneName.Size = new System.Drawing.Size(74, 20);
      this.tbHueSceneName.TabIndex = 2;
      // 
      // tbHueSceneID
      // 
      this.tbHueSceneID.Location = new System.Drawing.Point(76, 96);
      this.tbHueSceneID.Name = "tbHueSceneID";
      this.tbHueSceneID.Size = new System.Drawing.Size(74, 20);
      this.tbHueSceneID.TabIndex = 1;
      // 
      // btnHueLocateScenes
      // 
      this.btnHueLocateScenes.Location = new System.Drawing.Point(7, 32);
      this.btnHueLocateScenes.Name = "btnHueLocateScenes";
      this.btnHueLocateScenes.Size = new System.Drawing.Size(235, 33);
      this.btnHueLocateScenes.TabIndex = 0;
      this.btnHueLocateScenes.Text = "Retrieve scenes from bridge and log";
      this.btnHueLocateScenes.UseVisualStyleBackColor = true;
      this.btnHueLocateScenes.Click += new System.EventHandler(this.btnHueLocateScenes_Click);
      // 
      // gbColorCalibration
      // 
      this.gbColorCalibration.Controls.Add(this.label7);
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
      this.gbColorCalibration.Location = new System.Drawing.Point(4, 228);
      this.gbColorCalibration.Name = "gbColorCalibration";
      this.gbColorCalibration.Size = new System.Drawing.Size(788, 317);
      this.gbColorCalibration.TabIndex = 48;
      this.gbColorCalibration.TabStop = false;
      this.gbColorCalibration.Text = "Color Calibrations";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(508, 16);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(274, 65);
      this.label7.TabIndex = 79;
      this.label7.Text = "Defaults:\r\n\r\nX = Red 0.649926 / Green  0.103455 / Blue  0.197109\r\nY = Red 0.23432" +
    "7 / Green  0.743075 / Blue  0.022598\r\nZ = Red 0.0000000 / Green  0.053077 / Blue" +
    "  1.035763\r\n";
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
      // tbZBlue
      // 
      this.tbZBlue.Location = new System.Drawing.Point(346, 194);
      this.tbZBlue.Name = "tbZBlue";
      this.tbZBlue.Size = new System.Drawing.Size(74, 20);
      this.tbZBlue.TabIndex = 59;
      this.tbZBlue.Text = "1.835763";
      this.tbZBlue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbZBlue_KeyDown);
      // 
      // tbZGreen
      // 
      this.tbZGreen.Location = new System.Drawing.Point(243, 194);
      this.tbZGreen.Name = "tbZGreen";
      this.tbZGreen.Size = new System.Drawing.Size(74, 20);
      this.tbZGreen.TabIndex = 58;
      this.tbZGreen.Text = "0.053077";
      this.tbZGreen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbZGreen_KeyDown);
      // 
      // tbZRed
      // 
      this.tbZRed.Location = new System.Drawing.Point(148, 194);
      this.tbZRed.Name = "tbZRed";
      this.tbZRed.Size = new System.Drawing.Size(74, 20);
      this.tbZRed.TabIndex = 57;
      this.tbZRed.Text = "0.0000000";
      this.tbZRed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbZRed_KeyDown);
      // 
      // tbYBlue
      // 
      this.tbYBlue.Location = new System.Drawing.Point(346, 155);
      this.tbYBlue.Name = "tbYBlue";
      this.tbYBlue.Size = new System.Drawing.Size(74, 20);
      this.tbYBlue.TabIndex = 56;
      this.tbYBlue.Text = "0.022598";
      this.tbYBlue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbYBlue_KeyDown);
      // 
      // tbYGreen
      // 
      this.tbYGreen.Location = new System.Drawing.Point(243, 155);
      this.tbYGreen.Name = "tbYGreen";
      this.tbYGreen.Size = new System.Drawing.Size(74, 20);
      this.tbYGreen.TabIndex = 55;
      this.tbYGreen.Text = "0.743075";
      this.tbYGreen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbYGreen_KeyDown);
      // 
      // tbYRed
      // 
      this.tbYRed.Location = new System.Drawing.Point(148, 155);
      this.tbYRed.Name = "tbYRed";
      this.tbYRed.Size = new System.Drawing.Size(74, 20);
      this.tbYRed.TabIndex = 54;
      this.tbYRed.Text = "0.234327";
      this.tbYRed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbYRed_KeyDown);
      // 
      // tbXBlue
      // 
      this.tbXBlue.Location = new System.Drawing.Point(346, 114);
      this.tbXBlue.Name = "tbXBlue";
      this.tbXBlue.Size = new System.Drawing.Size(74, 20);
      this.tbXBlue.TabIndex = 53;
      this.tbXBlue.Text = "0.197109";
      this.tbXBlue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbXBlue_KeyDown);
      // 
      // tbXGreen
      // 
      this.tbXGreen.Location = new System.Drawing.Point(243, 114);
      this.tbXGreen.Name = "tbXGreen";
      this.tbXGreen.Size = new System.Drawing.Size(74, 20);
      this.tbXGreen.TabIndex = 52;
      this.tbXGreen.Text = "0.103455";
      this.tbXGreen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbXGreen_KeyDown);
      // 
      // tbXRed
      // 
      this.tbXRed.Location = new System.Drawing.Point(148, 114);
      this.tbXRed.Name = "tbXRed";
      this.tbXRed.Size = new System.Drawing.Size(74, 20);
      this.tbXRed.TabIndex = 51;
      this.tbXRed.Text = "0.649926";
      this.tbXRed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbXRed_KeyDown);
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
      // trayIconHue
      // 
      this.trayIconHue.ContextMenuStrip = this.trayIconHueContextMenu;
      this.trayIconHue.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIconHue.Icon")));
      this.trayIconHue.Text = "AtmoHue";
      this.trayIconHue.Visible = true;
      this.trayIconHue.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
      // 
      // trayIconHueContextMenu
      // 
      this.trayIconHueContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.toolStripSeparator1,
            this.toolStripMenuItemClose});
      this.trayIconHueContextMenu.Name = "trayIconHueContextMenu";
      this.trayIconHueContextMenu.Size = new System.Drawing.Size(104, 54);
      // 
      // toolStripMenuItemOpen
      // 
      this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
      this.toolStripMenuItemOpen.Size = new System.Drawing.Size(103, 22);
      this.toolStripMenuItemOpen.Text = "Open";
      this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
      // 
      // toolStripMenuItemClose
      // 
      this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
      this.toolStripMenuItemClose.Size = new System.Drawing.Size(103, 22);
      this.toolStripMenuItemClose.Text = "Exit";
      this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(1108, 740);
      this.Controls.Add(this.tabControl1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.Text = "Atmo Hue";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.gbBridgeTools.ResumeLayout(false);
      this.gbBridgeTools.PerformLayout();
      this.grpAtmowin.ResumeLayout(false);
      this.grpAtmowin.PerformLayout();
      this.grpRemoteAPI.ResumeLayout(false);
      this.grpRemoteAPI.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPageGeneral.ResumeLayout(false);
      this.tabPageGeneral.PerformLayout();
      this.gbLogOutput.ResumeLayout(false);
      this.gbHueSettings.ResumeLayout(false);
      this.gbHueSettings.PerformLayout();
      this.tabPageLeds.ResumeLayout(false);
      this.tabPageLeds.PerformLayout();
      this.grpPredefinedStaticColors.ResumeLayout(false);
      this.grpLedLocations.ResumeLayout(false);
      this.gbManageLeds.ResumeLayout(false);
      this.gbManageLeds.PerformLayout();
      this.gbLedOptional.ResumeLayout(false);
      this.gbLedOptional.PerformLayout();
      this.tabPageTesting.ResumeLayout(false);
      this.gbColorTests.ResumeLayout(false);
      this.gbColorTests.PerformLayout();
      this.tabPageExperimental.ResumeLayout(false);
      this.gbHueSceneTester.ResumeLayout(false);
      this.gbHueSceneTester.PerformLayout();
      this.gbColorCalibration.ResumeLayout(false);
      this.gbColorCalibration.PerformLayout();
      this.trayIconHueContextMenu.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLocateHueBridge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAtmoWinFolder;
        private System.Windows.Forms.TextBox tbHueBridgeIP;
        private System.Windows.Forms.TextBox tbAtmowinLocation;
        private System.Windows.Forms.CheckBox cbRunningWindows8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHueAppName;
        private System.Windows.Forms.TextBox tbHueAppKey;
        private System.Windows.Forms.Button btnStartAtmowinHue;
        private System.Windows.Forms.TextBox tbAtmowinScanInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.ComboBox cbHueBrightness;
        private System.Windows.Forms.Label lblHueSaturation;
        private System.Windows.Forms.Label lblHueTransTime;
        private System.Windows.Forms.Label lblHueHue;
        private System.Windows.Forms.Label lblHueCustomColorTest;
        private System.Windows.Forms.Button btnHueSendCustomColor;
        private System.Windows.Forms.Button btnHueColorRotateTestStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRotateTestDelay;
        private System.Windows.Forms.Button btnHueColorRotateTestStop;
        private System.Windows.Forms.CheckBox cbEnableDebuglog;
        private System.Windows.Forms.Label lblAtmoinPresetColor;
        private System.Windows.Forms.TextBox tbAtmowinStaticColor;
        private System.Windows.Forms.Button btnStopAtmowinHue;
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
        private System.Windows.Forms.Label lblHueColorTemperature;
        private System.Windows.Forms.GroupBox gbColorCalibration;
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
        private System.Windows.Forms.CheckBox cbHueSetBrightnessStartup;
        private System.Windows.Forms.TabPage tabPageLeds;
        private System.Windows.Forms.ListView lvLedDevices;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chLedDelay;
        private System.Windows.Forms.ColumnHeader chLedBrightness;
        private System.Windows.Forms.GroupBox gbManageLeds;
        private System.Windows.Forms.TextBox tbLedBrightness;
        private System.Windows.Forms.TextBox tbLedSendDelay;
        private System.Windows.Forms.TextBox tbLedID;
        private System.Windows.Forms.Label lblLedBrightness;
        private System.Windows.Forms.Label lblLedSendDelay;
        private System.Windows.Forms.Label lblLedType;
        private System.Windows.Forms.Label lblLedID;
        private System.Windows.Forms.Label lblLedColorTemperature;
        private System.Windows.Forms.TextBox tbLedColorTemperature;
        private System.Windows.Forms.Label lnlLedSaturation;
        private System.Windows.Forms.TextBox tbLedSaturation;
        private System.Windows.Forms.Button btnAddLed;
        private System.Windows.Forms.GroupBox gbLedOptional;
        private System.Windows.Forms.ColumnHeader chLedSaturation;
        private System.Windows.Forms.ColumnHeader chLedColorTemperature;
        private System.Windows.Forms.ColumnHeader chLedHue;
        private System.Windows.Forms.ComboBox cbLedType;
        private System.Windows.Forms.Button btnLedItemDown;
        private System.Windows.Forms.Button btnLedItemUp;
        private System.Windows.Forms.Button btnRemoveLeds;
        private System.Windows.Forms.ComboBox cbHueHue;
        private System.Windows.Forms.ComboBox cbHueColorTemperature;
        private System.Windows.Forms.ComboBox cbHueTransitionTime;
        private System.Windows.Forms.ComboBox cbHueSaturation;
        private System.Windows.Forms.GroupBox gbHueSceneTester;
        private System.Windows.Forms.TextBox tbHueSceneID;
        private System.Windows.Forms.Button btnHueLocateScenes;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblHueSceneID;
        private System.Windows.Forms.Button btnHueSetScene;
        private System.Windows.Forms.TextBox tbHueSceneName;
        private System.Windows.Forms.Label lblLedLocation;
        private System.Windows.Forms.ColumnHeader chLedLocation;
        private System.Windows.Forms.Label lblLedHue;
        private System.Windows.Forms.TextBox tbLedHue;
        private System.Windows.Forms.ColumnHeader chLedStaticColor;
        private System.Windows.Forms.Label lblLedB;
        private System.Windows.Forms.Label lblLedG;
        private System.Windows.Forms.Label lblLedR;
        private System.Windows.Forms.TextBox tbLedB;
        private System.Windows.Forms.TextBox tbLedG;
        private System.Windows.Forms.Label lblLedStaticColor;
        private System.Windows.Forms.TextBox tbLedR;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cbTestCustomColorB;
        private System.Windows.Forms.ComboBox cbTestCustomColorG;
        private System.Windows.Forms.ComboBox cbTestCustomColorR;
        private System.Windows.Forms.GroupBox gbHueSettings;
        private System.Windows.Forms.GroupBox gbColorTests;
        private System.Windows.Forms.NotifyIcon trayIconHue;
        private System.Windows.Forms.CheckBox cbMinimizeOnStartup;
        private System.Windows.Forms.CheckBox cbMinimizeToTray;
        private System.Windows.Forms.ContextMenuStrip trayIconHueContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
        private System.Windows.Forms.ComboBox cbHuePowerHandling;
        private System.Windows.Forms.Label lblHuePowerHandling;
        private System.Windows.Forms.Button btnGetLedIDs;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lCopyright;
        private System.Windows.Forms.LinkLabel llQ42;
        private System.Windows.Forms.GroupBox gbLogOutput;
        private System.Windows.Forms.ListBox lbOutputlog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
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
        private System.Windows.Forms.CheckBox cbEnableIndividualLightSettings;
        private System.Windows.Forms.Button btnLedStaticColorDOWN;
        private System.Windows.Forms.Button btnLedStaticColorUP;
        private System.Windows.Forms.Button btnLedLocationDOWN;
        private System.Windows.Forms.Button btnLedLocationUP;
        private System.Windows.Forms.GroupBox grpPredefinedStaticColors;
        private System.Windows.Forms.ListView lvPredefinedStaticColors;
        private System.Windows.Forms.ColumnHeader chPredefinedStaticColorName;
        private System.Windows.Forms.ColumnHeader chPredefinedStaticColorRGB;
        private System.Windows.Forms.GroupBox grpLedLocations;
        private System.Windows.Forms.ListView lvLedLocations;
        private System.Windows.Forms.ColumnHeader chLedLocationName;
        private System.Windows.Forms.ColumnHeader chLedLocationPriority;
        private System.Windows.Forms.Label lblAddLedPriority;
        private System.Windows.Forms.Label lblAddLedLocation;
        private System.Windows.Forms.TextBox tbLedLocationPriority;
        private System.Windows.Forms.TextBox tbLedLocation;
        private System.Windows.Forms.Button btnAddPredefinedStaticColor;
        private System.Windows.Forms.Button btnAddLedLocation;
        private System.Windows.Forms.Label lblPredefinedStaticColorName;
        private System.Windows.Forms.TextBox tbPredefinedStaticColorName;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbPredefinedColorB;
        private System.Windows.Forms.TextBox tbPredefinedColorG;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbPredefinedColorR;
        private System.Windows.Forms.ComboBox cbLedLocation;
        private System.Windows.Forms.Button btnRemoveLedPredefinedStaticColor;
        private System.Windows.Forms.Button btnRemoveLedLocation;
        private System.Windows.Forms.ComboBox cbTestHueBrightness;
        private System.Windows.Forms.Label lblTestHueBrightness;
        private System.Windows.Forms.Button btnTestHueBrightness;
    }
}

