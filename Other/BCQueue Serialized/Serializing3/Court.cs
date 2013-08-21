using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Serializing3
{
    [Serializable]
    public class Court : ISerializable
    {
        public Boolean IsCourtActive { get; set; } //indicates whether a certain court is available for usage

        private Court()
        {
        }

        private Court( SerializationInfo info, StreamingContext ctxt)
        {
            IsCourtActive = info.GetBoolean("IsCourtActive");
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = 
           SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData( SerializationInfo info, 
           StreamingContext ctxt )
        {
          info.AddValue("IsCourtActive", this.IsCourtActive);
        }
    }
}