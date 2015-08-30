using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Q42.HueApi;
using Q42.HueApi.NET;
using Q42.HueApi.Interfaces;
using Microsoft.Win32;

using System.Windows.Forms;

namespace AtmoHue
{
  public partial class Form1 : Form
  {
    delegate void UniversalVoidDelegate();

    public enum sources
    {
      ATMOLIGHT,
      HUEHELPER,
      LOCAL
    }
    public enum DeviceType
    {
      bloom,
      bulb,
      iris,
      strips,
      unknown
    }

    public class LEDDevice
    {
      public string ID { get; set; }
      public string type { get; set; }
      public string location { get; set; }
      public string sendDelay { get; set; }
      public string brightness { get; set; }
      public string saturation { get; set; }
      public string colorTemperature { get; set; }
      public string hue { get; set; }
      public string staticColor { get; set; }
    }

    public class LEDLocation
    {
      public string Location { get; set; }
      public string Priority { get; set; }
    }

    public class LEDPredefinedStaticColors
    {
      public string ColorName { get; set; }
      public string RGBvalue { get; set; }
    }

    private enum APIcommandType
    {
      Color,
      Group,
      Power,
      Room,
      Theater
    }

    public class HueXYColor
    {
      public float X;
      public float Y;
      public float Brightness;
    } 

    // Atmowin
    public Boolean scanAtmowin = false;
    public string atmowinLocation = "";
    public string atmowinStaticColor = "";
    public string atmowinScanInterval = "";

    // HUE
    public Boolean hueRotatingColors = false;
    HueClient client = new HueClient("127.0.0.1");
    public List<LEDDevice> ledDevices = new List<LEDDevice>();
    public List<LEDDevice> ledDevicesGroupFilter = new List<LEDDevice>();
    public List<LEDDevice> ledDevicesGroupStaticColors = new List<LEDDevice>();

    public List<LEDLocation> ledLocations = new List<LEDLocation>();
    public List<LEDPredefinedStaticColors> ledPredefinedStaticColors = new List<LEDPredefinedStaticColors>();

    public List<string> commandCache = new List<string>();
    public Boolean colorCommand = false;
    public Boolean colorisON = false;
    public int hueRotateDelay = 1000;
    public string hueBridgeIP = "127.0.0.1";
    public string hueAppName = "AtmoHue";
    public string hueAppKey = "AmtoHueAppKey";
    public string hueBrightness = "100";
    public string hueSaturation = "100";
    public string hueTransitiontime = "100";
    public string hueColorTemperature = "";
    public string hueHue = "";
    public string hueOutputDevices = "";
    public Boolean hueRunningWindows8 = false;
    public Boolean hueAutoconnectBridge = false;
    public Boolean HueRemoteAPIenabled = false;
    public Boolean HueSetBrightnessStartup = false;
    public string calibrateXred = "";
    public string calibrateYred = "";
    public string calibrateZred = "";
    public string calibrateXgreen = "";
    public string calibrateYgreen = "";
    public string calibrateZgreen = "";
    public string calibrateXblue = "";
    public string calibrateYblue = "";
    public string calibrateZblue = "";

    // Various
    public Boolean MinimizeOnStartup = false;
    public Boolean MinimizeToTray = false;
    public int HuePowerHandling = 0;
    public Boolean userEditedSettings = false;
    public Boolean EnableIndividualLightSettings = false;

    public Boolean waitTimer = false;


    // API
    private TcpListener tcpListener;
    private Thread listenThread;
    private Stopwatch swRemoteApi = new Stopwatch();
    public static string remoteAPIip = "127.0.0.1";
    public static string remoteAPIport = "20123";
    public static string remoteAPISendDelay = "300";
    public static Boolean LogRemoteApiCalls = false;
    private Boolean groupFilterActive = false;


    public Form1()
    {
      InitializeComponent();

      //Close program if already running
      if (isProgramRunning("AtmoHue", 0) > 1)
      {
        Environment.Exit(0);
      }

      //Load settings
      LoadSettings(true);

      if (MinimizeOnStartup)
      {
        this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        this.WindowState = FormWindowState.Minimized;
        this.Visible = false;
        this.ShowInTaskbar = false;
      }
      //Start remote server if enabled
      if (HueRemoteAPIenabled)
      {
        startAPIserver();
      }

      //Find bridge on startup for TESTING
      if (string.IsNullOrEmpty(hueBridgeIP) == true)
      {
        if (hueRunningWindows8 == false)
        {
          BridgeLocator();
        }
        else
        {
          SSDPBridgeLocator();
        }
      }

      //Create some default combobox values
      cbHueBrightness.Items.Clear();
      int maxBrightness = 500;
      int counter = 0;

      while (counter != maxBrightness)
      {
        cbHueBrightness.Items.Add(counter);
        counter++;
      }

      //Create some default combobox values
      setDefaultCombBoxValues(cbHueBrightness, 0, 254);
      setDefaultCombBoxValues(cbHueSaturation, 0, 254);
      setDefaultCombBoxValues(cbHueColorTemperature, 154, 500);
      setDefaultCombBoxValues(cbHueTransitionTime, 100, 5000);
      setDefaultCombBoxValues(cbHueHue, 0, 254);
      setDefaultCombBoxValues(cbTestCustomColorR, 0, 255);
      setDefaultCombBoxValues(cbTestCustomColorG, 0, 254);
      setDefaultCombBoxValues(cbTestCustomColorB, 0, 254);
      setDefaultCombBoxValues(cbTestHueBrightness, 0, 254);


      if (client.IsInitialized == false && string.IsNullOrEmpty(hueBridgeIP) == false)
      {
        client = new HueClient(hueBridgeIP);
        client.RegisterAsync(hueAppName, hueAppKey);
        try
        {
          client.Initialize(hueAppKey);
          Logger("HUE has been intialized on STARTUP");
        }
        catch (Exception et)
        {
          if (cbEnableDebuglog.Checked == true)
          {
            Logger(et.ToString());
          }
        }
      }

      if (client.IsInitialized)
      {
        lblConnectionStatus.Text = "Status: Connected";
      }
      else
      {
        lblConnectionStatus.Text = "Status: Disconnected";
      }

      // Monitor power state
      monitorPowerState();

      //Set window title
      this.Text = formatTitle();

      //Set link label for copyright
      LinkLabel.Link link = new LinkLabel.Link();
      link.LinkData = "https://github.com/Q42/Q42.HueApi";
      llQ42.Links.Add(link);
    }

    public static int isProgramRunning(string name, int runtime)
    {
      foreach (Process clsProcess in Process.GetProcesses())
      {
        if (clsProcess.ProcessName.ToLower().Equals(name.ToLower()))
        {
          //Console.WriteLine(clsProcess.ProcessName.ToLower().ToString());
          runtime++;
        }
      }
      return runtime;
    }

    private void setDefaultCombBoxValues(ComboBox cb, int min, int max)
    {
      cb.Items.Clear();

      while (min <= max)
      {
        cb.Items.Add(min);
        min++;
      }

    }
    private void LoadSettings(Boolean init)
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
          using (XmlReader reader = XmlReader.Create("settings.xml"))
          {
            while (reader.Read())
            {
              // HUE
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueBridgeIP"))
              {
                hueBridgeIP = reader.ReadString();
                if (init)
                {
                  tbHueBridgeIP.Text = hueBridgeIP;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueAppname"))
              {
                hueAppName = reader.ReadString();
                if (init)
                {
                  tbHueAppName.Text = hueAppName;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueAppKey"))
              {
                hueAppKey = reader.ReadString();
                if (init)
                {
                  tbHueAppKey.Text = hueAppKey;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueBrightness"))
              {
                hueBrightness = reader.ReadString();
                if (init)
                {
                  cbHueBrightness.Text = hueBrightness;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueSaturation"))
              {
                hueSaturation = reader.ReadString();
                if (init)
                {
                  cbHueSaturation.Text = hueSaturation;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueTransitionTime"))
              {
                hueTransitiontime = reader.ReadString();
                if (init)
                {
                  cbHueTransitionTime.Text = hueTransitiontime;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueColorTemperature"))
              {
                hueColorTemperature = reader.ReadString();
                if (init)
                {
                  cbHueColorTemperature.Text = hueColorTemperature;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueHue"))
              {
                hueHue = reader.ReadString();
                if (init)
                {
                  cbHueHue.Text = hueHue;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueSetBrightnessStartup"))
              {
                HueSetBrightnessStartup = Boolean.Parse(reader.ReadString());
                if (init)
                {
                  cbHueSetBrightnessStartup.Checked = HueSetBrightnessStartup;
                }
              }


              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueRunningWindows8"))
              {
                hueRunningWindows8 = Boolean.Parse(reader.ReadString());
                if (init)
                {
                  cbRunningWindows8.Checked = hueRunningWindows8;
                }
              }

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueAutoConnectBridge"))
              {
                hueAutoconnectBridge = Boolean.Parse(reader.ReadString());
                if (init)
                {
                  cbAutoConnectBridge.Checked = hueAutoconnectBridge;
                }
              }


              // Remote API
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "RemoteAPIenabled"))
              {
                HueRemoteAPIenabled = Boolean.Parse(reader.ReadString());
                if (init)
                {
                  cbRemoteAPIEnabled.Checked = HueRemoteAPIenabled;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "RemoteAPIIP"))
              {
                remoteAPIip = reader.ReadString();
                if (init)
                {
                  tbRemoteAPIip.Text = remoteAPIip;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "RemoteAPIPort"))
              {
                remoteAPIport = reader.ReadString();
                if (init)
                {
                  tbRemoteApiPort.Text = remoteAPIport;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "RemoteAPISenDelay"))
              {
                remoteAPISendDelay = reader.ReadString();
                if (init)
                {
                  tbRemoteAPIsendDelay.Text = remoteAPISendDelay;
                }
              }

              // Various
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "MinimizeToTray"))
              {
                MinimizeToTray = Boolean.Parse(reader.ReadString());
                if (init)
                {
                  cbMinimizeToTray.Checked = MinimizeToTray;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "MinimizeToTrayOnStartup"))
              {
                MinimizeOnStartup = Boolean.Parse(reader.ReadString());
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
                EnableIndividualLightSettings = Boolean.Parse(reader.ReadString());
                if (init)
                {
                  cbEnableIndividualLightSettings.Checked = EnableIndividualLightSettings;
                }
              }

              // LED devices
              string id = "";
              string type = "";
              string location = "";
              string sendDelay = "";
              string brightness = "";
              string saturation = "";
              string colorTemperature = "";
              string hue = "";
              string staticColors = "";

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

                  LEDDevice ld = new LEDDevice();
                  ld.ID = id;
                  ld.location = location;
                  ld.sendDelay = sendDelay;
                  ld.brightness = brightness;
                  ld.saturation = saturation;
                  ld.colorTemperature = colorTemperature;
                  ld.hue = hue;
                  ld.staticColor = staticColors;
                  ledDevices.Add(ld);
                  ledDevicesGroupFilter.Add(ld);

                  string[] subItems = { type, location, sendDelay, brightness, saturation, colorTemperature, hue, staticColors };
                  lvLedDevices.Items.Add(id).SubItems.AddRange(subItems);
                }
              }

              // LED Locations
              string LedLocation = "";
              string LedPriority = "";

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "LedLocation"))
              {
                reader.ReadToDescendant("Location");
                LedLocation = reader.ReadString();
                reader.ReadToFollowing("Priority");
                LedPriority = reader.ReadString();

                //Add LED ID to devices list
                if (string.IsNullOrEmpty(LedLocation.Trim()) == false)
                {

                  LEDLocation ll = new LEDLocation();
                  ll.Location = LedLocation;
                  ll.Priority = LedPriority;

                  ledLocations.Add(ll);

                  string[] subItems = { LedPriority };
                  lvLedLocations.Items.Add(LedLocation).SubItems.AddRange(subItems);

                  //Add item to combobox
                  cbLedLocation.Items.Add(LedLocation);
                }
              }

              // LED predefined static colors
              string LedPredefinedColorName = "";
              string LedPredefinedColorRGB = "";

              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "LedStaticColor"))
              {
                reader.ReadToDescendant("Name");
                LedPredefinedColorName = reader.ReadString();
                reader.ReadToFollowing("StaticColor");
                LedPredefinedColorRGB = reader.ReadString();

                //Add LED ID to devices list
                if (string.IsNullOrEmpty(LedPredefinedColorName.Trim()) == false)
                {

                  LEDPredefinedStaticColors lpsc = new LEDPredefinedStaticColors();
                  lpsc.ColorName = LedPredefinedColorName;
                  lpsc.RGBvalue = LedPredefinedColorRGB;

                  ledPredefinedStaticColors.Add(lpsc);

                  string[] subItems = { LedPredefinedColorRGB };
                  lvPredefinedStaticColors.Items.Add(LedPredefinedColorName).SubItems.AddRange(subItems);
                }
              }

              // Atmowin
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "AtmowinLocation"))
              {
                atmowinLocation = reader.ReadString();
                if (init)
                {
                  tbAtmowinLocation.Text = atmowinLocation;
                }
              }
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "AtmoWinScanInterval"))
              {
                atmowinScanInterval = reader.ReadString();
                if (init)
                {
                  tbAtmowinScanInterval.Text = atmowinScanInterval;
                }
              }

              //Color calibrations

                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "XRed"))
                {
                  calibrateXred = reader.ReadString();

                  if (init)
                  {
                    tbXRed.Text = calibrateXred;
                  }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "YRed"))
                {
                  calibrateYred = reader.ReadString();
                  if (init)
                  {
                    tbYRed.Text = calibrateYred;
                  }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ZRed"))
                {
                  calibrateZred = reader.ReadString();
                  if (init)
                  {
                    tbZRed.Text = calibrateZred;
                  }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "XGreen"))
                {
                  calibrateXgreen = reader.ReadString();
                  if (init)
                  {
                    tbXGreen.Text = calibrateXgreen;
                  }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "YGreen"))
                {
                  calibrateYgreen = reader.ReadString();
                  if (init)
                  {
                    tbYGreen.Text = calibrateYgreen;
                  }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ZGreen"))
                {
                  calibrateZgreen = reader.ReadString();
                  if (init)
                  {
                    tbZGreen.Text = calibrateZgreen;
                  }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "XBlue"))
                {
                  calibrateXblue = reader.ReadString();
                  if (init)
                  {
                    tbXBlue.Text = calibrateXblue;
                  }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "YBlue"))
                {
                  calibrateYblue = reader.ReadString();
                  if (init)
                  {
                    tbYBlue.Text = calibrateYblue;
                  }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "ZBlue"))
                {
                  calibrateZblue = reader.ReadString();
                  if (init)
                  {
                    tbZBlue.Text = calibrateZblue;
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
        else
        {
          //Logger("Error while loading XML configuration");
          //Logger(e.Message);
        }
      }
    }
    private void SaveSettings(Boolean init)
    {
      try
      {
        Properties.Settings.Default.Save();

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "  ";
        settings.NewLineOnAttributes = true;

        using (XmlWriter writer = XmlWriter.Create("settings.xml", settings))
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
              catch { };

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
              catch { };

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
              catch { };

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
        else
        {
          //Logger("Error while saving XML setings.");
          //Logger(et.Message);
        }
      }
    }
    private void refreshSettings()
    {
      userEditedSettings = true;
      SaveSettings(false);
      LoadSettings(true);
    }

    public static string formatTitle()
    {
      string title = AssemblyInfo.AssemblyInfoLookUp.Title;
      string version = AssemblyInfo.AssemblyInfoLookUp.VersionFull.ToString();
      string copyright = AssemblyInfo.AssemblyInfoLookUp.Copyright;

      string formattedTitle = string.Format("{0} - {1} - {2}", title, version, copyright);
      return formattedTitle;
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveSettings(false);
      scanAtmowin = false;
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
    public void startAPIserver()
    {
      swRemoteApi.Start();
      if (Form1.remoteAPIip == "Any")
      {
        tcpListener = new TcpListener(IPAddress.Any, int.Parse(remoteAPIport));
      }
      else
      {
        IPAddress IP = IPAddress.Parse(Form1.remoteAPIip);
        tcpListener = new TcpListener(IP, int.Parse(remoteAPIport));
      }

      listenThread = new Thread(new ThreadStart(ListenForClients));
      listenThread.Start();
      Logger("Started service for remote API calls");
    }
    private void ListenForClients()
    {
      tcpListener.Start();
      while (true)
      {
        //blocks until a client has connected to the server
        TcpClient client = tcpListener.AcceptTcpClient();

        //create a thread to handle communication 
        //with connected client
        Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
        clientThread.Start(client);
      }
    }

    private void HandleClientComm(object client)
    {

      TcpClient tcpClient = (TcpClient)client;
      NetworkStream clientStream = tcpClient.GetStream();

      byte[] message = new byte[4096];
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
        ASCIIEncoding encoder = new ASCIIEncoding();
        string apiCommandMessage = encoder.GetString(message, 0, bytesRead);
        try
        {
          //Get command type
          string[] apiMessageSplit = apiCommandMessage.Split(',');
          string commandSender = apiMessageSplit[0];
          string commandType = apiMessageSplit[1];


          //Command type COLOR
          if (commandType == APIcommandType.Color.ToString())
          {
            int red = int.Parse(apiMessageSplit[2]);
            int green = int.Parse(apiMessageSplit[3]);
            int blue = int.Parse(apiMessageSplit[4]);
            int priority = int.Parse(apiMessageSplit[5]);

            Color inputColor = Color.FromArgb(red, green, blue);

            //Only send if delay has expired or if we get a high priority color
            if (swRemoteApi.ElapsedMilliseconds >= int.Parse(remoteAPISendDelay) || priority < 50)
            {
              if (Form1.LogRemoteApiCalls)
              {
                Logger(string.Format("[ {0} ] [ PRIO {1} ] - {2}", commandSender, priority.ToString(), "Got color command from Atmolight"));
              }
              if (red == 0 && green == 0 && blue == 0)
              {
                inputColor = Color.Black;
              }

              //If we receive a high priority messsage drop subsequent messages for x amount of time
              if (priority < 50)
              {
                swRemoteApi.Reset();
                swRemoteApi.Stop();
                Thread.Sleep(1000);
                if (commandSender.ToLower() == "atmolight")
                {
                  hueSetColor(inputColor, Form1.sources.ATMOLIGHT, 0, false);
                }
                if (commandSender.ToLower() == "huehelper")
                {
                  hueSetColor(inputColor, Form1.sources.HUEHELPER, 0, false);
                }


                Thread.Sleep(1000);
              }

              //Validate if colors are correct
              if (red >= 0 && red <= 255 && green >= 0 && green <= 255 && blue >= 0 && blue <= 255)
              {
                if (commandSender.ToLower() == "atmolight")
                {
                  hueSetColor(inputColor, Form1.sources.ATMOLIGHT, 0, false);
                }
                if (commandSender.ToLower() == "huehelper")
                {
                  hueSetColor(inputColor, Form1.sources.HUEHELPER, 0, false);
                }
              }

              //Restart stop watch
              swRemoteApi.Restart();
            }
          }

          //Command type POWER
          if (commandType == APIcommandType.Power.ToString())
          {
            string powerCommand = apiMessageSplit[2];
            Logger(string.Format("[ {0} ], Powering {1} Hue Bridge", commandSender, powerCommand));
            if (powerCommand == "ON")
            {
              TurnLightsON();
            }
            else if (powerCommand == "OFF")
            {
              TurnLightsOFF();
            }
          }
          
          //Command type THEATER
          if (commandType == APIcommandType.Theater.ToString())
          {
            string theaterCommand = apiMessageSplit[2];
            Logger(string.Format("[ {0} ] COMMAND: {1}", commandSender, theaterCommand));

            if (theaterCommand == "DISABLE")
            {
                Logger("[ THEATER MODE ] - restoring leds as playback stopped or leds disabled");
                TurnLightsONTheater();
            }
            else if (theaterCommand == "ENABLE")
            {
              Logger("[ THEATER MODE ] - disabling leds during movie playback");
              TurnLightsOFFTheater();
            }
          }

          //Command type GROUP
          if (commandType == APIcommandType.Group.ToString())
          {
            string groupCommand = apiMessageSplit[2];
            Color inputColor = Color.Black;

            if (groupCommand == "SetStaticColor")
            {
              string groupName =  apiMessageSplit[3];
              string colorName = apiMessageSplit[4];
 
              if (string.IsNullOrEmpty(colorName) == false)
              {
                if (colorName == "Off" || colorName == "Uitschakelen")
                {
                  inputColor = Color.Black;
                }
                else
                {
                  foreach (LEDPredefinedStaticColors staticColor in ledPredefinedStaticColors)
                  {
                    if (staticColor.ColorName == colorName)
                    {
                      string[] RGBcolor = staticColor.RGBvalue.Split(',');
                      int ColorRed = int.Parse(RGBcolor[0]);
                      int ColorGreen = int.Parse(RGBcolor[1]);
                      int colorBlue = int.Parse(RGBcolor[2]);
                      inputColor = Color.FromArgb(ColorRed, ColorGreen, colorBlue);
                    }
                  }
                }
              }

              if (groupName == "All" || groupName == "Alle")
              {
                ledDevicesGroupStaticColors.Clear();

                foreach (LEDDevice ledDevice in ledDevices)
                {
                  LEDDevice ld = new LEDDevice();
                  ld.ID = ledDevice.ID;
                  ld.location = ledDevice.location;
                  ld.sendDelay = ledDevice.sendDelay;
                  ld.brightness = ledDevice.brightness;
                  ld.saturation = ledDevice.saturation;
                  ld.colorTemperature = ledDevice.colorTemperature;
                  ld.hue = ledDevice.hue;
                  ld.staticColor = ledDevice.staticColor;
                  ledDevicesGroupStaticColors.Add(ld);
                }

                Logger(string.Format("[ {0} ], Group command {1}, Setting Color {2} to {3}", commandSender, groupCommand, inputColor.ToString(),"ALL GROUPS"));

                hueSetColor(inputColor, Form1.sources.ATMOLIGHT, 0, true);
              }
              else
              {
                ledDevicesGroupStaticColors.Clear();
                if (string.IsNullOrEmpty(groupName) == false)
                {
                  foreach (LEDDevice ledDevice in ledDevices)
                  {
                    if (ledDevice.location == groupName)
                    {
                      LEDDevice ld = new LEDDevice();
                      ld.ID = ledDevice.ID;
                      ld.location = ledDevice.location;
                      ld.sendDelay = ledDevice.sendDelay;
                      ld.brightness = ledDevice.brightness;
                      ld.saturation = ledDevice.saturation;
                      ld.colorTemperature = ledDevice.colorTemperature;
                      ld.hue = ledDevice.hue;
                      ld.staticColor = ledDevice.staticColor;
                      ledDevicesGroupStaticColors.Add(ld);
                    }
                  }
                  Logger(string.Format("[ {0} ], Group command {1}, Setting Color {2} to {3}", commandSender, groupCommand, inputColor.ToString(), groupName));
                  hueSetColor(inputColor, Form1.sources.ATMOLIGHT, 0, true);
                }
              }
            }
            if (groupCommand == "OnlyActivate")
            {
              ledDevicesGroupFilter.Clear();
              
              //Clear all led states
              groupFilterActive = true;
              string groupName = apiMessageSplit[3];

              if (string.IsNullOrEmpty(groupName) == false)
              {
                if (groupName == "All" || groupName == "Alle")
                {
                  Logger(string.Format("[ {0} ], Group command {1}, Setting active group to {2}", commandSender, groupCommand, groupName));
                  groupFilterActive = false;
                }
                else
                {
                  foreach (LEDDevice ledDevice in ledDevices)
                  {
                    if (ledDevice.location == groupName)
                    {
                      LEDDevice ld = new LEDDevice();
                      ld.ID = ledDevice.ID;
                      ld.location = ledDevice.location;
                      ld.sendDelay = ledDevice.sendDelay;
                      ld.brightness = ledDevice.brightness;
                      ld.saturation = ledDevice.saturation;
                      ld.colorTemperature = ledDevice.colorTemperature;
                      ld.hue = ledDevice.hue;
                      ld.staticColor = ledDevice.staticColor;
                      ledDevicesGroupFilter.Add(ld);
                    }
                  }
                  Logger(string.Format("[ {0} ], Group command {1}, Setting active group to {2}", commandSender, groupCommand, groupName));
                  groupFilterActive = true;
                }
              }
            }
          }

        }
        catch (Exception e)
        {
          Logger(string.Format("[ {0} ] {1}", "UNKNOWN", e.Message));
          Logger(string.Format("[ {0} ] {1}", "UNKNOWN", e.ToString()));
        }
      }

      tcpClient.Close();
    }

    private void btnLocateHueBridge_Click(object sender, EventArgs e)
    {
      refreshSettings();
      MessageBox.Show("Click on the button of your Hue Bridge and press OK to continue.");
      if (cbRunningWindows8.Checked == false)
      {
        BridgeLocator();
      }
      else
      {
        SSDPBridgeLocator();
      }
    }

    public async Task BridgeLocator()
    {
      IBridgeLocator locator = new HttpBridgeLocator();
      int bridgesFound = 0;

      //For Windows 8 and .NET45 projects you can use the SSDPBridgeLocator which actually scans your network. 
      //See the included BridgeDiscoveryTests and the specific .NET and .WinRT projects

      IEnumerable<string> bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(10));
      foreach (string bridgeIP in bridgeIPs)
      {
        tbHueBridgeIP.Text = bridgeIP;
        Logger("Bridges found using standard discovery method: " + bridgeIP);
        bridgesFound++;
      }

      if (bridgesFound == 0)
      {
        Logger("Couldn't find any Hue Bridges in network using standard discovery method");
      }

      //Connect to bridge if found and option is enabled
      if (hueAutoconnectBridge)
      {
        client = new HueClient(hueBridgeIP);
        client.RegisterAsync(hueAppName, hueAppKey);
        try
        {
          client.Initialize(hueAppKey);
          Logger("HUE has been intialized on STARTUP");
        }
        catch (Exception et)
        {
          if (cbEnableDebuglog.Checked == true)
          {
            Logger(et.ToString());
          }
        }
      }

      //Set connection label
      if (client.IsInitialized)
      {
        lblConnectionStatus.Text = "Status: Connected";
      }
      else
      {
        lblConnectionStatus.Text = "Status: disconnected";
      }
    }
    public async Task SSDPBridgeLocator()
    {
      IBridgeLocator locator = new SSDPBridgeLocator();
      int bridgesFound = 0;

      var bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(10));
      foreach (string bridgeIP in bridgeIPs)
      {
        tbHueBridgeIP.Text = bridgeIP;
        Logger("Bridges found using SSDP discovery method: " + bridgeIP.ToString());
        bridgesFound++;
      }

      if (bridgesFound == 0)
      {
        Logger("Couldn't find any Hue Bridges in network using SSDP discovery method");
      }

      //Connect to bridge if found and option is enabled
      if (hueAutoconnectBridge)
      {
        client = new HueClient(hueBridgeIP);
        client.RegisterAsync(hueAppName, hueAppKey);
        try
        {
          client.Initialize(hueAppKey);
          Logger("HUE has been intialized on STARTUP");
        }
        catch (Exception et)
        {
          if (cbEnableDebuglog.Checked == true)
          {
            Logger(et.ToString());
          }
        }
      }

      //Set connection label
      if (client.IsInitialized)
      {
        lblConnectionStatus.Text = "Status: Connected";
      }
      else
      {
        lblConnectionStatus.Text = "Status: disconnected";
      }

    }
    public double[] getRGBtoXY(Color c, DeviceType device)
    {

      double[] normalizedToOne = new double[3];
      float cred, cgreen, cblue;
      cred = c.R;
      cgreen = c.G;
      cblue = c.B;
      normalizedToOne[0] = (cred / 255);
      normalizedToOne[1] = (cgreen / 255);
      normalizedToOne[2] = (cblue / 255);
      float red, green, blue;

      // Make red more vivid
      if (normalizedToOne[0] > 0.04045)
      {
        red = (float)Math.Pow(
                (normalizedToOne[0] + 0.055) / (1.0 + 0.055), 2.4);
      }
      else
      {
        red = (float)(normalizedToOne[0] / 12.92);
      }

      // Make green more vivid
      if (normalizedToOne[1] > 0.04045)
      {
        green = (float)Math.Pow((normalizedToOne[1] + 0.055)
                / (1.0 + 0.055), 2.4);
      }
      else
      {
        green = (float)(normalizedToOne[1] / 12.92);
      }

      // Make blue more vivid
      if (normalizedToOne[2] > 0.04045)
      {
        blue = (float)Math.Pow((normalizedToOne[2] + 0.055)
                / (1.0 + 0.055), 2.4);
      }
      else
      {
        blue = (float)(normalizedToOne[2] / 12.92);
      }

      float X = (float)0;
      float Y = (float)0;
      float Z = (float)0;


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
      }

      float x = X / (X + Y + Z);
      float y = Y / (X + Y + Z);

      double[] xy = new double[2];
      xy[0] = x;
      xy[1] = y;
      List<double> xyAsList = new List<double>(xy);
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
      if (client.IsInitialized == false && string.IsNullOrEmpty(hueBridgeIP) == false)
      {
        client = new HueClient(hueBridgeIP);
        client.RegisterAsync(hueAppName, hueAppKey);
        try
        {
          client.Initialize(hueAppKey);
          Logger("HUE has been intialized on COLOR CHANGE");
        }
        catch (Exception et)
        {
          if (cbEnableDebuglog.Checked == true)
          {
            Logger(et.ToString());
          }
        }
      }

      LightCommand command = new LightCommand();
      command.On = true;
      command.Brightness = brightness;

      List<string> lights = new List<string>();
      foreach (LEDDevice ld in ledDevices)
      {
        lights.Add(ld.ID);
      }

      if (lights.Count() > 0)
      {
        client.SendCommandAsync(command, lights);
        Logger(string.Format("[ {0} ] {1}", sources.LOCAL, "Completed sending brightness " + brightness.ToString() + " to Hue Bridge"));
      }
    }

    public async Task hueSetColor(Color ColorInput, sources source, int delay, Boolean UsingManualGroupFilter)
    {
      try
      {
        //Reset wait flag
        waitTimer = false;
        if (cbLogRemoteApiCalls.Checked && source == sources.ATMOLIGHT)
        {
          Logger(string.Format("[ {0} ] {1}", source.ToString(), "Setting color #" + ColorInput.ToString() + " to Hue Bridge"));
        }
        else
        {
          Logger(string.Format("[ {0} ] {1}", source.ToString(), "Setting color #" + ColorInput.ToString() + " to Hue Bridge"));
        }

        //If client isn't connected we try to reconnect, for example when network disconnects or on power events(suspend/resume).
        if (client.IsInitialized == false && string.IsNullOrEmpty(hueBridgeIP) == false)
        {
          client = new HueClient(hueBridgeIP);
          client.RegisterAsync(hueAppName, hueAppKey);
          try
          {
            client.Initialize(hueAppKey);
            Logger("HUE has been intialized on COLOR CHANGE");
          }
          catch (Exception et)
          {
            if (cbEnableDebuglog.Checked == true)
            {
              Logger(et.ToString());
            }
          }
        }

        //Send command to Hue and split up commands for every light
        if (ledDevices.Count > 0)
        {
           List<LEDDevice> ledDevicesIndividualWithGroupFilter = new List<LEDDevice>();
          if (groupFilterActive && UsingManualGroupFilter == false)
          {
            ledDevicesIndividualWithGroupFilter = ledDevicesGroupFilter;
          }
          else if (UsingManualGroupFilter)
          {
            ledDevicesIndividualWithGroupFilter = ledDevicesGroupStaticColors;
          }
          else if (UsingManualGroupFilter == false && groupFilterActive == false)
          {
            ledDevicesIndividualWithGroupFilter = ledDevices;
          }

          if (EnableIndividualLightSettings)
          {
            List<string> lights = new List<string>();
            foreach (LEDDevice ld in ledDevicesIndividualWithGroupFilter)
            {
              waitTimer = true;
              lights.Add(ld.ID);
              IEnumerable<string> lightList = lights;


              LightCommand command = new LightCommand();
              command.On = true;

              double[] colorCoordinates = getRGBtoXY(ColorInput, DeviceType.bloom);
              if (colorisON)
              {
                command.ColorCoordinates = colorCoordinates;
              }
              else
              {
                command.TurnOn();
                command.ColorCoordinates = colorCoordinates;

                colorisON = true;
              }

              //Turn leds off if we receive black
              if (ColorInput == Color.Black)
              {
                colorisON = false;
                command.TurnOff();
              }

              //Check to see if LED device has custom settings


              //Color transition
              //0-~
              if (ld.sendDelay != hueTransitiontime && string.IsNullOrEmpty(ld.sendDelay) == false)
              {
                command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(ld.sendDelay));
              }
              else
              {
                command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(hueTransitiontime));
              }

              //Brightness
              //0-254
              if (ld.brightness != hueBrightness && string.IsNullOrEmpty(ld.brightness) == false)
              {
                command.Brightness = byte.Parse(ld.brightness);
              }
              else
              {
                if (HueSetBrightnessStartup == false || userEditedSettings)
                {
                  command.Brightness = byte.Parse(hueBrightness);
                }
              }

              //Saturation
              //0-254
              if (ld.saturation != hueSaturation && string.IsNullOrEmpty(ld.saturation) == false)
              {
                command.Saturation = int.Parse(ld.saturation);
              }
              else
              {
                if (userEditedSettings)
                {
                  command.Saturation = int.Parse(hueSaturation);
                }
              }

              //Color temperature
              //154-500
              if (ld.colorTemperature != hueColorTemperature && string.IsNullOrEmpty(ld.colorTemperature) == false)
              {
                command.ColorTemperature = int.Parse(ld.colorTemperature);
              }
              else
              {
                if (string.IsNullOrEmpty(hueColorTemperature) == false)
                {
                  if (userEditedSettings)
                  {
                    command.ColorTemperature = int.Parse(hueColorTemperature);
                  }
                }
              }

              //Hue
              if (ld.hue != hueHue && string.IsNullOrEmpty(ld.hue) == false)
              {
                command.Hue = int.Parse(ld.hue);
              }
              else
              {
                if (string.IsNullOrEmpty(hueHue) == false)
                {
                  if (userEditedSettings)
                  {
                    command.Hue = int.Parse(hueHue);
                  }
                }
              }

              userEditedSettings = false;

              Logger(string.Format("[ {0} ] {1}", source.ToString(), "Sending color " + ColorInput.ToString() + " to Hue Bridge for LIGHT " + ld.ID.ToString()));

              //Logger(ld.ID + "  ->> transition time" + command.TransitionTime.ToString() + "- >> brightness" + command.Brightness.ToString() + " ->> saturation" + command.Saturation.ToString() + " ->> list #" + lightList.Count().ToString());

              client.SendCommandAsync(command, lightList);
              command.On = false;
              lights.Clear();
            }
            waitTimer = false;
          }
          else
          {
            LightCommand command = new LightCommand();
            command.On = true;

            double[] colorCoordinates = getRGBtoXY(ColorInput, DeviceType.bloom);
            if (colorisON)
            {
              command.ColorCoordinates = colorCoordinates;
            }
            else
            {
              command.TurnOn();
              command.ColorCoordinates = colorCoordinates;

              colorisON = true;
            }

            //Turn leds off if we receive black
            if (ColorInput == Color.Black)
            {
              colorisON = false;
              command.TurnOff();
            }

            //Color transition
            //0-~
            command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(hueTransitiontime));

            //Brightness
            //0-254
            if (HueSetBrightnessStartup == false || userEditedSettings)
            {
              command.Brightness = byte.Parse(hueBrightness);
            }

            //Saturation
            //0-254
            if (userEditedSettings)
            {
              command.Saturation = int.Parse(hueSaturation);
            }

            //Color temperature
            //154-500
            if (string.IsNullOrEmpty(hueColorTemperature) == false)
            {
              if (userEditedSettings)
              {
                command.ColorTemperature = int.Parse(hueColorTemperature);
              }
            }

            //Hue
            if (string.IsNullOrEmpty(hueHue) == false)
            {
              if (userEditedSettings)
              {
                command.Hue = int.Parse(hueHue);
              }
            }

            userEditedSettings = false;

            List<string> lights = new List<string>();

            if (groupFilterActive && UsingManualGroupFilter == false)
            {
              foreach (LEDDevice ld in ledDevicesGroupFilter)
              {
                lights.Add(ld.ID);
              }
            }
            else if (UsingManualGroupFilter)
            {
              foreach (LEDDevice ld in ledDevicesGroupStaticColors)
              {
                lights.Add(ld.ID);
              }
            }
            else if (UsingManualGroupFilter == false && groupFilterActive == false)
            {
              foreach (LEDDevice ld in ledDevices)
              {
                lights.Add(ld.ID);
              }
            }

            IEnumerable<string> lightList = lights;
            if (lightList.Count() > 0)
            {
              client.SendCommandAsync(command, lightList);
            }
            command.On = false;
          }
          if (cbLogRemoteApiCalls.Checked && source == sources.ATMOLIGHT)
          {

            Logger(string.Format("[ {0} ] {1}", source.ToString(), "Completed sending color " + ColorInput.ToString() + " to Hue Bridge"));
          }
          else
          {
            Logger(string.Format("[ {0} ] {1}", source.ToString(), "Completed sending color " + ColorInput.ToString() + " to Hue Bridge"));
          }
        }
      }
      catch (Exception et)
      {
        //MessageBox.Show(et.ToString());
        if (cbEnableDebuglog.Checked == true)
        {
          Logger(et.ToString());
        }
      }
    }
    private void sendLightCommand(LightCommand command,IEnumerable<string> lightList)
    {
      /*
      while(waitTimer)
      {
        //Wait
        Thread.Sleep(1);
      }*/
      client.SendCommandAsync(command, lightList);
    }
    private void btnStartAtmowinHue_Click(object sender, EventArgs e)
    {

      if (string.IsNullOrEmpty(hueBridgeIP) == true)
      {
        if (cbRunningWindows8.Checked == false)
        {
          BridgeLocator();
        }
        else
        {
          SSDPBridgeLocator();
        }
      }
      scanAtmowin = true;
      Logger("Start monitoring Atmowin");
      Thread t = new Thread(startMonitoringAtmowin);
      t.IsBackground = true;
      t.Start();

    }
    private void btnStopAtmowinHue_Click(object sender, EventArgs e)
    {
      scanAtmowin = false;
      Logger("Stop monitoring Atmowin");

      if (string.IsNullOrEmpty(atmowinStaticColor) == false)
      {
        hueSetColor(Color.Black, sources.LOCAL, 0, false);
      }
      else
      {
        hueSetColor(Color.Black, sources.LOCAL, 0, false);
      }
    }

    private void startMonitoringAtmowin()
    {
      string atmowinColorInformation = "";
      string colorRed = "";
      string colorGreen = "";
      string colorBlue = "";
      string numberOfChannels = "";
      Color previousColor = Color.Black;
      try
      {
        while (scanAtmowin == true)
        {
          try
          {
            using (FileStream fileStream = new FileStream(atmowinLocation + "hue_output.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
              using (StreamReader streamReader = new StreamReader(fileStream))
              {
                atmowinColorInformation = streamReader.ReadToEnd().Trim();
              }
            }
            string[] atmowinColorSplit = atmowinColorInformation.Split(',');
            colorRed = atmowinColorSplit[0];
            colorGreen = atmowinColorSplit[1];
            colorBlue = atmowinColorSplit[2];
            numberOfChannels = atmowinColorSplit[3];
            Logger("------------------------------");
            Logger("Atmowin information -> R = " + colorRed + " / G = " + colorGreen + " / B = " + colorBlue + " / CHANNELS = " + numberOfChannels);

            //Needs changing as Atmowin might report 0,0,0 normally
            if (colorRed == "0" && colorGreen == "0" && colorBlue == "0" && string.IsNullOrEmpty(atmowinStaticColor) == false)
            {
              Logger("Atmowin disconnected, sending preset static color");
              hueSetColor(Color.Black, sources.LOCAL, 0, false);
            }
            else
            {
              //Convert RGB to HEX
              Color myColor = Color.FromArgb(int.Parse(colorRed), int.Parse(colorGreen), int.Parse(colorBlue));

              //Send color
              if (myColor != previousColor)
              {
                hueSetColor(myColor, sources.LOCAL, 0, false);
              }
              previousColor = myColor;

              Logger("Completed sending color #" + myColor.ToString() + " to Hue Bridge.");
              Logger("------------------------------");
            }

            int sleeptime = int.Parse(atmowinScanInterval);
            Thread.Sleep(sleeptime);
          }
          catch (Exception et)
          {
            Logger(et.ToString());
            int sleeptime = int.Parse(atmowinScanInterval);
            Thread.Sleep(sleeptime);

          }
        }
      }
      catch (Exception et)
      {
        Logger(et.ToString());
        int sleeptime = int.Parse(atmowinScanInterval);
        Thread.Sleep(sleeptime);
      }
    }
    public static string addTrailingSlash(string atmowinFolder)
    {
      try
      {
        string checkForTrailingSlash = atmowinFolder.Substring(atmowinFolder.Length - 1, 1);
        if (checkForTrailingSlash != "\\")
        {
          atmowinFolder = atmowinFolder + "\\";
        }
      }
      catch { };
      return atmowinFolder;
    }
    public void Logger(string text)
    {
      string timestamp = DateTime.Now.ToString("HH:mm:ss.ffffff");
      string message = string.Format("[ {0} ] - {1}", timestamp, text);
      ControlInvike(lbOutputlog, () => lbOutputlog.Items.Add(message));

      if (cbEnableDebuglog.Checked == true)
      {
        StreamWriter sw = new StreamWriter("debug.log", true);
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

    private void rotateColors()
    {
      try
      {
        if (client.IsInitialized == false)
        {
          client = new HueClient(hueBridgeIP);
          client.RegisterAsync(hueAppName, hueAppKey);
          try
          {
            client.Initialize(hueAppKey);
            Logger("HUE has been intialized on COLOR CHANGE");
          }
          catch (Exception et)
          {
            Logger(et.ToString());
          }
        }
        while (hueRotatingColors)
        {
          hueSetColor(Color.Red, sources.LOCAL, 0, false);
          Thread.Sleep(hueRotateDelay);
          hueSetColor(Color.Green, sources.LOCAL, 0, false);
          Thread.Sleep(hueRotateDelay);
          hueSetColor(Color.Blue, sources.LOCAL, 0, false);
          Thread.Sleep(hueRotateDelay);
        }
      }
      catch (Exception et)
      {
        if (cbEnableDebuglog.Checked == true)
        {
          Logger(et.ToString());
        }
      }
    }

    private void btnTestRed_Click(object sender, EventArgs e)
    {
      TurnLightsON();
      hueSetColor(Color.Red, sources.LOCAL, 0, false);
    }

    private void btnTestGreen_Click(object sender, EventArgs e)
    {
      TurnLightsON();
      hueSetColor(Color.Green, sources.LOCAL, 0, false);
    }

    private void btnTestBlue_Click(object sender, EventArgs e)
    {
      TurnLightsON();
      hueSetColor(Color.Blue, sources.LOCAL, 0, false);
    }

    private void btnHueColorClear_Click(object sender, EventArgs e)
    {
      TurnLightsON();
      hueSetColor(Color.Black, sources.LOCAL, 0, false);
    }

    private void btnHueSendCustomColor_Click(object sender, EventArgs e)
    {
      Color customColor = new Color();
      try
      {
        int red = int.Parse(cbTestCustomColorR.Text);
        int green = int.Parse(cbTestCustomColorG.Text);
        int blue = int.Parse(cbTestCustomColorB.Text);
        customColor = Color.FromArgb(red, green, blue);
      }
      catch
      {
        Logger("Incorrect color values for test custom colors used, R/G/B must be between 0 and 255");
        MessageBox.Show("Incorrect color values for test custom colors used, R/G/B must be between 0 and 255");
      }
      hueSetColor(customColor, sources.LOCAL, 0, false);
    }

    private void btnHueColorRotateTestStart_Click(object sender, EventArgs e)
    {

      hueRotatingColors = true;
      Thread t = new Thread(rotateColors);
      t.IsBackground = true;
      t.Start();
    }
    private void btnHueColorRotateTestStop_Click(object sender, EventArgs e)
    {
      hueRotatingColors = false;
      hueSetColor(Color.Black, sources.LOCAL, 0, false);
      colorisON = false;
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
        string id = tbLedID.Text;
        string staticColors = "";
        if (string.IsNullOrEmpty(tbLedR.Text) == false && string.IsNullOrEmpty(tbLedG.Text) == false && string.IsNullOrEmpty(tbLedB.Text) == false)
        {
          staticColors = string.Format("{0},{1},{2}", tbLedR.Text, tbLedG.Text, tbLedB.Text);
        }

        string[] subItems = { cbLedType.Text, cbLedLocation.Text, tbLedSendDelay.Text, tbLedBrightness.Text, tbLedSaturation.Text, tbLedColorTemperature.Text, tbLedHue.Text, staticColors };

        lvLedDevices.Items.Add(id).SubItems.AddRange(subItems);

        SetInUseLedDevices();

        tbLedID.Text = "";
        cbLedType.Text = "";
        cbLedLocation.Text = "";
        tbLedID.Focus();
      }
    }
    private enum MoveDirection { Up = -1, Down = 1 };

    private static void MoveListViewItems(ListView sender, MoveDirection direction)
    {
      int dir = (int)direction;
      int opp = dir * -1;

      bool valid = sender.SelectedItems.Count > 0 &&
                      ((direction == MoveDirection.Down && (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
                  || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));

      if (valid)
      {
        foreach (ListViewItem item in sender.SelectedItems)
        {
          int index = item.Index + dir;
          sender.Items.RemoveAt(item.Index);
          sender.Items.Insert(index, item);

          sender.Items[index + opp].SubItems[1].Text = (index + opp).ToString();
          item.SubItems[1].Text = (index).ToString();
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
      ledDevices.Clear();
      foreach (ListViewItem item in lvLedDevices.Items)
      {
        LEDDevice ld = new LEDDevice();
        ld.ID = item.Text;
        ledDevices.Add(ld);
      }
    }
    private void btnHueSetScene_Click(object sender, EventArgs e)
    {
      //client.CreateOrUpdateSceneAsync(tbHueSceneID.Text, tbHueSceneName.Text, ledDevices);
    }

    private void btnHueLocateScenes_Click(object sender, EventArgs e)
    {
      getScenes();
    }
    private async Task getScenes()
    {
      IEnumerable<Q42.HueApi.Models.Scene> scenes = await client.GetScenesAsync();
      foreach (Q42.HueApi.Models.Scene scene in scenes)
      {
        Logger(string.Format("Active:{0} - ID:{1} - Name:{2} - Lights:{3}", scene.Active, scene.Id, scene.Name, scene.Lights));
      }
    }
    private void btnRefreshSettings_Click(object sender, EventArgs e)
    {
      refreshSettings();
    }

    private void tbHueBridgeIP_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void tbHueAppName_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void tbHueAppKey_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbHueBrightness_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbHueSaturation_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbHueColorTemperature_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbHueHue_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbHueTransitionTime_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbHueSetBrightnessStartup_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbRunningWindows8_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbAutoConnectBridge_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private void cbRemoteAPIEnabled_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }

    private Boolean validatorInt(string input, int minValue, int maxValue, Boolean validateMaxValue)
    {
      Boolean IsValid = false;
      Int32 value;
      bool IsInteger = Int32.TryParse(input, out value);

      if (IsInteger)
      {
        //Only check minValue
        if (validateMaxValue == false && value >= minValue)
        {
          IsValid = true;
        }
        //Check both min/max values
        else
        {
          if (value >= minValue && value <= maxValue)
          {
            IsValid = true;
          }
        }
      }
      return IsValid;
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      if (MinimizeToTray)
      {
        if (FormWindowState.Minimized == this.WindowState)
        {
          this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
          trayIconHue.Visible = true;
          this.Hide();
        }

        else if (FormWindowState.Normal == this.WindowState)
        {
          this.FormBorderStyle = FormBorderStyle.FixedSingle;
          trayIconHue.Visible = false;
        }
      }
    }

    private void notifyIcon1_DoubleClick(object sender, EventArgs e)
    {
      this.Show();
      this.WindowState = FormWindowState.Normal;
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
      int min = 0;
      int max = 255;
      if (validatorInt(cbTestCustomColorR.Text, min, max,true) == false)
      {
        MessageBox.Show("RGB color value must be between 0 and 255");
      }
    }

    private void cbTestCustomColorG_Validating(object sender, CancelEventArgs e)
    {
      int min = 0;
      int max = 255;
      if (validatorInt(cbTestCustomColorG.Text, min, max, true) == false)
      {
        MessageBox.Show("RGB color value must be between 0 and 255");
      }
    }

    private void cbTestCustomColorB_Validating(object sender, CancelEventArgs e)
    {
      int min = 0;
      int max = 255;
      if (validatorInt(cbTestCustomColorB.Text, min, max, true) == false)
      {
        MessageBox.Show("RGB color value must be between 0 and 255");
      }
    }
    private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
    {
      this.Show();
      this.WindowState = FormWindowState.Normal;
    }
    private void toolStripMenuItemClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    private void cbHuePowerHandling_SelectedIndexChanged(object sender, EventArgs e)
    {
      HuePowerHandling = cbHuePowerHandling.SelectedIndex;
    }

    #region powerstate monitoring
    private void monitorPowerState()
    {
      SystemEvents.PowerModeChanged += OnPowerModeChanged;
    }
    private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
    {
      switch (e.Mode)
      {
        case PowerModes.Resume:
          int selectedPowerModeResume = HuePowerHandling;
          if (selectedPowerModeResume == 0 || selectedPowerModeResume == 2)
          {
            Logger("[ STANDBY ] - resuming AtmoHue connection and setting initial command");
            Thread tResume = new Thread(TurnLightsON);
            tResume.IsBackground = true;
            tResume.Start();
          }
          break;
        case PowerModes.Suspend:
          int selectedPowerModeSuspend = HuePowerHandling;
          if (selectedPowerModeSuspend == 1 || selectedPowerModeSuspend == 2)
          {
            Logger("[ STANDBY ] - Suspending AtmoHue and turning off leds");
            Thread tSuspend = new Thread(TurnLightsOFF);
            tSuspend.IsBackground = true;
            tSuspend.Start();
          }
          break;
      }
    }
    public void TurnLightsOFF()
    {
      try
      {
        colorisON = false;
        LightCommand command = new LightCommand();
        command.On = true;
        command.TurnOff();

        List<string> lights = new List<string>();
        foreach (LEDDevice ld in ledDevices)
        {
          lights.Add(ld.ID);
        }

        IEnumerable<string> lightList = lights;

        client.SendCommandAsync(command, lightList);
        command.On = false;
        Logger("[ STANDBY ] - Suspended AtmoHue and set color to black");

      }
      catch (Exception e)
      {
        Logger("[ STANDBY ] - Error while sending color black on suspend");
        Logger(e.Message);
      }
    }

    public void TurnLightsON()
    {
      try
      {
        if (client.IsInitialized == false)
        {
          client.Initialize(hueAppKey);
        }

        colorisON = true;
        LightCommand command = new LightCommand();
        command.On = true;
        command.Brightness = byte.Parse(hueBrightness);

        double[] colorCoordinates = getRGBtoXY(Color.Black, DeviceType.bloom);

        command.ColorCoordinates = colorCoordinates;
        command.TurnOn();

        List<string> lights = new List<string>();
        foreach (LEDDevice ld in ledDevices)
        {
          lights.Add(ld.ID);
        }

        IEnumerable<string> lightList = lights;

        client.SendCommandAsync(command, lightList);
        command.On = false;
        Logger("[ STANDBY / THEATER ] - Resumed AtmoHue and set initial color command (TurnOn) with brightness " + hueBrightness);
      }
      catch (Exception e)
      {
        Logger("[ STANDBY / THEATER ] - Error while turning on Hue on resume");
        Logger(e.Message);
      }
    }
    public void TurnLightsONTheater()
    {
      try
      {
        if (client.IsInitialized == false)
        {
          client.Initialize(hueAppKey);
        }

        colorisON = true;
        LightCommand command = new LightCommand();
        command.On = true;

        command.TurnOn();

        List<string> lights = new List<string>();
        foreach (LEDDevice ld in ledDevices)
        {
          lights.Add(ld.ID);
        }

        IEnumerable<string> lightList = lights;

        client.SendCommandAsync(command, lightList);
        command.On = false;
        Logger("[ THEATER MODE ] - Turned back on lights.");
      }
      catch (Exception e)
      {
        Logger("[ THEATER MODE ] - Error while turning on Hue on after Theater mode");
        Logger(e.Message);
      }
    }
    public void TurnLightsOFFTheater()
    {
      try
      {
        colorisON = false;
        LightCommand command = new LightCommand();
        command.On = true;
        command.TurnOff();

        List<string> lights = new List<string>();
        foreach (LEDDevice ld in ledDevices)
        {
          lights.Add(ld.ID);
        }

        IEnumerable<string> lightList = lights;

        client.SendCommandAsync(command, lightList);
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

    private void btnGetLedIDs_Click(object sender, EventArgs e)
    {
      if (client.IsInitialized)
      {
        getLights();
        MessageBox.Show("Please check log window for listing of located light IDs");
      }
      else
      {
        MessageBox.Show("Not connected to Hue Bridge");
      }
    }
    private async Task getLights()
    {
      IEnumerable<Light> lights = await client.GetLightsAsync();
      foreach (Light light in lights)
      {
        Logger(string.Format("{0} - {1} - {2} - {3} - {4} - {5}", light.Id,light.ModelId,light.Name,light.SoftwareVersion,light.State,light.Type));
      }
    }

    private void tbXRed_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Red, sources.LOCAL, 0, false);
      }
    }

    private void tbXGreen_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Red, sources.LOCAL, 0, false);
      }

    }

    private void tbXBlue_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Red, sources.LOCAL, 0, false);
      }

    }

    private void tbYRed_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Green, sources.LOCAL, 0, false);
      }
    }

    private void tbYGreen_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Green, sources.LOCAL, 0, false);
      }
    }

    private void tbYBlue_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Green, sources.LOCAL, 0, false);
      }
    }

    private void tbZRed_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Blue, sources.LOCAL, 0, false);
      }
    }

    private void tbZGreen_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Blue, sources.LOCAL, 0, false);
      }
    }

    private void tbZBlue_KeyDown(object sender, KeyEventArgs e)
    {
      refreshColorCalibrations();
      if (e.KeyCode.ToString().ToLower() == "return")
      {
        hueSetColor(Color.Blue, sources.LOCAL, 0, false);
      }
    }
    private void refreshColorCalibrations()
    {
        calibrateXred = tbXRed.Text;
        calibrateYred = tbYRed.Text;
        calibrateZred = tbZRed.Text;
        calibrateXgreen = tbXGreen.Text;
        calibrateYgreen = tbYGreen.Text;
        calibrateZgreen = tbZGreen.Text;
        calibrateXblue = tbXBlue.Text;
        calibrateYblue = tbYBlue.Text;
        calibrateZblue = tbZBlue.Text;
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
        string[] subItems = { tbLedLocationPriority.Text };
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
        string predefinedColor = tbPredefinedColorR.Text + "," + tbPredefinedColorG.Text + "," + tbPredefinedColorB.Text;
        string[] subItems = { predefinedColor };
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
      int min = 0;
      int max = 255;
      if (validatorInt(cbTestHueBrightness.Text, min, max, true) == false)
      {
        MessageBox.Show("RGB color value must be between 0 and 500");
      }
      else
      {
        try
        {
          byte brightness = byte.Parse(cbTestHueBrightness.Text);
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
      refreshSettings();
    }

    private void cbHueTheaterModeRestoreColor_Validating(object sender, CancelEventArgs e)
    {
      refreshSettings();
    }
  }
}
