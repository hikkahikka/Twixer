using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;

using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Twixer.MVVM.Model
{

    internal class InfoAboutSystemModel {     
       

        public string GetOperationSystemInfo()
        {
            
            Process process = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = @"/c chcp 65001 & wmic os get Caption, Version / value ",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });

            string infoAboutSystem = process.StandardOutput.ReadToEnd();
            string result = "";
            Regex regex = new Regex(@"=.*");
            MatchCollection matches = regex.Matches(infoAboutSystem);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)

                    result += match.Value.Replace("\r", "");
            }
            else
            {
                result = "ERROR";
            }
            result = result.Replace("=", " ").Remove(0, 11).Trim();
            return result;
        }

        public string GetMotherboardInfo()
        {
            Process process = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = @"/c wmic baseboard get manufacturer, product ",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });

            string motherboard = process.StandardOutput.ReadToEnd();
            string result;
            result = motherboard.Replace("Manufacturer", "").Replace("Product", "").Replace("\r", "").Replace("\n", "").Trim();
            return result;
        }

        public string GetCPUInfo()
        {
            Process process = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = @"/c wmic cpu get name",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });
            string cpu = process.StandardOutput.ReadToEnd();
            string result;
            result = cpu.Replace("\r", "").Replace("\n", "").Replace("Name", "").Trim();
            return result;
        }

        public string GetRAMInfo()
        {
            Process processVolume = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = @"/c wmic memorychip get Capacity",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });

            string ramVolume = processVolume.StandardOutput.ReadToEnd();

            string buffVolume;



            buffVolume = ramVolume.Replace("Capacity", "").Replace("\n", "").Replace("\r", "").Trim();


            string[] wordsVolume = buffVolume.Split(new char[] { ' ' });

            double resultVolume = 0;

            foreach (string sv in wordsVolume)
            {
                if (sv != "")
                {
                    resultVolume += Convert.ToInt64(sv);
                }
            }
            resultVolume = resultVolume / 1024 / 1024 / 1024;



            Process processSpeed = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = @"/c wmic memorychip get Speed",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });

            string ramSpeed = processSpeed.StandardOutput.ReadToEnd();


            string buffSpeed;

            buffSpeed = ramSpeed.Replace("Speed", "").Replace("\n", "").Replace("\r", "").Trim();



            string[] wordsSpeed = buffSpeed.Split(new char[] { ' ' });
            double resultSpeed = Int64.MaxValue;

            foreach (string ss in wordsSpeed)
            {
                if (ss != "")
                {
                    if (Convert.ToInt64(ss) < resultSpeed)
                    {
                        resultSpeed = Convert.ToInt64(ss);
                    }
                }
            }

            string result = Convert.ToString(resultVolume) + "Gb   " + Convert.ToString(resultSpeed) + "MHz";
            return result;
        }

        public string GetGPUInfo()
        {
            Process process = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = @"/c wmic path win32_VideoController get name",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });

            string cpu = process.StandardOutput.ReadToEnd();

            string result;

            result = cpu.Replace("\r", "").Replace("\n", "").Replace("Name", "").Trim();


            return result;
        }

        public string GetTimeOfWorkInfo()
        {
            Process process = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = @"/c wmic path Win32_OperatingSystem get LastBootUpTime",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,

            });

            string cpu = process.StandardOutput.ReadToEnd();

            string result;

            result = cpu.Replace("\r", "").Replace("\n", "").Replace("LastBootUpTime", "").Replace(".", "").Replace("+", "").Trim();



            int buff_year = Convert.ToInt32(result.Substring(0, 4).TrimStart('0'));
            int buff_month = Convert.ToInt32(result.Substring(4, 2).TrimStart('0'));
            int buff_day = Convert.ToInt32(result.Substring(6, 2).TrimStart('0'));




            int buff_hour = (result.Substring(8, 2) == "00") ? 0 : Convert.ToInt32(result.Substring(8, 2).TrimStart('0'));  //красивое условие в одну строку ваааааа



            int buff_minute = (result.Substring(10, 2) == "00") ? 0 : Convert.ToInt32(result.Substring(10, 2).TrimStart('0'));
            int buff_second = (result.Substring(12, 2) == "00") ? 0 : Convert.ToInt32(result.Substring(12, 2).TrimStart('0'));

            DateTime timeNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime timeOn = new DateTime(buff_year, buff_month, buff_day, buff_hour, buff_minute, buff_second);
            return Convert.ToString(timeNow.Subtract(timeOn));
        }

        public string GetIPAddressInfo()
        {
            
            try
            {
                string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
                var externalIp = IPAddress.Parse(externalIpString);
                return externalIp.ToString();
            }
            catch(Exception ex)
            {
                return "Ошибка, проверьте подключение к интернету";
            }
            
        }
    }
}
