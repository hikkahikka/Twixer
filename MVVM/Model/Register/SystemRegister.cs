using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Twixer.MVVM.Model.Register
{
    internal class SystemRegister
    {
        public void DisableSecurityNotification(int value)
        {

            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows", true);

            try
            {

                RegistryKey newKey = wKey.CreateSubKey("Explorer");
                RegistryKey curKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", true);
                curKey.SetValue("DisableNotificationCenter", value, RegistryValueKind.DWord);
            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при получении Уведомлений");

            }
            finally
            {
                myKey.Close();
            }
        }
        public bool GetSecurityNotification()
        {
            RegistryKey myKey = Registry.CurrentUser;

            RegistryKey wKey = null;

            try
            {
                wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Explorer", true);
                if (wKey == null)
                {
                    SystemRegister register = new SystemRegister();
                    register.DisableSecurityNotification(0);
                    return false;
                }
                var result = Registry.GetValue(wKey.ToString(), "DisableNotificationCenter", null);

                if (result == null)
                {
                    SystemRegister register = new SystemRegister();
                    register.DisableSecurityNotification(0);
                    return false;
                }
                else
                {
                    return !Convert.ToBoolean(result);
                }


            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
                Environment.Exit(0);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при получении Уведомлений");
                return false;
            }
            finally
            {
                wKey?.Close();
            }
        }
        public void DisableDefenderWindows(int value)
        {

            Process process = Process.Start(new ProcessStartInfo
            {

                FileName = "cmd",
                Arguments = $"powershell.exe -command \"Set-MpPreference -DisableRealtimeMonitoring ${Convert.ToBoolean(value)} \"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });
        }

        public bool GetDefenderWindows() {


            return false;
        }

        public void DisableUAC(int value)
        {
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = null;

            try
            {
                wKey = myKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true);
                wKey.SetValue("EnableLUA", Convert.ToInt32(!Convert.ToBoolean(value)), RegistryValueKind.DWord);
            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при получении UAC");
            }
            finally
            {
                wKey?.Close();
            }       
        }
        public bool GetUAC()
        {
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = null;
            
            try
            {
                wKey = myKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true);
                var result = Registry.GetValue(wKey.ToString(), "EnableLUA", null);

                if (result == null)
                {
                    SystemRegister register = new SystemRegister();
                    register.DisableUAC(1);//1 or 0 ?
                    return false;
                }
                else
                {
                    return !Convert.ToBoolean(result);
                }


            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
                Environment.Exit(0);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при получении Уведомлений");
                return false;
            }
            finally
            {
                wKey?.Close();
            }
        }
        public void DisableTaskManager(int value)
        {
            RegistryKey myKey = Registry.CurrentUser;
            RegistryKey wKey = myKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies", true);

            try
            {
                RegistryKey newKey = wKey.CreateSubKey("System");
                RegistryKey curKey = myKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true);
                curKey.SetValue("DisableTaskMgr", value, RegistryValueKind.DWord);

            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при изменении Диспетчера задач");

            }
            finally
            {
                myKey.Close();
            }
        }
        public bool GetTaskManager()
        {
            RegistryKey myKey = Registry.CurrentUser;

            RegistryKey wKey = null;

            try
            {
                wKey = myKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true);
                if (wKey == null)
                {
                    SystemRegister register = new SystemRegister();
                    register.DisableTaskManager(0);
                    return false;
                }
                var result = Registry.GetValue(wKey.ToString(), "DisableTaskMgr", null);

                if (result == null)
                {
                    PrivacyRegister register = new PrivacyRegister();
                    register.DisableMicrosoftTelemetry(1);
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(result);
                }


            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
                Environment.Exit(0);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при получении Диспетчера");
                return false;
            }
            finally
            {
                wKey?.Close();
            }
        }
        public void DisableMemoryDiagnostics(int value)
        {
            //иззначально этой записи нет, по умолчание no

            if (Convert.ToBoolean(value) == true)
            {
                Process process = Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $@"bcdedit /set disabledynamictick yes",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,

                });
            }
            else
            {

                Process process = Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $@"bcdedit /set disabledynamictick no",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,

                });
            }
        }
        public bool GetMemoryDiagnostics()
        {
            return false;
        }
        public void DisableCortana(int value)
        {
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows", true);
            try
            {
                RegistryKey windowsSearch = wKey.CreateSubKey("Windows Search");
                RegistryKey curKey = myKey.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Windows Search", true);
                curKey.SetValue("AllowCortana", Convert.ToInt32(!Convert.ToBoolean(value)), RegistryValueKind.DWord);
            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при изменении Кортаны");

            }
            finally
            {
                myKey.Close();
            }
        }

        public void AddCache(int value)
        {
            RegistryKey myKey = Registry.LocalMachine;
            try
            {
                RegistryKey wKey = myKey.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management", true);
                wKey.SetValue("DisablePagingExecutive", value, RegistryValueKind.DWord);
                wKey.SetValue("LargeSystemCache", value, RegistryValueKind.DWord);
            }
            catch (SecurityException e)
            {
                MessageBox.Show("Скорее всего, вы запустили программу не от имени администратора!", "Неверный пользователь");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при изменении Кэша");

            }
            finally
            {
                myKey.Close();
            }
        }

        

    }
}
