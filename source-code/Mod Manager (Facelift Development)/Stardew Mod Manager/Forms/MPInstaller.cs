using Ionic.Zip;
using Stardew_Mod_Manager.Startup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stardew_Mod_Manager.Forms
{
    public partial class MPInstaller : Form
    {
        public MPInstaller()
        {
            InitializeComponent();

            var SMAPIVersion = FileVersionInfo.GetVersionInfo(Properties.Settings.Default.StardewDir + @"\StardewModdingAPI.exe");
            string SMAPIVersionText = "SMAPI " + "v" + SMAPIVersion.ProductVersion;
            SMAPIVersionInfo.Text = SMAPIVersionText;

            //For each mod in mods directory...
            foreach (string folder in Directory.GetDirectories(Properties.Settings.Default.ModsDir))
            {
                //Add to disable list
                ModsToDisable.Items.Add(Path.GetFileName(folder));
            }

            //For each mod in the disable list
            foreach (string item in ModsToDisable.Items)
            {
                //Move to the inactive mods folder
                Directory.Move(Properties.Settings.Default.ModsDir + item, Properties.Settings.Default.InactiveModsDir + item);
            }

            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
            string UnpackLocation = Properties.Settings.Default.StardewDir + @"\tmp\unpack\";
            string LA = Path.GetFileName(Properties.Settings.Default.LaunchArguments);

            //for every folder in the modpack (unpacked)
            foreach (string folder in Directory.GetDirectories(UnpackLocation))
            {
                //mark mod as one to be overwritten
                if (Directory.Exists(Properties.Settings.Default.InactiveModsDir + Path.GetFileName(folder)))
                {
                    OverwriteMods.Items.Add(Path.GetFileName(folder));
                }

                ModsToInstall.Items.Add(Path.GetFileName(folder));
            }

            try
            {
                //read the metadata for the modpack if possible
                MetaInfRead.LoadFile(UnpackLocation + @"meta.ini", RichTextBoxStreamType.PlainText);
                foreach(string line in MetaInfRead.Lines)
                {
                    if (line.Contains("$TARGETSMAPI=")){ SMAPITarget.Text = "SMAPI v" + line.Replace("$TARGETSMAPI=", "").ToString(); }
                }
            }
            catch
            {
                SMAPITarget.Text = "Could not determine SMAPI target.";
            }

        }

        private void MPInstaller_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MPInstaller_Click(object sender, EventArgs e)
        {
            DoModInstall.RunWorkerAsync();
            ExtractProgress.Visible = true;
        }

        private void DoModInstall_DoWork(object sender, DoWorkEventArgs e)
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
            string UnpackLocation = Properties.Settings.Default.StardewDir + @"\tmp\unpack\";
            string DeleteLocation = Properties.Settings.Default.StardewDir + @"\tmp\del";
            string LA = Path.GetFileName(Properties.Settings.Default.LaunchArguments);
            //string ModsOld = Properties.Settings.Default.StardewDir + @"\vdsk\";
            string zipPath = UnpackLocation + LA.Replace(".sdvmp", ".zip");
            string extractPath = Properties.Settings.Default.InactiveModsDir;

            //move the modpack to the unpack location, as a zip file
            File.Move(Properties.Settings.Default.LaunchArguments, UnpackLocation + LA.Replace(".sdvmp", ".zip"));

            //extract the zip file to the inactive mods folder
            using (Ionic.Zip.ZipFile zipFile = Ionic.Zip.ZipFile.Read(zipPath))
            {
                foreach(ZipEntry zipEntry in zipFile)
                {
                    //overwrite if the file already exists!
                    zipEntry.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently);
                }
            }

            //delete the metadata for the modpack after installation
            if(File.Exists(Properties.Settings.Default.ModsDir + @"\meta.ini"))
            {
                File.Delete(Properties.Settings.Default.ModsDir + @"\meta.ini");
            }
            if (File.Exists(Properties.Settings.Default.InactiveModsDir + @"\meta.ini"))
            {
                File.Delete(Properties.Settings.Default.InactiveModsDir + @"\meta.ini");
            }
        }

        private void DoModInstall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("The operation was cancelled by the user or the system.", "Stardew Valley Modpack Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateErrorLog("The operation was cancelled by the user or the system: " + e.Error.Message);
                Application.Exit();
            }
            else if (e.Error != null)
            {
                //resultLabel.Text = "Error: " + e.Error.Message;
                MessageBox.Show("The application experienced an issue whilst trying to delete an old version of a mod: " + Environment.NewLine + e.Error.Message, "Stardew Valley Modpack Installer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateErrorLog("The application experienced an issue whilst trying to delete an old version of a mod: " + e.Error.Message);
                Application.Exit();
            }
            else
            {
                DoMovementOperation.Start();
            }
        }

        private void DoMovementOperation_Tick(object sender, EventArgs e)
        {
            DoMovementOperation.Stop();
            DoFinish();
        }

        private void DoFinish()
        {
            string PresetName = Path.GetFileNameWithoutExtension(Properties.Settings.Default.LaunchArguments);
            //string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
            string UnpackLocation = Properties.Settings.Default.StardewDir + @"\tmp\unpack\";
            string LA = Path.GetFileName(Properties.Settings.Default.LaunchArguments);

            //Move the zip file back to the original location, with SDVMP file extension
            File.Move(UnpackLocation + LA.Replace(".sdvmp", ".zip"), Properties.Settings.Default.LaunchArguments);

            //Generate a preset based on the installed modpack
            foreach (string item in ModsToInstall.Items)
            {
                PresetGenerator.AppendText(item + Environment.NewLine);
            }

            PresetGenerator.AppendText("ConsoleCommands" + Environment.NewLine);
            PresetGenerator.AppendText("ErrorHandler" + Environment.NewLine);
            PresetGenerator.AppendText("SaveBackup" + Environment.NewLine);

            //Save the preset
            PresetGenerator.SaveFile(Properties.Settings.Default.PresetsDir + PresetName + ".txt", RichTextBoxStreamType.PlainText);

            //Tell user it was successful.
            DialogResult dr = MessageBox.Show("The modpack has been successfully installed. We've added a preset so you can easily one-click enable this modpack. The preset is called: " + PresetName + Environment.NewLine + Environment.NewLine + "Would you like to open the Stardew Valley Mod Manager now, to re-enable your mods?", "Stardew Valley Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Hide();

                Properties.Settings.Default.LaunchArguments = null;
                Properties.Settings.Default.Save();

                MainPage splash = new MainPage();
                splash.Show();
                splash.Activate();

                string DeleteLocation = Properties.Settings.Default.StardewDir + @"\tmp\";
                try
                {
                    Directory.Delete(DeleteLocation, true);
                }
                catch (Exception ex)
                {
                    CreateErrorLog("Cleanup operations were unable to take place. Error Message: " + ex.Message);
                }
            }
            else
            {
                Properties.Settings.Default.LaunchArguments = null;
                Properties.Settings.Default.Save();
                Application.Exit();

                string DeleteLocation = Properties.Settings.Default.StardewDir + @"\tmp\";
                try
                {
                    Directory.Delete(DeleteLocation, true);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Cleanup operations were unable to take place.");
                    CreateErrorLog("Cleanup operations were unable to take place. Error Message: " + ex.Message);
                }
            }
        }

        private void DoModInstall_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //ExtractProgress.Value = e.ProgressPercentage;
        }

        private void DoModDelete_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //ExtractProgress.Value = e.ProgressPercentage;
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