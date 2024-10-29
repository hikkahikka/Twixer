using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Twixer.MVVM.Model.Register
{
    internal class PrivacyRegister
    {
        public void DisableMicrosoftTelemetry(int value)
        {

            RegistryKey myKey = Registry.LocalMachine;
            
            RegistryKey wKey =null;

            try
            {
                wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection", true);
                wKey.SetValue("AllowTelemetry", Convert.ToInt32(!Convert.ToBoolean(value)), RegistryValueKind.DWord);
            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить", "Поражение");

            }

            finally
            {
                wKey?.Close();
            }
        }
        
        public void DisableEventLogProcessing(int value)
        {
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = null;

            try
            {
                wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows", true);
                RegistryKey eventLog = wKey.CreateSubKey("EventLog");
                RegistryKey setupLog = eventLog.CreateSubKey("Setup");


                RegistryKey curKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\EventLog\Setup", true);
                curKey.SetValue("Enabled", Convert.ToInt32(!Convert.ToBoolean(value)), RegistryValueKind.String);
            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить", "Поражение");

            }
            finally
            {
                wKey?.Close();
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
            RegistryKey wKey = null;
            try
            {

                wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows", true);
                RegistryKey windowsUpdate = wKey.CreateSubKey("WindowsUpdate");
                RegistryKey setupLog = windowsUpdate.CreateSubKey("AU");


                RegistryKey curKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", true);
                curKey.SetValue("NoAutoUpdate", value, RegistryValueKind.DWord);
            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить", "Поражение");

            }
            finally
            {
                wKey?.Close();
            }
        }

        public void DisableCollectionHandwrittenInput(int value)
        {
            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = null;

            try
            {
                wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft", true);
                RegistryKey windowsUpdate = wKey.CreateSubKey("InputPersonalization");
                RegistryKey curKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\InputPersonalization", true);
                curKey.SetValue("RestrictImplicitTextCollection", value, RegistryValueKind.DWord);
                curKey.SetValue("RestrictImplicitInkCollection", value, RegistryValueKind.DWord);

            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить", "Поражение");

            }
            finally
            {
                wKey?.Close();
            }





            RegistryKey myKey2 = Registry.LocalMachine;

            RegistryKey wKey2 = null;

            try
            {
                wKey2 = myKey2.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows", true);
                RegistryKey newKey2 = wKey2.CreateSubKey("HandwritingErrorReports");

                RegistryKey curKey2 = myKey2.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\HandwritingErrorReports", true);
                curKey2.SetValue("PreventHandwritingErrorReports", Convert.ToInt32(!Convert.ToBoolean(value)), RegistryValueKind.DWord);

            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить", "Поражение");

            }
            finally
            {
                wKey2?.Close();
            }
        }

    }
}
