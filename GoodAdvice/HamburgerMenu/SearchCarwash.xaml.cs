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
using Awesomium.Core;
using Awesomium.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using Awesomium.Windows.Controls;
using System.Net.NetworkInformation;

namespace GoodAdvice
{
    public partial class SearchCarwash : Page
    {
        // создаём новый поток
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public SearchCarwash()
        {
            InitializeComponent();
            if (PingHost("www.yandex.ru"))
            {
                awesom.Initialized += PG1_Initialized;
            }
            else
            {
                pb.Visibility = System.Windows.Visibility.Hidden;
                viewBox1.Visibility = System.Windows.Visibility.Hidden;
                picture.Visibility = System.Windows.Visibility.Hidden;
                awesom.Visibility = System.Windows.Visibility.Collapsed;
                worker.DoWork += worker_DoWork;
                worker.RunWorkerAsync();
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;               
            }
        }
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
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBox.Show("Невозможно загрузить страницу. Проверьте соединение с интернетом.", "Ошибка #002", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MainWindow wnd = (MainWindow)App.Current.MainWindow;
            wnd.item1.IsSelected = true;
        }
        private void ContentFrame_ContentRendered(object sender, EventArgs e)
        {
            ContentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void awesom_LoadingFrameComplete(object sender, FrameEventArgs e)
        {
            bg.Visibility = System.Windows.Visibility.Collapsed;
            pb.Visibility = System.Windows.Visibility.Collapsed;
            viewBox1.Visibility = System.Windows.Visibility.Collapsed;
            picture.Visibility = System.Windows.Visibility.Collapsed;
            gr.Visibility = System.Windows.Visibility.Collapsed;
            awesom.Visibility = System.Windows.Visibility.Visible;
            if (!((App)Application.Current).hasLoadedSearchedCarWash)
            {
                MessageBox.Show("Для начала найдите свой город в строке поиска.", "Подсказка", MessageBoxButton.OK, MessageBoxImage.Information);
                ((App)Application.Current).hasLoadedSearchedCarWash = true;
                textBlock1.Text = "← Вот тут";
                pLink.IsOpen = true; // запускаем всплывающее окно
            }
        }
        private void PG1_Initialized(object sender, EventArgs e)
        {
            string appDir = Environment.CurrentDirectory;
            Uri pageUri = new Uri($@"{appDir}..\..\..\..\wb\searchCarwash\geolocation.html");
            awesom.Source = pageUri;
        }
    }
}
