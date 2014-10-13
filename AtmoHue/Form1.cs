using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
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
        public Boolean scanAtmowin = false;
        public Boolean hueRotatingColors = false;
        HueClient client = new HueClient("0.0.0.0");
        public int hueRotateDelay = 1000;
        public string hueBridgeIP = "";
        public string hueLightsEnable = "";
        public string hueAppName = "";
        public string hueAppKey = "";
        public string hueBrightness = "100";
        public string hueSaturation = "100";
        public string hueTransitiontime = "100";
        public string hueHue = "";
        public string hueOutputDevices = "";

        public Form1()
        {
            InitializeComponent();

            loadSettings();

            if (string.IsNullOrEmpty(tbHueBridgeIP.Text))
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

            if (string.IsNullOrEmpty(tbHueBridgeIP.Text) == false)
            {
                client = new HueClient(hueBridgeIP);
                client.RegisterAsync(hueAppName, hueAppKey);
                try
                {
                    client.Initialize(tbHueAppKey.Text);
                    outputtoLog("HUE has been intialized on STARTUP");
                }
                catch (Exception et)
                {
                    MessageBox.Show(et.ToString());
                }
            }

            //Create some default brightness levels
            cbHueBrightness.Items.Clear();
            int maxBrightness = 500;
            int counter = 0;

            while (counter != maxBrightness)
            {
                cbHueBrightness.Items.Add(counter);
                counter++;
            }

            //Set link label for copyright
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://github.com/Q42/Q42.HueApi";
            llQ42.Links.Add(link);
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

        private void loadSettings()
        {
            hueBridgeIP = tbHueBridgeIP.Text;
            hueAppName = tbHueAppName.Text;
            hueAppKey = tbHueAppKey.Text;
            hueBrightness = cbHueBrightness.Text;
            hueSaturation = tbHueSaturation.Text;
            hueTransitiontime = tbHueTransitionTime.Text;
            hueHue = tbHueHue.Text;
            hueOutputDevices = cbOutputHueDevicesRange.Text;

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

        }
        public async Task SSDPBridgeLocator()
        {
            IBridgeLocator locator = new SSDPBridgeLocator();
            int bridgesFound = 0;

            var bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            foreach (string bridgeIP in bridgeIPs)
            {
                tbHueBridgeIP.Text = bridgeIP;
                outputtoLog("Bridges found using SSDP discovery method: " + bridgeIPs.ToString());
                bridgesFound++;
            }

            if (bridgesFound == 0)
            {
                outputtoLog("Couldn't find any Hue Bridges in network using SSDP discovery method");
            }
        }
        public async Task hueSetColor(string color)
        {
            try
            {
                outputtoLog("Setting color #" + color + " to Hue Bridge");

                if (client.IsInitialized == false)
                {
                    client.Initialize(tbHueAppKey.Text);
                    outputtoLog("HUE has been intialized on COLOR CHANGE");
                }

                //Color lights

                var command = new LightCommand();
                command.On = true;

                //Set custom values
                command.Brightness = byte.Parse(hueBrightness);
                command.Saturation = int.Parse(hueSaturation);
                command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(hueTransitiontime));

                if (string.IsNullOrEmpty(tbHueHue.Text) == false)
                {
                    command.Hue = int.Parse(hueHue);
                }

                //Turn the light on and set a Hex color for the command
                command.TurnOn().SetColor(color);

                if (hueOutputDevices.ToLower().Trim() == "all")
                {
                    await client.SendCommandAsync(command);
                }
                else
                {
                    await client.SendCommandAsync(command, new List<string> {hueOutputDevices.ToLower().Trim() });
                }
                outputtoLog("Completed sending color #" + color + " to Hue Bridge.");

            }
            catch (Exception et)
            {
                MessageBox.Show(et.ToString());
            }
        }

        private void btnStartAtmowinHue_Click(object sender, EventArgs e)
        {
            loadSettings();
            if (string.IsNullOrEmpty(tbHueBridgeIP.Text) == true)
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
            hueLightsEnable = cbOutputHueDevicesRange.Text.ToLower().Trim();
            scanAtmowin = true;
            outputtoLog("Start monitoring Atmowin");
            Thread t = new Thread(startMonitoringAtmowin);
            t.Start();

        }
        private void btnStopAtmowinHue_Click(object sender, EventArgs e)
        {
            scanAtmowin = false;
            outputtoLog("Stop monitoring Atmowin");
            if (string.IsNullOrEmpty(tbAtmowinStaticColor.Text) == false)
            {
                hueSetColor(tbAtmowinStaticColor.Text.Replace("#", string.Empty).Trim());
            }
            else
            {
                hueSetColor("000000");
            }
        }

        private void startMonitoringAtmowin()
        {
            string atmowinLocation = addTrailingSlash(tbAtmowinLocation.Text);
            string atmowinColorInformation = "";
            string colorRed = "";
            string colorGreen = "";
            string colorBlue = "";
            string numberOfChannels = "";

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
                        if (colorRed == "0" && colorGreen == "0" && colorBlue == "0" && string.IsNullOrEmpty(tbAtmowinStaticColor.Text) == false)
                        {
                            outputtoLog("Atmowin disconnected, sending preset static color");
                            hueSetColor(tbAtmowinStaticColor.Text.Replace("#", string.Empty).Trim());
                        }
                        else
                        {
                            //Convert RGB to HEX
                            Color myColor = Color.FromArgb(int.Parse(colorRed), int.Parse(colorGreen), int.Parse(colorBlue));
                            string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
                            outputtoLog("HUE information -> " + hex);

                            //Send color
                            hueSetColor(hex);

                            outputtoLog("Completed sending color #" + hex + " to Hue Bridge.");
                            outputtoLog("------------------------------");
                        }

                        int sleeptime = int.Parse(tbAtmowinScanInterval.Text);
                        Thread.Sleep(sleeptime);
                    }
                    catch (Exception et)
                    {
                        outputtoLog(et.ToString());
                        int sleeptime = int.Parse(tbAtmowinScanInterval.Text);
                        Thread.Sleep(sleeptime);

                    }
                }
            }
            catch(Exception et)
            {
                outputtoLog(et.ToString());
                int sleeptime = int.Parse(tbAtmowinScanInterval.Text);
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
            ControlInvike(lbOutputlog, () => lbOutputlog.Items.Add(text));

            if (cbEnableDebuglog.Checked == true)
            {
                StreamWriter sw = new StreamWriter("debug.log", true);
                sw.WriteLine(text);
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
                        client.Initialize(tbHueAppKey.Text);
                        outputtoLog("HUE has been intialized on COLOR CHANGE");
                    }
                    catch (Exception et)
                    {
                        MessageBox.Show(et.ToString());
                    }
                }

                //Color lights

                var command = new LightCommand();
                command.On = true;

                //Set custom values
                command.Brightness = byte.Parse(hueBrightness);
                command.Saturation = int.Parse(hueSaturation);
                command.TransitionTime = TimeSpan.FromMilliseconds(int.Parse(hueTransitiontime));

                if (string.IsNullOrEmpty(tbHueHue.Text) == false)
                {
                    command.Hue = int.Parse(hueHue);
                }

                while (hueRotatingColors == true)
                {
                    //Turn the light on and set a Hex color for the command
                    command.TurnOn().SetColor("FF0000");
                    outputtoLog("Completed sending color #" + "FF0000" + " to Hue Bridge.");
                    if (hueOutputDevices.ToLower().Trim() == "all")
                    {
                        client.SendCommandAsync(command);
                    }
                    else
                    {
                        client.SendCommandAsync(command, new List<string> { hueOutputDevices.ToLower().Trim() });

                    }
                    Thread.Sleep(int.Parse(tbRotateTestDelay.Text));

                    command.TurnOn().SetColor("00FF00");
                    outputtoLog("Completed sending color #" + "00FF00" + " to Hue Bridge.");
                    if (hueOutputDevices.ToLower().Trim() == "all")
                    {
                        client.SendCommandAsync(command);
                    }
                    else
                    {
                        client.SendCommandAsync(command, new List<string> { hueOutputDevices.ToLower().Trim() });

                    }
                    Thread.Sleep(int.Parse(tbRotateTestDelay.Text));

                    command.TurnOn().SetColor("0000FF");
                    outputtoLog("Completed sending color #" + "0000FF" + " to Hue Bridge.");
                    if (hueOutputDevices.ToLower().Trim() == "all")
                    {
                        client.SendCommandAsync(command);
                    }
                    else
                    {
                        client.SendCommandAsync(command, new List<string> { hueOutputDevices.ToLower().Trim() });
                    }
                    Thread.Sleep(int.Parse(tbRotateTestDelay.Text));
                }

            }
            catch (Exception et)
            {
                MessageBox.Show(et.ToString());
            }
        }

        private void btnTestRed_Click(object sender, EventArgs e)
        {
            loadSettings();
            hueSetColor("FF0000");
        }

        private void btnTestGreen_Click(object sender, EventArgs e)
        {
            loadSettings();
            hueSetColor("00FF00");
        }

        private void btnTestBlue_Click(object sender, EventArgs e)
        {
            loadSettings();
            hueSetColor("0000FF");
        }

        private void btnHueColorClear_Click(object sender, EventArgs e)
        {
            loadSettings();
            hueSetColor("0000FF");
        }

        private void btnHueSendCustomColor_Click(object sender, EventArgs e)
        {
            loadSettings();
            hueSetColor(tbHueCustomColor.Text.Replace("#", string.Empty).Trim());
        }

        private void btnHueColorRotateTestStart_Click(object sender, EventArgs e)
        {
            loadSettings();
            hueRotatingColors = true;
            hueRotateDelay = int.Parse(tbRotateTestDelay.Text);
            Thread t = new Thread(rotateColors);
            t.Start();
        }
        private void btnHueColorRotateTestStop_Click(object sender, EventArgs e)
        {
            hueRotatingColors = false;
            hueSetColor("000000");
        }

        private void llQ42_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }

}
