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

        private bool _buffCheckedDisableEventLogProcessing;
        private bool _buffCheckedDisableUpdates;
        private bool _buffCheckedDisableCollectionHandwrittenInput;

        public bool CheckedDisableMicrosoftTelemetry
        {
            get => _buffCheckedDisableMicrosoftTelemetry;
            set
            {
                _buffCheckedDisableMicrosoftTelemetry = value;
                OnPropertyChanged(nameof(CheckedDisableMicrosoftTelemetry));
                
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

        public DelegateCommand CheckBoxDisableMicrosoftTelemetryCommand { get; set; }
        public DelegateCommand CheckBoxDisableDeleteOneDriveCommand { get; set; }
        public DelegateCommand CheckBoxDisableEventLogProcessingCommand { get; set; }
        public DelegateCommand CheckBoxDisableUpdatesCommand { get; set; }
        public DelegateCommand CheckBoxDisableCollectionHandwrittenInputCommand { get; set; }

        public void OnCheckBoxDisableMicrosoftTelemetryPress()
        {
            new PrivacyModel().SetMicrosoftTelemetry(Convert.ToInt32(CheckedDisableMicrosoftTelemetry));

        }
        public void OnCheckBoxDisableEventLogProcessingPress()
        {
            new PrivacyModel().SetEventLogProcessing(Convert.ToInt32(CheckedDisableEventLogProcessing));

        }

        public void OnCheckBoxDisableUpdatesPress()
        {
            new PrivacyModel().SetUpdates(Convert.ToInt32(CheckedDisableUpdates));
        }

        public void OnCheckBoxDisableCollectionHandwrittenInputPress()
        {
            new PrivacyModel().SetCollectionHandwrittenInput(Convert.ToInt32(CheckedDisableCollectionHandwrittenInput));
        }

        private void SetPrivacyButtonsStatus()
        {
            PrivacyData data = new PrivacyData();


        }
        public PrivacyViewModel()
        {
            CheckBoxDisableMicrosoftTelemetryCommand = new DelegateCommand(() => OnCheckBoxDisableMicrosoftTelemetryPress());
            CheckBoxDisableEventLogProcessingCommand = new DelegateCommand(()=>OnCheckBoxDisableEventLogProcessingPress());
            CheckBoxDisableUpdatesCommand = new DelegateCommand(()=>OnCheckBoxDisableUpdatesPress());
            CheckBoxDisableCollectionHandwrittenInputCommand = new DelegateCommand(()=>OnCheckBoxDisableCollectionHandwrittenInputPress());
        }
        

    }
}
