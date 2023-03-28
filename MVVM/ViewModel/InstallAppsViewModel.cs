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
    class InstallAppsViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public DelegateCommand PascalInstallCommand { get; set; }
        public DelegateCommand PythonInstallCommand { get; set; }
        public DelegateCommand KuMirInstallCommand { get; set; }
        public DelegateCommand KompasInstallCommand { get; set; }
        public DelegateCommand ScratchInstallCommand { get; set; }





        public void OnPascalInstallButtonPress()
        {
            new InstallAppsModel().InstallPascal();
        }

        public void OnPythonInstallButtonPress()
        {
            new InstallAppsModel().InstallPython();
        }

        public void OnKuMirInstallButtonPress()
        {
            new InstallAppsModel().InstallKuMir();
        }

        public void OnKompasInstallButtonPress()
        {
            new InstallAppsModel().InstallKompas();
        }

        public void OnScratchInstallButtonPress()
        {
            new InstallAppsModel().InstallScratch();
        }

        public InstallAppsViewModel()
        {
            PascalInstallCommand = new DelegateCommand(() => OnPascalInstallButtonPress());
            PythonInstallCommand = new DelegateCommand(() => OnPythonInstallButtonPress());
            KuMirInstallCommand = new DelegateCommand(() => OnKuMirInstallButtonPress());
            KompasInstallCommand = new DelegateCommand(() => OnKompasInstallButtonPress());
            ScratchInstallCommand = new DelegateCommand(() => OnScratchInstallButtonPress());


        }


    }
}
