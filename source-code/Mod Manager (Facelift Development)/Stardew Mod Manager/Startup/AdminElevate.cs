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

            //Prefill the Stardew Valley directory textbox with the directory saved to settings
            //(Since this form only shows if this has a valid value, we can assume a value exists)
            SDVDirectory.Text = Properties.Settings.Default.StardewDir.ToString();

            //Set the button border styles to be invisible for the "Run Normally" button.
            {
                RunUser.Style.Border = null;
                RunUser.Style.HoverBorder = null;
                RunUser.Style.FocusedBorder = null;
                RunUser.Style.PressedBorder = null;
            }
            //Set the button border styles to be invisible for the "Run as Admin" button.
            {
                RunAdmin.Style.Border = null;
                RunAdmin.Style.HoverBorder = null;
                RunAdmin.Style.FocusedBorder = null;
                RunAdmin.Style.PressedBorder = null;
            }
        }

        private void RunAdmin_Click(object sender, EventArgs e)
        {
            //Define the process information, including the launch arguments and admin rights
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Arguments = Properties.Settings.Default.LaunchArguments;
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = true;

            //Start the process and close this instance of the application
            Process.Start(startInfo);
            Application.Exit();
        }

        private void RunUser_Click(object sender, EventArgs e)
        {
            //Set the "Launch as Admin" flag to "False" and then proceed to the splash screen.
            Properties.Settings.Default.LaunchAsAdmin = "FALSE";
            Splash splash = new Splash();
            splash.Show();
            //Hide this window after opening the splash screen
            this.Hide();
        }

        private void SDVDirectory_TextChanged(object sender, EventArgs e)
        {
            //If the user attempts to change the stardew directory textbox, re-write it to the correct value.
            SDVDirectory.Text = Properties.Settings.Default.StardewDir.ToString();
        }

        private void LearnMoreLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Open the page on the SDV Mod Manager wiki, detailing the information regarding this window.
            Process.Start("https://rwe-labs.gitbook.io/sdvmm/getting-started/setup-and-configuration/running-with-elevated-privileges");
        }
    }
}
