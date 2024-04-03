using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stardew_Mod_Manager.Forms.Webapp
{
    public partial class WebToolsHome : Form
    {
        public WebToolsHome()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\SDV Mod Manager\WV2\"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\SDVMM\WV2\");
            }
            if (!Directory.Exists(@"C:\Program Files (x86)\Microsoft\EdgeWebView\Application"))
            {
                //Alert and Install Options
                DialogResult dr = MessageBox.Show("Stardew Valley WebTools requires an installation of Microsoft Edge WebView2 to function. We weren't able to find an installation on your machine. Would you like to install this now? Installation will require an active internet connection.","Install Required Component", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes) { try { Process.Start(@"C:\Program Files (x86)\RWE Labs\Stardew Valley Mod Manager\wv2setuputil.exe"); } catch {  } }
                this.Close();
            }
            else
            {
                InitializeComponent();
                InitializeBrowser();
            }
        }

        private void webView_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (webView.CanGoBack) { Back.Enabled = true; } else if (!webView.CanGoBack) { Back.Enabled = false; }
            if (webView.CanGoForward) { Forward.Enabled = true; } else if (!webView.CanGoForward) { Forward.Enabled = false; }

            string URL = webView.CoreWebView2.Source.ToString();
            //MessageBox.Show(webView.CoreWebView2.Source.ToString());

            if (!URL.StartsWith("https://rwelabs.github.io/"))
            {
                if (Properties.Settings.Default.IgnoreWebsiteWarning == "FALSE" )
                {
                    WarningPanel.Visible = true;
                    StatusButton.Visible = true;
                    Refresh.Enabled = false;
                }
                else if (Properties.Settings.Default.IgnoreWebsiteWarning == "TRUE")
                {
                    WarningPanel.Visible = false;
                    StatusButton.Visible = true;
                    Refresh.Enabled = true;
                }
            }
            
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            webView.Reload();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Navigate(new Uri("https://rwelabs.github.io/sdvmm/webtools/").ToString());
            Debug.WriteLine("after Navigate");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            webView.GoBack();
            string URL = webView.CoreWebView2.Source.ToString();
            //MessageBox.Show(webView.CoreWebView2.Source.ToString());

            if (!URL.StartsWith("https://rwelabs.github.io/"))
            {
                StatusButton.Visible = false;
                WarningPanel.Visible = false;
            }
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            webView.GoForward();
            string URL = webView.CoreWebView2.Source.ToString();
            //MessageBox.Show(webView.CoreWebView2.Source.ToString());

            if (!URL.StartsWith("https://rwelabs.github.io/"))
            {
                StatusButton.Visible = false;
                WarningPanel.Visible = false;
            }
        }

        private async void WebToolsHome_Load(object sender, EventArgs e)
        {
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        private async Task InitializeBrowser()
        {
            var userDataFolder =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RWE Labs\SDV Mod Manager\WV2\";
            var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder);
            await webView.EnsureCoreWebView2Async(env);
            webView.Source = new Uri("https://rwelabs.github.io/sdvmm/webtools");
        }


        private void WebView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Debug.WriteLine("WebView_CoreWebView2InitializationCompleted");
        }

        private void ContinueWarning_Click(object sender, EventArgs e)
        {
            WarningPanel.Visible = false;
            Properties.Settings.Default.IgnoreWebsiteWarning = "TRUE";
            Refresh.Enabled = true;
            if(IgnoreWarning.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void WarningReturn_Click(object sender, EventArgs e)
        {
            webView.GoBack();
            WarningPanel.Visible = false;
            Refresh.Enabled = true;
            Properties.Settings.Default.IgnoreWebsiteWarning = "FALSE";
            Properties.Settings.Default.Save();
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            WarningPanel.Visible = true;
        }
    }
}
