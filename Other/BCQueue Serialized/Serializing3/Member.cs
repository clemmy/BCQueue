using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; 
using System.Security.Permissions;

namespace Serializing3
{
    public class Member : ISerializable
    {
        #region enum declarations
        public enum pd { Singles = 0, Doubles = 1, Mixed = 2, None = 3 }
        public enum sl { Beginner = 0, Intermediate = 1, Advanced = 2, Tournament = 3, Unknown = 4 }
        #endregion

        private pd _preferredDiscipline;
        private sl _skillLevel;
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int TotalGames { get { return GamesLost + GamesWon; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public pd PreferredDiscipline
        {
            get { return _preferredDiscipline; }
            set
            {
                if ((int)value < 0 || (int)value > 3)
                    _preferredDiscipline = value;
                else
                    _preferredDiscipline = pd.None;
            }
        }
        public sl SkillLevel
        {
            get { return _skillLevel; }
            set
            {
                if ((int)value < 0 || (int)value > 4)
                    _skillLevel = value;
                else
                    _skillLevel = sl.Unknown;
            }
        }

        private Member()
        {
        }

        private Member(SerializationInfo info, StreamingContext ctxt)
        {
            _preferredDiscipline = (pd)info.GetValue("PreferredDiscipline", typeof(int));
            _skillLevel = (sl)info.GetValue("SkillLevel", typeof(int));
            GamesWon = info.GetInt32("GamesWon");
            GamesLost = info.GetInt32("GamesLost");
            FirstName = info.GetString("FirstName");
            LastName = info.GetString("LastName");
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = 
           SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, 
           StreamingContext ctxt )
        {
            info.AddValue("PreferredDiscipline", this._preferredDiscipline);
            info.AddValue("SkillLevel", this._skillLevel);
            info.AddValue("GamesWon", this.GamesWon);
            info.AddValue("GamesLost", this.GamesLost);
            info.AddValue("FirstName", this.FirstName);
            info.AddValue("LastName", this.LastName);
        }


    }
}
