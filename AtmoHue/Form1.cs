using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AtmoHue.Properties;
using Microsoft.Win32;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models;
using Q42.HueApi.NET;

namespace AtmoHue
{
  public partial class Form1 : Form
  {
    public enum DeviceType
    {
      Bloom,
      Bulb,
      Iris,
      Strips,
      Unknown
    }

    public enum Sources
    {
      Atmolight,
      Huehelper,
      Local
    }

    public static string RemoteApIip = "127.0.0.1";
    public static string RemoteApIport = "20123";
    public static string RemoteApiSendDelay = "300";
    public static bool LogRemoteApiCalls;
    public string AtmowinLocation = "";
    public string AtmowinScanInterval = "";
    public string AtmowinStaticColor = "";
    public string CalibrateXblue = "";
    public string CalibrateXgreen = "";
    public string CalibrateXred = "";
    public string CalibrateYblue = "";
    public string CalibrateYgreen = "";
    public string CalibrateYred = "";
    public string CalibrateZblue = "";
    public string CalibrateZgreen = "";
    public string CalibrateZred = "";
    private ILocalHueClient _client;
    public bool ColorCommand = false;
    public bool ColorisOn;

    public List<string> CommandCache = new List<string>();
    public bool EnableIndividualLightSettings;
    private bool _groupFilterActive;
    public string HueAppKey = "AmtoHueAppKey";
    public string HueAppName = "AtmoHue";
    public bool HueAutoconnectBridge;
    public string HueBridgeIp = "127.0.0.1";
    public string HueBrightness = "100";
    public string HueColorTemperature = "";
    public string HueHue = "";
    public string HueOutputDevices = "";
    public int HuePowerHandling;
    public bool HueRemoteApIenabled;
    public int HueRotateDelay = 1000;

    // HUE
    public bool HueRotatingColors;
    public bool HueRunningWindows8;
    public string HueSaturation = "100";
    public bool HueSetBrightnessStartup;
    public string HueTransitiontime = "100";
    public bool IsConnectedToBridge;

    public List<LedDevice> LedDevices = new List<LedDevice>();
    public List<LedDevice> LedDevicesGroupFilter = new List<LedDevice>();
    public List<LedDevice> LedDevicesGroupStaticColors = new List<LedDevice>();

    public List<LedLocation> LedLocations = new List<LedLocation>();
    public List<LEDPredefinedStaticColors> LedPredefinedStaticColors = new List<LEDPredefinedStaticColors>();
    private Thread _listenThread;

    // Various
    public bool MinimizeOnStartup;
    public bool MinimizeToTray;

    // Atmowin
    public bool ScanAtmowin;
    private readonly Stopwatch _swRemoteApi = new Stopwatch();


    // API
    private TcpListener _tcpListener;
    public bool UserEditedSettings;

    public bool WaitTimer;


    public Form1()
    {
      InitializeComponent();

      //Close program if already running
      if (IsProgramRunning("AtmoHue", 0) > 1)
      {
        Environment.Exit(0);
      }

      //Load settings
      LoadSettings(true);

      if (MinimizeOnStartup)
      {
        FormBorderStyle = FormBorderStyle.SizableToolWindow;
        WindowState = FormWindowState.Minimized;
        Visible = false;
        ShowInTaskbar = false;
      }
      //Start remote server if enabled
      if (HueRemoteApIenabled)
      {
        StartApIserver();
      }

      //Find bridge on startup for TESTING
      if (string.IsNullOrEmpty(HueBridgeIp))
      {
        if (HueRunningWindows8 == false)
        {
          BridgeLocator();
        }
        else
        {
          SsdpBridgeLocator();
        }
      }

      //Create some default combobox values
      cbHueBrightness.Items.Clear();
      var maxBrightness = 500;
      var counter = 0;

      while (counter != maxBrightness)
      {
        cbHueBrightness.Items.Add(counter);
        counter++;
      }

      //Create some default combobox values
      SetDefaultCombBoxValues(cbHueBrightness, 0, 254);
      SetDefaultCombBoxValues(cbHueSaturation, 0, 254);
      SetDefaultCombBoxValues(cbHueColorTemperature, 154, 500);
      SetDefaultCombBoxValues(cbHueTransitionTime, 100, 5000);
      SetDefaultCombBoxValues(cbHueHue, 0, 254);
      SetDefaultCombBoxValues(cbTestCustomColorR, 0, 255);
      SetDefaultCombBoxValues(cbTestCustomColorG, 0, 254);
      SetDefaultCombBoxValues(cbTestCustomColorB, 0, 254);
      SetDefaultCombBoxValues(cbTestHueBrightness, 0, 254);

      ReInitialize("");
      IsInitialized(true);

      // Monitor power state
      MonitorPowerState();

      //Set window title
      Text = FormatTitle();

      //Set link label for copyright
      var link = new LinkLabel.Link();
      link.LinkData = "https://github.com/Q42/Q42.HueApi";
      llQ42.Links.Add(link);
    }

    public static int IsProgramRunning(string name, int runtime)
    {
      foreach (var clsProcess in Process.GetProcesses())
      {
        if (clsProcess.ProcessName.ToLower().Equals(name.ToLower()))
        {
          //Console.WriteLine(clsProcess.ProcessName.ToLower().ToString());
          runtime++;
        }
      }
      return runtime;
    }

    public async Task<bool> IsInitialized(bool updateLabels)
    {
      var isConnected = false;

      if (_client != null)
      {
        isConnected = await _client.CheckConnection();
      }

      if (updateLabels)
      {
        if (isConnected)
        {
          Logger("Hue bridge has been intialized");
          Logger("Connection to bridge was successful");
          lblConnectionStatus.Text = "Status: Connected";
        }
        else
        {
          Logger("Hue bridge failed to intialize");
          Logger("Connection to bridge was successful");
          lblConnectionStatus.Text = "Status: Disconnected";
        }
      }

      IsConnectedToBridge = isConnected;

      return isConnected;
    }

    private void ReInitialize(string logMessage)
    {
      _client = new LocalHueClient(HueBridgeIp.Replace(":80", "").Trim());

      try
      {
        _client.Initialize(HueAppKey);

        if (!string.IsNullOrEmpty(logMessage))
        {
          Logger(logMessage);
        }
      }
      catch (Exception et)
      {
        if (cbEnableDebuglog.Checked)
        {
          Logger(et.ToString());
        }
      }
    }

    private void SetDefaultCombBoxValues(ComboBox cb, int min, int max)
    {
      cb.Items.Clear();

      while (min <= max)
      {
        cb.Items.Add(min);
        min++;
      }
    }

    private void LoadSettings(bool init)
    {
      try
      {
        //Clear listviews comboxes on startup to prevent duplicates
        lvLedDevices.Items.Clear();
        lvLedLocations.Items.Clear();
        lvPredefinedStaticColors.Items.Clear();
        cbLedLocation.Items.Clear();

        if (File.Exists("settings.xml"))
        {
          using (var reader = XmlReader.Create("settings.xml"))
          {
            while (reader.Read())
            {
              // HUE
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueBridgeIP"))
              {
                HueBridgeIp = reader.ReadString();
                if (init)
                {
                  tbHueBridgeIP.Text = HueBridgeIp.Replace(":80", string.Empty).Trim();
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueAppname"))
              {
                HueAppName = reader.ReadString();
                if (init)
                {
                  tbHueAppName.Text = HueAppName;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueAppKey"))
              {
                HueAppKey = reader.ReadString();
                if (init)
                {
                  tbHueAppKey.Text = HueAppKey;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueBrightness"))
              {
                HueBrightness = reader.ReadString();
                if (init)
                {
                  cbHueBrightness.Text = HueBrightness;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueSaturation"))
              {
                HueSaturation = reader.ReadString();
                if (init)
                {
                  cbHueSaturation.Text = HueSaturation;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueTransitionTime"))
              {
                HueTransitiontime = reader.ReadString();
                if (init)
                {
                  cbHueTransitionTime.Text = HueTransitiontime;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueColorTemperature"))
              {
                HueColorTemperature = reader.ReadString();
                if (init)
                {
                  cbHueColorTemperature.Text = HueColorTemperature;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueHue"))
              {
                HueHue = reader.ReadString();
                if (init)
                {
                  cbHueHue.Text = HueHue;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueSetBrightnessStartup"))
              {
                HueSetBrightnessStartup = bool.Parse(reader.ReadString());
                if (init)
                {
                  cbHueSetBrightnessStartup.Checked = HueSetBrightnessStartup;
                }
              }


              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueRunningWindows8"))
              {
                HueRunningWindows8 = bool.Parse(reader.ReadString());
                if (init)
                {
                  cbRunningWindows8.Checked = HueRunningWindows8;
                }
              }

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueAutoConnectBridge"))
              {
                HueAutoconnectBridge = bool.Parse(reader.ReadString());
                if (init)
                {
                  cbAutoConnectBridge.Checked = HueAutoconnectBridge;
                }
              }


              // Remote API
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "RemoteAPIenabled"))
              {
                HueRemoteApIenabled = bool.Parse(reader.ReadString());
                if (init)
                {
                  cbRemoteAPIEnabled.Checked = HueRemoteApIenabled;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "RemoteAPIIP"))
              {
                RemoteApIip = reader.ReadString();
                if (init)
                {
                  tbRemoteAPIip.Text = RemoteApIip;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "RemoteAPIPort"))
              {
                RemoteApIport = reader.ReadString();
                if (init)
                {
                  tbRemoteApiPort.Text = RemoteApIport;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "RemoteAPISenDelay"))
              {
                RemoteApiSendDelay = reader.ReadString();
                if (init)
                {
                  tbRemoteAPIsendDelay.Text = RemoteApiSendDelay;
                }
              }

              // Various
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "MinimizeToTray"))
              {
                MinimizeToTray = bool.Parse(reader.ReadString());
                if (init)
                {
                  cbMinimizeToTray.Checked = MinimizeToTray;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "MinimizeToTrayOnStartup"))
              {
                MinimizeOnStartup = bool.Parse(reader.ReadString());
                if (init)
                {
                  cbMinimizeOnStartup.Checked = MinimizeOnStartup;
                }
              }

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HuePowerHandling"))
              {
                HuePowerHandling = int.Parse(reader.ReadString());
                if (init)
                {
                  cbHuePowerHandling.SelectedIndex = HuePowerHandling;
                }
              }

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "EnableIndividualLightSettings"))
              {
                EnableIndividualLightSettings = bool.Parse(reader.ReadString());
                if (init)
                {
                  cbEnableIndividualLightSettings.Checked = EnableIndividualLightSettings;
                }
              }

              // LED devices
              var id = "";
              var type = "";
              var location = "";
              var sendDelay = "";
              var brightness = "";
              var saturation = "";
              var colorTemperature = "";
              var hue = "";
              var staticColors = "";

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "LED"))
              {
                reader.ReadToDescendant("ID");
                id = reader.ReadString();
                reader.ReadToFollowing("Type");
                type = reader.ReadString();
                reader.ReadToFollowing("Location");
                location = reader.ReadString();
                reader.ReadToFollowing("SendDelay");
                sendDelay = reader.ReadString();
                reader.ReadToFollowing("Brightness");
                brightness = reader.ReadString();
                reader.ReadToFollowing("Saturation");
                saturation = reader.ReadString();
                reader.ReadToFollowing("ColorTemperature");
                colorTemperature = reader.ReadString();
                reader.ReadToFollowing("Hue");
                hue = reader.ReadString();
                reader.ReadToFollowing("StaticColor");
                staticColors = reader.ReadString();

                //Add LED ID to devices list
                if (string.IsNullOrEmpty(id.Trim()) == false)
                {
                  var ld = new LedDevice();
                  ld.Id = id;
                  ld.location = location;
                  ld.SendDelay = sendDelay;
                  ld.Brightness = brightness;
                  ld.Saturation = saturation;
                  ld.ColorTemperature = colorTemperature;
                  ld.Hue = hue;
                  ld.StaticColor = staticColors;
                  LedDevices.Add(ld);
                  LedDevicesGroupFilter.Add(ld);

                  string[] subItems =
                  {
                    type, location, sendDelay, brightness, saturation, colorTemperature, hue,
                    staticColors
                  };
                  lvLedDevices.Items.Add(id).SubItems.AddRange(subItems);
                }
              }

              // LED Locations
              var ledLocation = "";
              var ledPriority = "";

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "LedLocation"))
              {
                reader.ReadToDescendant("Location");
                ledLocation = reader.ReadString();
                reader.ReadToFollowing("Priority");
                ledPriority = reader.ReadString();

                //Add LED ID to devices list
                if (string.IsNullOrEmpty(ledLocation.Trim()) == false)
                {
                  var ll = new LedLocation();
                  ll.Location = ledLocation;
                  ll.Priority = ledPriority;

                  LedLocations.Add(ll);

                  string[] subItems = {ledPriority};
                  lvLedLocations.Items.Add(ledLocation).SubItems.AddRange(subItems);

                  //Add item to combobox
                  cbLedLocation.Items.Add(ledLocation);
                }
              }

              // LED predefined static colors
              var ledPredefinedColorName = "";
              var ledPredefinedColorRgb = "";

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "LedStaticColor"))
              {
                reader.ReadToDescendant("Name");
                ledPredefinedColorName = reader.ReadString();
                reader.ReadToFollowing("StaticColor");
                ledPredefinedColorRgb = reader.ReadString();

                //Add LED ID to devices list
                if (string.IsNullOrEmpty(ledPredefinedColorName.Trim()) == false)
                {
                  var lpsc = new LEDPredefinedStaticColors();
                  lpsc.ColorName = ledPredefinedColorName;
                  lpsc.RgBvalue = ledPredefinedColorRgb;

                  LedPredefinedStaticColors.Add(lpsc);

                  string[] subItems = {ledPredefinedColorRgb};
                  lvPredefinedStaticColors.Items.Add(ledPredefinedColorName).SubItems.AddRange(subItems);
                }
              }

              // Atmowin
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "AtmowinLocation"))
              {
                AtmowinLocation = reader.ReadString();
                if (init)
                {
                  tbAtmowinLocation.Text = AtmowinLocation;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "AtmoWinScanInterval"))
              {
                AtmowinScanInterval = reader.ReadString();
                if (init)
                {
                  tbAtmowinScanInterval.Text = AtmowinScanInterval;
                }
              }

              //Color calibrations

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "XRed"))
              {
                CalibrateXred = reader.ReadString();

                if (init)
                {
                  tbXRed.Text = CalibrateXred;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "YRed"))
              {
                CalibrateYred = reader.ReadString();
                if (init)
                {
                  tbYRed.Text = CalibrateYred;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ZRed"))
              {
                CalibrateZred = reader.ReadString();
                if (init)
                {
                  tbZRed.Text = CalibrateZred;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "XGreen"))
              {
                CalibrateXgreen = reader.ReadString();
                if (init)
                {
                  tbXGreen.Text = CalibrateXgreen;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "YGreen"))
              {
                CalibrateYgreen = reader.ReadString();
                if (init)
                {
                  tbYGreen.Text = CalibrateYgreen;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ZGreen"))
              {
                CalibrateZgreen = reader.ReadString();
                if (init)
                {
                  tbZGreen.Text = CalibrateZgreen;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "XBlue"))
              {
                CalibrateXblue = reader.ReadString();
                if (init)
                {
                  tbXBlue.Text = CalibrateXblue;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "YBlue"))
              {
                CalibrateYblue = reader.ReadString();
                if (init)
                {
                  tbYBlue.Text = CalibrateYblue;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ZBlue"))
              {
                CalibrateZblue = reader.ReadString();
                if (init)
                {
                  tbZBlue.Text = CalibrateZblue;
                }
              }
            }
          }
        }
      }
      catch (Exception e)
      {
        if (init)
        {
          //If checkboxes are being set during first init it might cause a file level lock which is normal
        }
      }
    }

    private void SaveSettings(bool init)
    {
      try
      {
        Settings.Default.Save();

        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "  ";
        settings.NewLineOnAttributes = true;

        using (var writer = XmlWriter.Create("settings.xml", settings))
        {
          writer.WriteStartDocument();
          writer.WriteStartElement("Settings");
          writer.WriteStartElement("General");
          writer.WriteElementString("HueBridgeIP", tbHueBridgeIP.Text);
          writer.WriteElementString("HueAppname", tbHueAppName.Text);
          writer.WriteElementString("HueAppKey", tbHueAppKey.Text);
          writer.WriteElementString("HueBrightness", cbHueBrightness.Text);
          writer.WriteElementString("HueSaturation", cbHueSaturation.Text);
          writer.WriteElementString("HueTransitionTime", cbHueTransitionTime.Text);
          writer.WriteElementString("HueColorTemperature", cbHueColorTemperature.Text);
          writer.WriteElementString("HueHue", cbHueHue.Text);
          writer.WriteElementString("HueSetBrightnessStartup", cbHueSetBrightnessStartup.Checked.ToString());
          writer.WriteElementString("HueRunningWindows8", cbRunningWindows8.Checked.ToString());
          writer.WriteElementString("HueAutoConnectBridge", cbAutoConnectBridge.Checked.ToString());
          writer.WriteElementString("RemoteAPIenabled", cbRemoteAPIEnabled.Checked.ToString());
          writer.WriteElementString("RemoteAPIIP", tbRemoteAPIip.Text);
          writer.WriteElementString("RemoteAPIPort", tbRemoteApiPort.Text);
          writer.WriteElementString("MinimizeToTray", cbMinimizeToTray.Checked.ToString());
          writer.WriteElementString("MinimizeToTrayOnStartup", cbMinimizeOnStartup.Checked.ToString());
          writer.WriteElementString("RemoteAPISenDelay", tbRemoteAPIsendDelay.Text);
          writer.WriteElementString("HuePowerHandling", cbHuePowerHandling.SelectedIndex.ToString());
          writer.WriteElementString("EnableIndividualLightSettings", cbEnableIndividualLightSettings.Checked.ToString());

          writer.WriteEndElement();

          writer.WriteStartElement("LedDevices");

          foreach (ListViewItem device in lvLedDevices.Items)
          {
            if (string.IsNullOrEmpty(device.Text) == false)
            {
              writer.WriteStartElement("LED");
              try
              {
                writer.WriteElementString("ID", device.Text);
                writer.WriteElementString("Type", device.SubItems[1].Text);
                writer.WriteElementString("Location", device.SubItems[2].Text);
                writer.WriteElementString("SendDelay", device.SubItems[3].Text);
                writer.WriteElementString("Brightness", device.SubItems[4].Text);
                writer.WriteElementString("Saturation", device.SubItems[5].Text);
                writer.WriteElementString("ColorTemperature", device.SubItems[6].Text);
                writer.WriteElementString("Hue", device.SubItems[7].Text);
                writer.WriteElementString("StaticColor", device.SubItems[8].Text);
              }
              catch
              {
              }
              ;

              writer.WriteEndElement();
            }
          }
          writer.WriteEndElement();


          writer.WriteStartElement("LedLocations");

          foreach (ListViewItem location in lvLedLocations.Items)
          {
            if (string.IsNullOrEmpty(location.Text) == false)
            {
              writer.WriteStartElement("LedLocation");
              try
              {
                writer.WriteElementString("Location", location.Text);
                writer.WriteElementString("Priority", location.SubItems[1].Text);
              }
              catch
              {
              }
              ;

              writer.WriteEndElement();
            }
          }
          writer.WriteEndElement();


          writer.WriteStartElement("LedPredefinedStaticColors");

          foreach (ListViewItem staticColor in lvPredefinedStaticColors.Items)
          {
            if (string.IsNullOrEmpty(staticColor.Text) == false)
            {
              writer.WriteStartElement("LedStaticColor");
              try
              {
                writer.WriteElementString("Name", staticColor.Text);
                writer.WriteElementString("StaticColor", staticColor.SubItems[1].Text);
              }
              catch
              {
              }
              ;

              writer.WriteEndElement();
            }
          }
          writer.WriteEndElement();


          writer.WriteStartElement("Atmowin");
          writer.WriteElementString("AtmowinLocation", tbAtmowinLocation.Text);
          writer.WriteElementString("AtmoWinScanInterval", tbAtmowinScanInterval.Text);
          writer.WriteEndElement();

          writer.WriteStartElement("ColorCalibrations");
          writer.WriteElementString("XRed", tbXRed.Text);
          writer.WriteElementString("YRed", tbYRed.Text);
          writer.WriteElementString("ZRed", tbZRed.Text);
          writer.WriteElementString("XGreen", tbXGreen.Text);
          writer.WriteElementString("YGreen", tbYGreen.Text);
          writer.WriteElementString("ZGreen", tbZGreen.Text);
          writer.WriteElementString("XBlue", tbXBlue.Text);
          writer.WriteElementString("YBlue", tbYBlue.Text);
          writer.WriteElementString("ZBlue", tbZBlue.Text);

          writer.WriteEndElement();

          writer.WriteEndElement();
          writer.WriteEndDocument();
        }
      }
      catch (Exception et)
      {
        if (init)
        {
          //If checkboxes are being set during first init it might cause a file level lock which is normal
        }
      }
    }

    private void RefreshSettings()
    {
      UserEditedSettings = true;
      SaveSettings(false);
      LoadSettings(true);
    }

    public static string FormatTitle()
    {
      var title = AssemblyInfo.AssemblyInfoLookUp.Title;
      var version = AssemblyInfo.AssemblyInfoLookUp.VersionFull;
      var copyright = AssemblyInfo.AssemblyInfoLookUp.Copyright;

      var formattedTitle = string.Format("{0} - {1} - {2}", title, version, copyright);
      return formattedTitle;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveSettings(false);
      ScanAtmowin = false;
      trayIconHue.Dispose();
      Application.ExitThread();
      Environment.Exit(0);
    }

    public static void ControlInvike(Control control, Action function)
    {
      if (control.IsDisposed || control.Disposing)
        return;

      if (control.InvokeRequired)
      {
        control.Invoke(new UniversalVoidDelegate(() => ControlInvike(control, function)));
        return;
      }
      function();
    }

    public void StartApIserver()
    {
      _swRemoteApi.Start();
      if (RemoteApIip == "Any")
      {
        _tcpListener = new TcpListener(IPAddress.Any, int.Parse(RemoteApIport));
      }
      else
      {
        var ip = IPAddress.Parse(RemoteApIip);
        _tcpListener = new TcpListener(ip, int.Parse(RemoteApIport));
      }

      _listenThread = new Thread(ListenForClients);
      _listenThread.Start();
      Logger("Started service for remote API calls");
    }

    private void ListenForClients()
    {
      _tcpListener.Start();
      while (true)
      {
        //blocks until a client has connected to the server
        var client = _tcpListener.AcceptTcpClient();

        //create a thread to handle communication 
        //with connected client
        var clientThread = new Thread(HandleClientComm);
        clientThread.Start(client);
      }
    }

    private void HandleClientComm(object client)
    {
      var tcpClient = (TcpClient) client;
      var clientStream = tcpClient.GetStream();

      var message = new byte[4096];
      int bytesRead;

      while (true)
      {
        bytesRead = 0;

        try
        {
          //blocks until a client sends a message
          bytesRead = clientStream.Read(message, 0, 4096);
        }
        catch
        {
          //a socket error has occured
          break;
        }

        if (bytesRead == 0)
        {
          //the client has disconnected from the server
          break;
        }

        //message has successfully been received
        var encoder = new ASCIIEncoding();
        var apiCommandMessage = encoder.GetString(message, 0, bytesRead);
        try
        {
          //Get command type
          var apiMessageSplit = apiCommandMessage.Split(',');
          var commandSender = apiMessageSplit[0];
          var commandType = apiMessageSplit[1];


          //Command type COLOR
          if (commandType == ApIcommandType.Color.ToString())
          {
            var red = int.Parse(apiMessageSplit[2]);
            var green = int.Parse(apiMessageSplit[3]);
            var blue = int.Parse(apiMessageSplit[4]);
            var priority = int.Parse(apiMessageSplit[5]);

            var inputColor = Color.FromArgb(red, green, blue);

            //Only send if delay has expired or if we get a high priority color
            if (_swRemoteApi.ElapsedMilliseconds >= int.Parse(RemoteApiSendDelay) || priority < 50)
            {
              if (LogRemoteApiCalls)
              {
                Logger(string.Format("[ {0} ] [ PRIO {1} ] - {2}", commandSender, priority,
                  "Got color command from Atmolight"));
              }
              if (red == 0 && green == 0 && blue == 0)
              {
                inputColor = Color.Black;
              }

              //If we receive a high priority messsage drop subsequent messages for x amount of time
              if (priority < 50)
              {
                _swRemoteApi.Reset();
                _swRemoteApi.Stop();
                Thread.Sleep(1000);
                if (commandSender.ToLower() == "atmolight")
                {
                  HueSetColor(inputColor, Sources.Atmolight, 0, false);
                }
                if (commandSender.ToLower() == "huehelper")
                {
                  HueSetColor(inputColor, Sources.Huehelper, 0, false);
                }


                Thread.Sleep(1000);
              }

              //Validate if colors are correct
              if (red >= 0 && red <= 255 && green >= 0 && green <= 255 && blue >= 0 && blue <= 255)
              {
                if (commandSender.ToLower() == "atmolight")
                {
                  HueSetColor(inputColor, Sources.Atmolight, 0, false);
                }
                if (commandSender.ToLower() == "huehelper")
                {
                  HueSetColor(inputColor, Sources.Huehelper, 0, false);
                }
              }

              //Restart stop watch
              _swRemoteApi.Restart();
            }
          }

          //Command type POWER
          if (commandType == ApIcommandType.Power.ToString())
          {
            var powerCommand = apiMessageSplit[2];
            Logger(string.Format("[ {0} ], Powering {1} Hue Bridge", commandSender, powerCommand));
            if (powerCommand == "ON")
            {
              TurnLightsOn();
            }
            else if (powerCommand == "OFF")
            {
              TurnLightsOff();
            }
          }

          //Command type THEATER
          if (commandType == ApIcommandType.Theater.ToString())
          {
            var theaterCommand = apiMessageSplit[2];
            Logger(string.Format("[ {0} ] COMMAND: {1}", commandSender, theaterCommand));

            if (theaterCommand == "DISABLE")
            {
              Logger("[ THEATER MODE ] - restoring leds as playback stopped or leds disabled");
              TurnLightsOnTheater();
            }
            else if (theaterCommand == "ENABLE")
            {
              Logger("[ THEATER MODE ] - disabling leds during movie playback");
              TurnLightsOffTheater();
            }
          }

          //Command type GROUP
          if (commandType == ApIcommandType.Group.ToString())
          {
            var groupCommand = apiMessageSplit[2];
            var inputColor = Color.Black;

            if (groupCommand == "SetStaticColor")
            {
              var groupName = apiMessageSplit[3];
              var colorName = apiMessageSplit[4];

              if (string.IsNullOrEmpty(colorName) == false)
              {
                if (colorName == "Off" || colorName == "Uitschakelen")
                {
                  inputColor = Color.Black;
                }
                else
                {
                  foreach (var staticColor in LedPredefinedStaticColors)
                  {
                    if (staticColor.ColorName == colorName)
                    {
                      var rgBcolor = staticColor.RgBvalue.Split(',');
                      var colorRed = int.Parse(rgBcolor[0]);
                      var colorGreen = int.Parse(rgBcolor[1]);
                      var colorBlue = int.Parse(rgBcolor[2]);
                      inputColor = Color.FromArgb(colorRed, colorGreen, colorBlue);
                    }
                  }
                }
              }

              if (groupName == "All" || groupName == "Alle")
              {
                LedDevicesGroupStaticColors.Clear();

                foreach (var ledDevice in LedDevices)
                {
                  var ld = new LedDevice();
                  ld.Id = ledDevice.Id;
                  ld.location = ledDevice.location;
                  ld.SendDelay = ledDevice.SendDelay;
                  ld.Brightness = ledDevice.Brightness;
                  ld.Saturation = ledDevice.Saturation;
                  ld.ColorTemperature = ledDevice.ColorTemperature;
                  ld.Hue = ledDevice.Hue;
                  ld.StaticColor = ledDevice.StaticColor;
                  LedDevicesGroupStaticColors.Add(ld);
                }

                Logger(string.Format("[ {0} ], Group command {1}, Setting Color {2} to {3}", commandSender, groupCommand,
                  inputColor, "ALL GROUPS"));

                HueSetColor(inputColor, Sources.Atmolight, 0, true);
              }
              else
              {
                LedDevicesGroupStaticColors.Clear();
                if (string.IsNullOrEmpty(groupName) == false)
                {
                  foreach (var ledDevice in LedDevices)
                  {
                    if (ledDevice.location == groupName)
                    {
                      var ld = new LedDevice();
                      ld.Id = ledDevice.Id;
                      ld.location = ledDevice.location;
                      ld.SendDelay = ledDevice.SendDelay;
                      ld.Brightness = ledDevice.Brightness;
                      ld.Saturation = ledDevice.Saturation;
                      ld.ColorTemperature = ledDevice.ColorTemperature;
                      ld.Hue = ledDevice.Hue;
                      ld.StaticColor = ledDevice.StaticColor;
                      LedDevicesGroupStaticColors.Add(ld);
                    }
                  }
                  Logger(string.Format("[ {0} ], Group command {1}, Setting Color {2} to {3}", commandSender,
                    groupCommand, inputColor, groupName));
                  HueSetColor(inputColor, Sources.Atmolight, 0, true);
                }
              }
            }
            if (groupCommand == "OnlyActivate")
            {
              LedDevicesGroupFilter.Clear();

              //Clear all led states
              _groupFilterActive = true;
              var groupName = apiMessageSplit[3];

              if (string.IsNullOrEmpty(groupName) == false)
              {
                if (groupName == "All" || groupName == "Alle")
                {
                  Logger(string.Format("[ {0} ], Group command {1}, Setting active group to {2}", commandSender,
                    groupCommand, groupName));
                  _groupFilterActive = false;
                }
                else
                {
                  foreach (var ledDevice in LedDevices)
                  {
                    if (ledDevice.location == groupName)
                    {
                      var ld = new LedDevice();
                      ld.Id = ledDevice.Id;
                      ld.location = ledDevice.location;
                      ld.SendDelay = ledDevice.SendDelay;
                      ld.Brightness = ledDevice.Brightness;
                      ld.Saturation = ledDevice.Saturation;
                      ld.ColorTemperature = ledDevice.ColorTemperature;
                      ld.Hue = ledDevice.Hue;
                      ld.StaticColor = ledDevice.StaticColor;
                      LedDevicesGroupFilter.Add(ld);
                    }
                  }
                  Logger(string.Format("[ {0} ], Group command {1}, Setting active group to {2}", commandSender,
                    groupCommand, groupName));
                  _groupFilterActive = true;
                }
              }
            }
          }
        }
        catch (Exception e)
        {
          Logger(string.Format("[ {0} ] {1}", "UNKNOWN", e.Message));
          Logger(string.Format("[ {0} ] {1}", "UNKNOWN", e));
        }
      }

      tcpClient.Close();
    }

    private void btnLocateHueBridge_Click(object sender, EventArgs e)
    {
      RefreshSettings();
      MessageBox.Show("Click on the button of your Hue Bridge and press OK to continue.");
      if (cbRunningWindows8.Checked == false)
      {
        BridgeLocator();
      }
      else
      {
        SsdpBridgeLocator();
      }
    }

    public async Task BridgeLocator()
    {
      IBridgeLocator locator = new HttpBridgeLocator();
      var bridgesFound = 0;

      //For Windows 8 and .NET45 projects you can use the SSDPBridgeLocator which actually scans your network. 
      //See the included BridgeDiscoveryTests and the specific .NET and .WinRT projects

      var bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(10));
      foreach (var bridgeIp in bridgeIPs)
      {
        tbHueBridgeIP.Text = bridgeIp.Replace(":80", "").Trim();
        Logger("Bridges found using standard discovery method: " + bridgeIp);
        bridgesFound++;
      }

      if (bridgesFound == 0)
      {
        Logger("Couldn't find any Hue Bridges in network using standard discovery method");
      }

      //Connect to bridge if found and option is enabled
      if (HueAutoconnectBridge)
      {
        _client = new LocalHueClient(HueBridgeIp.Replace(":80", "").Trim());
        await _client.RegisterAsync(HueAppName, HueAppKey);
        try
        {
          _client.Initialize(HueAppKey);
          IsConnectedToBridge = true;
        }
        catch (Exception et)
        {
          if (cbEnableDebuglog.Checked)
          {
            Logger(et.ToString());
          }
        }
      }

      //Check connection
      IsInitialized(true);
    }

    public async Task SsdpBridgeLocator()
    {
      IBridgeLocator locator = new SSDPBridgeLocator();
      var bridgesFound = 0;

      var bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(10));
      foreach (var bridgeIp in bridgeIPs)
      {
        tbHueBridgeIP.Text = bridgeIp.Replace(":80", "").Trim();
        Logger("Bridges found using SSDP discovery method: " + bridgeIp);
        bridgesFound++;
      }

      if (bridgesFound == 0)
      {
        Logger("Couldn't find any Hue Bridges in network using SSDP discovery method");
      }

      //Connect to bridge if found and option is enabled
      if (HueAutoconnectBridge)
      {
        _client = new LocalHueClient(HueBridgeIp);
        await _client.RegisterAsync(HueAppName, HueAppKey);
        try
        {
          _client.Initialize(HueAppKey);
          IsConnectedToBridge = true;
        }
        catch (Exception et)
        {
          if (cbEnableDebuglog.Checked)
          {
            Logger(et.ToString());
          }
        }
      }

      //Check connection
      IsInitialized(true);
    }

    public double[] GetRgBtoXy(Color c, DeviceType device)
    {
      var normalizedToOne = new double[3];
      float cred, cgreen, cblue;
      cred = c.R;
      cgreen = c.G;
      cblue = c.B;
      normalizedToOne[0] = cred/255;
      normalizedToOne[1] = cgreen/255;
      normalizedToOne[2] = cblue/255;
      float red, green, blue;

      // Make red more vivid
      if (normalizedToOne[0] > 0.04045)
      {
        red = (float) Math.Pow(
          (normalizedToOne[0] + 0.055)/(1.0 + 0.055), 2.4);
      }
      else
      {
        red = (float) (normalizedToOne[0]/12.92);
      }

      // Make green more vivid
      if (normalizedToOne[1] > 0.04045)
      {
        green = (float) Math.Pow((normalizedToOne[1] + 0.055)
                                 /(1.0 + 0.055), 2.4);
      }
      else
      {
        green = (float) (normalizedToOne[1]/12.92);
      }

      // Make blue more vivid
      if (normalizedToOne[2] > 0.04045)
      {
        blue = (float) Math.Pow((normalizedToOne[2] + 0.055)
                                /(1.0 + 0.055), 2.4);
      }
      else
      {
        blue = (float) (normalizedToOne[2]/12.92);
      }

      float X = 0;
      float Y = 0;
      float z = 0;


      // For the hue bulb the corners of the triangle are:
      // -Red: 0.675, 0.322
      // -Green: 0.4091, 0.518
      // -Blue: 0.167, 0.04

      // For the hue bloom the corners of the triangle are:
      //Red: 0.703, 0.296
      //Green: 0.214, 0.709
      //Blue: 0.139, 0.081

      //If all else fails we use these
      //Red: 1.0, 0
      //Green: 0.0, 1.0
      //Blue: 0.0, 0.0

      /*
      if (device == DeviceType.bloom)
      {
        X = (float)(red * double.Parse(calibrateXred) + green * double.Parse(calibrateXgreen) + blue * double.Parse(calibrateXblue));
        Y = (float)(red * double.Parse(calibrateYred) + green * double.Parse(calibrateYgreen) + blue * double.Parse(calibrateYblue));
        Z = (float)(red * double.Parse(calibrateZred) + green * double.Parse(calibrateZgreen) + blue * double.Parse(calibrateZblue));
      }

      if (device == DeviceType.bulb)
      {
        X = (float)(red * 0.649926 + green * 0.103455 + blue * 0.197109);
        Y = (float)(red * 0.234327 + green * 0.743075 + blue * 0.022598);
        Z = (float)(red * 0.0000000 + green * 0.053077 + blue * 1.035763);

      }
      if (device == DeviceType.unknown)
      {
        X = (float)(red * 0.649926 + green * 0.103455 + blue * 0.197109);
        Y = (float)(red * 0.234327 + green * 0.743075 + blue * 0.022598);
        Z = (float)(red * 0.0000000 + green * 0.053077 + blue * 1.035763);
      }*/

      X =
        (float)
          (red*double.Parse(CalibrateXred, CultureInfo.InvariantCulture) +
           green*double.Parse(CalibrateXgreen, CultureInfo.InvariantCulture) +
           blue*double.Parse(CalibrateXblue, CultureInfo.InvariantCulture));
      Y =
        (float)
          (red*double.Parse(CalibrateYred, CultureInfo.InvariantCulture) +
           green*double.Parse(CalibrateYgreen, CultureInfo.InvariantCulture) +
           blue*double.Parse(CalibrateYblue, CultureInfo.InvariantCulture));
      z =
        (float)
          (red*double.Parse(CalibrateZred, CultureInfo.InvariantCulture) +
           green*double.Parse(CalibrateZgreen, CultureInfo.InvariantCulture) +
           blue*double.Parse(CalibrateZblue, CultureInfo.InvariantCulture));

      var x = X/(X + Y + z);
      var y = Y/(X + Y + z);

      var xy = new double[2];
      xy[0] = x;
      xy[1] = y;
      var xyAsList = new List<double>(xy);
      return xy;
    }

    /*
    public HueXYColor ConvertRGBToXY(Color RGB)
    {
      PointF xy = new PointF(0f, 0f);
      float red = RGB.R / 255f;
      float green = RGB.G / 255f;
      float blue = RGB.B / 255f;
      float r = (red > 0.04045f) ? (float)Math.Pow((red + 0.055f) / (1.0f + 0.055f), 2.4f) : (red / 12.92f);
      float g = (green > 0.04045f) ? (float)Math.Pow((green + 0.055f) / (1.0f + 0.055f), 2.4f) : (green / 12.92f);
      float b = (blue > 0.04045f) ? (float)Math.Pow((blue + 0.055f) / (1.0f + 0.055f), 2.4f) : (blue / 12.92f);

      float X = r * float.Parse(calibrateXred, CultureInfo.InvariantCulture.NumberFormat) + g * float.Parse(calibrateXgreen, CultureInfo.InvariantCulture.NumberFormat) + b * float.Parse(calibrateXblue, CultureInfo.InvariantCulture.NumberFormat);
      float Y = r * float.Parse(calibrateYred, CultureInfo.InvariantCulture.NumberFormat) + g * float.Parse(calibrateYgreen, CultureInfo.InvariantCulture.NumberFormat) + b * float.Parse(calibrateYblue, CultureInfo.InvariantCulture.NumberFormat);
      float Z = r * float.Parse(calibrateZred, CultureInfo.InvariantCulture.NumberFormat) + g * float.Parse(calibrateZgreen, CultureInfo.InvariantCulture.NumberFormat) + b * float.Parse(calibrateZblue, CultureInfo.InvariantCulture.NumberFormat);

      float cx = X / (X + Y + Z);
      float cy = Y / (X + Y + Z);

      if (cx == float.NaN)
      {
        cx = 0.0f;
      }
      if (cy == float.NaN)
      {
        cy = 0.0f;
      }
      PointF xyPoint = new PointF(cx, cy);
      if (!CheckIfInLampGamut(xyPoint))
      {
        PointF pAB = getClosestPointToPoints(Red, Green, xyPoint);
        PointF pAC = getClosestPointToPoints(Blue, Red, xyPoint);
        PointF pBC = getClosestPointToPoints(Green, Blue, xyPoint);
        float dAB = getDistanceBetweenTwoPoints(xyPoint, pAB);
        float dAC = getDistanceBetweenTwoPoints(xyPoint, pAC);
        float dBC = getDistanceBetweenTwoPoints(xyPoint, pBC);
        float lowest = dAB;
        PointF closestPoint = pAB;
        if (dAC < lowest)
        {
          lowest = dAC;
          closestPoint = pAC;
        }
        if (dBC < lowest)
        {
          lowest = dBC;
          closestPoint = pBC;
        }
        xy.X = closestPoint.X;
        xy.Y = closestPoint.Y;
      }
      HueXYColor XYColor = new HueXYColor();
      XYColor.X = cx;
      XYColor.Y = cy;
      XYColor.Brightness = Y;
      return XYColor;
    }

    public float getDistanceBetweenTwoPoints(PointF p1, PointF p2)
    {
      float dx = p1.X - p2.X;
      float dy = p1.Y - p2.Y;
      float dist = (float)Math.Sqrt(dx * dx + dy * dy);
      return dist;
    }

    public bool CheckIfInLampGamut(PointF XYCoordinates)
    {
      bool IsReachable = false;
      PointF v1 = new PointF(Green.X - Red.X, Green.Y - Red.Y);
      PointF v2 = new PointF(Blue.X - Red.X, Blue.Y - Red.Y);
      PointF q = new PointF(XYCoordinates.X - Red.X, XYCoordinates.Y - Red.Y);
      float s = CrossProduct(q, v2) / CrossProduct(v1, v2);
      float t = CrossProduct(v1, q) / CrossProduct(v1, v2);
      if ((s >= 0.0f) && (t >= 0.0f) && (s + t <= 1.0f))
      {
        IsReachable = true;
      }
      else
      {
        IsReachable = false;
      }
      return IsReachable;
    }
    private PointF getClosestPointToPoints(PointF A, PointF B, PointF P)
    {
      PointF AP = new PointF(P.X - A.X, P.Y - A.Y);
      PointF AB = new PointF(B.X - A.X, B.Y - A.Y);
      float ab2 = AB.X * AB.X + AB.Y * AB.Y;
      float ap_ab = AP.X * AB.X + AP.Y * AB.Y;
      float t = ap_ab / ab2;
      if (t < 0.0f)
      {
        t = 0.0f;
      }
      else
      {
        if (t > 1.0f)
          t = 1.0f;
      }
      PointF newPoint = new PointF(A.X + AB.X * t, A.Y + AB.Y * t);
      return newPoint;
    }
    private float CrossProduct(PointF p1, PointF p2)
    {
      return p1.X * p2.Y - p1.Y * p2.X;
    }*/

    public async Task HueSetBrightness(byte brightness)
    {
      //If client isn't connected we try to reconnect, for example when network disconnects or on power events(suspend/resume).
      IsInitialized(false);

      if (IsConnectedToBridge == false && string.IsNullOrEmpty(HueBridgeIp) == false)
      {
        try
        {
          ReInitialize("HUE has been intialized on SET BRIGHTNESS");
        }
        catch (Exception et)
        {
          if (cbEnableDebuglog.Checked)
          {
            Logger(et.ToString());
          }
        }
      }

      var command = new LightCommand();
      command.On = true;
      command.Brightness = brightness;

      var lights = new List<string>();
      foreach (var ld in LedDevices)
      {
        lights.Add(ld.Id);
      }

      if (lights.Count() > 0)
      {
        _client.SendCommandAsync(command, lights);
        Logger(string.Format("[ {0} ] {1}", Sources.Local,
          "Completed sending brightness " + brightness + " to Hue Bridge"));
      }
    }

    public async Task HueSetColor(Color colorInput, Sources source, int delay, bool usingManualGroupFilter)
    {
      try
      {
        //Reset wait flag
        WaitTimer = false;
        if (cbLogRemoteApiCalls.Checked && source == Sources.Atmolight)
        {
          Logger(string.Format("[ {0} ] {1}", source, "Setting color #" + colorInput + " to Hue Bridge"));
        }
        else
        {
          Logger(string.Format("[ {0} ] {1}", source, "Setting color #" + colorInput + " to Hue Bridge"));
        }

        //If client isn't connected we try to reconnect, for example when network disconnects or on power events(suspend/resume).
        IsInitialized(false);

        if (IsConnectedToBridge == false && string.IsNullOrEmpty(HueBridgeIp) == false)
        {
          ReInitialize("HUE has been intialized on COLOR CHANGE");
        }

        //Send command to Hue and split up commands for every light
        if (LedDevices.Count > 0)
        {
          var ledDevicesIndividualWithGroupFilter = new List<LedDevice>();
          if (_groupFilterActive && usingManualGroupFilter == false)
          {
            ledDevicesIndividualWithGroupFilter = LedDevicesGroupFilter;
          }
          else if (usingManualGroupFilter)
          {
            ledDevicesIndividualWithGroupFilter = LedDevicesGroupStaticColors;
          }
          else if (usingManualGroupFilter == false && _groupFilterActive == false)
          {
            ledDevicesIndividualWithGroupFilter = LedDevices;
          }

          if (EnableIndividualLightSettings)
          {
            var lights = new List<string>();
            foreach (var ld in ledDevicesIndividualWithGroupFilter)
            {
              WaitTimer = true;
              lights.Add(ld.Id);
              IEnumerable<string> lightList = lights;


              var command = new LightCommand();
              command.On = true;

              var colorCoordinates = GetRgBtoXy(colorInput, DeviceType.Bloom);
              if (ColorisOn)
              {
                command.ColorCoordinates = colorCoordinates;
              }
              else
              {
                command.TurnOn();
                command.ColorCoordinates = colorCoordinates;

                ColorisOn = true;
              }

              //Turn leds off if we receive black
              if (colorInput == Color.Black)
              {
                ColorisOn = false;
                command.TurnOff();
              }

              //Check to see if LED device has custom settings


              //Color transition
              //0-~
              if (ld.SendDelay != HueTransitiontime && string.IsNullOrEmpty(ld.SendDelay) == false)
              {
                command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(ld.SendDelay));
              }
              else
              {
                command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(HueTransitiontime));
              }

              //Brightness
              //0-254
              if (ld.Brightness != HueBrightness && string.IsNullOrEmpty(ld.Brightness) == false)
              {
                command.Brightness = byte.Parse(ld.Brightness);
              }
              else
              {
                if (HueSetBrightnessStartup == false || UserEditedSettings)
                {
                  command.Brightness = byte.Parse(HueBrightness);
                }
              }

              //Saturation
              //0-254
              if (ld.Saturation != HueSaturation && string.IsNullOrEmpty(ld.Saturation) == false)
              {
                command.Saturation = int.Parse(ld.Saturation);
              }
              else
              {
                if (UserEditedSettings)
                {
                  command.Saturation = int.Parse(HueSaturation);
                }
              }

              //Color temperature
              //154-500
              if (ld.ColorTemperature != HueColorTemperature && string.IsNullOrEmpty(ld.ColorTemperature) == false)
              {
                command.ColorTemperature = int.Parse(ld.ColorTemperature);
              }
              else
              {
                if (string.IsNullOrEmpty(HueColorTemperature) == false)
                {
                  if (UserEditedSettings)
                  {
                    command.ColorTemperature = int.Parse(HueColorTemperature);
                  }
                }
              }

              //Hue
              if (ld.Hue != HueHue && string.IsNullOrEmpty(ld.Hue) == false)
              {
                command.Hue = int.Parse(ld.Hue);
              }
              else
              {
                if (string.IsNullOrEmpty(HueHue) == false)
                {
                  if (UserEditedSettings)
                  {
                    command.Hue = int.Parse(HueHue);
                  }
                }
              }

              UserEditedSettings = false;

              Logger(string.Format("[ {0} ] {1}", source,
                "Sending color " + colorInput + " to Hue Bridge for LIGHT " + ld.Id));

              //Logger(ld.ID + "  ->> transition time" + command.TransitionTime.ToString() + "- >> brightness" + command.Brightness.ToString() + " ->> saturation" + command.Saturation.ToString() + " ->> list #" + lightList.Count().ToString());

              _client.SendCommandAsync(command, lightList);
              command.On = false;
              lights.Clear();
            }
            WaitTimer = false;
          }
          else
          {
            var command = new LightCommand();
            command.On = true;

            var colorCoordinates = GetRgBtoXy(colorInput, DeviceType.Bloom);
            if (ColorisOn)
            {
              command.ColorCoordinates = colorCoordinates;
            }
            else
            {
              command.TurnOn();
              command.ColorCoordinates = colorCoordinates;

              ColorisOn = true;
            }

            //Turn leds off if we receive black
            if (colorInput == Color.Black)
            {
              ColorisOn = false;
              command.TurnOff();
            }

            //Color transition
            //0-~
            command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(HueTransitiontime));

            //Brightness
            //0-254
            if (HueSetBrightnessStartup == false || UserEditedSettings)
            {
              command.Brightness = byte.Parse(HueBrightness);
            }

            //Saturation
            //0-254
            if (UserEditedSettings)
            {
              command.Saturation = int.Parse(HueSaturation);
            }

            //Color temperature
            //154-500
            if (string.IsNullOrEmpty(HueColorTemperature) == false)
            {
              if (UserEditedSettings)
              {
                command.ColorTemperature = int.Parse(HueColorTemperature);
              }
            }

            //Hue
            if (string.IsNullOrEmpty(HueHue) == false)
            {
              if (UserEditedSettings)
              {
                command.Hue = int.Parse(HueHue);
              }
            }

            UserEditedSettings = false;

            var lights = new List<string>();

            if (_groupFilterActive && usingManualGroupFilter == false)
            {
              foreach (var ld in LedDevicesGroupFilter)
              {
                lights.Add(ld.Id);
              }
            }
            else if (usingManualGroupFilter)
            {
              foreach (var ld in LedDevicesGroupStaticColors)
              {
                lights.Add(ld.Id);
              }
            }
            else if (usingManualGroupFilter == false && _groupFilterActive == false)
            {
              foreach (var ld in LedDevices)
              {
                lights.Add(ld.Id);
              }
            }

            IEnumerable<string> lightList = lights;
            if (lightList.Count() > 0)
            {
              _client.SendCommandAsync(command, lightList);
            }
            command.On = false;
          }
          if (cbLogRemoteApiCalls.Checked && source == Sources.Atmolight)
          {
            Logger(string.Format("[ {0} ] {1}", source, "Completed sending color " + colorInput + " to Hue Bridge"));
          }
          else
          {
            Logger(string.Format("[ {0} ] {1}", source, "Completed sending color " + colorInput + " to Hue Bridge"));
          }
        }
      }
      catch (Exception et)
      {
        //MessageBox.Show(et.ToString());
        if (cbEnableDebuglog.Checked)
        {
          Logger(et.ToString());
        }
      }
    }

    private void SendLightCommand(LightCommand command, IEnumerable<string> lightList)
    {
      /*
      while(waitTimer)
      {
        //Wait
        Thread.Sleep(1);
      }*/
      _client.SendCommandAsync(command, lightList);
    }

    private void btnStartAtmowinHue_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(HueBridgeIp))
      {
        if (cbRunningWindows8.Checked == false)
        {
          BridgeLocator();
        }
        else
        {
          SsdpBridgeLocator();
        }
      }
      ScanAtmowin = true;
      Logger("Start monitoring Atmowin");
      var t = new Thread(StartMonitoringAtmowin);
      t.IsBackground = true;
      t.Start();
    }

    private void btnStopAtmowinHue_Click(object sender, EventArgs e)
    {
      ScanAtmowin = false;
      Logger("Stop monitoring Atmowin");

      if (string.IsNullOrEmpty(AtmowinStaticColor) == false)
      {
        HueSetColor(Color.Black, Sources.Local, 0, false);
      }
      else
      {
        HueSetColor(Color.Black, Sources.Local, 0, false);
      }
    }

    private void StartMonitoringAtmowin()
    {
      var atmowinColorInformation = "";
      var colorRed = "";
      var colorGreen = "";
      var colorBlue = "";
      var numberOfChannels = "";
      var previousColor = Color.Black;
      try
      {
        while (ScanAtmowin)
        {
          try
          {
            using (
              var fileStream = new FileStream(AtmowinLocation + "hue_output.txt", FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite))
            {
              using (var streamReader = new StreamReader(fileStream))
              {
                atmowinColorInformation = streamReader.ReadToEnd().Trim();
              }
            }
            var atmowinColorSplit = atmowinColorInformation.Split(',');
            colorRed = atmowinColorSplit[0];
            colorGreen = atmowinColorSplit[1];
            colorBlue = atmowinColorSplit[2];
            numberOfChannels = atmowinColorSplit[3];
            Logger("------------------------------");
            Logger("Atmowin information -> R = " + colorRed + " / G = " + colorGreen + " / B = " + colorBlue +
                   " / CHANNELS = " + numberOfChannels);

            //Needs changing as Atmowin might report 0,0,0 normally
            if (colorRed == "0" && colorGreen == "0" && colorBlue == "0" &&
                string.IsNullOrEmpty(AtmowinStaticColor) == false)
            {
              Logger("Atmowin disconnected, sending preset static color");
              HueSetColor(Color.Black, Sources.Local, 0, false);
            }
            else
            {
              //Convert RGB to HEX
              var myColor = Color.FromArgb(int.Parse(colorRed), int.Parse(colorGreen), int.Parse(colorBlue));

              //Send color
              if (myColor != previousColor)
              {
                HueSetColor(myColor, Sources.Local, 0, false);
              }
              previousColor = myColor;

              Logger("Completed sending color #" + myColor + " to Hue Bridge.");
              Logger("------------------------------");
            }

            var sleeptime = int.Parse(AtmowinScanInterval);
            Thread.Sleep(sleeptime);
          }
          catch (Exception et)
          {
            Logger(et.ToString());
            var sleeptime = int.Parse(AtmowinScanInterval);
            Thread.Sleep(sleeptime);
          }
        }
      }
      catch (Exception et)
      {
        Logger(et.ToString());
        var sleeptime = int.Parse(AtmowinScanInterval);
        Thread.Sleep(sleeptime);
      }
    }

    public static string AddTrailingSlash(string atmowinFolder)
    {
      try
      {
        var checkForTrailingSlash = atmowinFolder.Substring(atmowinFolder.Length - 1, 1);
        if (checkForTrailingSlash != "\\")
        {
          atmowinFolder = atmowinFolder + "\\";
        }
      }
      catch
      {
      }
      ;
      return atmowinFolder;
    }

    public void Logger(string text)
    {
      var timestamp = DateTime.Now.ToString("HH:mm:ss.ffffff");
      var message = string.Format("[ {0} ] - {1}", timestamp, text);
      ControlInvike(lbOutputlog, () => lbOutputlog.Items.Add(message));

      if (cbEnableDebuglog.Checked)
      {
        var sw = new StreamWriter("debug.log", true);
        sw.WriteLine(message);
        sw.Close();
      }

      ListBoxScrollToBottom();
    }

    public void ListBoxScrollToBottom()
    {
      try
      {
        ControlInvike(lbOutputlog, () => lbOutputlog.SelectedIndex = lbOutputlog.Items.Count - 1);
        ControlInvike(lbOutputlog, () => lbOutputlog.SelectedIndex = -1);
      }
      catch (Exception et)
      {
      }
    }

    private void RotateColors()
    {
      try
      {
        IsInitialized(false);

        if (!IsConnectedToBridge)
        {
          ReInitialize("HUE has been intialized on COLOR CHANGE");
        }

        while (HueRotatingColors)
        {
          HueSetColor(Color.Red, Sources.Local, 0, false);
          Thread.Sleep(HueRotateDelay);
          HueSetColor(Color.Green, Sources.Local, 0, false);
          Thread.Sleep(HueRotateDelay);
          HueSetColor(Color.Blue, Sources.Local, 0, false);
          Thread.Sleep(HueRotateDelay);
        }
      }
      catch (Exception et)
      {
        if (cbEnableDebuglog.Checked)
        {
          Logger(et.ToString());
        }
      }
    }

    private void btnTestRed_Click(object sender, EventArgs e)
    {
      TurnLightsOn();
      HueSetColor(Color.Red, Sources.Local, 0, false);
    }

    private void btnTestGreen_Click(object sender, EventArgs e)
    {
      TurnLightsOn();
      HueSetColor(Color.Green, Sources.Local, 0, false);
    }

    private void btnTestBlue_Click(object sender, EventArgs e)
    {
      TurnLightsOn();
      HueSetColor(Color.Blue, Sources.Local, 0, false);
    }

    private void btnHueColorClear_Click(object sender, EventArgs e)
    {
      TurnLightsOn();
      HueSetColor(Color.Black, Sources.Local, 0, false);
    }

    private void btnHueSendCustomColor_Click(object sender, EventArgs e)
    {
      var customColor = new Color();
      try
      {
        var red = int.Parse(cbTestCustomColorR.Text);
        var green = int.Parse(cbTestCustomColorG.Text);
        var blue = int.Parse(cbTestCustomColorB.Text);
        customColor = Color.FromArgb(red, green, blue);
      }
      catch
      {
        Logger("Incorrect color values for test custom colors used, R/G/B must be between 0 and 255");
        MessageBox.Show("Incorrect color values for test custom colors used, R/G/B must be between 0 and 255");
        return;
      }
      HueSetColor(customColor, Sources.Local, 0, false);
    }

    private void btnHueColorRotateTestStart_Click(object sender, EventArgs e)
    {
      HueRotatingColors = true;
      var t = new Thread(RotateColors);
      t.IsBackground = true;
      t.Start();
    }

    private void btnHueColorRotateTestStop_Click(object sender, EventArgs e)
    {
      HueRotatingColors = false;
      HueSetColor(Color.Black, Sources.Local, 0, false);
      ColorisOn = false;
    }

    private void llQ42_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(e.Link.LinkData as string);
    }

    private void btnAddLed_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(tbLedID.Text.Trim()))
      {
        MessageBox.Show("A valid led ID is required");
        tbLedID.Focus();
      }
      else
      {
        var id = tbLedID.Text;
        var staticColors = "";
        if (string.IsNullOrEmpty(tbLedR.Text) == false && string.IsNullOrEmpty(tbLedG.Text) == false &&
            string.IsNullOrEmpty(tbLedB.Text) == false)
        {
          staticColors = string.Format("{0},{1},{2}", tbLedR.Text, tbLedG.Text, tbLedB.Text);
        }

        string[] subItems =
        {
          cbLedType.Text, cbLedLocation.Text, tbLedSendDelay.Text, tbLedBrightness.Text,
          tbLedSaturation.Text, tbLedColorTemperature.Text, tbLedHue.Text, staticColors
        };

        lvLedDevices.Items.Add(id).SubItems.AddRange(subItems);

        SetInUseLedDevices();

        tbLedID.Text = "";
        cbLedType.Text = "";
        cbLedLocation.Text = "";
        tbLedID.Focus();
      }
    }

    private static void MoveListViewItems(ListView sender, MoveDirection direction)
    {
      var dir = (int) direction;
      var opp = dir*-1;

      var valid = sender.SelectedItems.Count > 0 &&
                  ((direction == MoveDirection.Down &&
                    (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
                   || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));

      if (valid)
      {
        foreach (ListViewItem item in sender.SelectedItems)
        {
          var index = item.Index + dir;
          sender.Items.RemoveAt(item.Index);
          sender.Items.Insert(index, item);

          sender.Items[index + opp].SubItems[1].Text = (index + opp).ToString();
          item.SubItems[1].Text = index.ToString();
        }
      }
    }

    private void btnLedItemUp_Click(object sender, EventArgs e)
    {
      MoveListViewItems(lvLedDevices, MoveDirection.Up);
    }

    private void btnLedItemDown_Click(object sender, EventArgs e)
    {
      MoveListViewItems(lvLedDevices, MoveDirection.Down);
    }

    private void btnRemoveLeds_Click(object sender, EventArgs e)
    {
      lvLedDevices.Items.Cast<ListViewItem>().Where(T => T.Selected)
        .Select(T => T.Index).ToList().ForEach(T => lvLedDevices.Items.RemoveAt(T));

      SetInUseLedDevices();
    }

    private void SetInUseLedDevices()
    {
      LedDevices.Clear();
      foreach (ListViewItem item in lvLedDevices.Items)
      {
        var ld = new LedDevice();
        ld.Id = item.Text;
        LedDevices.Add(ld);
      }
    }

    private void btnHueSetScene_Click(object sender, EventArgs e)
    {
      //client.CreateOrUpdateSceneAsync(tbHueSceneID.Text, tbHueSceneName.Text, ledDevices);
    }

    private void btnHueLocateScenes_Click(object sender, EventArgs e)
    {
      GetScenes();
    }

    private async Task GetScenes()
    {
      IEnumerable<Scene> scenes = await _client.GetScenesAsync();
      foreach (var scene in scenes)
      {
        //Logger(string.Format("Active:{0} - ID:{1} - Name:{2} - Lights:{3}", scene.Active, scene.Id, scene.Name, scene.Lights));
      }
    }

    private void btnRefreshSettings_Click(object sender, EventArgs e)
    {
      RefreshSettings();
    }

    private void tbHueBridgeIP_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void tbHueAppName_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void tbHueAppKey_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbHueBrightness_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbHueSaturation_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbHueColorTemperature_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbHueHue_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbHueTransitionTime_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbHueSetBrightnessStartup_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbRunningWindows8_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbAutoConnectBridge_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbRemoteAPIEnabled_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private bool ValidatorInt(string input, int minValue, int maxValue, bool validateMaxValue)
    {
      var isValid = false;
      int value;
      var isInteger = int.TryParse(input, out value);

      if (isInteger)
      {
        //Only check minValue
        if (validateMaxValue == false && value >= minValue)
        {
          isValid = true;
        }
        //Check both min/max values
        else
        {
          if (value >= minValue && value <= maxValue)
          {
            isValid = true;
          }
        }
      }
      return isValid;
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      if (MinimizeToTray)
      {
        if (FormWindowState.Minimized == WindowState)
        {
          FormBorderStyle = FormBorderStyle.SizableToolWindow;
          trayIconHue.Visible = true;
          Hide();
        }

        else if (FormWindowState.Normal == WindowState)
        {
          FormBorderStyle = FormBorderStyle.FixedSingle;
          trayIconHue.Visible = false;
        }
      }
    }

    private void notifyIcon1_DoubleClick(object sender, EventArgs e)
    {
      Show();
      WindowState = FormWindowState.Normal;
    }

    private void cbMinimizeOnStartup_CheckedChanged(object sender, EventArgs e)
    {
      if (cbMinimizeOnStartup.Checked)
      {
        MinimizeOnStartup = true;
        cbMinimizeToTray.Checked = true;
      }
    }

    private void cbMinimizeToTray_CheckedChanged(object sender, EventArgs e)
    {
      if (cbMinimizeToTray.Checked)
      {
        MinimizeToTray = true;
      }
      else
      {
        MinimizeToTray = false;
      }
    }

    private void cbLogRemoteApiCalls_CheckedChanged(object sender, EventArgs e)
    {
      if (cbLogRemoteApiCalls.Checked)
      {
        LogRemoteApiCalls = true;
      }
      else
      {
        LogRemoteApiCalls = false;
      }
    }

    private void cbTestCustomColorR_Validating(object sender, CancelEventArgs e)
    {
      var min = 0;
      var max = 255;
      if (ValidatorInt(cbTestCustomColorR.Text, min, max, true) == false)
      {
        MessageBox.Show("RGB color value must be between 0 and 255");
      }
    }

    private void cbTestCustomColorG_Validating(object sender, CancelEventArgs e)
    {
      var min = 0;
      var max = 255;
      if (ValidatorInt(cbTestCustomColorG.Text, min, max, true) == false)
      {
        MessageBox.Show("RGB color value must be between 0 and 255");
      }
    }

    private void cbTestCustomColorB_Validating(object sender, CancelEventArgs e)
    {
      var min = 0;
      var max = 255;
      if (ValidatorInt(cbTestCustomColorB.Text, min, max, true) == false)
      {
        MessageBox.Show("RGB color value must be between 0 and 255");
      }
    }

    private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
    {
      Show();
      WindowState = FormWindowState.Normal;
    }

    private void toolStripMenuItemClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void cbHuePowerHandling_SelectedIndexChanged(object sender, EventArgs e)
    {
      HuePowerHandling = cbHuePowerHandling.SelectedIndex;
    }

    private void btnGetLedIDs_Click(object sender, EventArgs e)
    {
      IsInitialized(false);

      if (!IsConnectedToBridge)
      {
        ReInitialize("HUE has been intialized on getLights");
      }
      else
      {
        GetLights();
      }
    }

    private async Task GetLights()
    {
      var lights = await _client.GetLightsAsync();
      foreach (var light in lights)
      {
        Logger(string.Format("{0} - {1} - {2} - {3} - {4} - {5}", light.Id, light.ModelId, light.Name,
          light.SoftwareVersion, light.State, light.Type));
      }
    }

    private void tbXRed_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Red, Sources.Local, 0, false);
      }
    }

    private void tbXGreen_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Red, Sources.Local, 0, false);
      }
    }

    private void tbXBlue_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Red, Sources.Local, 0, false);
      }
    }

    private void tbYRed_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Green, Sources.Local, 0, false);
      }
    }

    private void tbYGreen_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Green, Sources.Local, 0, false);
      }
    }

    private void tbYBlue_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Green, Sources.Local, 0, false);
      }
    }

    private void tbZRed_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Blue, Sources.Local, 0, false);
      }
    }

    private void tbZGreen_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Blue, Sources.Local, 0, false);
      }
    }

    private void tbZBlue_KeyDown(object sender, KeyEventArgs e)
    {
      RefreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        HueSetColor(Color.Blue, Sources.Local, 0, false);
      }
    }

    private void RefreshColorCalibrations()
    {
      CalibrateXred = tbXRed.Text;
      CalibrateYred = tbYRed.Text;
      CalibrateZred = tbZRed.Text;
      CalibrateXgreen = tbXGreen.Text;
      CalibrateYgreen = tbYGreen.Text;
      CalibrateZgreen = tbZGreen.Text;
      CalibrateXblue = tbXBlue.Text;
      CalibrateYblue = tbYBlue.Text;
      CalibrateZblue = tbZBlue.Text;
    }

    private void cbEnableIndividualLightSettings_CheckedChanged(object sender, EventArgs e)
    {
      if (cbEnableIndividualLightSettings.Checked)
      {
        EnableIndividualLightSettings = true;
      }
      else
      {
        EnableIndividualLightSettings = false;
      }
    }

    private void btnAddLedLocation_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(tbLedLocation.Text))
      {
        MessageBox.Show("A valid led locaton is required");
        tbLedLocation.Focus();
      }
      else
      {
        string[] subItems = {tbLedLocationPriority.Text};
        lvLedLocations.Items.Add(tbLedLocation.Text).SubItems.AddRange(subItems);

        // Refresh combo box selection options
        cbLedLocation.Items.Clear();
        foreach (ListViewItem location in lvLedLocations.Items)
        {
          cbLedLocation.Items.Add(location.Text);
        }

        tbLedLocation.Text = "";
        tbLedLocationPriority.Text = "";
        tbLedLocation.Focus();
      }
    }

    private void btnAddPredefinedStaticColor_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(tbPredefinedStaticColorName.Text))
      {
        MessageBox.Show("A valid static color name is required");
        tbLedLocation.Focus();
      }
      else
      {
        var predefinedColor = tbPredefinedColorR.Text + "," + tbPredefinedColorG.Text + "," + tbPredefinedColorB.Text;
        string[] subItems = {predefinedColor};
        lvPredefinedStaticColors.Items.Add(tbPredefinedStaticColorName.Text).SubItems.AddRange(subItems);
        tbPredefinedStaticColorName.Text = "";
        tbPredefinedColorR.Text = "";
        tbPredefinedColorG.Text = "";
        tbPredefinedColorB.Text = "";
        tbPredefinedStaticColorName.Focus();
      }
    }

    private void btnRemoveLedLocation_Click(object sender, EventArgs e)
    {
      lvLedLocations.Items.Cast<ListViewItem>().Where(T => T.Selected)
        .Select(T => T.Index).ToList().ForEach(T => lvLedLocations.Items.RemoveAt(T));

      // Refresh combo box selection options
      cbLedLocation.Items.Clear();
      foreach (ListViewItem location in lvLedLocations.Items)
      {
        cbLedLocation.Items.Add(location.Text);
      }
    }

    private void btnRemoveLedPredefinedStaticColor_Click(object sender, EventArgs e)
    {
      lvPredefinedStaticColors.Items.Cast<ListViewItem>().Where(T => T.Selected)
        .Select(T => T.Index).ToList().ForEach(T => lvPredefinedStaticColors.Items.RemoveAt(T));
    }

    private void btnLedLocationUP_Click(object sender, EventArgs e)
    {
      MoveListViewItems(lvLedLocations, MoveDirection.Up);
    }

    private void btnLedLocationDOWN_Click(object sender, EventArgs e)
    {
      MoveListViewItems(lvLedLocations, MoveDirection.Down);
    }

    private void btnLedStaticColorUP_Click(object sender, EventArgs e)
    {
      MoveListViewItems(lvPredefinedStaticColors, MoveDirection.Up);
    }

    private void btnLedStaticColorDOWN_Click(object sender, EventArgs e)
    {
      MoveListViewItems(lvPredefinedStaticColors, MoveDirection.Down);
    }

    private void btnTestHueBrightness_Click(object sender, EventArgs e)
    {
      var min = 0;
      var max = 255;
      if (ValidatorInt(cbTestHueBrightness.Text, min, max, true) == false)
      {
        MessageBox.Show("RGB color value must be between 0 and 500");
      }
      else
      {
        try
        {
          var brightness = byte.Parse(cbTestHueBrightness.Text);
          HueSetBrightness(brightness);
        }
        catch (Exception et)
        {
          MessageBox.Show("Error while setting brightness");
          MessageBox.Show(et.Message);
        }
      }
    }

    private void cbHueEnableTheaterMode_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private void cbHueTheaterModeRestoreColor_Validating(object sender, CancelEventArgs e)
    {
      RefreshSettings();
    }

    private delegate void UniversalVoidDelegate();

    public class LedDevice
    {
      public string Id { get; set; }
      public string Type { get; set; }
      public string location { get; set; }
      public string SendDelay { get; set; }
      public string Brightness { get; set; }
      public string Saturation { get; set; }
      public string ColorTemperature { get; set; }
      public string Hue { get; set; }
      public string StaticColor { get; set; }
    }

    public class LedLocation
    {
      public string Location { get; set; }
      public string Priority { get; set; }
    }

    public class LEDPredefinedStaticColors
    {
      public string ColorName { get; set; }
      public string RgBvalue { get; set; }
    }

    private enum ApIcommandType
    {
      Color,
      Group,
      Power,
      Room,
      Theater
    }

    public class HueXyColor
    {
      public float Brightness;
      public float X;
      public float Y;
    }

    private enum MoveDirection
    {
      Up = -1,
      Down = 1
    }

    #region powerstate monitoring

    private void MonitorPowerState()
    {
      SystemEvents.PowerModeChanged += OnPowerModeChanged;
    }

    private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
      switch (e.Mode)
      {
        case PowerModes.Resume:
          var selectedPowerModeResume = HuePowerHandling;
          if (selectedPowerModeResume == 0 || selectedPowerModeResume == 2)
          {
            Logger("[ STANDBY ] - resuming AtmoHue connection and setting initial command");
            var tResume = new Thread(TurnLightsOn);
            tResume.IsBackground = true;
            tResume.Start();
          }
          break;
        case PowerModes.Suspend:
          var selectedPowerModeSuspend = HuePowerHandling;
          if (selectedPowerModeSuspend == 1 || selectedPowerModeSuspend == 2)
          {
            Logger("[ STANDBY ] - Suspending AtmoHue and turning off leds");
            var tSuspend = new Thread(TurnLightsOff);
            tSuspend.IsBackground = true;
            tSuspend.Start();
          }
          break;
      }
    }

    public void TurnLightsOff()
    {
      try
      {
        ColorisOn = false;
        var command = new LightCommand();
        command.On = true;
        command.TurnOff();

        var lights = new List<string>();
        foreach (var ld in LedDevices)
        {
          lights.Add(ld.Id);
        }

        IEnumerable<string> lightList = lights;

        _client.SendCommandAsync(command, lightList);
        command.On = false;
        Logger("[ STANDBY ] - Suspended AtmoHue and set color to black");
      }
      catch (Exception e)
      {
        Logger("[ STANDBY ] - Error while sending color black on suspend");
        Logger(e.Message);
      }
    }

    public void TurnLightsOn()
    {
      try
      {
        IsInitialized(false);

        if (!IsConnectedToBridge)
        {
          ReInitialize("HUE has been intialized on LIGHTS ON");
        }

        ColorisOn = true;
        var command = new LightCommand();
        command.On = true;
        command.Brightness = byte.Parse(HueBrightness);

        var colorCoordinates = GetRgBtoXy(Color.Black, DeviceType.Bloom);

        command.ColorCoordinates = colorCoordinates;
        command.TurnOn();

        var lights = new List<string>();
        foreach (var ld in LedDevices)
        {
          lights.Add(ld.Id);
        }

        IEnumerable<string> lightList = lights;

        _client.SendCommandAsync(command, lightList);
        command.On = false;
        Logger("[ STANDBY ] - Resumed AtmoHue and set initial color command (TurnOn) with brightness " + HueBrightness);
      }
      catch (Exception e)
      {
        Logger("[ STANDBY ] - Error while turning on Hue on resume");
        Logger(e.Message);
      }
    }

    public void TurnLightsOnTheater()
    {
      try
      {
        IsInitialized(false);

        if (!IsConnectedToBridge)
        {
          ReInitialize("HUE has been intialized on LIGHTS ON THEATER");
        }

        ColorisOn = true;
        var command = new LightCommand();
        command.On = true;

        command.TurnOn();

        var lights = new List<string>();
        foreach (var ld in LedDevices)
        {
          lights.Add(ld.Id);
        }

        IEnumerable<string> lightList = lights;

        _client.SendCommandAsync(command, lightList);
        command.On = false;
        Logger("[ THEATER MODE ] - Turned back on lights.");
      }
      catch (Exception e)
      {
        Logger("[ THEATER MODE ] - Error while turning on Hue on after Theater mode");
        Logger(e.Message);
      }
    }

    public void TurnLightsOffTheater()
    {
      try
      {
        ColorisOn = false;
        var command = new LightCommand();
        command.On = true;
        command.TurnOff();

        var lights = new List<string>();
        foreach (var ld in LedDevices)
        {
          lights.Add(ld.Id);
        }

        IEnumerable<string> lightList = lights;

        _client.SendCommandAsync(command, lightList);
        command.On = false;
        Logger("[ THEATER MODE ] - Turning off lights during movie playback.");
      }
      catch (Exception e)
      {
        Logger("[ THEATER MODE ] - Error while turning off Hue lights during Theater mode");
        Logger(e.Message);
      }
    }

    #endregion
  }
}