using Stardew_Mod_Manager.Forms;
using Stardew_Mod_Manager.Forms.First_Run;
using Stardew_Mod_Manager.Startup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stardew_Mod_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjAyMjgyQDMxMzkyZTM0MmUzMGxmc1dVMjg5L3VsV1c0ekEyckJXQm9kN1g3bzVZYmw3cGhUdkcwMVB0NWc9");

            Properties.Settings.Default.CancelDownload = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create Launch Arguments
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("args[{0}] == {1}", i, args[i]);
                
                if(args.Length > 0)
                {
                    Properties.Settings.Default.LaunchArguments = args[i];
                }
                else
                {
                    Properties.Settings.Default.LaunchArguments = null;
                }    
            }

            if (Properties.Settings.Default.StardewDir != string.Empty)
            {
                string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
                string SettingsINI = SDVAppData + @"settings.ini";

                if (File.Exists(SettingsINI))
                {
                    Application.Run(new Splash());
                }
                else if (!File.Exists(SettingsINI))
                {
                    Application.Run(new FirstRunSetup());
                }
            }
            else
            {
                //First Run Setup hasn't been completed.
                if (Properties.Settings.Default.StardewDir == string.Empty)
                {
                    string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
                    string SettingsINI = SDVAppData + @"settings.ini";

                    if (File.Exists(SettingsINI))
                    {
                        if(Properties.Settings.Default.IsManuallyReset == "TRUE")
                        {
                            try
                            {
                                File.Delete(SettingsINI);
                            }
                            catch
                            {
                                //
                            }

                            Application.Run(new FirstRunSetup());
                        }
                        else
                        {
                            Application.Run(new UpdateVersion());
                        }
                    }
                    else if (!File.Exists(SettingsINI))
                    {
                        Application.Run(new FirstRunSetup());
                    }
                }
                else
                {
                    Application.Run(new Splash());
                }
            }
        }
    }
}
