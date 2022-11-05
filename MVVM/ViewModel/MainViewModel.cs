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
        public PrivacyViewModel PrivacyVM { get; set; }

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
            CurrentView = PrivacyVM;
        }
    }
}
