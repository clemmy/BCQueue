using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.ComponentModel;

namespace BCQueue
{
    /// <summary>
    /// A class that represents a court in a badminton club.
    /// </summary>
    [Serializable]
    public class Court : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents a collection of 1 or 2 players, who will v.s. Team 2
        /// </summary>
        private ObservableCollection<Member> _team1 = new ObservableCollection<Member>();
        /// <summary>
        /// Represents a collection of 1 or 2 players, who will v.s. Team 1
        /// </summary>
        private ObservableCollection<Member> _team2 = new ObservableCollection<Member>();

        /// <summary>
        /// Indicates whether a court is available for usage
        /// </summary>
        public Boolean IsCourtActive { get; set; }

        /// <summary>
        /// Provides a naming structure for the court (ex. Court 1, Court 2, Court 3)
        /// </summary>
        public String CourtNumber { get; set; }

        /// <summary>
        /// Adds a player to the specified slot
        /// </summary>
        /// <param name="TeamNumber"></param>
        /// <param name="m"></param>
        public void AddPlayer(int TeamNumber, Member m)
        {
            if (TeamNumber == 1)
            {
                if (_team1.Count < 2)
                    _team1.Add(m);
                else
                    throw new Exception("This team is full.");
            }
            else
            {
                if (_team2.Count < 2)
                    _team2.Add(m);
                else
                    throw new Exception("This team is full.");
            }
        }

        /// <summary>
        /// Removes the specified player from the court
        /// </summary>
        /// <param name="TeamNumber"></param>
        /// <param name="m"></param>
        public void RemovePlayer(int TeamNumber, Member m)
        {
            if (TeamNumber == 1)
                _team1.Remove(m);
            else
                _team2.Remove(m);
        }

        /// <summary>
        /// Removes all the players that are currently on court
        /// </summary>
        public void ClearCourt()
        {
            _team1.Clear();
            _team2.Clear();
        }

        /// <summary>
        /// An empty constructor in order to be serializable
        /// </summary>
        public Court() { }

        /// <summary>
        /// A constructor that sets the name of the court
        /// </summary>
        /// <param name="index"></param>
        public Court(int index)
        {
            CourtNumber = "Court "+index.ToString();
        }

        //TODO: Move the following code to a viewmodel
        #region Timer Code
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private TimeSpan _interval = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Begins the timer for the court. Make sure that this method is only called once during the countdown period.
        /// </summary>
        public void StartTimer()
        {
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            _dispatcherTimer.Interval = _interval;

            //_timeLeft = TimeSpan.FromMinutes((App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.TimerValue);
            _timeLeft = TimeSpan.FromSeconds(10);
            OnPropertyChanged("TimeLeft");

            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Stops the timer for the court.
        /// </summary>
        public void StopTimer()
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Tick -= dispatcherTimer_Tick;
        }

        /// <summary>
        /// A Tick eventhandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (_timeLeft.Subtract(_interval) >= TimeSpan.Zero)
            {
                _timeLeft = _timeLeft.Subtract(_interval);
                OnPropertyChanged("TimeLeft");
            }
            else
            {
                StopTimer();
                OnTimerStopped();
            }
        }

        /// <summary>
        /// Code to execute once the countdown is over (time is up on court)
        /// </summary>
        private void OnTimerStopped()//change this to a method
        {
            //Add methods here, parameters object sender and eventargs ;)
            //ex. TimeUp
            //ex. Clean up other properties
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// TimeSpan that represents the remaining time on court. It defaults to the value set in Profile.cs
        /// </summary>
        private TimeSpan _timeLeft;

        /// <summary>
        /// A property that is bound to a textbox in .xaml to represent a timer
        /// </summary>
        public String TimeLeft
        {
            get { return _timeLeft.ToString("c"); }
        }
        #endregion

    }
}
