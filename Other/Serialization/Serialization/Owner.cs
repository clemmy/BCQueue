using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Serialization
{
    [Serializable]
    public class Owner : ISerializable
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;

        public Owner() { }

        public Owner(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        //note: this is private to control access; 
        //the serializer can still access this constructor
        private Owner(SerializationInfo info, StreamingContext ctxt)
        {
            _firstName = info.GetString("FirstName");
            _lastName = info.GetString("LastName");
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags =
            SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info,
            StreamingContext ctxt)
        {
            info.AddValue("FirstName", this._firstName);
            info.AddValue("LastName", this._lastName);
        }
    }
}