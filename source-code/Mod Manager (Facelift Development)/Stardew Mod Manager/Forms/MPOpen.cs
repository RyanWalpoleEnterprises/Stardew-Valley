using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Stardew_Mod_Manager.Forms
{
    public partial class MPOpen : Form
    {
        public MPOpen()
        {
            InitializeComponent();
            Continue.Enabled = false;
            ExtractProgress.Visible = false;

            //string filePath = Properties.Settings.Default.LaunchArguments;
            //var file = ShellFile.FromFilePath(filePath);
            //string smapiVer = file.Properties.System.Title.ToString();
            //RequiredSMAPIVersion.Text = smapiVer;
            //MessageBox.Show(smapiVer);

            ShowWarning("Some users are experiencing a bug where modpacks will not install due to a file path issue. We are working on fixing this. If you experience this issue, you can provide assistance by reporting it to us along with your error logs. You can do this from the Feedback link on the main dashboard.");

            try
            {
                var diInactiveMods = new DirectoryInfo(Properties.Settings.Default.InactiveModsDir);
                diInactiveMods.Attributes &= ~FileAttributes.ReadOnly;

                var diMods = new DirectoryInfo(Properties.Settings.Default.ModsDir);
                diMods.Attributes &= ~FileAttributes.ReadOnly;
            }
            catch (Exception ex)
            {
                CreateErrorLog("Could not remove the read-only attribute on the enabled and disabled mods folder. Error Message: " + ex.Message);
            }

            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
            string UnpackLocation = Properties.Settings.Default.StardewDir + @"\tmp\unpack\";

            if (Directory.Exists(UnpackLocation))
            {
                Directory.Delete(UnpackLocation, true);
            }

            DriveInfo cDrive = new DriveInfo("C");
            DriveInfo destDrive = new DriveInfo(Properties.Settings.Default.StardewDir);
            FileInfo fInfo = new FileInfo(Properties.Settings.Default.LaunchArguments);

            if (destDrive.IsReady)
            {
                var drivekb = cDrive.AvailableFreeSpace / 1024;
                var drivemb = drivekb / 1024;
                var drivegb = drivemb / 1024;

                var filekb = fInfo.Length / 1024;
                var filemb = filekb / 1024 + 100;
                var filegb = filemb / 1024;

                var ddrivekb = destDrive.AvailableFreeSpace / 1024;
                var ddrivemb = ddrivekb / 1024;
                var ddrivegb = ddrivemb / 1024;

                DriveSpaceDestination.Text = ddrivemb.ToString() + " mb (on " + destDrive.Name + ")";
                DriveSpaceAvailable.Text = ddrivemb.ToString() + " mb (" + ddrivegb + " gb) on (" + destDrive.Name + ")";
                DriveSpaceRequired.Text = filemb.ToString() + " mb";

                if(filemb < drivemb)
                {
                    IsValidSpaceText.Text = "There is enough disk space to unpack your modpack.";

                    if (filemb < ddrivemb)
                    {
                        IsValidSpaceText.Text = "There is enough disk space to unpack and install your modpack.";
                        IsValidSpace.Image = Properties.Resources.sdvvalidated;
                        Continue.Enabled = true;
                    }
                    else
                    {
                        IsValidSpaceText.Text = "There is enough disk space to unpack but not install your modpack.";
                        IsValidSpace.Image = Properties.Resources.sdvError;
                        Continue.Enabled = false;
                    }
                }
                else
                {
                    IsValidSpaceText.Text = "There is not enough disk space to unpack or install your modpack.";
                    IsValidSpace.Image = Properties.Resources.sdvError;
                    Continue.Enabled = false;
                }

                if(filemb > 40)
                {
                    WarningText.AppendText(Environment.NewLine + Environment.NewLine + "Modpacks may take a long time to install when they contain many mods. This modpack contains " + filemb + "mb of mods and may take a while to install.");
                }

                Continue.Focus();
            }

        }

        private void ShowWarning(string WarningMessage)
        {
            MessageBox.Show(WarningMessage,"Stardew Valley Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MPOpen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.LaunchArguments = null;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
            string UnpackLocation = Properties.Settings.Default.StardewDir + @"\tmp\unpack\";
            string LA = Path.GetFileName(Properties.Settings.Default.LaunchArguments);

            ExtractProgress.Visible = true;

            Directory.CreateDirectory(UnpackLocation);

            if (Directory.Exists(UnpackLocation))
            {
                File.Move(Properties.Settings.Default.LaunchArguments, UnpackLocation + LA.Replace(".sdvmp", ".zip"));

                Extract.RunWorkerAsync();
            }
        }

        private void Extract_DoWork(object sender, DoWorkEventArgs e)
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
            string UnpackLocation = Properties.Settings.Default.StardewDir + @"\tmp\unpack\";
            string LA = Path.GetFileName(Properties.Settings.Default.LaunchArguments);

            try
            {
                ZipFile.ExtractToDirectory(UnpackLocation + LA.Replace(".sdvmp", ".zip"), UnpackLocation);
                //MessageBox.Show("Done");
                File.Move(UnpackLocation + LA.Replace(".sdvmp", ".zip"), Properties.Settings.Default.LaunchArguments);
            }
            catch(Exception ex)
            {
                MessageBox.Show("There's an issue with your SDVMP file. It may be corrupted or incorrectly configured. Try re-downloading it or getting in touch with the modpack creator to solve this issue.", "Stardew Valley Mod Manager", MessageBoxButtons.OK);
                CreateErrorLog("The modpack could not be read: " + ex.Message + Environment.NewLine + "There's an issue with your SDVMP file. It may be corrupted or incorrectly configured. Try re-downloading it or getting in touch with the modpack creator to solve this issue.");
                Application.Exit();
            }
        }

        private void Extract_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled == true)
            {
                MessageBox.Show("The operation was cancelled by the user or the system.", "Stardew Valley Modpack Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateErrorLog("The operation was cancelled by the user or the system: " + e.Error.Message);
                Application.Exit();
            }
            else if (e.Error != null)
            {
                MessageBox.Show("The application experienced an issue whilst trying to install the modpack:" + Environment.NewLine + e.Error.Message, "Stardew Valley Modpack Installer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateErrorLog("The application experienced an issue whilst trying to install the modpack: " + e.Error.Message);
                Application.Exit();
            }
            else
            {
                MPInstaller steptwo = new MPInstaller();
                this.Hide();
                steptwo.Show();
                steptwo.Activate();
            }
        }

        private void CreateErrorLog(string errorMessage)
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\tmp\logs\";
            string LogID = DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss");

            //Check for Log Directory
            string logsdir = AppData + @"\RWE Labs\SDV Mod Manager\tmp\logs\";
            if (!Directory.Exists(logsdir))
            {
                Directory.CreateDirectory(logsdir);
            }
            else
            {
                //Directory exists
            }

            ErrorLog.Clear();
            ErrorLog.AppendText("Stardew Valley Mod Manager v" + Properties.Settings.Default.Version);
            ErrorLog.AppendText(Environment.NewLine + "(C) RWE Labs, 2022" + Environment.NewLine);
            ErrorLog.AppendText("-------------------- ERROR LOG --------------------" + Environment.NewLine);
            ErrorLog.AppendText("This log was generated at: " + LogID + Environment.NewLine + "With Stardew Valley Mod Manager version " + Properties.Settings.Default.Version + Environment.NewLine);
            ErrorLog.AppendText(Environment.NewLine + errorMessage);
            ErrorLog.SaveFile(SDVAppData + "log_" + LogID + ".sdvmmerrorlog", RichTextBoxStreamType.PlainText);
        }
    }
}
