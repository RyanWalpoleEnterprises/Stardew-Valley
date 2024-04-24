using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stardew_Mod_Manager.Startup
{
    public partial class AdminElevate : Form
    {
        public AdminElevate()
        {
            InitializeComponent();
            SDVDirectory.Text = Properties.Settings.Default.StardewDir.ToString();

            RunUser.Style.Border = null;
            RunUser.Style.HoverBorder = null;
            RunUser.Style.FocusedBorder = null;
            RunUser.Style.PressedBorder = null;

            RunAdmin.Style.Border = null;
            RunAdmin.Style.HoverBorder = null;
            RunAdmin.Style.FocusedBorder = null;
            RunAdmin.Style.PressedBorder = null;
        }

        private void RunAdmin_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Arguments = Properties.Settings.Default.LaunchArguments;
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = true;

            Process.Start(startInfo);
            Application.Exit();
        }

        private void RunUser_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchAsAdmin = "FALSE";
            Splash splash = new Splash();
            splash.Show();
            this.Hide();
        }

        private void SDVDirectory_TextChanged(object sender, EventArgs e)
        {
            SDVDirectory.Text = Properties.Settings.Default.StardewDir.ToString();
        }

        private void LearnMoreLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://rwe-labs.gitbook.io/sdvmm/getting-started/setup-and-configuration/running-with-elevated-privileges");
        }
    }
}
