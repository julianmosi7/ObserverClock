using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ObserverClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClockSubject clockSubject = new ClockSubject();

        public MainWindow()
        {
            InitializeComponent();
            new Thread(() =>
            {
                while (true)
                {
                    clockSubject.SetState(DateTime.Now);
                    Thread.Sleep(1000);
                }
            }).Start();
        }

        private void NewClockClicked(object sender, RoutedEventArgs e)
        {
            new ClockObserverWindow(clockSubject).Show();
        }

    }
}
