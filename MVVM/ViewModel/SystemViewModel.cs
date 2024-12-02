using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;

using Twixer.MVVM.Model;
using System.Windows;
using System.Windows.Controls;

namespace Twixer.MVVM.ViewModel
{
    class SystemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private bool _buffCheckedDisableSecurityNotification;
        private bool _buffCheckedDisableDefenderWindows;
        private bool _buffCheckedDisableUAC;
        private bool _buffCheckedDisableTaskManager;
        private bool _buffCheckedDisableMemoryDiagnostics;
        private bool _buffCheckedDisableCortana;
        private bool _buffCheckedAddCache;
        


        public bool CheckedDisableSecurityNotification
        {
            get => _buffCheckedDisableSecurityNotification;
            set
            {
                _buffCheckedDisableSecurityNotification = value;
                OnPropertyChanged(nameof(CheckedDisableSecurityNotification));
            }
        }

        public bool CheckedDisableDefenderWindows
        {
            get => _buffCheckedDisableDefenderWindows;
            set
            {
                _buffCheckedDisableDefenderWindows = value;
                OnPropertyChanged(nameof(CheckedDisableDefenderWindows));

            }
        }

        public bool CheckedDisableUAC
        {
            get=> _buffCheckedDisableUAC;
            set
            {
                _buffCheckedDisableUAC = value;
                OnPropertyChanged(nameof(CheckedDisableUAC));
            }
        }

        public bool CheckedDisableTaskManager
        {
            get => _buffCheckedDisableTaskManager;
            set
            {
                _buffCheckedDisableTaskManager = value;
                OnPropertyChanged(nameof(CheckedDisableTaskManager));
            }
        }

        public bool CheckedDisableMemoryDiagnostics
        {
            get => _buffCheckedDisableMemoryDiagnostics;
            set
            {
                _buffCheckedDisableMemoryDiagnostics = value;
                OnPropertyChanged(nameof(CheckedDisableMemoryDiagnostics));
            }
        }

        public bool CheckedDisableCortana
        {
            get => _buffCheckedDisableCortana;
            set
            {
                _buffCheckedDisableCortana = value;
                OnPropertyChanged(nameof(CheckedDisableCortana));
            }
        }

        public bool CheckedAddCache
        {
            get => _buffCheckedAddCache;
            set
            {
                _buffCheckedAddCache = value;
                OnPropertyChanged(nameof(CheckedAddCache));
            }
        }

       

        public DelegateCommand CheckBoxDisableSecurityNotificationCommand { get; set; }
        public DelegateCommand CheckBoxDisableUACCommand { get; set; }
        public DelegateCommand CheckBoxDisableDefenderWindowsCommand { get; set; }
        public DelegateCommand CheckBoxDisableTaskManagerCommand { get; set; }
        public DelegateCommand CheckBoxDisableMemoryDiagnosticsCommand { get; set; }
        public DelegateCommand CheckBoxDisableCortanaCommand { get; set; }
        public DelegateCommand CheckBoxAddCacheCommand { get; set; }

       


        public void OnCheckBoxDisableSecurityNotificationPress()
        {         
            new SystemModel().SetSecurityNotification(Convert.ToInt32(CheckedDisableSecurityNotification));
        }

        public void OnCheckBoxDisableDefenderWindowsPress()
        {
            new SystemModel().SetDefenderWindows(Convert.ToInt32(CheckedDisableDefenderWindows));
        }

        public void OnCheckBoxDisableUACPress()
        {
            new SystemModel().SetUAC(Convert.ToInt32(CheckedDisableUAC));
        }

        public void OnCheckBoxDisableTaskManagerPress()
        {
            new SystemModel().SetTaskManager(Convert.ToInt32(CheckedDisableTaskManager));
        }

        public void OnCheckBoxDisableMemoryDiagnosticsPress()
        {
            new SystemModel().SetMemoryDiagnostics(Convert.ToInt32(CheckedDisableMemoryDiagnostics));
        }

        public void OnCheckBoxDisableCortanaPress()
        {
            new SystemModel().SetCortana(Convert.ToInt32(CheckedDisableCortana));
        }

        public void OnCheckBoxAddCachePress()
        {
            new SystemModel().SetCache(Convert.ToInt32(CheckedAddCache));
        }
        private void SetSystemButtonsStatus()
        {
            SystemData data = new SystemModel().GetSystemData();
            CheckedDisableSecurityNotification = data.StatusSecurityNotification;
            CheckedDisableDefenderWindows = data.StatusDefenderWindows;
            CheckedDisableUAC = data.StatusUAC;
            CheckedDisableTaskManager = data.StatusTaskManager;
            CheckedDisableMemoryDiagnostics = data.StatusMemoryDiagnostics;
            CheckedDisableCortana = data.StatusCortana;
            CheckedAddCache = data.StatusCache;

        }


        public SystemViewModel()
        {
            SetSystemButtonsStatus();
            CheckBoxDisableSecurityNotificationCommand = new DelegateCommand(() => OnCheckBoxDisableSecurityNotificationPress());
            CheckBoxDisableUACCommand = new DelegateCommand(() => OnCheckBoxDisableUACPress());
            CheckBoxDisableDefenderWindowsCommand = new DelegateCommand(() => OnCheckBoxDisableDefenderWindowsPress());
            CheckBoxDisableTaskManagerCommand = new DelegateCommand(() => OnCheckBoxDisableTaskManagerPress());
            CheckBoxDisableMemoryDiagnosticsCommand = new DelegateCommand(() => OnCheckBoxDisableMemoryDiagnosticsPress());
            CheckBoxDisableCortanaCommand = new DelegateCommand(() => OnCheckBoxDisableCortanaPress()); 
            CheckBoxAddCacheCommand = new DelegateCommand(() => OnCheckBoxAddCachePress());
            

        }


    }
}
