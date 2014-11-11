using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
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

    // Server
    private TcpListener tcpListener;
    private Thread listenThread;
    private Stopwatch swRemoteApi = new Stopwatch();

    // Atmowin
    public Boolean scanAtmowin = false;
    public string atmowinLocation = "";
    public string atmowinStaticColor = "";
    public string atmowinScanInterval = "";

    // HUE
    public Boolean hueRotatingColors = false;
    HueClient client = new HueClient("127.0.0.1");
    public List<string> ledDevices = new List<string>();
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

    // Remote API
    public string remoteAPIip = "127.0.0.1";
    public string remoteAPIport = "20123";
    public string remoteSendDelay = "300";


    // Various
    public Boolean MinimizeOnStartup = false;
    public Boolean MinimizeToTray = false;
    public Boolean HueTurnOffOnSuspend = false;

    // Tray icon

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
      if (cbRemoteAPIEnabled.Checked)
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
        //Clear devices listview on startup to prevent duplicates

        lvLedDevices.Items.Clear();

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
                remoteSendDelay = reader.ReadString();
                if (init)
                {
                  tbRemoteAPIsendDelay.Text = remoteSendDelay;
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
              if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "HueTurnOffOnSuspend"))
              {
                HueTurnOffOnSuspend = Boolean.Parse(reader.ReadString());
                if (init)
                {
                  cbHueTurnOffOnSuspend.Checked = HueTurnOffOnSuspend;
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
                  ledDevices.Add(id);
                  string[] subItems = { type, location, sendDelay, brightness, saturation, colorTemperature, hue, staticColors };
                  lvLedDevices.Items.Add(id).SubItems.AddRange(subItems);
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
          writer.WriteElementString("HueTurnOffOnSuspend", cbHueTurnOffOnSuspend.Checked.ToString());


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
      SaveSettings(false);
      LoadSettings(true);
    }

    public static string formatTitle()
    {
      string title = AssemblyInfo.Title;
      string version = AssemblyInfo.VersionFull.ToString();
      string copyright = AssemblyInfo.Copyright;

      string formattedTitle = string.Format("{0} - {1} - {2}", title, version, copyright);
      return formattedTitle;
    }

    static public class AssemblyInfo
    {
      public static string Company { get { return GetExecutingAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company); } }
      public static string Configuration { get { return GetExecutingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }

      public static string Copyright { get { return GetExecutingAssemblyAttribute<AssemblyCopyrightAttribute>(a => a.Copyright); } }

      public static string Description { get { return GetExecutingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }

      public static string FileVersion { get { return GetExecutingAssemblyAttribute<AssemblyFileVersionAttribute>(a => a.Version); } }

      public static string Product { get { return GetExecutingAssemblyAttribute<AssemblyProductAttribute>(a => a.Product); } }
      public static string Title { get { return GetExecutingAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title); } }

      public static string Trademark { get { return GetExecutingAssemblyAttribute<AssemblyTrademarkAttribute>(a => a.Trademark); } }
      public static Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
      public static string VersionBuild { get { return Version.Build.ToString(); } }

      public static string VersionFull { get { return Version.ToString(); } }
      public static string VersionMajor { get { return Version.Major.ToString(); } }
      public static string VersionMinor { get { return Version.Minor.ToString(); } }
      public static string VersionRevision { get { return Version.Revision.ToString(); } }

      private static string GetExecutingAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
      {
        T attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(T));
        return value.Invoke(attribute);
      }
    }


    /// <summary>
    /// Gets the values from the AssemblyInfo.cs file for the previous assembly
    /// </summary>
    /// <example>
    /// AssemblyInfoCalling assembly = new AssemblyInfoCalling();
    /// string company1 = assembly.Company;
    /// string product1 = assembly.Product;
    /// string copyright1 = assembly.Copyright;
    /// string trademark1 = assembly.Trademark;
    /// string title1 = assembly.Title;
    /// string description1 = assembly.Description;
    /// string configuration1 = assembly.Configuration;
    /// string fileversion1 = assembly.FileVersion;
    /// Version version1 = assembly.Version;
    /// string versionFull1 = assembly.VersionFull;
    /// string versionMajor1 = assembly.VersionMajor;
    /// string versionMinor1 = assembly.VersionMinor;
    /// string versionBuild1 = assembly.VersionBuild;
    /// string versionRevision1 = assembly.VersionRevision;
    /// </example>
    public class AssemblyInfoCalling
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="AssemblyInfoCalling"/> class.
      /// </summary>
      /// <param name="traceLevel">The trace level needed to get correct assembly 
      /// - will need to adjust based on where you put these classes in your project(s).</param>
      public AssemblyInfoCalling(int traceLevel = 4)
      {
        //----------------------------------------------------------------------
        // Default to "3" as the number of levels back in the stack trace to get the 
        //  correct assembly for "calling" assembly
        //----------------------------------------------------------------------
        StackTraceLevel = traceLevel;
      }

      //----------------------------------------------------------------------
      // Set how deep in the stack trace we're looking - allows for customized changes
      //----------------------------------------------------------------------
      public static int StackTraceLevel { get; set; }

      //----------------------------------------------------------------------
      // Version attributes
      //----------------------------------------------------------------------
      public static Version Version
      {
        get
        {
          //----------------------------------------------------------------------
          // Get the assembly, return empty if null
          //----------------------------------------------------------------------
          Assembly assembly = GetAssembly(StackTraceLevel);
          return assembly == null ? new Version() : assembly.GetName().Version;
        }
      }

      //----------------------------------------------------------------------
      // Standard assembly attributes
      //----------------------------------------------------------------------
      public string Company { get { return GetCallingAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company); } }
      public string Configuration { get { return GetCallingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }

      public string Copyright { get { return GetCallingAssemblyAttribute<AssemblyCopyrightAttribute>(a => a.Copyright); } }

      public string Description { get { return GetCallingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }

      public string FileVersion { get { return GetCallingAssemblyAttribute<AssemblyFileVersionAttribute>(a => a.Version); } }

      public string Product { get { return GetCallingAssemblyAttribute<AssemblyProductAttribute>(a => a.Product); } }
      public string Title { get { return GetCallingAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title); } }

      public string Trademark { get { return GetCallingAssemblyAttribute<AssemblyTrademarkAttribute>(a => a.Trademark); } }
      public string VersionBuild { get { return Version.Build.ToString(); } }

      public string VersionFull { get { return Version.ToString(); } }
      public string VersionMajor { get { return Version.Major.ToString(); } }
      public string VersionMinor { get { return Version.Minor.ToString(); } }
      public string VersionRevision { get { return Version.Revision.ToString(); } }
      /// <summary>
      /// Go through the stack and gets the assembly
      /// </summary>
      /// <param name="stackTraceLevel">The stack trace level.</param>
      /// <returns></returns>
      private static Assembly GetAssembly(int stackTraceLevel)
      {
        //----------------------------------------------------------------------
        // Get the stack frame, returning null if none
        //----------------------------------------------------------------------
        StackTrace stackTrace = new StackTrace();
        StackFrame[] stackFrames = stackTrace.GetFrames();
        if (stackFrames == null) return null;

        //----------------------------------------------------------------------
        // Get the declaring type from the associated stack frame, returning null if nonw
        //----------------------------------------------------------------------
        var declaringType = stackFrames[stackTraceLevel].GetMethod().DeclaringType;
        if (declaringType == null) return null;

        //----------------------------------------------------------------------
        // Return the assembly
        //----------------------------------------------------------------------
        var assembly = declaringType.Assembly;
        return assembly;
      }

      /// <summary>
      /// Gets the calling assembly attribute.
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="value">The value.</param>
      /// <example>return GetCallingAssemblyAttribute&lt;AssemblyCompanyAttribute&gt;(a => a.Company);</example>
      /// <returns></returns>
      private string GetCallingAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
      {
        //----------------------------------------------------------------------
        // Get the assembly, return empty if null
        //----------------------------------------------------------------------
        Assembly assembly = GetAssembly(StackTraceLevel);
        if (assembly == null) return string.Empty;

        //----------------------------------------------------------------------
        // Get the attribute value
        //----------------------------------------------------------------------
        T attribute = (T)Attribute.GetCustomAttribute(assembly, typeof(T));
        return value.Invoke(attribute);
      }
    }
    private void startAPIserver()
    {
      swRemoteApi.Start();
      if (remoteAPIip == "Any")
      {
        tcpListener = new TcpListener(IPAddress.Any, int.Parse(remoteAPIport));
      }
      else
      {
        IPAddress IP = IPAddress.Parse(remoteAPIip);
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
        string ColorMessage = encoder.GetString(message, 0, bytesRead);
        try
        {
          string[] colorMessageSplit = ColorMessage.Split(',');
          int red = int.Parse(colorMessageSplit[0]);
          int green = int.Parse(colorMessageSplit[1]);
          int blue = int.Parse(colorMessageSplit[2]);
          int priority = int.Parse(colorMessageSplit[3]);

          Color inputColor = Color.FromArgb(red, green, blue);

          //Only send if delay has expired or if we get a high priority color
          if (swRemoteApi.ElapsedMilliseconds >= int.Parse(remoteSendDelay) || priority < 50)
          {
            if (cbLogRemoteApiCalls.Checked)
            {
              Logger(string.Format("[ {0} ][PRIO {1} ] - {2}", sources.ATMOLIGHT, priority.ToString(), "Got color command from Atmolight"));
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
              hueSetColor(inputColor, sources.ATMOLIGHT, 0);
              Thread.Sleep(2000);
              swRemoteApi.Restart();
            }

            //Validate if colors are correct
            if (red >= 0 && red <= 255 && green >= 0 && green <= 255 && blue >= 0 && blue <= 255)
            {
              hueSetColor(inputColor, sources.ATMOLIGHT, 0);
            }

            swRemoteApi.Restart();
          }
        }
        catch (Exception e)
        {
          Logger(string.Format("[ {0} ] {1}", sources.ATMOLIGHT, e.Message));
        }
      }

      tcpClient.Close();
    }
    public static void APIChangeColor(int red, int green, int blue, sources source)
    {
      Form1 hue = new Form1();
      Color inputColor = Color.FromArgb(red, green, blue);
      hue.hueSetColor(inputColor, source, 0);
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
      if (string.IsNullOrEmpty(hueBridgeIP) == false && cbAutoConnectBridge.Checked == true)
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
      if (hueAutoconnectBridge == true)
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

    public async Task hueSetColor(Color ColorInput, sources source, int delay)
    {
      try
      {
        if (cbLogRemoteApiCalls.Checked && source == sources.ATMOLIGHT)
        {
          Logger(string.Format("[ {0} ] {1}", source.ToString(), "Setting color #" + ColorInput.ToString() + " to Hue Bridge"));
        }
        if (source == sources.LOCAL)
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

        //Enable initial command
        LightCommand command = new LightCommand();
        command.On = true;

        // Set custom values

        //0-254
        if (HueSetBrightnessStartup == false)
        {
          command.Brightness = byte.Parse(hueBrightness);
        }

        //0-254
        command.Saturation = int.Parse(hueSaturation);

        //0-~
        command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(hueTransitiontime));

        //154-500
        if (string.IsNullOrEmpty(hueColorTemperature) == false)
        {
          command.ColorTemperature = int.Parse(hueColorTemperature);
        }

        //0-254
        if (string.IsNullOrEmpty(hueHue) == false)
        {
          command.Hue = int.Parse(hueHue);
        }

        //Calculate color coordinates from RGB
        double[] colorCoordinates = getRGBtoXY(ColorInput, DeviceType.bloom);

        if (colorisON)
        {
          command.ColorCoordinates = colorCoordinates;
        }
        else
        {
          command.TurnOn();
          command.ColorCoordinates = colorCoordinates;

          if (HueSetBrightnessStartup)
          {
            command.Brightness = byte.Parse(hueBrightness);
          }

          colorisON = true;
        }

        //Turn leds off if we receive black
        if (ColorInput == Color.Black)
        {
          colorisON = false;
          command.TurnOff();
        }

        //Send command to Hue
        if (ledDevices.Count > 0)
        {
          client.SendCommandAsync(command, ledDevices);
        }

        if (cbLogRemoteApiCalls.Checked && source == sources.ATMOLIGHT)
        {

          Logger(string.Format("[ {0} ] {1}", source.ToString(), "Completed sending color #" + ColorInput.ToString() + " to Hue Bridge."));
        }

        if (source == sources.LOCAL)
        {
          Logger(string.Format("[ {0} ] {1}", source.ToString(), "Completed sending color #" + ColorInput.ToString() + " to Hue Bridge."));
        }

        command.On = false;
      }
      catch (Exception et)
      {
        MessageBox.Show(et.ToString());
        if (cbEnableDebuglog.Checked == true)
        {
          Logger(et.ToString());
        }
      }
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
        hueSetColor(Color.Black, sources.LOCAL, 0);
      }
      else
      {
        hueSetColor(Color.Black, sources.LOCAL, 0);
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
              hueSetColor(Color.Black, sources.LOCAL, 0);
            }
            else
            {
              //Convert RGB to HEX
              Color myColor = Color.FromArgb(int.Parse(colorRed), int.Parse(colorGreen), int.Parse(colorBlue));

              //Send color
              if (myColor != previousColor)
              {
                hueSetColor(myColor, sources.LOCAL, 0);
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
    private void Logger(string text)
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
          hueSetColor(Color.Red, sources.LOCAL, 0);
          Thread.Sleep(hueRotateDelay);
          hueSetColor(Color.Green, sources.LOCAL, 0);
          Thread.Sleep(hueRotateDelay);
          hueSetColor(Color.Blue, sources.LOCAL, 0);
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


      hueSetColor(Color.Red, sources.LOCAL, 0);
    }

    private void btnTestGreen_Click(object sender, EventArgs e)
    {

      hueSetColor(Color.Green, sources.LOCAL, 0);
    }

    private void btnTestBlue_Click(object sender, EventArgs e)
    {

      hueSetColor(Color.Blue, sources.LOCAL, 0);
    }

    private void btnHueColorClear_Click(object sender, EventArgs e)
    {

      hueSetColor(Color.Black, sources.LOCAL, 0);
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
      hueSetColor(customColor, sources.LOCAL, 0);
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
      hueSetColor(Color.Black, sources.LOCAL, 0);
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
        if (string.IsNullOrEmpty(tbLedR.Text) == false && string.IsNullOrEmpty(tbLedG.Text) && string.IsNullOrEmpty(tbLedB.Text))
        {
          staticColors = string.Format("{0},{1},{2}", tbLedR.Text, tbLedG.Text, tbLedB.Text);
        }
        string[] subItems = { cbLedType.Text, tbLedLocation.Text, tbLedSendDelay.Text, tbLedBrightness.Text, tbLedSaturation.Text, tbLedColorTemperature.Text, tbLedHue.Text, staticColors };

        lvLedDevices.Items.Add(id).SubItems.AddRange(subItems);

        SetInUseLedDevices();

        tbLedID.Text = "";
        cbLedType.Text = "";
        tbLedLocation.Text = "";
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
        ledDevices.Add(item.Text);
      }
    }
    private void btnHueSetScene_Click(object sender, EventArgs e)
    {
      client.CreateOrUpdateSceneAsync(tbHueSceneID.Text, tbHueSceneName.Text, ledDevices);
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
    private void cbHueTurnOffOnSuspend_CheckedChanged(object sender, EventArgs e)
    {
      if (cbHueTurnOffOnSuspend.Checked)
      {
        HueTurnOffOnSuspend = true;
      }
      else
      {
        HueTurnOffOnSuspend = false;
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
          Logger("StandbyHandler - resuming AtmoHue connection and setting initial command");
          Thread tResume = new Thread(TurnLightsON);
          tResume.IsBackground = true;
          tResume.Start();
          break;
        case PowerModes.Suspend:
          if (HueTurnOffOnSuspend)
          {
            Logger("StandbyHandler - suspending AtmoHue and turning off leds");
            Thread tSuspend = new Thread(TurnLightsOFF);
            tSuspend.IsBackground = true;
            tSuspend.Start();
          }
          break;
      }
    }
    private void TurnLightsOFF()
    {
      try
      {
        colorisON = false;
        LightCommand command = new LightCommand();
        command.On = true;
        command.TurnOff();
        client.SendCommandAsync(command, ledDevices);
        command.On = false;
        Logger("StandbyHandler - suspended AtmoHue and set color to black");

      }
      catch (Exception e)
      {
        Logger("StandbyHandler - error while sending color black on suspend");
        Logger(e.Message);
      }
    }
    private void TurnLightsON()
    {
      try
      {
        //Delay the command for 2.5s to allow for startup
        Thread.Sleep(2500);
        if (client.IsInitialized == false)
        {
          client.Initialize(hueAppKey);
        }
        colorisON = true;
        LightCommand command = new LightCommand();
        command.On = true;
        command.Brightness = byte.Parse(hueBrightness);
        command.TurnOn();
        client.SendCommandAsync(command, ledDevices);
        command.On = false;
        Logger("StandbyHandler - resumed AtmoHue and set initial color command (TurnOn) with default brightness 100");
      }
      catch (Exception e)
      {
        Logger("StandbyHandler - error while turning on Hue on resume");
        Logger(e.Message);
      }
    }
    #endregion
  }
}
