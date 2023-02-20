using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;

using Twixer.MVVM.Model;

namespace Twixer.MVVM.ViewModel
{
    public class InfoAboutSystemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string _buff;
        public string OperationSystem
        {
            get => _buff;
            set
            {
                _buff = value;
                OnPropertyChanged(nameof(OperationSystem));
            }
        }


        public DelegateCommand OperationSystemButtonCommand { get; set; }
        private void OnOperationSystemButtonPress()
        {
            //при нажатии меняет текст
            OperationSystem = "ASAS";
            //MessageBox.Show(TextString2);
            
        }

        public InfoAboutSystemViewModel()
        {
           

            OperationSystemButtonCommand = new DelegateCommand(() => OnOperationSystemButtonPress());
            OperationSystem = "start text ";
            OnOperationSystemButtonPress();
        } 






    }
}
