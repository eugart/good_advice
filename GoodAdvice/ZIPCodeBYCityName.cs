using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoodAdvice
{
    public class ZIPCodeBYCityName
    {
        //словарь содержит название города и его zip code для запроса прогноза погоды
        List<KeyValuePair<string, string>> dictionary = new List<KeyValuePair<string, string>>();
        //метод заполнение словаря
        public void FillDictionary()
        {
            string temp = System.String.Empty;
            //считываем инфомацию из файла
            using (System.IO.StreamReader file = new System.IO.StreamReader("initialZIPCodeAndCityName.ini"))
            {
                temp = file.ReadToEnd();
                file.Close();
                //сплитим по переносу строки
                String[] subtemp = temp.Split('\n');
                for (int i = 0; i < subtemp.Length; ++i)
                {
                    //вырезаем не нужные символы и добавлям элементы
                    if (subtemp[i].Contains("\r"))
                    {
                        subtemp[i] = subtemp[i].Remove(subtemp[i].Length - 1, 1);
                        dictionary.Add(new KeyValuePair<string, string>(subtemp[i].Split(' ')[1].ToUpper(), subtemp[i].Split(' ')[0]));
                    }
                    else
                    {
                        dictionary.Add(new KeyValuePair<string, string>(subtemp[i].Split(' ')[1].ToUpper(), subtemp[i].Split(' ')[0]));
                    }
                }   
            }
        }
        //метод ищет zip code переданного ему в качестве парамметра названия города
        public int SearchZIPCodeByCityName(string cityName)
        {
            KeyValuePair<string, string> temp = dictionary.First(v => v.Key.Equals(cityName));
            return Int32.Parse(temp.Value);
        }
    }

    
}
