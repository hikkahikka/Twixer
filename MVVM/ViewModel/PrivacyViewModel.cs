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
        private bool _buffCheckedDisableEventLogProcessing;
        private bool _buffCheckedDisableUpdates;
        private bool _buffCheckedDisableCollectionHandwrittenInput;
        
        //private bool _buffCheckedDisableDownloadApps;



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

        public bool CheckedDisableEventLogProcessing
        {
            get => _buffCheckedDisableEventLogProcessing;
            set
            {
                _buffCheckedDisableEventLogProcessing = value;
                OnPropertyChanged(nameof(CheckedDisableEventLogProcessing));
            }
        }
        public bool CheckedDisableUpdates
        {
            get => _buffCheckedDisableUpdates;
            set
            {
                _buffCheckedDisableUpdates = value;
                OnPropertyChanged(nameof(CheckedDisableUpdates));
            }
        }

        public bool CheckedDisableCollectionHandwrittenInput
        {
            get=> _buffCheckedDisableCollectionHandwrittenInput;
            set
            {
                _buffCheckedDisableCollectionHandwrittenInput = value;
                OnPropertyChanged(nameof(CheckedDisableCollectionHandwrittenInput));
            }
        }



        //public bool CheckedDisableDownloadApps
        //{
        //    get => _buffCheckedDisableDownloadApps;

        //    set
        //    {
        //        _buffCheckedDisableDownloadApps = value;
        //        OnPropertyChanged(nameof(_buffCheckedDisableDownloadApps));
        //    }
        //}


        public DelegateCommand CheckBoxDisableMicrosoftTelemetryCommand { get; set; }
        public DelegateCommand CheckBoxDisableDeleteOneDriveCommand { get; set; }
        public DelegateCommand CheckBoxDisableEventLogProcessingCommand { get; set; }
        public DelegateCommand CheckBoxDisableUpdatesCommand { get; set; }
        public DelegateCommand CheckBoxDisableCollectionHandwrittenInputCommand { get; set; }
       
       // public DelegateCommand CheckBoxDisableDownloadAppsCommand { get; set; }



        public void OnCheckBoxDisableMicrosoftTelemetryPress()
        {
            new PrivacyModel().DisableMicrosoftTelemetry(Convert.ToInt32(CheckedDisableMicrosoftTelemetry));

        }

        public void OnCheckBoxDisableDeleteOneDrivePress()
        {
            new PrivacyModel().DisableDeleteOneDrive();
            IsEnableDeteleOneDrive=false;
        }

        public void OnCheckBoxDisableEventLogProcessingPress()
        {
            new PrivacyModel().DisableEventLogProcessing(Convert.ToInt32(CheckedDisableEventLogProcessing));

        }

        public void OnCheckBoxDisableUpdatesPress()
        {
            new PrivacyModel().DisableUpdates(Convert.ToInt32(CheckedDisableUpdates));
        }

        public void OnCheckBoxDisableCollectionHandwrittenInputPress()
        {
            new PrivacyModel().DisableCollectionHandwrittenInput(Convert.ToInt32(CheckedDisableCollectionHandwrittenInput));
        }

        

        //public void OnCheckBoxDisableDownloadAppsPress()
        //{
        //    new PrivacyModel().DisableDownloadApps(Convert.ToInt32(CheckedDisableDownloadApps));
        //}

        public PrivacyViewModel()
        {
            CheckBoxDisableMicrosoftTelemetryCommand = new DelegateCommand(() => OnCheckBoxDisableMicrosoftTelemetryPress());
            CheckBoxDisableDeleteOneDriveCommand = new DelegateCommand(() => OnCheckBoxDisableDeleteOneDrivePress());
            CheckBoxDisableEventLogProcessingCommand = new DelegateCommand(()=>OnCheckBoxDisableEventLogProcessingPress());
            CheckBoxDisableUpdatesCommand = new DelegateCommand(()=>OnCheckBoxDisableUpdatesPress());
            CheckBoxDisableCollectionHandwrittenInputCommand = new DelegateCommand(()=>OnCheckBoxDisableCollectionHandwrittenInputPress());
        }
        

    }
}
