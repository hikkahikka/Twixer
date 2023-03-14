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

        private bool _buffChekedDisableSecurityNotification;

        private bool _buffChekedDisableUAC;


        public bool ChekedDisableSecurityNotification
        {
            get => _buffChekedDisableSecurityNotification;
            set
            {
                _buffChekedDisableSecurityNotification = value;
                OnPropertyChanged(nameof(ChekedDisableSecurityNotification));
            }
        }

        public bool ChekedDisableUAC
        {
            get=> _buffChekedDisableUAC;
            set
            {
                _buffChekedDisableUAC = value;
                OnPropertyChanged(nameof(_buffChekedDisableUAC));
            }
        }








        public DelegateCommand CheckBoxDisableSecurityNotificationCommand { get; set; }
        public DelegateCommand CheckBoxDisableUACCommand { get; set; }



        public void OnCheckBoxDisableSecurityNotificationPress()
        {         
            new SystemModel().DisableSecurityNotification(Convert.ToInt32(ChekedDisableSecurityNotification));
        }

        public void OnCheckBoxDisableUACPress()
        {
            new SystemModel().DisableUAC(Convert.ToInt32(ChekedDisableUAC));
        }



        public SystemViewModel()
        {
            CheckBoxDisableSecurityNotificationCommand = new DelegateCommand(() => OnCheckBoxDisableSecurityNotificationPress());
            CheckBoxDisableUACCommand = new DelegateCommand(() => OnCheckBoxDisableUACPress());
        }

        
    }
}
