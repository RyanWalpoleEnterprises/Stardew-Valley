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
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;


namespace SDVMP_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void doCheckSave(string savefile)
        {
            if (File.Exists(savefile))
            {
                MessageBox.Show("Your Modpack file has been created successfully." + Environment.NewLine + Environment.NewLine + savefile, "SDVMP Geneator | Stardew Valley Modded Framework", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There was an issue saving the file. Please make sure you have access to the save location and try again later.", "SDVMP Generator | Stardew Valley Modded Framework", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LearnMoreLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://rwe-labs.gitbook.io/sdvmm/developer/developing-for-stardew-valley-mod-manager/creating-a-modpack");
        }

        private void Cancelquit_Click(object sender, EventArgs e)
        {
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tmp = AppDataFolder + @"\RWE Labs\SDV Mod Manager\tmp\pack\";

            if (Directory.Exists(tmp))
            {
                Directory.Delete(tmp, true);
            }

            Application.Exit();
        }

        private void AddMod_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.InitialDirectory = @"C:\\Users";
            dialog.Filter = "ZIP Folder (.zip)|*.zip";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in dialog.FileNames)
                {
                    try
                    {
                        if (folderlist.Items.Contains(file))
                        {
                            MessageBox.Show("This mod has already been added to the mods list.", "SDVMP Generator", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            folderlist.Items.Add(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "SDVMP Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tmp = AppDataFolder + @"\RWE Labs\SDV Mod Manager\tmp\pack\";

            if (!Directory.Exists(tmp))
            {
                Directory.CreateDirectory(tmp);
            }

            if(folderlist.Items.Count < 2)
            {
                MessageBox.Show("Please add at least two mods to create a modpack.", "SDVMP Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(folderlist.Items.Count >= 2)
            {
                if(TargetSMAPIVersion.Text == null)
                {
                    MessageBox.Show("Please add a target SMAPI version. This is the version of SMAPI your modpack is designed to run with.");
                }
                else
                {
                    Operation1.RunWorkerAsync();
                    ProgressWorker.Visible = true;
                    Create.Enabled = false;
                    Cancelquit.Enabled = false;
                }
            }
        }

        private void folderlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(folderlist.SelectedIndex > 0)
            {
                RemoveMod.Enabled = true;
            }
            if (folderlist.SelectedIndex == 0)
            {
                RemoveMod.Enabled = true;
            }
            if (folderlist.SelectedIndex < 0)
            {
                RemoveMod.Enabled = false;
            }
        }

        private void RemoveMod_Click(object sender, EventArgs e)
        {
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tmp = AppDataFolder + @"\RWE Labs\SDV Mod Manager\tmp\pack\";

            folderlist.Items.Remove(folderlist.SelectedItem);
            RemoveMod.Enabled = false;
        }

        private void Operation1_DoWork(object sender, DoWorkEventArgs e)
        {
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tmp = AppDataFolder + @"\RWE Labs\SDV Mod Manager\tmp\pack\";

            foreach (string item in folderlist.Items)
            {
                ZipFile.ExtractToDirectory(item, tmp + Path.GetFileNameWithoutExtension(item));
            }
        }

        private void Operation1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tmp = AppDataFolder + @"\RWE Labs\SDV Mod Manager\tmp\pack\";

            ProgressWorker.Visible = true;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Stardew Valley Modpack|*sdvmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.tmpFN = dialog.FileName + ".sdvmp";
                Operation2.RunWorkerAsync();
            }
            else
            {
                Properties.Settings.Default.tmpFN = null;
                ProgressWorker.Visible = false;
            }
        }

        private void Operation2_DoWork(object sender, DoWorkEventArgs e)
        {
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tmp = AppDataFolder + @"\RWE Labs\SDV Mod Manager\tmp\pack\";
            IniWrite.AppendText("$TARGETSMAPI=" + TargetSMAPIVersion.Text);
            IniWrite.SaveFile(tmp + "meta.ini", RichTextBoxStreamType.PlainText);

            ZipFile.CreateFromDirectory(tmp, Properties.Settings.Default.tmpFN);
        }

        private void Operation2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tmp = AppDataFolder + @"\RWE Labs\SDV Mod Manager\tmp\pack\";

            MessageBox.Show("Modpack has been successfully created!", "SDVMP Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            folderlist.Items.Clear();
            Create.Enabled = true;
            Cancelquit.Enabled = true;

            if (Directory.Exists(tmp))
            {
                Directory.Delete(tmp, true);
            }

            ProgressWorker.Visible = false;
        }
    }
}
