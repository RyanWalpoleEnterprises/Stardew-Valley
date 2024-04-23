using IWshRuntimeLibrary;
using Stardew_Mod_Manager.Forms;
using Stardew_Mod_Manager.Forms.Error_Log_Viewer;
using Stardew_Mod_Manager.Forms.Repair;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Stardew_Mod_Manager.Startup
{
    public partial class Splash : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public Splash()
        {
            InitializeComponent();
            Version.Text = "v" + Properties.Settings.Default.Version;
            Status.Text = "Please Wait...";
            Properties.Telemetry.Default.TimesOpenedApplication++;
            Properties.Telemetry.Default.Save();

            if (Properties.Settings.Default.LaunchArguments == String.Empty)
            {
                //No Startup Arguments
                Properties.Settings.Default.RepairActive = "No";
                Properties.Settings.Default.Save();
                StartupTimer.Start();
            }
            else
            {
                //Startup Arguments Found

                //Debug
                //Show MessageBox to Verify Arguments
                //MessageBox.Show(Properties.Settings.Default.LaunchArguments);

                //File is a modpack
                if (Properties.Settings.Default.LaunchArguments.EndsWith(".sdvmp"))
                {
                    //Launch Modpack Installer
                    //MessageBox.Show(Properties.Settings.Default.LaunchArguments);
                    Status.Text = "Doing Fun Things...";
                    ModpackStarter.Start();
                }
                //File is an error log
                else 
                if (Properties.Settings.Default.LaunchArguments.EndsWith(".sdvmmerrorlog"))
                {
                    //Launch error log viewer
                    Status.Text = "Decompiling logs...";
                    LogTimer.Start();
                }
                else //Arguments are for repair
                if (Properties.Settings.Default.LaunchArguments.EndsWith("repair"))
                {
                    //Launch Modpack Installer
                    Status.Text = "Please wait...";
                    RepairTimer.Start();
                    Properties.Settings.Default.RepairActive = "Yes";
                    Properties.Settings.Default.Save();
                }
                else //Argument is invalid
                {
                    //No Startup Arguments
                    Properties.Settings.Default.RepairActive = "No";
                    Properties.Settings.Default.Save();
                    StartupTimer.Start();
                }
            }
        }

        private void LogTimer_Tick(object sender, EventArgs e)
        {
            LogTimer.Stop();
            ELViewer errorlogviewer = new ELViewer();
            errorlogviewer.Show();
            this.Hide();
        }

        private void StartupTimer_Tick(object sender, EventArgs e)
        {
            StartupTimer.Stop();
            ValidateDirectories.RunWorkerAsync();
        }

        private void ValidateDirectories_DoWork(object sender, DoWorkEventArgs e)
        {
            Status.Text = "Validating Directories...";

            //Check for Mods Directory
            string ModsDirectory = Properties.Settings.Default.StardewDir + @"\Mods";
            if (!Directory.Exists(ModsDirectory))
            {
                Directory.CreateDirectory(ModsDirectory);
            }

            //Check for Inactive Mods Directory
            string InactiveModsDirectory = Properties.Settings.Default.StardewDir + @"\inactive-mods";
            if (!Directory.Exists(InactiveModsDirectory))
            {
                Directory.CreateDirectory(InactiveModsDirectory);
            }

            //Check for Presets Directory
            string PresetsDirectory = Properties.Settings.Default.StardewDir + @"\mod-presets";
            if (!Directory.Exists(PresetsDirectory))
            {
                Directory.CreateDirectory(PresetsDirectory);
            }

            //Check for Saves Directory
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string sdvsaves = appdata + @"\StardewValley\Saves\";
            if (!Directory.Exists(sdvsaves))
            {
                Directory.CreateDirectory(sdvsaves);
            }

            //Check for Save Backups Directory
            string backupsdir = Properties.Settings.Default.StardewDir + @"\savebackups\";
            if (!Directory.Exists(backupsdir))
            {
                Directory.CreateDirectory(backupsdir);
            }

            //Check for Log Directory
            string logsdir = appdata + @"\RWE Labs\SDV Mod Manager\tmp\logs\";
            if (!Directory.Exists(logsdir))
            {
                Directory.CreateDirectory(logsdir);
            }
        }

        private void ValidateDirectories_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Validated Directories
            MigrateSettings.RunWorkerAsync();
        }

        private void MigrateSettings_DoWork(object sender, DoWorkEventArgs e)
        {
            Status.Text = "Checking settings...";
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
            string SettingsINI = SDVAppData + @"settings.ini";

            if (System.IO.File.Exists(SettingsINI))
            {
                //LaunchApplicationNow();
                //MessageBox.Show("File Exists");
            }
            else if (!System.IO.File.Exists(SettingsINI))
            {
                //MessageBox.Show("File Does Not Exist");
                Directory.CreateDirectory(SDVAppData);
                FileWrite.Invoke(new MethodInvoker(delegate
                 {
                     FileWrite.AppendText("$StardewDir=" + Properties.Settings.Default.StardewDir + Environment.NewLine);
                     FileWrite.AppendText("$ModsDir=" + Properties.Settings.Default.ModsDir + Environment.NewLine);
                     FileWrite.AppendText("$InactiveModsDir=" + Properties.Settings.Default.InactiveModsDir + Environment.NewLine);
                     FileWrite.AppendText("$PresetsDir=" + Properties.Settings.Default.PresetsDir + Environment.NewLine);
                     FileWrite.AppendText("$CheckUpdateOnStartup=" + Properties.Settings.Default.CheckUpdateOnStartup + Environment.NewLine);
                     FileWrite.AppendText("$CheckSMAPIUpdateOnStartup=" + Properties.Settings.Default.CheckSMAPIUpdateOnStartup + Environment.NewLine);
                     FileWrite.AppendText("$IsManuallyReset=" + Properties.Settings.Default.IsManuallyReset + Environment.NewLine);
                     FileWrite.AppendText("$ColorProfile=" + Properties.Settings.Default.ColorProfile + Environment.NewLine);
                     FileWrite.AppendText("$$DoTelemetry=" + Properties.Settings.Default.DoTelemetry + Environment.NewLine);
                     FileWrite.SaveFile(SettingsINI, RichTextBoxStreamType.PlainText);
                 }));

                //Cleanup.Start();
            }

        }

        private void MigrateSettings_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Settings Migrated
            //Check for Updates

            if(Properties.Settings.Default.CheckUpdateOnStartup == "TRUE")
            {
                CheckForUpdates.RunWorkerAsync();
            }
            else
            {
                Cleanup.Start();
            }
        }

        private void CheckForUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
            string CurrentUpdateVersion = "https://raw.githubusercontent.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/main/web/uc.xml";
            string LatestRelease = "https://github.com/RyanWalpoleEnterprises/Stardew-Valley-Mod-Manager/releases/latest";

            //View current stable version number
            XmlDocument document = new XmlDocument();
            document.Load(CurrentUpdateVersion);
            string CVER = document.InnerText;

            //Compare current stable version against installed version
            if (CVER.Contains(Properties.Settings.Default.Version))
            {
                //No updates available - install version matches stable version
                Status.Invoke(new MethodInvoker(delegate
                {
                    Status.Text = "No updates found.";
                }));
            }
            else
            {
                //No updates available - install version matches stable version
                Status.Invoke(new MethodInvoker(delegate
                {
                    Status.Text = "Updates available.";
                }));
            }
        }

        private void CheckForUpdates_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                Cleanup.Start(); 
            }
            else if (e.Error != null)
            {
                Status.Text = "Could not connect to update server.";
                Cleanup.Start();
            }
            else
            {
                if(Status.Text == "Updates available.")
                {
                    //Alert to available update
                    DialogResult dr = MessageBox.Show("There are updates available for Stardew Mod Manager. Would you like to download and install the latest version?", "Update | Stardew Valley Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //User clicks yes
                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            //Process.Start(LatestRelease);
                            UpdateDownload download = new UpdateDownload();
                            download.ShowDialog();
                            Status.Text = "Launching Mod Manager...";
                            Cleanup.Start();
                        }
                        catch
                        {
                            Status.Text = "Issue updating. Launching Mod Manager...";
                            Cleanup.Start();
                        }
                    }
                    else if (dr == DialogResult.No)
                    {
                        Status.Text = "Launching Mod Manager...";
                        LaunchApplicationNow();
                    }
                    else
                    {
                        Status.Text = "Launching Mod Manager...";
                        LaunchApplicationNow();
                    }
                }
                else
                {
                    LaunchApplicationNow();
                }
                
            }
        }

        private void ModpackStarter_Tick(object sender, EventArgs e)
        {
            //Start Modpack Installer
            ModpackStarter.Stop();
            this.Hide();
            MPOpen ModpackFile = new MPOpen();
            ModpackFile.Show();
            ModpackFile.Activate();
        }

        private void LaunchApplicationNow()
        {
            try
            {
                //Show Main Dashboard and Hide Splash
                this.Hide();
                MainPage Dashboard = new MainPage();
                Dashboard.Show();
                Dashboard.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cleanup_Tick(object sender, EventArgs e)
        {
            Cleanup.Stop();
            LaunchApplicationNow();
        }

        private void RepairTimer_Tick(object sender, EventArgs e)
        {
            RepairTimer.Stop();
            //Launch Repair
            RepairApplication ra = new RepairApplication();
            ra.Show();
            this.Hide();
        }
    }
}
