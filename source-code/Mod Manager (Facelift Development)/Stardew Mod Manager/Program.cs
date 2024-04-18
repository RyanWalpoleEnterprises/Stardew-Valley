using Stardew_Mod_Manager.Forms;
using Stardew_Mod_Manager.Forms.First_Run;
using Stardew_Mod_Manager.Startup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
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

            //License Application with Syncfusion
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjAyMjgyQDMxMzkyZTM0MmUzMGxmc1dVMjg5L3VsV1c0ekEyckJXQm9kN1g3bzVZYmw3cGhUdkcwMVB0NWc9");
            //Set CancelDownload setting to False
            Properties.Settings.Default.CancelDownload = false;
            //Enable Visual Styles and Text Rendering
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Create and Get Launch Arguments
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("args[{0}] == {1}", i, args[i]);
                MessageBox.Show(args[i]);

                if (args.Length > 0)
                {
                    //There are launch arguments, save them to settings.
                    Properties.Settings.Default.LaunchArguments = args[i];
                }
                else
                {
                    //There are no launch arguments, save them absolutely nowhere.
                    Properties.Settings.Default.LaunchArguments = null;
                }    
            }

            //If there is a valid Stardew Directory saved to settings...
            if (Properties.Settings.Default.StardewDir != string.Empty)
            {
                //Define locations for AppData/Settings INI
                string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
                string SettingsINI = SDVAppData + @"settings.ini";

                //If the StardewDir is on the C Drive...
                if (Properties.Settings.Default.StardewDir.ToLower().Contains(@"c:\"))
                {
                    //And saved in a C:\Users location (not in the root, program files, etc)
                    if (Properties.Settings.Default.StardewDir.ToLower().Contains(@"c:\users\"))
                    {
                         //The application is likely installed in Documents/Downloads/etc.
                         //These are not admin-protected folders, so there's no need to do anything special...
                     }
                    //And it's in a location not dedicated to a user...
                    else if (!Properties.Settings.Default.StardewDir.ToLower().Contains(@"c:\users\"))
                     {
                        //Check if the app is already running as admin...
                        WindowsIdentity identity = WindowsIdentity.GetCurrent();
                        WindowsPrincipal principal = new WindowsPrincipal(identity);
                        bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

                        //The user is already running as an admin...
                        if (isAdmin)
                        {
                            //The program is already in administrator mode.
                            //Do not set "LaunchAsAdmin" to TRUE
                            Properties.Settings.Default.LaunchAsAdmin = "FALSE";
                        }
                        //The user is not running as an admin
                        else
                        {
                            //The prorgram is not in administrator mode, but the user needs it to be.
                            //Set "LaunchAsAdmin" to TRUE
                            Properties.Settings.Default.LaunchAsAdmin = "TRUE";
                        }

                        
                     }
                 }

                if (File.Exists(SettingsINI))
                {
                    if (Properties.Settings.Default.LaunchAsAdmin == "TRUE")
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = Application.ExecutablePath;
                        startInfo.Arguments = Properties.Settings.Default.LaunchArguments;
                        startInfo.Verb = "runas";
                        startInfo.UseShellExecute = true;

                        Process.Start(startInfo);
                        Application.Exit();
                    }
                    else
                    {
                        Application.Run(new Splash());
                    }
                    
                }
                else if (!File.Exists(SettingsINI))
                {
                    Application.Run(new FirstRunSetup());
                }
            }

            //If there is not a valid Stardew Directory saved to settings...
            else
            {
                //If the directory is empty...
                if (Properties.Settings.Default.StardewDir == string.Empty)
                {
                    //Define locations for Settings and AppData
                    string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string SDVAppData = AppData + @"\RWE Labs\SDV Mod Manager\";
                    string SettingsINI = SDVAppData + @"settings.ini";

                    //The directory is empty but there is a valid Settings.ini file.
                    if (File.Exists(SettingsINI))
                    {
                        //If the Settings.ini file exists, and the user manually reset...
                        if(Properties.Settings.Default.IsManuallyReset == "TRUE")
                        {
                            try
                            {
                                //Delete the settings file.
                                File.Delete(SettingsINI);
                            }
                            catch
                            {
                                //
                            }
                            //...and run the application's FirstRunSetup!
                            Application.Run(new FirstRunSetup());
                        }

                        //Otherwise migrate the settings.ini file to the application using the "updateversion" form...
                        else
                        {
                            Application.Run(new UpdateVersion());
                        }
                    }

                    //Otherwise, if the Settings.ini file doesn't exist, we can assume the user has never completed the FirstRunSetup
                    //So we can launch the application to that directory!
                    else if (!File.Exists(SettingsINI))
                    {
                        Application.Run(new FirstRunSetup());
                    }
                }

                //Otherwise, if the Stardew Directory is valid, we can assume the FirstRunSetup has been completed!
                else
                {
                    //If the Stardew Directory is on a protected C drive location, and the LaunchAsAdmin setting has been set to true...
                    //Launch the application again - this time as administrator.
                    if (Properties.Settings.Default.LaunchAsAdmin == "TRUE")
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = Application.ExecutablePath;
                        startInfo.Arguments = Properties.Settings.Default.LaunchArguments;
                        startInfo.Verb = "runas";
                        startInfo.UseShellExecute = true;

                        Process.Start(startInfo);
                        Application.Exit();
                    }
                    //Otherwise, we just need to run the application normally.
                    else
                    {
                        Application.Run(new Splash());
                    }
                }
            }
        }
    }
}
