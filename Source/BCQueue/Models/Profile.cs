using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BCQueue
{
    /// <summary>
    /// A class that stores collections of courts, members, and settings specfic to a specific badminton club
    /// </summary>
    [Serializable]
    public class Profile
    {
        private ObservableCollection<Court> _courts = new ObservableCollection<Court>();
        private ObservableCollection<Member> _members = new ObservableCollection<Member>();

        public string ClubName { get; set; }
        public int NumCourts { get {return NumRows*NumColumns;} } //number of courts in the gym
        public int NumRows { get; set; }  //keep columns<rows for optimal visuals
        public int NumColumns { get; set; }
        public int TimerValue { get; set; } //minutes of play allowed on court
        public ObservableCollection<Court> Courts { get { return _courts; } }
        public ObservableCollection<Member> Members { get { return _members; } }
        public string Password { get; set; }
        
    }
}
