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
    /// TODO: Move this class to ViewModels
    /// </summary>
    [Serializable]
    public class Court : INotifyPropertyChanged
    {
        /// <summary>
        /// Backing field for Group
        /// </summary>
        private ObservableCollection<ObservableCollection<Member>> _group = new ObservableCollection<ObservableCollection<Member>>();

        /// <summary>
        /// Represents a collection of the two teams of players who are currently on the court
        /// </summary>
        public ObservableCollection<ObservableCollection<Member>> Group 
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged("Group");
            }
        }

        /// <summary>
        /// Can be "Overdue", "Inactive", "Available", and "InUse"
        /// </summary>
        private string _courtState;

        /// <summary>
        /// Provides a naming structure for the court (ex. Court 1, Court 2, Court 3)
        /// </summary>
        public String CourtNumber { get; set; }

        /// <summary>
        /// Removes all the players that are currently on court
        /// </summary>
        public void ClearCourt()
        {
            Group.Clear();
        }

        /// <summary>
        /// Adds the specified group into this court
        /// </summary>
        /// <param name="group">Group to add</param>
        public void AddToCourt(ObservableCollection<ObservableCollection<Member>> group)
        {
            if (group != null)
            {
                Group = group;
                return;
            }
            throw new ArgumentException("Group cannot be null");
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
            CourtNumber = "Court " + index.ToString();
            CourtState = "Available";
        }

        //TODO: Move the following code to a viewmodel
        #region Timer Code
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private TimeSpan _interval = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Begins the timer for the court. Make sure that this method is only called once during the countdown period.
        /// Also, ensure that the initial _timeLeft value is positive, or else the ticker will display a negative number
        /// </summary>
        public void StartTimer()
        {
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            _dispatcherTimer.Interval = _interval;

            //_timeLeft = TimeSpan.FromMinutes((App.Current.Resources["Locator"] as BCQueue.ViewModels.ViewModelLocator).Main.MyProfile.TimerValue);
            SetTimeLeft(TimeSpan.FromSeconds(10));
            CourtState = "InUse";
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Made to be called by the "Finish" button in CourtControlTemplate.
        /// This method closes the session and deals with related properties to ensure a smooth next session
        /// Modifications made to the following properties: IsBusy, AvailablePool, CourtState, and group in the Court, Wins/Losses
        /// </summary>
        public void FinishSession()
        {
            StopTimer();
            ObservableCollection<Member> availablePool = BCQueue.ViewModels.MainViewModel._mMAddToQueueVM.AvailablePool;
            BCQueue.Views.GameResultsWindow resultWindow = new BCQueue.Views.GameResultsWindow(Group);
            resultWindow.Show();
            foreach (ObservableCollection<Member> team in Group)
            {
                foreach (Member m in team)
                {
                    m.IsBusy = false;
                    availablePool.Add(m);
                }
            }
            ClearCourt();
            CourtState = "Available";
        }

        /// <summary>
        /// Stops the timer for the court.
        /// </summary>
        private void StopTimer()
        {
            if (_dispatcherTimer.IsEnabled)
            {
                _dispatcherTimer.Stop();
                SetTimeLeft(TimeSpan.Zero); //in the scenario where timer is stopped prematurely
                _dispatcherTimer.Tick -= dispatcherTimer_Tick;
            }        
        }

        /// <summary>
        /// A Tick eventhandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            SetTimeLeft(_timeLeft.Subtract(_interval));
            if (_timeLeft <= TimeSpan.Zero)
            {
                //TimeUpEventArgs x = new TimeUpEventArgs();
                //x.CourtNumber = this.CourtNumber;
                StopTimer();
                //OnTimeUp(x);
                CourtState = "Overdue";
            }
        }

        /*
        /// <summary>
        /// Fires TimeUp event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTimeUp(TimeUpEventArgs e)
        {
            EventHandler<TimeUpEventArgs> handler = TimeUp;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Event that is fired when the countdown is over for this instance of Court
        /// </summary>
        public static event EventHandler<TimeUpEventArgs> TimeUp; //might change the argument to include players in court later if necessary
        */

        /// <summary>
        /// TimeSpan that represents the remaining time on court. It defaults to the value set in Profile.cs
        /// </summary>
        private TimeSpan _timeLeft;

        /// <summary>
        /// A Setter method for the timespan _timeLeft, which notifies that the TimeLeft property is changed
        /// </summary>
        /// <param name="value"></param>
        public void SetTimeLeft(TimeSpan value)
        {
            _timeLeft = value;
            OnPropertyChanged("TimeLeft");
        }

        /// <summary>
        /// A Setter method for the field _courtState, which validates the value and notifies if the TimeLeft property is changed
        /// Can be "Overdue", "Inactive", "Available", and "InUse"
        /// </summary>
        public string CourtState
        {
            get {return _courtState;}
            set
            {
                if (!((value == "Overdue") || (value == "Available") || (value == "Inactive") || (value == "InUse")))
                    throw new ArgumentException("Incorrect parameters");
                _courtState = value;
                OnPropertyChanged("CourtState");
            }
        }

        /// <summary>
        /// A property that is bound to a textbox in .xaml to represent a timer
        /// </summary>
        public String TimeLeft
        {
            get { return _timeLeft.ToString("c"); }
        }

        /// <summary>
        /// Returns true if the timer on court is running
        /// </summary>
        public bool TimerIsStarted
        {
            get { return _dispatcherTimer.IsEnabled; }
        }
        #endregion
        

        #region PropertyChanged event and event handler declaration/methods
        /// <summary>
        /// Event that is fired when a property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fires the PropertyChanged event
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

    }
    /*
    public class TimeUpEventArgs : EventArgs
    {
        public string CourtNumber { get; set; }
    }
    */

}
