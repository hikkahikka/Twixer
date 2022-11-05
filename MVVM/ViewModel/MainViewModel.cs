using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twixer.Core;

namespace Twixer.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {

        public RelayCommand PrivacyViewCommand { get; set; }
        public RelayCommand InterfaceViewCommand { get; set; }


        public PrivacyViewModel PrivacyVM { get; set; }
        public InterfaceViewModel InterfaceVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            PrivacyVM = new PrivacyViewModel();
            InterfaceVM = new InterfaceViewModel();
            CurrentView = PrivacyVM;

            PrivacyViewCommand = new RelayCommand(o =>
            {
                CurrentView = PrivacyVM;
            });

            InterfaceViewCommand = new RelayCommand(o =>
            {
                CurrentView = InterfaceVM;
            });
        }
    }
}
