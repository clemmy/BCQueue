using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BCQueue.ViewModels.MainMenuVM
{
    public class MMViewActiveGamesVM:ViewModelBase
    {

        /// <summary>
        /// backing field for QueueStatus
        /// </summary>
        private string _queueStatus;
 
        /// <summary>
        /// The message that is bound to a label in order to indicate whether there is an available court or not
        /// Can be "Waiting for Court" or "Court available! Click Start to begin!"
        /// </summary>
        public string QueueStatus 
        {
            get {return _queueStatus;}
            set 
            {
                _queueStatus=value;
                RaisePropertyChanged("QueueStatus");
            }
        }

        /// <summary>
        /// backing field for IsWaiting
        /// </summary>
        private bool _isWaiting;

        /// <summary>
        /// Indicates whether there is a court available or not. When setting, this will set the view-bound labels to their appropriate values
        /// </summary>
        public bool IsWaiting 
        {
            get {return _isWaiting;}
            set 
            {
                _isWaiting = value;
                if (_isWaiting==true)
                {
                    QueueStatus="Waiting for Court...";
                }
                else
                {
                    QueueStatus="Court available! Click Start to begin!";
                }
            }
        }

        /// <summary>
        /// The method that is called by stopTheTimer in order to stop the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void stopTheTimerExecute(object sender, RoutedEventArgs e)
        {
            Visual button = (Visual)sender;
            var parent = VisualTreeHelper.GetParent(button);
            if (!(((parent as Grid).Children[2]) is TextBlock))
                throw new ArgumentException("Sender is not a textblock"); //The following lines of code run assuming that the sender is a TimerTextBlock, thus will crash the program if sender is not of that type
            TextBlock timer = (parent as Grid).Children[2] as TextBlock;
            (timer.DataContext as Court).FinishSession();
            //(timer.DataContext as Court).Resolve... (notify queuelist that a court is free?)
        }

        /// <summary>
        /// Begins a session on an available court once clicked by the user (only available for index 0 on the Queue List)
        /// </summary>
        public ICommand StartSessionCommand { get; set; }

        /// <summary>
        /// Execute method for StartSessionCommand
        /// </summary>
        private void StartSessionCommandExecute()
        {
            TryAddToCourt();
        }

        /// <summary>
        /// Returns the index of the first available court in the Courts ObservableCollection in the MainViewModel
        /// Returns -1 if no courts are free
        /// </summary>
        /// <returns></returns>
        public static int GetIndexOfEmptyCourt()
        {
            ObservableCollection<Court> temp = (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Courts;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].CourtState == "Available")
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Checks if any of the courts are available, and adds the group whose index is 1 to it, if possible
        /// </summary>
        public void TryAddToCourt()
        {
            int index = GetIndexOfEmptyCourt();
            if (index != -1)
            {
                ObservableCollection<Court> courts = (App.Current.Resources["Locator"] as ViewModelLocator).Main.MyProfile.Courts;
                ObservableCollection<ObservableCollection<ObservableCollection<Member>>> queueList = BCQueue.ViewModels.MainViewModel._mMAddToQueueVM.QueueList; 
                courts[index].AddToCourt(queueList[0]);
                queueList.RemoveAt(0);
                courts[index].StartTimer();
            }
        }

        public MMViewActiveGamesVM()
        {
            StartSessionCommand = new RelayCommand(() => StartSessionCommandExecute());
        }
        
    }
}
