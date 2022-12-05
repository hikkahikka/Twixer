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

        public RelayCommand InfoAboutSystemViewCommand { get; set; }

        public RelayCommand SystemViewCommand { get; set; }

        public RelayCommand OnCloseButtonClickCommand { get; set; }

        public RelayCommand OnTurnButtonClickCommand { get; set; }


        public PrivacyViewModel PrivacyVM { get; set; }

        public InfoAboutSystemViewModel InfoAboutSystemVM { get; set; }

        public SystemViewModel SystemVM { get; set; }

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
            SystemVM=new SystemViewModel();

            CurrentView = PrivacyVM;
            
            PrivacyViewCommand = new RelayCommand(o =>
            {
                CurrentView = PrivacyVM;
            });

            SystemViewCommand = new RelayCommand(o =>
            {
                CurrentView=SystemVM;
            });

            InfoAboutSystemViewCommand = new RelayCommand(o =>
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
