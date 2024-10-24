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
using System.Windows.Shell;
using System.Windows;



namespace Twixer.MVVM.Model
{

    internal class InfoAboutSystemModel {

        private const string json_path = "info_about_system.json";        

        public InfoAboutSystemData GetInfoAboutSystemData()
        {
            string json;
            Serializer serializer = new ();
            InfoAboutSystemData data = new();
            while (File.Exists(json_path))
            {
                try
                {
                    json = File.ReadAllText(json_path);
                    data = serializer.DeserializeInfoAboutSystem(json);
                    return data;
                }
                catch
                {
                    break;
                }
            }
              
            SystemInfoRegister register = new SystemInfoRegister();
            
            data.OperationSystem = register.GetOperationSystemInfo();
            data.Motherboard = register.GetMotherboardInfo();
            data.CPU = register.GetCPUInfo();
            data.GPU = register.GetGPUInfo();
            data.RAM = register.GetRAMInfo();
            data.IP = register.GetIPAddressInfo();
            
            json = serializer.SerializeInfoAboutSystem(data);
            try
            {
                File.WriteAllText(json_path, json);
            }
            catch (IOException)
            {
                string random_time = SetTimeOfWorkInfo();
                string new_path = random_time + json_path;
                if (!File.Exists(new_path))
                {
                    File.WriteAllText(new_path, json);
                }
            }
            catch
            {
                throw new NotImplementedException("string path to json is invalid");
            }
            
            return data;
        }
        public string SetTimeOfWorkInfo()
        {
            SystemInfoRegister data = new SystemInfoRegister();
            return data.GetTimeOfWorkInfo();
        }

        
    }
}
