﻿using Microsoft.Win32;
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
            RegistryKey myKey = Registry.LocalMachine;
            RegistryKey wKey = null;
            //тудум проверить в реестре
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
                MessageBox.Show(Convert.ToString(e), "Произошла ошибка при изменении UAC");
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

        public void DisableMemoryDiagnostics(bool value)
        {
            //иззначально этой записи нет, по умолчание no
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
                    key.SetValue("Wallpaper", "");

                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");

                }
                finally
                {
                    key.Close();
                }



            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

                try
                {
                    key.SetValue("Wallpaper", @"C:\Windows\Web\Screen\img105.jpg");

                }
                catch (Exception e)
                {
                    MessageBox.Show("Произошла непредвиденная ошибка, прошу простить");
                }
                finally
                {
                    key.Close();
                }
            }


        }

    }
}
