using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BCQueue
{
    [Serializable]
    public class Court
    {
        private ObservableCollection<Member> _team1 = new ObservableCollection<Member>();
        private ObservableCollection<Member> _team2 = new ObservableCollection<Member>();

        public Boolean IsCourtActive { get; set; } //indicates whether a certain court is available for usage
        public String CourtNumber { get; set; } //provides a naming structure for the court (ex. Court 1, Court 2, Court 3)
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
        public void RemovePlayer(int TeamNumber, Member m)
        {
            if (TeamNumber == 1)
                _team1.Remove(m);
            else
                _team2.Remove(m);
        }
        public void ClearCourt()
        {
            _team1.Clear();
            _team2.Clear();
        }

        public Court() { } //empty constructor in order to be serializable
        public Court(int index)
        {
            CourtNumber = "Court "+index.ToString();
        }

    }
}
