using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows;

namespace BCQueue
{
    /// <summary>
    /// A member who is registered in a badminton club
    /// TODO: Move this class to ViewModels
    /// </summary>
    public class Member:ViewModelBase,INotifyPropertyChanged
    {
        //temp
        public Member() { }
       
        #region enum declarations
        public enum pd { None = 0, Singles = 1, Doubles = 2, Mixed = 3 }
        public enum sl { Unknown = 0, Beginner = 1, Intermediate = 2, Advanced = 3, Tournament = 4 }
        public enum gend { Unspecified = 0, Male = 1, Female = 2 }
        #endregion

        #region backing fields
        private pd _preferredDiscipline;
        private sl _skillLevel;
        private gend _gender;
        private bool _isBusy;
        private bool _isOnline;
        private string _aboutMe;
        private int _gamesWon;
        private int _gamesLost;
        private string _firstName;
        private string _lastName;
        #endregion
        
        /// <summary>
        /// True if a player cannot be logged out currently (ex. in an active game or on the queue list)
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set 
            { 
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        /// <summary>
        /// True once the player is signed in and false once the player has signed off
        /// </summary>
        public bool IsOnline 
        {
            get { return _isOnline; }
            set 
            { 
                _isOnline = value;
                RaisePropertyChanged("IsOnline");
            }
        } 
        /// <summary>
        /// Stores a short description of a member that will be displayed in the player's profile
        /// </summary>
        public String AboutMe //TODO: Find a better data type to support this
        {
            get { return _aboutMe; }
            set
            {
                _aboutMe = value;
                RaisePropertyChanged("AboutMe");
            }
        } 
        public int GamesWon
        {
            get { return _gamesWon; }
            set
            {
                _gamesWon = value;
                RaisePropertyChanged("GamesWon");
                RaisePropertyChanged("TotalGames"); //Not sure if this is necessary
            }
        } 
        public int GamesLost
        {
            get { return _gamesLost; }
            set 
            {
                _gamesLost = value;
                RaisePropertyChanged("GamesLost");
                RaisePropertyChanged("TotalGames"); //Not sure if this is necessary
            }
        } 
        public int TotalGames 
        { 
            get 
            { 
                return _gamesLost + _gamesWon;
            } 
        }
        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
                RaisePropertyChanged("FullName");
            }
        } 
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
                RaisePropertyChanged("FullName");
            }
        } 
        public string FullName { get { return _firstName+" "+_lastName; } }

        /// <summary>
        /// None = 0, Singles = 1, Doubles = 2, Mixed = 3
        /// </summary>
        public pd PreferredDiscipline
        {
            get { return _preferredDiscipline; }
            set
            {
                if ((int)value < 0 || (int)value > 3)
                    _preferredDiscipline = pd.None;
                else
                    _preferredDiscipline = value;
                RaisePropertyChanged("PreferredDiscipline");
            }
        }
        /// <summary>
        /// Unknown = 0, Beginner = 1, Intermediate = 2, Advanced = 3, Tournament = 4
        /// </summary>
        public sl SkillLevel
        {
            get { return _skillLevel; }
            set
            {
                if ((int)value < 0 || (int)value > 4)
                    _skillLevel = sl.Unknown;
                else
                    _skillLevel = value;
                RaisePropertyChanged("SkillLevel");
            }
        }
        /// <summary>
        /// Unspecified = 0, Male = 1, Female = 2
        /// </summary>
        public gend Gender
        {
            get { return _gender; }
            set
            {
                if ((int)value < 0 || (int)value > 2)
                    _skillLevel = sl.Unknown;
                else
                    _gender = value;
                RaisePropertyChanged("Gender");
            }
        }
    }
}
