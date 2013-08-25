using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BCQueue.Resources.ResourceDictionaries
{
    /// <summary>
    /// Interaction logic for Styles.xaml
    /// </summary>
    partial class Styles : ResourceDictionary
    {
        public Styles()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Stops the Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopTheTimer(object sender, RoutedEventArgs e)
        {
            Visual button = (Visual)sender;
            var parent = VisualTreeHelper.GetParent(button);
            if (!(((parent as Grid).Children[1]) is TextBlock))
                return; //The following lines of code run assuming that the sender is a TimerTextBlock, thus will crash the program if sender is not of that type
            TextBlock timer = (parent as Grid).Children[1] as TextBlock;
            (timer.DataContext as Court).StopTimer();
        }

        /// <summary>
        /// Sets textblock animation to indicate that time is up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeUp(object sender, EventArgs e)
        {
        }


    }
}
