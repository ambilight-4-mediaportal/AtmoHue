using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Q42.HueApi;
using Q42.HueApi.NET;
using Q42.HueApi.Interfaces;

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

        //Server
        private TcpListener tcpListener;
        private Thread listenThread;
        private Stopwatch swRemoteApi = new Stopwatch();

        //Atmowin
        public Boolean scanAtmowin = false;
        public string atmowinLocation = "";
        public string atmowinStaticColor = "";
        public string atmowinScanInterval = "";

        //HUE
        public Boolean hueRotatingColors = false;
        HueClient client = new HueClient("127.0.0.1");
        public int hueRotateDelay = 1000;
        public string hueBridgeIP = "127.0.0.1";
        public string hueAppName = "mypersonalappname";
        public string hueAppKey = "mypersonalappkey";
        public string hueBrightness = "100";
        public string hueSaturation = "100";
        public string hueTransitiontime = "100";
        public string hueColorTemperature = "";
        public string hueHue = "";
        public string hueOutputDevices = "";
        

        //Remote API
        public string remoteAPIip = "";
        public string remoteAPIport = "";
        public string remoteSendDelay = "";
        
        public Boolean colorCommand = false;
        public Boolean colorisON = false;
        public LightCommand command = new LightCommand();


        public Form1()
        {
            InitializeComponent();

            refreshSettings();


            //Find bridge on startup
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
            
            //Refresh settings
            refreshSettings();

            //Create some default brightness levels
            cbHueBrightness.Items.Clear();
            int maxBrightness = 500;
            int counter = 0;

            while (counter != maxBrightness)
            {
                cbHueBrightness.Items.Add(counter);
                counter++;
            }

            //Enable initial command
            command.On = true;

            if (client.IsInitialized == false && string.IsNullOrEmpty(hueBridgeIP) == false)
            {
              client = new HueClient(hueBridgeIP);
              client.RegisterAsync(hueAppName, hueAppKey);
              try
              {
                client.Initialize(hueAppKey);
                outputtoLog("HUE has been intialized on STARTUP");
              }
              catch (Exception et)
              {
                if (cbEnableDebuglog.Checked == true)
                {
                  outputtoLog(et.ToString());
                }
              }
            }

            //Start remote server if enabled
            if (cbRemoteAPIEnabled.Checked)
            {
              startAPIserver();
            }

            //Set link label for copyright
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://github.com/Q42/Q42.HueApi";
            llQ42.Links.Add(link);
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
          outputtoLog("Started service for remote API calls");
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
              if (swRemoteApi.ElapsedMilliseconds >= int.Parse(remoteSendDelay))
              {
                string[] colorMessageSplit = ColorMessage.Split(',');
                int red = int.Parse(colorMessageSplit[0]);
                int green = int.Parse(colorMessageSplit[1]);
                int blue = int.Parse(colorMessageSplit[2]);
                Color inputColor = Color.FromArgb(red, green, blue);

                if (cbLogRemoteApiCalls.Checked)
                {
                  outputtoLog(string.Format("[ {0} ] {1}", sources.ATMOLIGHT, "Got color command from Atmolight"));
                }
                if (red == 0 && green == 0 && blue == 0)
                {
                  inputColor = Color.Black;
                }

                //Validate if colors are correct
                if (red >= 0 && red <= 255 && green >= 0 && green <= 255 && blue >= 0 && blue <= 255)
                hueSetColor(inputColor, sources.ATMOLIGHT);
                swRemoteApi.Restart();
              }
            }
            catch (Exception e)
            {
              outputtoLog(string.Format("[ {0} ] {1}", sources.ATMOLIGHT, e.Message));
            }
          }

          tcpClient.Close();
        }
        public static void APIChangeColor(int red, int green, int blue, sources source)
        {
          Form1 hue = new Form1();
          Color inputColor = Color.FromArgb(red, green, blue);
          hue.hueSetColor(inputColor, source);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            scanAtmowin = false;
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

        private void refreshSettings()
        {
            hueBridgeIP = tbHueBridgeIP.Text.Replace(":80", string.Empty).Trim();
            hueAppName = tbHueAppName.Text;
            hueAppKey = tbHueAppKey.Text;
            hueBrightness = cbHueBrightness.Text;
            hueSaturation = tbHueSaturation.Text;
            hueTransitiontime = tbHueTransitionTime.Text;
            hueColorTemperature = tbHueColorTemperature.Text;
            hueHue = tbHueHue.Text;
            hueOutputDevices = cbOutputHueDevicesRange.Text;
            atmowinLocation = addTrailingSlash(tbAtmowinLocation.Text);
            atmowinStaticColor = tbAtmowinStaticColor.Text;
            atmowinScanInterval = tbAtmowinScanInterval.Text;
            remoteAPIip = tbRemoteAPIip.Text;
            remoteAPIport = tbRemoteApiPort.Text;
            remoteSendDelay = tbRemoteAPIsendDelay.Text;
        }
        private void btnLocateHueBridge_Click(object sender, EventArgs e)
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
        public async Task BridgeLocator()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            int bridgesFound = 0;

            //For Windows 8 and .NET45 projects you can use the SSDPBridgeLocator which actually scans your network. 
            //See the included BridgeDiscoveryTests and the specific .NET and .WinRT projects

            IEnumerable<string> bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            foreach (string bridgeIP in bridgeIPs)
            {
               tbHueBridgeIP.Text = bridgeIP;
               outputtoLog("Bridges found using standard discovery method: " + bridgeIP);
               bridgesFound++;
            }


            if (bridgesFound == 0)
            {
                outputtoLog("Couldn't find any Hue Bridges in network using standard discovery method");
            }

            refreshSettings();

            //Connect to bridge if found and option is enabled
            if (string.IsNullOrEmpty(hueBridgeIP) == false && cbAutoConnectBridge.Checked == true)
            {
                client = new HueClient(hueBridgeIP);
                client.RegisterAsync(hueAppName, hueAppKey);
                try
                {
                    client.Initialize(hueAppKey);
                    outputtoLog("HUE has been intialized on STARTUP");
                }
                catch (Exception et)
                {
                    if (cbEnableDebuglog.Checked == true)
                    {
                        outputtoLog(et.ToString());
                    }
                }
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
                outputtoLog("Bridges found using SSDP discovery method: " + bridgeIP.ToString());
                bridgesFound++;
            }

            if (bridgesFound == 0)
            {
                outputtoLog("Couldn't find any Hue Bridges in network using SSDP discovery method");
            }

            refreshSettings();

            //Connect to bridge if found and option is enabled
            if (string.IsNullOrEmpty(hueBridgeIP) == false && cbAutoConnectBridge.Checked == true)
            {
                client = new HueClient(hueBridgeIP);
                client.RegisterAsync(hueAppName, hueAppKey);
                try
                {
                    client.Initialize(hueAppKey);
                    outputtoLog("HUE has been intialized on STARTUP");
                }
                catch (Exception et)
                {
                    if (cbEnableDebuglog.Checked == true)
                    {
                        outputtoLog(et.ToString());
                    }
                }
            }
        }
        public static double[] getRGBtoXY(Color c, DeviceType device)
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

          float X =(float)0;
          float Y = (float)0;
          float Z =(float)0;


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

          if(device == DeviceType.bloom)
          {
            X = (float)(red * 0.649926 + green * 0.103455 + blue * 0.197109);
            Y = (float)(red * 0.234327 + green * 0.743075 + blue * 0.022598);
            Z = (float)(red * 0.0000000 + green * 0.053077 + blue * 1.035763);

          }

          if(device == DeviceType.bulb)
          {
            X = (float)(red * 0.649926 + green * 0.103455 + blue * 0.197109);
            Y = (float)(red * 0.234327 + green * 0.743075 + blue * 0.022598);
            Z = (float)(red * 0.0000000 + green * 0.053077 + blue * 1.035763);

          }
          if(device == DeviceType.unknown)
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
        public async Task hueSetColor(Color colorToSet, sources source)
        {
            try
            {                
                if (cbLogRemoteApiCalls.Checked && source == sources.ATMOLIGHT)
                {
                  outputtoLog(string.Format("[ {0} ] {1}", source.ToString(), "Setting color #" + colorToSet.ToString() + " to Hue Bridge"));
                }
                if (client.IsInitialized == false)
                {
                  client.Initialize(hueAppKey);
                  outputtoLog(string.Format("[ {0} ] {1}", source.ToString(), "HUE has been intialized on COLOR CHANGE"));
                }

                // Set custom values

                //0-254
                command.Brightness = byte.Parse(hueBrightness);

                //0-254
                command.Saturation = int.Parse(hueSaturation);

                //0-~
                command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(hueTransitiontime));

                //154-500
                command.ColorTemperature = int.Parse(hueColorTemperature);

                //0-254
                if (string.IsNullOrEmpty(hueHue) == false)
                {
                    command.Hue = int.Parse(hueHue);
                }

                if (colorisON)
                {
                  double[] colorCoordinates = getRGBtoXY(colorToSet, DeviceType.bloom);
                  command.ColorCoordinates = colorCoordinates;
                }
                else
                {
                  double[] colorCoordinates = getRGBtoXY(colorToSet, DeviceType.bloom);
                  command.TurnOn().ColorCoordinates = colorCoordinates;
                  colorisON = true;
                }

                //Turn leds off if we receive black
                if (colorToSet == Color.Black)
                {
                  command.TurnOff();
                  colorisON = false;
                }

                if (hueOutputDevices.ToLower().Trim() == "all")
                {
                    client.SendCommandAsync(command);
                }
                else
                {
                  List<string> devices = new List<string>();
                  string[] devicesSplit = hueOutputDevices.Trim().Split(',');
                  foreach (string device in devicesSplit)
                  {
                    devices.Add(device);
                  }
                  client.SendCommandAsync(command, devices);
                }

                if (cbLogRemoteApiCalls.Checked && source == sources.ATMOLIGHT)
                {

                  outputtoLog(string.Format("[ {0} ] {1}", source.ToString(), "Completed sending color #" + colorToSet.ToString() + " to Hue Bridge."));
                }

                //command.On = false;
            }
            catch (Exception et)
            {
                if (cbEnableDebuglog.Checked == true)
                {
                    outputtoLog(et.ToString());
                }
            }
        }

        private void btnStartAtmowinHue_Click(object sender, EventArgs e)
        {
            refreshSettings();
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
            outputtoLog("Start monitoring Atmowin");
            Thread t = new Thread(startMonitoringAtmowin);
            t.Start();

        }
        private void btnStopAtmowinHue_Click(object sender, EventArgs e)
        {
            scanAtmowin = false;
            outputtoLog("Stop monitoring Atmowin");

            if (string.IsNullOrEmpty(atmowinStaticColor) == false)
            {
                hueSetColor(Color.Black, sources.LOCAL);
            }
            else
            {
                hueSetColor(Color.Black,sources.LOCAL);
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
                        outputtoLog("------------------------------");
                        outputtoLog("Atmowin information -> R = " + colorRed + " / G = " + colorGreen + " / B = " + colorBlue + " / CHANNELS = " + numberOfChannels);

                        //Needs changing as Atmowin might report 0,0,0 normally
                        if (colorRed == "0" && colorGreen == "0" && colorBlue == "0" && string.IsNullOrEmpty(atmowinStaticColor) == false)
                        {
                            outputtoLog("Atmowin disconnected, sending preset static color");
                            hueSetColor(Color.Black,sources.LOCAL);
                        }
                        else
                        {
                            //Convert RGB to HEX
                            Color myColor = Color.FromArgb(int.Parse(colorRed), int.Parse(colorGreen), int.Parse(colorBlue));

                            //Send color
                            if (myColor != previousColor)
                            {
                              hueSetColor(myColor, sources.LOCAL);
                            }
                            previousColor = myColor;

                            outputtoLog("Completed sending color #" + myColor.ToString() + " to Hue Bridge.");
                            outputtoLog("------------------------------");
                        }

                        int sleeptime = int.Parse(atmowinScanInterval);
                        Thread.Sleep(sleeptime);
                    }
                    catch (Exception et)
                    {
                        outputtoLog(et.ToString());
                        int sleeptime = int.Parse(atmowinScanInterval);
                        Thread.Sleep(sleeptime);

                    }
                }
            }
            catch(Exception et)
            {
                outputtoLog(et.ToString());
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
        private void outputtoLog(string text)
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
                        outputtoLog("HUE has been intialized on COLOR CHANGE");
                    }
                    catch (Exception et)
                    {
                        outputtoLog(et.ToString());
                    }
                }
                while (hueRotatingColors)
                {
                  hueSetColor(Color.Red, sources.LOCAL);
                  Thread.Sleep(hueRotateDelay);
                  hueSetColor(Color.Green, sources.LOCAL);
                  Thread.Sleep(hueRotateDelay);
                  hueSetColor(Color.Blue, sources.LOCAL);
                  Thread.Sleep(hueRotateDelay);
                }
            }
            catch (Exception et)
            {
                if (cbEnableDebuglog.Checked == true)
                {
                    outputtoLog(et.ToString());
                }
            }
        }

        private void btnTestRed_Click(object sender, EventArgs e)
        {
            refreshSettings();
            hueSetColor(Color.Red, sources.LOCAL);
        }

        private void btnTestGreen_Click(object sender, EventArgs e)
        {
            refreshSettings();
            hueSetColor(Color.Green, sources.LOCAL);
        }

        private void btnTestBlue_Click(object sender, EventArgs e)
        {
            refreshSettings();
            hueSetColor(Color.Blue, sources.LOCAL);
        }

        private void btnHueColorClear_Click(object sender, EventArgs e)
        {
            refreshSettings();
            hueSetColor(Color.Black, sources.LOCAL);
        }

        private void btnHueSendCustomColor_Click(object sender, EventArgs e)
        {
            refreshSettings();
            string hexColor = tbHueCustomColor.Text.Replace("#", string.Empty).Trim();
            hexColor = "#" + hexColor;
            System.Drawing.Color customColor = System.Drawing.ColorTranslator.FromHtml(hexColor);
            hueSetColor(customColor, sources.LOCAL);
        }

        private void btnHueColorRotateTestStart_Click(object sender, EventArgs e)
        {
            refreshSettings();
            hueRotatingColors = true;
            Thread t = new Thread(rotateColors);
            t.Start();
        }
        private void btnHueColorRotateTestStop_Click(object sender, EventArgs e)
        {
            hueRotatingColors = false;
            hueSetColor(Color.Black, sources.LOCAL);
            colorisON = false;
        }

        private void llQ42_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void tabPageTesting_Click(object sender, EventArgs e)
        {

        }
    }

}
