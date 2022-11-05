using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Twixer.Core;

namespace Twixer.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {

        public RelayCommand PrivacyViewCommand { get; set; }

        public RelayCommand InfoAboutSystemCommand { get; set; }

        public RelayCommand OnCloseButtonClickCommand { get; set; }

        public RelayCommand OnTurnButtonClickCommand { get; set; }


        public PrivacyViewModel PrivacyVM { get; set; }

        public InfoAboutSystemViewModel InfoAboutSystemVM { get; set; }

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
            InfoAboutSystemVM = new InfoAboutSystemViewModel();
            CurrentView = PrivacyVM;
            
            PrivacyViewCommand = new RelayCommand(o =>
            {
                CurrentView = PrivacyVM;
            });

            InfoAboutSystemCommand = new RelayCommand(o =>
            {
                CurrentView = InfoAboutSystemVM;
            });


            OnCloseButtonClickCommand = new RelayCommand(o => Application.Current.Shutdown());
            OnTurnButtonClickCommand = new RelayCommand(o => {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
                });

        }
        
    }
}
