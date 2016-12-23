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
using System.Device.Location;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace GoodAdvice
{
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }
        // проверка интернет соединения
        private static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }
        private void ContentFrame_ContentRendered(object sender, EventArgs e)
        {
            ContentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        // Выводим начальное местоположение, считанное из файла
        private void label2_Initialized(object sender, EventArgs e)
        {
            label2.Content = ((App)Application.Current).cityName;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //если местоположение не определено, то выводим соответствующее сообщение
            if (((App)Application.Current).cityName == "Не определено")
            {
                MessageBox.Show("Для начала работы приложению необходимо знать ваше\nместоположение. Чтобы определить местоположение,\nперейдите в меню программы.", "Местоположение не определено", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Для более точного определения вашей геолокации убедитесь,\nчто в настройках вашего компьютера включена служба\nопределения местоположения.", "Служба определения местоположения Windows", MessageBoxButton.OK, MessageBoxImage.Information);
                textBlock1.Text = "А вот и меню\n↓↓↓";
                pLink.IsOpen = true; // запускаем всплывающее окно
            }
            else
            {
                Prediction prediction = new Prediction(((App)Application.Current).cityName);
                KeyValuePair<string, int> ans = prediction.Advice();
                if (ans.Value < 3 || ans.Value > 4)
                    AdviceText.Text = ans.Key;
                else
                    AdviceText.Text = $"{ans.Key}{ans.Value} дня ездить чистым.";

                Location.Visibility = Visibility.Hidden;
                Info.Visibility = Visibility.Hidden;
                Wheather.Visibility = Visibility.Hidden;
                main.Background = Brushes.Black;
                main.Opacity = 0.85;
                Advice.IsOpen = true;
            }
        }
        //при загруке страницы, если определено местоположение, запрашиваем проноз погоды
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).cityName != "Не определено")
            {
                try
                {
                    //создаём экземпляр класса, содержащего словарь
                    ZIPCodeBYCityName tempFile = new ZIPCodeBYCityName();
                    //заполяем его
                    tempFile.FillDictionary();
                    var xmlDataProvider = (XmlDataProvider)this.Wheather.Resources["rss"];
                    //получаем zip code для текущего города
                    string temp = tempFile.SearchZIPCodeByCityName(((App)Application.Current).cityName).ToString();
                    //отправляем запрос
                    xmlDataProvider.Source = new Uri("http://" + $@"informer.gismeteo.ua/rss/{temp}.xml", UriKind.RelativeOrAbsolute);
                    Wheather.Visibility = System.Windows.Visibility.Visible;
                    viewbox1.Visibility = System.Windows.Visibility.Visible;
                }
                catch
                {
                    //если при отправке запроса или получении zip code возникло исключение, выводим сообщение о том, что прогноз погоды не доступен
                    Wheather.Visibility = System.Windows.Visibility.Visible;
                    viewbox2.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void Advice_Closed(object sender, EventArgs e)
        {
            main.Background = Brushes.Transparent;
            main.Opacity = 1;
            Location.Visibility = Visibility.Visible;
            Info.Visibility = Visibility.Visible;
            Wheather.Visibility = Visibility.Visible;
        }
    }
}
