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
    internal class SystemModel
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
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");
            }
            finally
            {
                myKey.Close();
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

        public void DisableUAC(int value)
        {
            
            Process process = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $@"C:\Windows\System32\cmd.exe /k %windir%\System32\reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d {Convert.ToInt32(!Convert.ToBoolean(value))} /f",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });
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
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");

            }
            finally
            {
                myKey.Close();
            }
        }

        public void DisableMemoryDiagnostics(bool value)
        {
            if (value == true)
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
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");

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
            catch (Exception e)
            {
                MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");

            }
            finally
            {
                myKey.Close();
            }
        }

        public void DisableChangeWallpapers(int value)
        {

            if (value == 1)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

                try
                {

                    // Открываем ветку реестра "Control Panel\Desktop"

                    // Изменяем значение ключа "Wallpaper" на пустую строку
                    key.SetValue("Wallpaper", "");

                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");

                }
                finally
                {
                    // Закрываем ключ реестра
                    key.Close();
                }



            }


            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

                try
                {

                    // Открываем ветку реестра "Control Panel\Desktop"

                    // Изменяем значение ключа "Wallpaper" на пустую строку
                    key.SetValue("Wallpaper", @"C:\Windows\Web\Screen\img105.jpg");

                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");

                }
                finally
                {
                    // Закрываем ключ реестра
                    key.Close();
                }
            }


        }

    }
}
