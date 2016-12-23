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

namespace GoodAdvice
{
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void ContentFrame_ContentRendered(object sender, EventArgs e)
        {
            ContentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void CheckBox_Initialized(object sender, EventArgs e)
        {
            if (!((App)Application.Current).haschb1)
                chb1.IsChecked = false;
            if (((App)Application.Current).haschb1)
                chb1.IsChecked = true;
        }
        private void chb1_Checked(object sender, RoutedEventArgs e)
        {
            if (!(bool)chb1.IsChecked)
                ((App)Application.Current).haschb1 = false;
            if ((bool)chb1.IsChecked)
                ((App)Application.Current).haschb1 = true;
        }
    }
}
