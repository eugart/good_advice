using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace GoodAdvice
{
    public class Prediction
    {
        public Prediction(string _cityName)
        {
            temp = GetTranslit(_cityName);
        }

        public string temp;
        public string url;
        List<Wheather> forecast = new List<Wheather>();
        List<string> answer = new List<string>();
        int ret = 0;

        public KeyValuePair<string, int> Advice()
        {
            url = @"https://yandex.ru/pogoda/" + $"{temp}";

            resizeForecast();
            resizeAnswer();
            SetData(url, "forecast-brief__item-comment");
            SetData(url, "forecast-brief__item-temp-day");
            return new KeyValuePair<string, int>(answer[PredictionAnswer()], ret);
        }

        private void resizeForecast()
        {
            for (int i = 0; i < 5; ++i)
            {
                Wheather wh = new Wheather();
                wh.tempDay = 0;
                wh.cloudiness = "";
                forecast.Add(wh);
            }
        }
        private void resizeAnswer()
        {
            answer.Add("Пока нет ни одного подходящего дня для мойки вашего автомобиля. Придется немного подождать.");
            answer.Add("Самое время быстрее ехать на мойку и мыть свою ласточку.");
            answer.Add("Можете помыть машину сегодня и как минимум ");
            answer.Add("Можете помыть машину завтра и как минимум ");
            answer.Add("Можете помыть машину послезавтра и как минимум ");
        }
        private int PredictionAnswer()
        {
            int ans = 0;
            int pos = 0;

            for (int i = 4; i >= 0; i--)
            {
                if (i > 0)
                {
                    if (CheckCloudiness(forecast[i].cloudiness) && CheckTempDay(forecast[i].tempDay, forecast[i - 1].tempDay))
                        ret++;
                    else
                    {
                        if (ret >= 3)
                        {
                            pos = i + 2;
                            break;
                        }
                        ret = 0;
                    }
                            
                }
                if (i == 0)
                {
                    if (CheckCloudiness(forecast[i].cloudiness))
                    {
                        if (ret >= 2)
                        {
                            ret++;
                            pos = 1;
                        }
                    }
                    else
                    {
                        if (ret >= 3)
                        {
                            pos = i + 2;
                            break;
                        }
                    }
                }
            }

            if (pos == 1 && ret == 5)
                ans = 1;

            if (ret < 3)
                ans = 0;

            if (pos == 1 && ret != 5)
                ans = 2;

            if (pos == 2)
                ans = 3;

            if (pos == 3)
                ans = 4;

            return ans;
        }

        private bool CheckCloudiness(string temp)
        {
            bool hasCheckCloudiness = true;
            if (temp == "небольшой дождь")
                hasCheckCloudiness = false;
            if (temp == "дождь")
                hasCheckCloudiness = false;
            if (temp == "сильный дождь")
                hasCheckCloudiness = false;
            if (temp == "сильный дождь, гроза")
                hasCheckCloudiness = false;
            if (temp == "дождь со снегом")
                hasCheckCloudiness = false;
            if (temp == "небольшой снег")
                hasCheckCloudiness = false;
            if (temp == "снег")
                hasCheckCloudiness = false;
            if (temp == "снегопад")
                hasCheckCloudiness = false;

            return hasCheckCloudiness;
        }

        private bool CheckTempDay(int temp1, int temp2)
        {
            bool hasCheckTempDay = true;

            if (temp1 < 0 && temp2 > 0)
                hasCheckTempDay = false;

            return hasCheckTempDay;
        }
        private void SetData(string url, string className)
        {
            HtmlDocument HD = new HtmlDocument();
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            HD = web.Load(url);

            //выбирае деревья из класса написанного в textBox и элемента написанного
            HtmlNodeCollection NoAltElements = HD.DocumentNode.SelectNodes($"//div[@class='{className}']");

            int i = 0;

            if (NoAltElements != null)
            {
                foreach (HtmlNode hn in NoAltElements)
                {
                    string outputText = hn.InnerText.Trim();

                    if (className == "forecast-brief__item-comment")
                    {
                        forecast[i].cloudiness = outputText;
                        i++;
                        if (i == 5)
                            break;
                    }

                    else
                    {
                        if (i == 0)
                        {
                            outputText = outputText.Remove(2, outputText.Length - 2);
                            forecast[i].tempDay = Int32.Parse(outputText[1].ToString());
                            if (outputText[0] == '−')
                                forecast[i].tempDay = -forecast[i].tempDay;
                        }
                        else
                        {
                            if (outputText.Length > 1)
                            {
                                forecast[i].tempDay = Int32.Parse(outputText[1].ToString());
                                if (outputText[0] == '−')
                                    forecast[i].tempDay = -forecast[i].tempDay;
                            }
                            else
                                forecast[i].tempDay = Int32.Parse(outputText);
                        }
                        i++;
                        if (i == 5)
                            break;
                    }
                }
            }
        }

        public static string GetTranslit(string sourceText)
        {
            WebRequest request = WebRequest.Create("https://translate.yandex.net/api/v1.5/tr.json/translate?"
                    + "key=trnsl.1.1.20161223T182008Z.9d1ae536335cebe1.7d22d7829ce46f43568f157baf83b7c39b470297"
                    + "&text=" + sourceText
                    + "&lang=" + "ru-en");
            WebResponse response = request.GetResponse();

            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                string line;
                if ((line = stream.ReadLine()) != null)
                {
                    sourceText = line.Substring(line.IndexOf(":[\"") + 3);
                    sourceText = sourceText.Remove(sourceText.Length - 3);
                }
            }

            return sourceText;
        }
    }
}
