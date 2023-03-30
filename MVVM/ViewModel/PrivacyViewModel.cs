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





        public bool CheckedDisableMicrosoftTelemetry
        {
            get => _buffCheckedDisableMicrosoftTelemetry;
            set
            {
                _buffCheckedDisableMicrosoftTelemetry = value;
                OnPropertyChanged(nameof(CheckedDisableMicrosoftTelemetry));
            }
        }






        public DelegateCommand CheckBoxDisableMicrosoftTelemetryCommand { get; set; }








        public void OnCheckBoxDisableMicrosoftTelemetryPress()
        {
            new PrivacyModel().DisableMicrosoftTelemetry(Convert.ToInt32(CheckedDisableMicrosoftTelemetry));
        }









        public PrivacyViewModel()
        {
            CheckBoxDisableMicrosoftTelemetryCommand = new DelegateCommand(() => OnCheckBoxDisableMicrosoftTelemetryPress());
            

        }


    }
}
