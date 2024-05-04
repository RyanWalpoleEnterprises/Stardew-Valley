using Stardew_Mod_Manager.Properties;
using Stardew_Mod_Manager.Startup;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stardew_Mod_Manager
{
    public partial class FirstRunSetup : Form
    {
        //Create Parameters for Syncfusion UI Elements
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        
        //Let's plant our first crops then...
        public FirstRunSetup()
        {
            //Initialize UI
            InitializeComponent();

            //Attempt to prefill common Stardew Directory locations
            //Start with C drive
            if (File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley\"; }

            //Try external/other hard drives and disc drives
            if (File.Exists(@"A:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"A:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"B:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"B:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"D:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"D:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"E:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"E:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"F:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"F:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"G:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"G:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"H:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"H:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"I:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"I:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"J:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"J:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"K:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"K:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"L:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"L:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"M:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"M:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"N:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"N:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"O:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"O:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"P:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"P:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"Q:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"Q:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"R:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"R:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"S:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"S:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"T:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"T:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"U:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"U:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"V:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"V:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"W:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"W:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"X:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"X:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"Y:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"Y:\SteamLibrary\steamapps\common\Stardew Valley\"; }
            if (File.Exists(@"Z:\SteamLibrary\steamapps\common\Stardew Valley\Stardew Valley.exe")) { SDVDirPath.Text = @"Z:\SteamLibrary\steamapps\common\Stardew Valley\"; }
        }

        //Deprecated: Check the version of SMAPI installed
        private void CheckSMAPICurrentVersion()
        {
            string URL = "https://www.nexusmods.com/stardewvalley/mods/2400/";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();

                    WebData.Text = data;

                    doIdentifyVersion();
                }
            }
            catch
            {
                //
            }
        }

        //Deprecated: Identify the current available version of SMAPI
        private void doIdentifyVersion()
        {
            string regex = "<div class=\"stat\">";

            string selectstart = "<li class=\"stat-version\">";
            string selectend = "</li>";


            WebData.SelectionStart = WebData.Find(selectstart);
            WebData.SelectionLength = 289;

            WebData.Copy();
            WebDataParsed.Paste();

            foreach (string line in WebDataParsed.Lines)
            {
                if (line.Contains(regex))
                {
                    string ver = line.Replace(regex, null).Replace("<", null).Replace("/", null).Replace("div", null).Replace(">", null).Trim();

                    string SMAPICurrentVersionNumber = ver;
                    SMAPIToDownload.Text = SMAPICurrentVersionNumber;
                    SMAPIOpenInstall.Text = "Download SMAPI " + SMAPICurrentVersionNumber;
                }
            }
        }

//       _____ _                ____             
//      / ____| |              / __ \            
//     | (___ | |_ ___ _ __   | |  | |_ __   ___ 
//      \___ \| __/ _ \ '_ \  | |  | | '_ \ / _ \
//      ____) | ||  __/ |_) | | |__| | | | |  __/
//     |_____/ \__\___| .__/   \____/|_| |_|\___|
//                    | |                        
//                    |_|                        

        //Check the validity of the file path supplied
        private void SDVDirPath_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(SDVDirPath.Text + @"\Stardew Valley.exe"))
            {
                IsStardewValidIcon.Image = Resources.sdvError;
                IsStardewValidText.Text = "There is not a valid Stardew Valley installation at this directory.";
            }
            else if (File.Exists(SDVDirPath.Text + @"\Stardew Valley.exe"))
            {
                IsStardewValidIcon.Image = Resources.sdvvalidated;
                IsStardewValidText.Text = "There is a valid Stardew Valley installation at this directory.";
            }

            if (!File.Exists(SDVDirPath.Text + @"\StardewModdingAPI.exe"))
            {
                IsSMAPIValidIcon.Image = Resources.sdvError;
                IsSMAPIValidText.Text = "There is not a valid SMAPI installation at this directory.";
            }
            else if (File.Exists(SDVDirPath.Text + @"\StardewModdingAPI.exe"))
            {
                IsSMAPIValidIcon.Image = Resources.sdvvalidated;
                IsSMAPIValidText.Text = "There is a valid SMAPI installation at this directory.";
            }
        }

        //When the user clicks Continue on the first page, jumping to the LoadingStep
        private void StepOneContinue_Click(object sender, EventArgs e)
        {
            Step.SelectedTab = LoadingStep;
        }
        
        //Start a timer to move to the next step
        private void Step_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Step.SelectedTab == LoadingStep)
            {
                SetupEstablishTimer.Start();
            }
        }

        //Move to Step two once the loading has completed
        private void timer1_Tick(object sender, EventArgs e)
        {
            SetupEstablishTimer.Stop();
            //CheckSMAPICurrentVersion();
            Step.SelectedTab = StepTwo;
        }


//          _____ _               _______            
//         / ____| |              |__ __|           
//        | (___ | |_ ___ _ __      | |_ _____  ___
//         \___ \| __/ _ \ '_ \     | \ \ /\ / / _ \ 
//         ____) | ||  __/ |_) |    | |\ V V /  (_) |
//        |_____/ \__\___| .__/     |_| \_/\_/ \___/ 
//                        | |                         
//                        |_|                         


        //The user clicks Continue on Step Two, to move to Step Three
        private void Continue_Click(object sender, EventArgs e)
        {
            string AttemptedPath = SDVDirPath.Text;

            //Ensure that the correct files exist...
            try
            {
                if (Directory.GetFiles(AttemptedPath, "Stardew Valley.exe").Length == 0)
                {
                    //No Stardew Valley Installation Found
                    MessageBox.Show("We weren't able to find a valid Stardew Valley installation at that directory. Try watching the GIF again, making sure to follow the instructions closely - then try again. The path should include words like 'steamapps', 'common' and 'Stardew Valley'", "Setup | Stardew Valley Modded Framework", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Stardew Valley Installation Found
                    //Save Path as Setting
                    Properties.Settings.Default.StardewDir = AttemptedPath;
                    Properties.Settings.Default.Save();

                    //Check if SMAPI exists
                    if(File.Exists(AttemptedPath + @"\StardewModdingAPI.exe"))
                    {
                        //Show Setup Step 2, as SMAPI exists
                        Step.SelectedTab = StepThree;
                    }
                    else if(!File.Exists(AttemptedPath + @"\StardewModdingAPI.exe"))
                    {
                        //Show SMAPI Install Step
                        //SDVDirPath.SelectAll();
                        SDVDirPath.Copy();
                        MessageBox.Show("You don't seem to have SMAPI installed. We'll run you through the install process now.", "Setup | Stardew Valley Modded Framework", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            Step.SelectedTab = StepSmapi;
                        }
                        catch
                        {
                            //MessageBox.Show("SMAPI Installer was unable to launch.", "Setup | Stardew Valley Modded Framework", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                //Path not valid.
                MessageBox.Show("The text you entered doesn't seem to be a valid file path. Please re-read the instructions and try again.", "Setup | Stardew Valley Modded Framework", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //The user clicks to install SMAPI on the SMAPI install page. This installs the bundled copy.
        private void SMAPIOpenInstall_Click(object sender, EventArgs e)
        {
            string extractionpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\SDV Mod Manager\SMAPI\";

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            Process.Start(appPath + @"\smapi.bat");

            SMAPIOpenInstall.Text = "Open Installer Again";
            ContinueSMAPI.Visible = true;
        }

        //Once SMAPI is installed, the user clicks continue to move to the final step.
        private void ContinueSMAPI_Click(object sender, EventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string extractionpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\SDV Mod Manager\SMAPI\";
            string updatelocation = Path.Combine(dataPath, "latestSMAPI.zip");

            Step.SelectedTab = StepThree;
            try
            {
                Directory.Delete(extractionpath, true);
                File.Delete(updatelocation);
            }
            catch
            {
                //
            }
        }

        //The final step allows the user to either finish setup or view what's new in the application
        //The finishsteup button will create the settings, directories and launch the application
        private void FinishSetup_Click(object sender, EventArgs e)
        {
            string ModsFolder = Properties.Settings.Default.StardewDir + @"\Mods";
            string InactiveModsFolder = Properties.Settings.Default.StardewDir + @"\inactive-mods\";
            string ModPresets = Properties.Settings.Default.StardewDir + @"\mod-presets\";

            if (!Directory.Exists(ModsFolder))
            {
                Directory.CreateDirectory(ModsFolder);
            }
            if (!Directory.Exists(InactiveModsFolder))
            {
                Directory.CreateDirectory(InactiveModsFolder);
            }
            if (!Directory.Exists(ModPresets))
            {
                Directory.CreateDirectory(ModPresets);
            }

            Properties.Settings.Default.SetupComplete = "TRUE";
            Properties.Settings.Default.IsManuallyReset = "FALSE";
            Properties.Settings.Default.ModsDir = Properties.Settings.Default.StardewDir.ToString() + @"\Mods\";
            Properties.Settings.Default.InactiveModsDir = Properties.Settings.Default.StardewDir + @"\inactive-mods\";
            Properties.Settings.Default.PresetsDir = ModPresets;
            Properties.Settings.Default.Save();

            this.Hide();
            Splash Complete = new Splash();
            Complete.Show();
        }

        //What's New will open a web browser to the latest changelog!
        private void WhatsNew_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/RWELabs/Stardew-Valley-Mod-Manager/releases/tag/v" + Properties.Settings.Default.Version);
        }

        //If the user exits the window at any time, the application closes and progress is lost.
        private void FirstRunSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
