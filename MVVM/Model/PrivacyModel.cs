using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Twixer.MVVM.Model
{
    internal class PrivacyModel
    {

        public void DisableMicrosoftTelemetry(int value)
        {


            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", true);

            try
            {

                wKey.SetValue("AllowTelemetry", Convert.ToInt32(!Convert.ToBoolean(value)), RegistryValueKind.DWord);
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");
            }
            finally
            {
                wKey.Close();
            }

            
        }

        public void DisableDeleteOneDrive()
        {

            Process process = Process.Start(new ProcessStartInfo
            {

                FileName = "cmd",
                Arguments = @$"/uninstall %SystemRoot%\SysWOW64\OneDriveSetup.exe",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });
            
        }

        public void DisableEventLogProcessing(int value)
        {
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows", true);

            try
            {

                RegistryKey eventLog = wKey.CreateSubKey("EventLog");
                RegistryKey setupLog = eventLog.CreateSubKey("Setup");


                RegistryKey curKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\EventLog\Setup", true);
                curKey.SetValue("Enabled", Convert.ToInt32(!Convert.ToBoolean(value)), RegistryValueKind.String);
            }
            catch (Exception e)
            {
            }
            finally
            {
                myKey.Close();
            }

            Process process = Process.Start(new ProcessStartInfo
            {

                FileName = "cmd",
                Arguments = $"powershell.exe -command \"Get-EventLog -LogName * | ForEach {{ Clear-EventLog $_.Log }}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });
           
        }

        public void DisableUpdates(int value)
        {
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows", true);

            try
            {

                RegistryKey windowsUpdate = wKey.CreateSubKey("WindowsUpdate");
                RegistryKey setupLog = windowsUpdate.CreateSubKey("AU");


                RegistryKey curKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", true);
                curKey.SetValue("NoAutoUpdate", value, RegistryValueKind.DWord);
            }
            catch (Exception e)
            {
            }
            finally
            {
                myKey.Close();
            }
        }
    }
    
}
