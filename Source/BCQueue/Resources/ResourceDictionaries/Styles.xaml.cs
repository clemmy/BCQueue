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
            BCQueue.ViewModels.MainViewModel._mMViewActiveGamesVM.stopTheTimerExecute(sender, e);
        }
    }
}
