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
using System.IO;
using System.Windows.Forms;
using System.Web;
using Awesomium.Core;
using Awesomium.Windows;
using System.ComponentModel;

namespace GoodAdvice
{
    public partial class Encyclopedia : Page
    {
        public Encyclopedia()
        {
            InitializeComponent();
        }
        private void awesom_Initialized(object sender, EventArgs e)
        {
            string appDir = Environment.CurrentDirectory;
            Uri pageUri = new Uri($@"{appDir}..\..\..\..\wb\encyclopedia\index.html");
            awesom.Source = pageUri;
        }
    }
}
