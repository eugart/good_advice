using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Text.RegularExpressions;

namespace GoodAdvice
{
    public partial class App : Application
    {
        public bool hasLoadedSearchedCarWash = false;           // проверка загрузки страницы поиска автомойки
        public string cityName = "Не определено";               // текущее местоположение
        public bool haschb1 = false;                            // меняется состояние при изменении настроек
        public bool hasGPS = true;                              // меняет состояние, если пользователь при первом определении местоположения, 
                                                                // на вылетевшем MessageBox нажмет "отмена"
        public CheckCityName hasCityName = new CheckCityName(); // экземпляр класса для проверки наличия города с заданным именем
        // выход из приложения
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ILog initialCityName = new TextFileLogger("initialCityName.ini");       // создается или открывается файл, которой хранит текущее местоположение
            ILog settings = new TextFileLogger("settings.ini");                     // создается или открывается логгер
            
            if (haschb1)
            {
                if (((App)Application.Current).hasCityName.CheckCitiesName(cityName))
                {
                    initialCityName.Log(cityName);                                      // в зависимости от настроек, местоположение сохраняется
                    settings.Log(haschb1.ToString());                                   // в логгер записываются текущие настройки
                }
                else
                {
                    initialCityName.Log("Не определено");
                    settings.Log("False");                                              // в логгер записываются текущие настройки
                }
            }
            else
            {
                initialCityName.Log("Не определено");
                settings.Log(haschb1.ToString());                                       // в логгер записываются текущие настройки
            }
        }
        // старт приложения
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ILog settings = new TextFileLogger("settings.ini");                     // открывается логгер
            string temp = settings.Read();                                          // считываются настройки
            // устанавливаются флаги настроек
            if (temp == "False")
            {
                haschb1 = false;
            }
            if (temp == "True")
            {
                haschb1 = true;
            }
            // устанавливатеся текущее местоположение
            ILog initialCityName = new TextFileLogger("initialCityName.ini");
            cityName = initialCityName.Read();
        }
    }
}
