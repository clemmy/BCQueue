using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BCQueue.ViewModels
{
    class GameResultsViewModel: ViewModelBase
    {
        /// <summary>
        /// Represents the a team of members
        /// </summary>
        public ObservableCollection<Member> Team1 { get; set; }

        /// <summary>
        /// Represents another team of members
        /// </summary>
        public ObservableCollection<Member> Team2 { get; set; }

        /// <summary>
        /// Command that is fired when team one wins, changing the playing members' stats accordingly
        /// </summary>
        public ICommand Team1WonCommand { get; set; }
        /// <summary>
        /// Command that is fired when team two wins, changing the playing members' stats accordingly
        /// </summary>
        public ICommand Team2WonCommand { get; set; }

        /// <summary>
        /// Execute method for Team1WonCommand
        /// </summary>
        private void Team1WonCommandExecute()
        {

        }

        /// <summary>
        /// Execute method for Team2WonCommand
        /// </summary>
        private void Team2WonCommandExecute()
        {
            Console.WriteLine("Team2 won!");
        }

        /// <summary>
        /// Sets appropriate values to Team1 and Team2 to allow for correct binding to the view
        /// </summary>
        /// <param name="group"></param>
        public GameResultsViewModel(ObservableCollection<ObservableCollection<Member>> group)
        {
            Team1 = group[0];
            Team2 = group[1];
            Team1WonCommand = new RelayCommand(() => Team1WonCommandExecute());
            Team2WonCommand = new RelayCommand(() => Team2WonCommandExecute());
        }
    }
}
