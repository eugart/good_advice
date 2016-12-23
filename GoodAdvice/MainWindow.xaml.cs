using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoodAdvice
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.NavigationService.Navigate(new Uri("/HamburgerMenu/Main.xaml", UriKind.Relative));  
        }

        private void HamburgerMenuItem_Selected(object sender, RoutedEventArgs e)
        {
            ContentFrame.NavigationService.Navigate(new Uri("/HamburgerMenu/Main.xaml", UriKind.Relative));
        }
        private void HamburgerMenuItem_Selected_1(object sender, RoutedEventArgs e)
        {
            //если местоположение ещё не определено, то выводим всплывающую подсказу
            if (((App)Application.Current).cityName == "Не определено")
            {
                MessageBoxResult result = MessageBox.Show("Для более точного определения вашей геолокации убедитесь,\nчто в настройках вашего компьютера включена служба\nопределения местоположения.", "Служба определения местоположения Windows", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                switch (result)
                {
                    //если нажато ОК, то определяем местоположение
                    case MessageBoxResult.OK:
                        ContentFrame.NavigationService.Navigate(new Uri("/HamburgerMenu/CurrentPosition.xaml", UriKind.Relative));
                        break;
                    //иначе, устанавливаем флаг, означающий, что GPS модуль не включен
                    case MessageBoxResult.Cancel:
                        {
                            ((App)Application.Current).hasGPS = false;
                            ContentFrame.NavigationService.Navigate(new Uri("/HamburgerMenu/CurrentPosition.xaml", UriKind.Relative));
                        }
                        break;
                }
                
            }
            else
            {
                ContentFrame.NavigationService.Navigate(new Uri("/HamburgerMenu/CurrentPosition.xaml", UriKind.Relative));
            }
        }
        private void HamburgerMenuItem_Selected_2(object sender, RoutedEventArgs e)
        {
            ContentFrame.NavigationService.Navigate(new Uri("/HamburgerMenu/SearchCarwash.xaml", UriKind.Relative));
        }
        private void HamburgerMenuItem_Selected_3(object sender, RoutedEventArgs e)
        {
            ContentFrame.NavigationService.Navigate(new Uri("/HamburgerMenu/Settings.xaml", UriKind.Relative));
        }
        private void HamburgerMenuItem_Selected_4(object sender, RoutedEventArgs e)
        {
            ContentFrame.NavigationService.Navigate(new Uri("/HamburgerMenu/Encyclopedia.xaml", UriKind.Relative));
        }
        private void ContentFrame_ContentRendered(object sender, EventArgs e)
        {
            ContentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        //определяем текущий месяц. В зависимости от этого устанавливаем фоновый рисунок
        private void mainGrid_Initialized(object sender, EventArgs e)
        {
            HashSet<string> summer = new HashSet<string>();
            summer.Add("Июнь");
            summer.Add("Июль");
            summer.Add("Август");

            HashSet<string> autumn = new HashSet<string>();
            autumn.Add("Сентябрь");
            autumn.Add("Октябрь");
            autumn.Add("Ноябрь");

            HashSet<string> winter = new HashSet<string>();
            winter.Add("Декабрь");
            winter.Add("Январь");
            winter.Add("Февраль");

            HashSet<string> spring = new HashSet<string>();
            spring.Add("Март");
            spring.Add("Апрель");
            spring.Add("Май");

            string s = DateTime.Now.ToString("MMMM");

            if (winter.Contains(s))
            {
                string appDir = Environment.CurrentDirectory;
                ImageBrush imBr = new ImageBrush();
                imBr.Stretch = Stretch.UniformToFill;
                imBr.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri($@"{ appDir }..\..\..\..\image\background\bg1.png", UriKind.Relative));
                mainGrid.Background = imBr;
            }

            if (autumn.Contains(s))
            {
                string appDir = Environment.CurrentDirectory;
                ImageBrush imBr = new ImageBrush();
                imBr.Stretch = Stretch.UniformToFill;
                imBr.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri($@"{ appDir }..\..\..\..\image\background\bg2.png", UriKind.Relative));
                mainGrid.Background = imBr;
            }

            if (summer.Contains(s))
            {
                string appDir = Environment.CurrentDirectory;
                ImageBrush imBr = new ImageBrush();
                imBr.Stretch = Stretch.UniformToFill;
                imBr.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri($@"{ appDir }..\..\..\..\image\background\bg3.png", UriKind.Relative));
                mainGrid.Background = imBr;
            }

            if (spring.Contains(s))
            {
                string appDir = Environment.CurrentDirectory;
                ImageBrush imBr = new ImageBrush();
                imBr.Stretch = Stretch.UniformToFill;
                imBr.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri($@"{ appDir }..\..\..\..\image\background\bg4.png", UriKind.Relative));
                mainGrid.Background = imBr;
            }
        }
        //Пункт меню, который позволяет изменить местоположение
        private void HamburgerMenuItem_Selected_5(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = (MainWindow)App.Current.MainWindow;
            ((App)Application.Current).cityName = "change"; // задаем название города в "change"
            wnd.item2.IsSelected = true;
        }
    }
}
