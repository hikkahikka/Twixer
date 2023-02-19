using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Prism;
using Prism.Commands;


namespace Twixer.MVVM.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {

        public DelegateCommand PrivacyViewCommand { get; set; }

        public DelegateCommand InfoAboutSystemViewCommand { get; set; }

        public DelegateCommand SystemViewCommand { get; set; }

        public DelegateCommand DefoltAppsCommand { get; set; }

        public DelegateCommand OnCloseButtonClickCommand { get; set; }

        public DelegateCommand OnTurnButtonClickCommand { get; set; }


        public DefoltAppsViewModel DefoltAppsVM { get; set; }
        public PrivacyViewModel PrivacyVM { get; set; }

        public InfoAboutSystemViewModel InfoAboutSystemVM { get; set; }

        public SystemViewModel SystemVM { get; set; }

        private object _currentView;

        public event PropertyChangedEventHandler PropertyChanged;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged(null);
            }
        }

        private void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public MainViewModel()
        {
            PrivacyVM = new PrivacyViewModel();
            InfoAboutSystemVM = new InfoAboutSystemViewModel();
            SystemVM=new SystemViewModel();
            DefoltAppsVM = new DefoltAppsViewModel();

            CurrentView = PrivacyVM;
            
            PrivacyViewCommand = new DelegateCommand(() => CurrentView = PrivacyVM);

            SystemViewCommand = new DelegateCommand(() => CurrentView = SystemVM);

            InfoAboutSystemViewCommand = new DelegateCommand(() => CurrentView = InfoAboutSystemVM);

            DefoltAppsCommand = new DelegateCommand(() => CurrentView = DefoltAppsVM);

            OnCloseButtonClickCommand = new DelegateCommand(() => Application.Current.Shutdown());
            OnTurnButtonClickCommand = new DelegateCommand(() => Application.Current.MainWindow.WindowState = WindowState.Minimized);

        }
        
    }
}
