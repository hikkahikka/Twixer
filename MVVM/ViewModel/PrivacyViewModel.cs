using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twixer.MVVM.Model;

namespace Twixer.MVVM.ViewModel
{
    class PrivacyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }




        private bool _buffCheckedDisableMicrosoftTelemetry;
        private bool _buffCheckedDisableDeteleOneDrive;
        private bool _buffIsEnableDeleteOneDrive = true;
        public bool IsEnableDeteleOneDrive
        {

            get => _buffIsEnableDeleteOneDrive;
            set
            {
                _buffIsEnableDeleteOneDrive = value;
                OnPropertyChanged(nameof(IsEnableDeteleOneDrive));
            }

        }
        
        public bool CheckedDisableMicrosoftTelemetry
        {
            get => _buffCheckedDisableMicrosoftTelemetry;
            set
            {
                _buffCheckedDisableMicrosoftTelemetry = value;
                OnPropertyChanged(nameof(CheckedDisableMicrosoftTelemetry));
                
            }
        }

        public bool CheckedDisableDeleteOneDrive
        {
            get => _buffCheckedDisableDeteleOneDrive;
            set
            {
                _buffCheckedDisableDeteleOneDrive= value;
                OnPropertyChanged(nameof(CheckedDisableDeleteOneDrive));
            }
        }





        public DelegateCommand CheckBoxDisableMicrosoftTelemetryCommand { get; set; }
        public DelegateCommand CheckBoxDisableDeleteOneDriveCommand { get; set; }





        public void OnCheckBoxDisableMicrosoftTelemetryPress()
        {
            new PrivacyModel().DisableMicrosoftTelemetry(Convert.ToInt32(CheckedDisableMicrosoftTelemetry));

        }


        public void OnCheckBoxDisableDeleteOneDrivePress()
        {
            new PrivacyModel().DisableDeleteOneDrive();
            IsEnableDeteleOneDrive=false;
        }






        public PrivacyViewModel()
        {
            CheckBoxDisableMicrosoftTelemetryCommand = new DelegateCommand(() => OnCheckBoxDisableMicrosoftTelemetryPress());
            CheckBoxDisableDeleteOneDriveCommand = new DelegateCommand(() => OnCheckBoxDisableDeleteOneDrivePress());


        }


    }
}
