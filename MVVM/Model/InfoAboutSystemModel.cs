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



namespace Twixer.MVVM.Model
{

    internal class InfoAboutSystemModel {

        private const string json_path = "info_about_system.json";        

        public InfoAboutSystemData GetInfoAboutSystemData()
        {
            Serializer serializer = new ();
            InfoAboutSystemData data = new();
            if (File.Exists(json_path))
            {
                
                data = serializer.DeserializeInfoAboutSystem(json_path);
                
            }
            else
            {
                
                Register register = new Register();
                
                data.OperationSystem = register.GetOperationSystemInfo();
                data.Motherboard = register.GetMotherboardInfo();
                data.CPU = register.GetCPUInfo();
                data.GPU = register.GetGPUInfo();
                data.RAM = register.GetRAMInfo();
                data.IP = register.GetIPAddressInfo();
                
                string json = serializer.SerializeInfoAboutSystem(data);
                try { File.WriteAllText(json_path, json); }
                catch { }

            }
            return data;
        }
        public string SetTimeOfWorkInfo()
        {
            Register data = new Register();
            return data.GetTimeOfWorkInfo();
        }

        
    }
}
