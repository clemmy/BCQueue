using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; 
using System.Security.Permissions; 

namespace Serializing3
{
    [Serializable]
    public class Profile : ISerializable
    {
        private Court[] _courts;
        private List<Member> _members;

        public String Name { get; set; }
        public int NumCourts { get { return NumRows * NumColumns; } } //number of courts in the gym
        public int NumRows { get; set; }
        public int NumColumns { get; set; }
        public int timerValue { get; set; } //minutes of play allowed on court

        private Profile()
        {
        }

        //note: this is private to control access;
        //the serializer can still access this constructor
        private Profile( SerializationInfo info, StreamingContext ctxt)
        {
            Name = info.GetString("Name");
            NumRows = info.GetInt32("NumRows");
            NumColumns = info.GetInt32("NumColumns");
            timerValue = info.GetInt32("TimerValue");
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = 
           SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData( SerializationInfo info, 
           StreamingContext ctxt )
        {
          info.AddValue("Name", this.Name);
          info.AddValue("NumRows", this.NumRows);
          info.AddValue("NumColumns", this.NumColumns);
          info.AddValue("TimerValue", this.timerValue);
        }

    }
}
