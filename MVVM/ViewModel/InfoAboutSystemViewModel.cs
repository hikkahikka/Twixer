using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;

using Twixer.MVVM.Model;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Input;

namespace Twixer.MVVM.ViewModel
{
    public class InfoAboutSystemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        class SysInfo
        {
            public string OperationSystem
            {
                get;
                set;
            }

            public string Motherboard
            {
                get;
                set;
            }

            public string CPU
            {
                get;
                set;
            }

            public string RAM
            {
                get;
                set;
            }

            public string GPU
            {
                get;
                set;
            }

            public string TimeOfWork
            {
                get;
                set;
            }

            public string IPAddress
            {
                get;
                set;
            }
        };

        private string _buffOperationSystem;
        private string _buffMotherboard;
        private string _buffCPU;
        private string _buffRAM;
        private string _buffGPU;
        private string _buffTimeOfWork;
        private string _buffIPAddress;

        public string OperationSystem
        {
            get => _buffOperationSystem;
            set
            {
                _buffOperationSystem = value;
                OnPropertyChanged(nameof(OperationSystem));
            }
        }

        public string Motherboard
        {
            get => _buffMotherboard;
            set
            {
                _buffMotherboard = value;
                OnPropertyChanged(nameof(Motherboard));
            }
        }

        public string CPU
        {
            get => _buffCPU;
            set
            {
                _buffCPU = value; 
                OnPropertyChanged(nameof(CPU));
            }
        }

        public string RAM
        {
            get => _buffRAM;
            set
            {
                _buffRAM = value;
                OnPropertyChanged(nameof(RAM));
            }
        }

        public string GPU
        {
            get => _buffGPU;
            set
            {
                _buffGPU = value;
                OnPropertyChanged(nameof(GPU));
            }
        }

        public string TimeOfWork
        {
            get => _buffTimeOfWork;
            set
            {
                _buffTimeOfWork = value;
                OnPropertyChanged(nameof(TimeOfWork));
            }
        }

        public string IPAddress
        {
            get => _buffIPAddress;
            set
            {
                _buffIPAddress = value;
                OnPropertyChanged(nameof(IPAddress));
            }
        }

        public DelegateCommand OperationSystemCommand { get; set; }
        public DelegateCommand MotherboardCommand { get; set; }
        public DelegateCommand CPUCommand { get; set; }
        public DelegateCommand RAMCommand { get; set; }
        public DelegateCommand GPUCommand { get; set; }
        public DelegateCommand TimeOfWorkCommand { get; set; }
        public DelegateCommand IPAddressCommand { get; set; }


        private void SetOperationSystem()
        {
            OperationSystem =  new InfoAboutSystemModel().GetOperationSystemInfo();  
        }
        private void SetMotherboard()
        {
            Motherboard = new InfoAboutSystemModel().GetMotherboardInfo();
        }
        private void SetCPU()
        {
            CPU = new InfoAboutSystemModel().GetCPUInfo();
        }
        private void SetRAM()
        {
            RAM = new InfoAboutSystemModel().GetRAMInfo();
        }
        private void SetGPU()
        {
            GPU = new InfoAboutSystemModel().GetGPUInfo();
        }
        private void SetTimeOfWork()
        {
            TimeOfWork = new InfoAboutSystemModel().GetTimeOfWorkInfo();
        }
        private void SetIPAddress()
        {
            IPAddress = new InfoAboutSystemModel().GetIPAddressInfo();
        }

        public InfoAboutSystemViewModel()
        {
            const string json_path = "info_about_system.json";

            OperationSystemCommand = new DelegateCommand(() => SetOperationSystem());
            MotherboardCommand = new DelegateCommand(() => SetMotherboard());    
            CPUCommand= new DelegateCommand(() => SetCPU());
            RAMCommand= new DelegateCommand(() => SetRAM());
            GPUCommand= new DelegateCommand(() => SetGPU());
            TimeOfWorkCommand=new DelegateCommand(() => SetTimeOfWork());
            IPAddressCommand = new DelegateCommand(() => SetIPAddress());
            
            if (File.Exists(json_path))
            {
                SysInfo sysinfo = JsonConvert.DeserializeObject<SysInfo>(File.ReadAllText(json_path));
                OperationSystem = sysinfo.OperationSystem;
                CPU = sysinfo.CPU;
                RAM = sysinfo.RAM;
                GPU = sysinfo.GPU;
                Motherboard= sysinfo.Motherboard;
                IPAddress = sysinfo.IPAddress;
                TimeOfWork = sysinfo.TimeOfWork;
            }
            else
            {
                new Task(() =>
                {
                    SetOperationSystem();
                    SetMotherboard();
                    SetCPU();
                    SetRAM();
                    SetGPU();
                    SetTimeOfWork();
                    SetIPAddress();

                    string json = JsonConvert.SerializeObject(this);
                    try { File.WriteAllText(json_path, json); }
                    catch { }
                }).Start();
            }
        }
    }
}
