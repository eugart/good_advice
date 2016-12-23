using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodAdvice
{
    interface ILog
    {
        void Log(string Message); 
        string Read();
    }
}
