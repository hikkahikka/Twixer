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





        public DelegateCommand CheckBoxDisableSecurityNotificationCommand { get; set; }
        public DelegateCommand CheckBoxDisableUACCommand { get; set; }
        public DelegateCommand CheckBoxDisableDefenderWindowsCommand { get; set; }
        public DelegateCommand CheckBoxDisableTaskManagerCommand { get; set; }

        //public DelegateCommand ButtonRSTRUICommand { get; set; }

        public void OnCheckBoxDisableSecurityNotificationPress()
        {         
            new SystemModel().DisableSecurityNotification(Convert.ToInt32(CheckedDisableSecurityNotification));
        }

        public void OnCheckBoxDisableDefenderWindowsPress()
        {
            new SystemModel().DisableDefenderWindows(Convert.ToInt32(CheckedDisableDefenderWindows));
        }

        public void OnCheckBoxDisableUACPress()
        {
            new SystemModel().DisableUAC(Convert.ToInt32(CheckedDisableUAC));
        }

        public void OnCheckBoxDisableTaskManagerPress()
        {
            new SystemModel().DisableTaskManager(Convert.ToInt32(CheckedDisableTaskManager));
        }

        //public void OnButtonRSTRUIPress()
        //{
        //    new SystemModel().CreateRSTRUI();
        //}

        public SystemViewModel()
        {
            CheckBoxDisableSecurityNotificationCommand = new DelegateCommand(() => OnCheckBoxDisableSecurityNotificationPress());
            CheckBoxDisableUACCommand = new DelegateCommand(() => OnCheckBoxDisableUACPress());
            CheckBoxDisableDefenderWindowsCommand = new DelegateCommand(() => OnCheckBoxDisableDefenderWindowsPress());
            CheckBoxDisableTaskManagerCommand = new DelegateCommand(() => OnCheckBoxDisableTaskManagerPress());
            //ButtonRSTRUICommand = new DelegateCommand(() => OnButtonRSTRUIPress());

        }

        
    }
}
