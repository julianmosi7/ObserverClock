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
using System.Windows.Shapes;

namespace ObserverClock
{
    /// <summary>
    /// Interaction logic for ClockObserverWindow.xaml
    /// </summary>
    public partial class ClockObserverWindow : Window, IObserver
    {
        private ClockSubject subject;
        private DateTime state;

        public ClockObserverWindow(ClockSubject clockSubject)
        {
            InitializeComponent();
            subject = clockSubject;
            subject.Attach(this);
        }

        public void Update()
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(Update);
                return;
            }
            ShowTime.Content = subject.GetState().ToString();
        }

        private void Detach(object sender, RoutedEventArgs e)
        {
            subject.Detach(this);
            this.Close();
        }
    }
}      