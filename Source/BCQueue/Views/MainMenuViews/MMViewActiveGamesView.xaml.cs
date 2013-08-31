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
        /// <summary>
        /// Sets the datacontext to allow binding to work properly in the active games view
        /// Sets the items source to allow the Queue List to display properly
        /// </summary>
        public MMViewActiveGamesView()
        {
            InitializeComponent();
            if ((App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile != null)
            {
                CourtsControl.DataContext = (App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile;
                
            }
            QueueList.ItemsSource = BCQueue.ViewModels.MainViewModel._mMAddToQueueVM.QueueList;
            QueueList.DataContext = BCQueue.ViewModels.MainViewModel._mMViewActiveGamesVM;

            //Court.TimeUp += ShowTimeUpAnimation;

        }


        #region Commented Out

        /*
        /// <summary>
        /// An event handler for when the TimeUp event is raised. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowTimeUpAnimation(object sender, TimeUpEventArgs e)
        {
            Court x = null;
            foreach (Court court in CourtsControl.Items)
            {
                if (court.CourtNumber == e.CourtNumber)
                {
                    x = court;
                    break;
                }
            }
            if (x != null)
            {
                var item = CourtsControl.ItemContainerGenerator.ContainerFromItem(x);
                var template = App.Current.Resources["CourtControlTemplate"] as DataTemplate;
                var textblock = template.FindName("TimerTextBlock", item as FrameworkElement);
                (textblock as TextBlock).Background = Brushes.Yellow;
                var usercontrol = template.FindName("CourtControl", item as FrameworkElement);
                (usercontrol as UserControl).Background = Brushes.Red;
            }
        }
         */

        #endregion
    }
}
