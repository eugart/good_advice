using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodAdvice
{
    public class CheckCityName
    {
        //список городов
        List<String> citiesName = new List<string>();
        //считываем список городов в конструкторе класса из файла
        public CheckCityName()
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader("checkCityName.ini"))
            {
                string temp = file.ReadToEnd();
                file.Close();
                String[] subtemp = temp.Split('\n');
                for (int i = 0; i < subtemp.Length; ++i)
                {
                    if (subtemp[i].Contains("\r"))
                    {
                        subtemp[i] = subtemp[i].Remove(subtemp[i].Length - 1, 1);
                        citiesName.Add(subtemp[i].ToUpper());
                    }
                    else
                    {
                        citiesName.Add(subtemp[i].ToUpper());
                    }
                }
            }
        }
        //проверяем наличие города с таким именем
        public bool CheckCitiesName(string cityName)
        {
            if (citiesName.Contains(cityName))
                return true;
            else
                return false;
        }
    }
}
