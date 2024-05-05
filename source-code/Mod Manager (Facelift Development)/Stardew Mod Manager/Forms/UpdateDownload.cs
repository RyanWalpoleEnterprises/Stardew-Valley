using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Stardew_Mod_Manager.Forms
{
    public partial class UpdateDownload : SfForm
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        public UpdateDownload()
        {
            InitializeComponent();

            PercentText.Text = "Initialising...";

            //Font tbar = new System.Drawing.Font("Segoe UI", 8.25, FontStyle.Regular);

            FontFamily fontFamily = new FontFamily("Segoe UI");
            Font font = new Font(
               fontFamily,
               11,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            this.Style.TitleBar.Font = font;

            StartUpdate();
        }

        private void StartUpdate()
        {
            PercentText.Text = "Retrieving update information...";

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                    string updatelocation = Path.Combine(dataPath, "SDVMMlatest.exe");

                    // Check if the file already exists, delete if necessary
                    if (File.Exists(updatelocation))
                    {
                        File.Delete(updatelocation);
                    }

                    wc.DownloadProgressChanged += wc_DownloadProgressChanged2;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://github.com/RWELabs/Stardew-Valley-Mod-Manager/raw/release-stable/version/Latest/StardewModManagerSetup.exe"),
                        // Param2 = Path to save
                        updatelocation
                    );

                    this.BringToFront();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured whilst trying to update: " + ex.Message);
            }
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // First check for Cancelled and then for other exceptions
            if (e.Cancelled)
            {
                MessageBox.Show("Cancelled");
            }
            if (e.Error != null)
            {
                // Handle error scenario
                MessageBox.Show("The download failed: " + e.Error.Message);
                Cancel.Enabled = false;
                Cancel.Text = "Cancelling...";
                Properties.Settings.Default.CancelDownload = true;

                CancelCleanup.Start();
            }
        }

        void wc_DownloadProgressChanged2(object sender, DownloadProgressChangedEventArgs e)
        {
            if(Properties.Settings.Default.CancelDownload == false)
            {
                Progress.Value = e.ProgressPercentage;
                long FileSize = e.TotalBytesToReceive / 1024;
                long FileSizeMB = FileSize / 1000;
                //DLPercentText.Text = e.ProgressPercentage.ToString() + "% of " + FileSize.ToString() + " kb";

                PercentText.Text = "Downloading " + e.ProgressPercentage.ToString() + "% of " + FileSizeMB.ToString() + "mb (" + FileSize + "kb)";
            }
            else
            {
                Progress.Step = 0;
                PercentText.Text = "Cancelling...";
            }

            if (PercentText.Text.Contains("100%") && Progress.Value == 100)
            {
                StartExecute.Start();
            }
        }

        private void StartExecute_Tick(object sender, EventArgs e)
        {
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string updatelocation = Path.Combine(dataPath, "SDVMMlatest.exe");

            StartExecute.Stop();

            this.Focus();
            this.BringToFront();
            this.TopMost = true;

            try
            {
                DialogResult dr = MessageBox.Show("The update has been downloaded, the application will now close as the installer will launch.", "Update Software | RWE Labs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    Properties.Settings.Default.CancelDownload = false;
                    Process.Start(updatelocation);
                    Application.Exit();
                }
                else
                {
                    this.Close();
                    Properties.Settings.Default.CancelDownload = false;
                    Process.Start(updatelocation);
                    Application.Exit();
                }
            }
            catch(Exception ex)
            {
                Properties.Settings.Default.CancelDownload = false;
                //MessageBox.Show("There was an issue launching the update package. Do you have administrative priviliges on this user account?" + Environment.NewLine + ex.Message, "RWE Labs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Application.Exit();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Cancel.Enabled = false;
            Cancel.Text = "Cancelling...";
            Properties.Settings.Default.CancelDownload = true;

            CancelCleanup.Start();
        }

        private void CancelCleanup_Tick(object sender, EventArgs e)
        {
            CancelCleanup.Stop();

            this.Close();
        }

        private void UpdateDownload_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.CancelDownload = false;
        }
    }
}
