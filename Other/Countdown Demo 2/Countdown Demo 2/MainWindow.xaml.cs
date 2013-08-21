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

//Added for timer:
using System.Windows.Threading; 
using System.Timers;

namespace Countdown_Demo_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer; 
        double timeInMinutes; //Initial Time

        public MainWindow()
        {
            InitializeComponent();
        }

        private void setTime_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(time.Text, out timeInMinutes) || time.Text == string.Empty || timeInMinutes == 0.0f)
            {
                message.Text = "Not a number or zero";
                return;
            }
            timeInMinutes *= 60;
            start.IsEnabled = false;
            timer = new Timer(1000);
            timeRemaining.Text = TimeSpan.FromSeconds(timeInMinutes).ToString(@"hh\:mm\:ss");

            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
            //timerDone.Text = string.Empty;
            time.Text = string.Empty;
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            --timeInMinutes;
            if (timeInMinutes <= 0)
            {
                timer.Enabled = false;
                timeRemaining.Dispatcher.Invoke(DispatcherPriority.Send, new UpdateTimeHandler(updateTime), timeInMinutes);
                //timerDone.Dispatcher.Invoke(DispatcherPriority.Send, new UpdateComplete(timerComplete), "Countdown Complete");
            }
            else
            {
                timeRemaining.Dispatcher.Invoke(DispatcherPriority.Send, new UpdateTimeHandler(updateTime), timeInMinutes);
            }
        }
        delegate void UpdateTimeHandler(double time);
        delegate void UpdateComplete(string text);

        void timerComplete(string text)
        {
            //timerDone.Text = text;
            start.IsEnabled = true;
        }

        void updateTime(double time)
        {
            timeRemaining.Text = TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss");
        }
    }
}
