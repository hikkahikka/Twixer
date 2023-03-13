using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;

using Twixer.MVVM.Model;

namespace Twixer.MVVM.ViewModel
{
    public class InfoAboutSystemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



        private string _buffOperationSystem;
        private string _buffMotherboard;
        private string _buffCPU;
        private string _buffRAM;
        private string _buffGPU;
        private string _buffTimeOfWork;


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



        public DelegateCommand GetOperationSystemCommand { get; set; }
        public DelegateCommand GetMotherboardCommand { get; set; }
        public DelegateCommand GetCPUCommand { get; set; }
        public DelegateCommand GetRAMCommand { get; set; }
        public DelegateCommand GetGPUCommand { get; set; }
        public DelegateCommand GetTimeOfWorkCommand { get; set; }


        private void GetOperationSystem()
        {
            
            OperationSystem =  new InfoAboutSystemModel().GetOperationSystemInfo();  

        }
        private void GetMotherboard()
        {

            Motherboard = new InfoAboutSystemModel().GetMotherboardInfo();

        }
        private void GetCPU()
        {
            CPU = new InfoAboutSystemModel().GetCPUInfo();
        }
        private void GetRAM()
        {
            RAM = new InfoAboutSystemModel().GetRAMInfo();
        }
        private void GetGPU()
        {
            GPU = new InfoAboutSystemModel().GetGPUInfo();
        }
        private void GetTimeOfWork()
        {
            TimeOfWork = new InfoAboutSystemModel().GetTimeOfWorkInfo();
        }

        public InfoAboutSystemViewModel()
        {


            GetOperationSystemCommand = new DelegateCommand(() => GetOperationSystem());
            GetMotherboardCommand = new DelegateCommand(() => GetMotherboard());    
            GetCPUCommand= new DelegateCommand(() => GetCPU());
            GetRAMCommand= new DelegateCommand(() => GetRAM());
            GetGPUCommand= new DelegateCommand(() => GetGPU());
            GetTimeOfWorkCommand=new DelegateCommand(() => GetTimeOfWork());


            GetOperationSystem();
            GetMotherboard();
            GetCPU();
            GetRAM();
            GetGPU();
            GetTimeOfWork();

        } 


    }
}
