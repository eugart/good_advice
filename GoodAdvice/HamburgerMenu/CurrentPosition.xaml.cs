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
using System.Globalization;
using System.Device.Location;
using System.Text.RegularExpressions;
using System.ServiceProcess;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.ComponentModel;
using System.Media;
using System.Net.NetworkInformation;

namespace GoodAdvice
{
    public partial class CurrentPosition : Page
    {   // создаём новый поток
        private readonly BackgroundWorker worker = new BackgroundWorker();
        bool hasLocation = false; // определяли ли мы до этого местоположение
        public CurrentPosition()
        {
            MainWindow wnd = (MainWindow)App.Current.MainWindow;
            wnd.hamMenu.Visibility = System.Windows.Visibility.Hidden; //прячем меню
            InitializeComponent();
            // запускаем поток
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        // начало работы потока
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // если пользователь нажал отмена на MessageBox
            if (((App)Application.Current).hasGPS == false)
            {
                ((App)Application.Current).cityName = "noGPS";
            }
            // если значение cityName = "не определено", то определяем
            if (((App)Application.Current).cityName == "Не определено")       
                ((App)Application.Current).cityName = SearchCurrentLocation().ToUpper();                 //определяем местоположение пользователя
            // иначе, значит мы уже определяли местоположение, устанавливаем флаг
            else if (((App)Application.Current).cityName != "noGPS")
            {
                hasLocation = true;
            }
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
        // завершение работы потока
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // базовый случай, когда мы определяли местоположение
            if (((App)Application.Current).cityName != "none" && ((App)Application.Current).cityName != "Не определено" && ((App)Application.Current).cityName != "noGPS" && hasLocation == false)
            {
                // спрашиваем пользователя, правильно ли определено местоположение
                textBox2.Content = $"Вы находитесь в городе {((App)Application.Current).cityName} ?";
                BG.Visibility = System.Windows.Visibility.Collapsed;
                PB.Visibility = System.Windows.Visibility.Collapsed;
                viewBox1.Visibility = System.Windows.Visibility.Collapsed;
                picture.Visibility = System.Windows.Visibility.Collapsed;
                // активируем WrapPanel и уничтожаем всё остальное
                WP.Visibility = System.Windows.Visibility.Visible;
                SystemSounds.Beep.Play(); // издаем системный звук
                hasLocation = true;
            }
            // случай когда местоположение уже определяли
            else if (hasLocation == true && ((App)Application.Current).cityName != "change")
            {
                MainWindow wnd = (MainWindow)App.Current.MainWindow;
                wnd.hamMenu.Visibility = System.Windows.Visibility.Visible;
                PB.Visibility = System.Windows.Visibility.Collapsed;
                viewBox1.Visibility = System.Windows.Visibility.Collapsed;
                picture.Visibility = System.Windows.Visibility.Collapsed;
                MessageBox.Show("Ваше местоположение уже определено!", "Ошибка #001", MessageBoxButton.OK, MessageBoxImage.Error);
                wnd.item1.IsSelected = true; // переходим на главную страницу
            }
            // случай, когда не получилось определить местоположение
            if (((App)Application.Current).cityName == "none")
            {
                 // просим пользователя задать местоположение вручную, если интернет соединение активно
                if (PingHost("www.yandex.ru"))
                {
                    MessageBox.Show("Неозможно определить местоположение!\nПроблемы соединения с сервером.\nВведите местоположение вручную.", "Ошибка #004", MessageBoxButton.OK, MessageBoxImage.Error);
                    ButtonClickNo();
                }
                else
                {
                    MessageBox.Show("Неозможно определить местоположение!\nПроверьте соединение с интернетом.", "Ошибка #003", MessageBoxButton.OK, MessageBoxImage.Error);
                    ((App)Application.Current).cityName = "Не определено";
                    MainWindow wnd = (MainWindow)App.Current.MainWindow;
                    wnd.hamMenu.Visibility = System.Windows.Visibility.Visible;
                    wnd.item1.IsSelected = true;
                }
            }
            // случай, когда пользователь захотел изменить местоположение
            if (((App)Application.Current).cityName == "change")
            {
                // просим пользователя задать местоположение вручную, если интернет соединение активно
                if (PingHost("www.yandex.ru"))
                {
                    ButtonClickNo();
                }
                else
                {
                    PB.Visibility = System.Windows.Visibility.Collapsed;
                    viewBox1.Visibility = System.Windows.Visibility.Collapsed;
                    picture.Visibility = System.Windows.Visibility.Collapsed;
                    MessageBox.Show("Неозможно изменить местоположение!\nПроверьте соединение с интернетом.", "Ошибка #005", MessageBoxButton.OK, MessageBoxImage.Error);
                    ((App)Application.Current).cityName = "Не определено";
                    MainWindow wnd = (MainWindow)App.Current.MainWindow;
                    wnd.hamMenu.Visibility = System.Windows.Visibility.Visible;
                    wnd.item1.IsSelected = true;
                }
            }
            // случай когда пользователь нажал "отмена" на MessageBox при первой попытке определения местоположения
            if (((App)Application.Current).cityName == "noGPS" && hasLocation == false)
            {
                ((App)Application.Current).cityName = "Не определено";
                ((App)Application.Current).hasGPS = true;
                MainWindow wnd = (MainWindow)App.Current.MainWindow;
                wnd.hamMenu.Visibility = System.Windows.Visibility.Visible;
                wnd.item1.IsSelected = true;
            }
        }
        //Навигация между страницами
        private void ContentFrame_ContentRendered(object sender, EventArgs e)
        {
            ContentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        //Определение местоположения
        private string SearchCurrentLocation()
        {
            List<double> coordinates =                          //хранит широту и долготу, если удалось определить местоположение
                                                                //хранит -999, ели местоположение не удалось определить
                SearchCurrentLocationViaGPS();                  //пытается определить координаты по GPS

            string cityName = "";

            if (coordinates[0] != -999)
            {
                try
                {
                    string longitude = coordinates[0].ToString().Replace(",", ".");
                    string latitude = coordinates[1].ToString().Replace(",", ".");
                    cityName =                                  //преобразует полученные координаты в название города                                  
                        GeocodeCoordinatesInTheNameOfTheCity("https://" + $"geocode-maps.yandex.ru/1.x/?geocode={longitude},{latitude}&kind=locality&results=1.");
                }
                catch
                {
                    coordinates.Clear();
                    coordinates.Add(-999);
                }
            }
            //Если не удалось определить местоположение по GPS, пробуем вычислить по IP
            if (coordinates[0] == -999)
            {
                try
                {
                    coordinates =                               //пытается определить координаты по IP
                        SearchCurrentLocationViaIP();
                    string longitude = coordinates[0].ToString().Replace(",", ".");
                    string latitude = coordinates[1].ToString().Replace(",", ".");
                    cityName =                                 //преобразует полученные координаты в название города
                        GeocodeCoordinatesInTheNameOfTheCity("https://" + $"geocode-maps.yandex.ru/1.x/?geocode={longitude},{latitude}&kind=locality&results=1.");
                }
                catch
                {
                    cityName = "none"; //возвращает "none" если не удалось определить местоположение
                }
            }
            return cityName;
        }
        //Поиск местоположения через GPS
        private List<double> SearchCurrentLocationViaGPS()
        {
            var watcher = new GeoCoordinateWatcher();                   //создаем объект типа GeoCoordinateWatcher
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            var coord = watcher.Position.Location;                      //пытаемся получить координаты
            List<double> answer = new List<double>();

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();                                          //начинаем отсчет
            //Стандартный GPS модуль компьютера может определить координаты местоположеня ни с разу, а только с некоторой попытке
            //поэтому пытаемся определить координаты в цикле в течении 6 секунд
            while (coord.IsUnknown == true)
            {
                coord = watcher.Position.Location;                      //пытаемся получить координаты
                TimeSpan ts = stopWatch.Elapsed;
                int temp = (int)ts.TotalMilliseconds;
                //Если прошло 6 секунд, то возвращаем -999 и пытаемся определить метоположение по IP
                if (temp >= 6000)
                {
                    answer.Add(-999);
                    return answer;
                }
            }

            stopWatch.Stop();
            //Иначе, возвращаем координаты
            answer.Add(coord.Longitude);
            answer.Add(coord.Latitude);
            return answer;
        }
        //Поиск местоположения через IP
        private List<double> SearchCurrentLocationViaIP()
        {
            List<double> answer = new List<double>();
            //Подключаемся к открытой базе
            var locationResponse = new WebClient().DownloadString("https://freegeoip.net/xml/");
            //Получаем результат в формате xml и достаем из него координаты в виде строк
            var responseXml = XDocument.Parse(locationResponse).Element("Response");
            string longitude = responseXml.Element("Longitude").Value;
            string latitude = responseXml.Element("Latitude").Value;
            longitude = longitude.Replace(".", ",");
            latitude = latitude.Replace(".", ",");
            //Преобразуем кординаты в тип double и возвращаем
            answer.Add(double.Parse(longitude));
            answer.Add(double.Parse(latitude));
            return answer;
        }
        //Геоодирование координат в название города
        private string GeocodeCoordinatesInTheNameOfTheCity(string reguest)
        {
            XmlDocument xd = new XmlDocument();
            //Отправляем запрос Яндекс.Геокодеру и загружаем ответ в виде xml
            xd.Load(reguest);
            //Начинаем проходить по тегам xml документа и считываем информацию
            XmlNode ymaps = xd.DocumentElement;
            //Тэг "Country"
            XmlNodeList GeoObjectTempCountry = xd.GetElementsByTagName("Country");
            string addressLine = "",
                   countryNameCode = "",
                   countryName = "",
                   administrativeAreaName = "",
                   localityName = "";
            foreach (XmlNode countryNode in GeoObjectTempCountry)
            {
                foreach (XmlNode childCountry in countryNode.ChildNodes)
                {
                    switch (childCountry.Name)
                    {
                        case "AddressLine":
                            addressLine = childCountry.FirstChild.InnerText;
                            break;
                        case "CountryNameCode":
                            countryNameCode = childCountry.FirstChild.InnerText;
                            break;
                        case "CountryName":
                            countryName = childCountry.FirstChild.InnerText;
                            break;
                    }
                }
                //Ребенок "AdministrativeArea"
                XmlNodeList GeoObjectTempAdministrativeArea = xd.GetElementsByTagName("AdministrativeArea");
                foreach (XmlNode areaNode in GeoObjectTempAdministrativeArea)
                {
                    foreach (XmlNode childAreaName in areaNode.ChildNodes)
                    {
                        switch (childAreaName.Name)
                        {
                            case "AdministrativeAreaName":
                                administrativeAreaName = childAreaName.FirstChild.InnerText;
                                break;
                        }
                    }
                }
                //Ребенок "Locality"
                XmlNodeList GeoObjectTempLocality = xd.GetElementsByTagName("Locality");
                foreach (XmlNode localityNode in GeoObjectTempLocality)
                {
                    foreach (XmlNode childLocalituName in localityNode.ChildNodes)
                    {
                        switch (childLocalituName.Name)
                        {
                            case "LocalityName":
                                localityName = childLocalituName.FirstChild.InnerText;
                                break;
                        }
                    }
                }
            }
            return localityName;
        }
        // пользователь согласился с местоположением, определенным программой
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = (MainWindow)App.Current.MainWindow;
            wnd.hamMenu.Visibility = System.Windows.Visibility.Visible;
            wnd.item1.IsSelected = true;
        }
        // пользователь не согласился с местоположением, определенным программой
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ButtonClickNo();
        }
        // задаем местоположение вручную
        private void ButtonClickNo()
        {
            textBox4.Focus(); // устанваливаем фоксу на textBox
            if (((App)Application.Current).cityName == "none" || ((App)Application.Current).cityName == "change")
            {
                // в этом случае, сначала унчтожаем все объекты и активиуем WrapPanel
                BG.Visibility = System.Windows.Visibility.Collapsed;
                PB.Visibility = System.Windows.Visibility.Collapsed;
                viewBox1.Visibility = System.Windows.Visibility.Collapsed;
                picture.Visibility = System.Windows.Visibility.Collapsed; 
                WP.Visibility = System.Windows.Visibility.Visible;
            }
            viewBox2.Visibility = System.Windows.Visibility.Hidden;
            but1.Visibility = System.Windows.Visibility.Hidden;
            but2.Visibility = System.Windows.Visibility.Hidden;
            viewBox5.Visibility = System.Windows.Visibility.Visible;
            viewBox6.Visibility = System.Windows.Visibility.Visible;
        }
        // при нажатии на textBox, очищаем его содержимое и показываем кнопку
        private void textBox4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBox4.Clear();
        }
        // обрабатываем кнопку "Подтверить"
        private void but3_Click(object sender, RoutedEventArgs e)
        {
            
            ((App)Application.Current).cityName = textBox4.Text.ToUpper();
            MainWindow wnd = (MainWindow)App.Current.MainWindow;
            wnd.hamMenu.Visibility = System.Windows.Visibility.Visible;
            wnd.item1.IsSelected = true;
        }
        //обратываем поле для ручного ввода названия города
        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            //если введеное название есть в словаре, то показываем зеленую галочке и кнопку "подтвердить"
            //вызываем метод "CheckCitiesName", который и проверяет наличие города в базеы
            if (((App)Application.Current).hasCityName.CheckCitiesName(textBox4.Text.ToUpper()))
            {
                viewBox7.Visibility = System.Windows.Visibility.Visible;
                picture3.Visibility = System.Windows.Visibility.Hidden;
                picture2.Visibility = System.Windows.Visibility.Visible;
            }
            //показываем красный крестик и прячем кнопку
            else
            {
                if (viewBox7 != null)
                    viewBox7.Visibility = System.Windows.Visibility.Hidden;
                if (picture2 != null)
                    picture2.Visibility = System.Windows.Visibility.Hidden;
                if (picture3 != null)
                    picture3.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
    //Описываем ProgessBar для изображения процесса загрузки
    public class RoundProgressPathConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values?.Contains(DependencyProperty.UnsetValue) != false)
                return DependencyProperty.UnsetValue;

            var v = (double)values[0]; // значение слайдера
            var min = (double)values[1]; // минимальное значение
            var max = (double)values[2]; // максимальное

            var ratio = (v - min) / (max - min); // какую долю окружности закрашивать
            var isFull = ratio >= 1; // для случая полной окружности нужна особая обработка
            var angleRadians = 2 * Math.PI * ratio;
            var angleDegrees = 360 * ratio;

            // внешний радиус примем за 1, растянем в XAML'е.
            var outerR = 1;
            // как параметр передадим долю радиуса, которую занимает внутренняя часть
            var innerR =
                  System.Convert.ToDouble(parameter, CultureInfo.InvariantCulture) * outerR;
            // вспомогательные штуки: вектор направления вверх
            var vector1 = new Vector(0, -1);
            // ... и на конечную точку дуги
            var vector2 = new Vector(Math.Sin(angleRadians), -Math.Cos(angleRadians));
            var center = new Point();

            var geo = new StreamGeometry();
            geo.FillRule = FillRule.EvenOdd;

            using (var ctx = geo.Open())
            {
                Size outerSize = new Size(outerR, outerR),
                     innerSize = new Size(innerR, innerR);

                if (!isFull)
                {
                    Point p1 = center + vector1 * outerR, p2 = center + vector2 * outerR,
                          p3 = center + vector2 * innerR, p4 = center + vector1 * innerR;

                    ctx.BeginFigure(p1, isFilled: true, isClosed: true);
                    ctx.ArcTo(p2, outerSize, angleDegrees, isLargeArc: angleDegrees > 180,
                        sweepDirection: SweepDirection.Clockwise, isStroked: true,
                        isSmoothJoin: false);
                    ctx.LineTo(p3, isStroked: true, isSmoothJoin: false);
                    ctx.ArcTo(p4, innerSize, -angleDegrees, isLargeArc: angleDegrees > 180,
                        sweepDirection: SweepDirection.Counterclockwise, isStroked: true,
                        isSmoothJoin: false);

                    Point diag1 = new Point(-outerR, -outerR),
                          diag2 = new Point(outerR, outerR);
                    ctx.BeginFigure(diag1, isFilled: false, isClosed: false);
                    ctx.LineTo(diag2, isStroked: false, isSmoothJoin: false);
                }
                else
                {
                    Point p1 = center + vector1 * outerR, p2 = center - vector1 * outerR,
                          p3 = center + vector1 * innerR, p4 = center - vector1 * innerR;

                    ctx.BeginFigure(p1, isFilled: true, isClosed: true);
                    ctx.ArcTo(p2, outerSize, 180, isLargeArc: false,
                        sweepDirection: SweepDirection.Clockwise, isStroked: true,
                        isSmoothJoin: false);
                    ctx.ArcTo(p1, outerSize, 180, isLargeArc: false,
                        sweepDirection: SweepDirection.Clockwise, isStroked: true,
                        isSmoothJoin: false);
                    ctx.BeginFigure(p3, isFilled: true, isClosed: true);
                    ctx.ArcTo(p4, innerSize, 180, isLargeArc: false,
                        sweepDirection: SweepDirection.Clockwise, isStroked: true,
                        isSmoothJoin: false);
                    ctx.ArcTo(p3, innerSize, 180, isLargeArc: false,
                        sweepDirection: SweepDirection.Clockwise, isStroked: true,
                        isSmoothJoin: false);
                }
            }

            geo.Freeze();
            return geo;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }
}
