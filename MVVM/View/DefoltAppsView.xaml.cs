using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Twixer.MVVM.ViewModel;

namespace Twixer.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для InterfaceView.xaml
    /// </summary>
    public partial class DefoltAppsView : UserControl
    {
        public DefoltAppsView()
        {
            InitializeComponent();
            DataContext = new DefoltAppsViewModel();
        }
    }
}
