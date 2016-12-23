using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GoodAdvice
{
    public class TextFileLogger : ILog
    {
        public void Log(string Message)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(_name, false))
            {
                file.WriteLine(Message);
                file.Close();
            }
        }
        public string Read()
        {
            string temp = System.String.Empty;
            using (System.IO.StreamReader file = new System.IO.StreamReader(_name))
            {
                temp = file.ReadLine();
            }
            return temp;
        }
        private string _name;

        public TextFileLogger(string name)
        {
            this._name = name;
        }
    }
}
