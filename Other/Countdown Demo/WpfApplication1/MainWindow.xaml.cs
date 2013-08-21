using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication2;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ttbCountDown.IsStarted = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            ttbCountDown.IsStarted = false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ttbCountDown.Reset();
            ttbCountDown.Background = Brushes.LightGray;
            ttbCountDown.Foreground = Brushes.Black;
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            ttbCountDown.TimeSpan = TimeSpan.FromSeconds(59);
            ttbCountDown.Background = Brushes.LightGray;
            ttbCountDown.Foreground = Brushes.Black;
        }

        private void btnSetTimer_Click(object sender, RoutedEventArgs e)
        {
            ttbTimer.TimeSpan = TimeSpan.FromMinutes(5);
        }

        private void btnStartTimer_Click(object sender, RoutedEventArgs e)
        {
            ttbTimer.IsStarted = true;
        }

        private void btnStopTimer_Click(object sender, RoutedEventArgs e)
        {
            ttbTimer.IsStarted = false;
        }

        private void btnResetTimer_Click(object sender, RoutedEventArgs e)
        {
            ttbTimer.Reset();
        }

        private void ttbCountDown_OnCountDownComplete(object sender, EventArgs e)
        {
            ttbCountDown.Background = Brushes.Red;
            ttbCountDown.Foreground = Brushes.White;
        }
    }
}
