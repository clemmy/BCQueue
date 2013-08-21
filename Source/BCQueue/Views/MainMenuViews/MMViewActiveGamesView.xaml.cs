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

namespace BCQueue.Views.MainMenuViews
{
    /// <summary>
    /// Interaction logic for MMViewActiveGamesView.xaml
    /// </summary>
    public partial class MMViewActiveGamesView : UserControl
    {
        public MMViewActiveGamesView()
        {
            InitializeComponent();
            if ((App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile != null)
            {
                CourtsControl.DataContext = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile;
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.GetType().ToString());
            MessageBox.Show(((FrameworkElement)sender).Parent.GetType().ToString());
            //Call method here
            //give the button a better name...
        }
    }
}
