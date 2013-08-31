using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace BCQueue.Views
{
    /// <summary>
    /// Interaction logic for GameResultsWindow.xaml
    /// </summary>
    public partial class GameResultsWindow : Window
    {
        /// <summary>
        /// Creates a Result Window where the user can choose the winning team
        /// </summary>
        /// <param name="group">The group (of teams of members) who were playing on the court</param>
        public GameResultsWindow(ObservableCollection<ObservableCollection<Member>> group)
        {
            InitializeComponent();
            this.DataContext = new BCQueue.ViewModels.GameResultsViewModel(group);
        }

        /// <summary>
        /// Closes the GameResultsWindow without recording the win/loss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
