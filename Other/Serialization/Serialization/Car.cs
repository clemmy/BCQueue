//1
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization; //Library necessary to serialize
using System.Security.Permissions; //Convention

namespace Serialization
{
    //Adding the following "attribute" allows serialization
    [Serializable]
    public class Car : ISerializable
    /*ISerializable is an interface that allows Custom serialization, basically controlling how and what gets serialized
     * If this was not implemented, "then all of our public and private data members are serialized behind the scenes 
     * and we would need a default constructor...There are several other attributes that we can apply to properties and 
     * methods to control serialization; however, I've found the easiest and best way is to provide Custom Serialization, 
     * which will also aid in supporting different versions, which I'll discuss shortly.
     */
    {
        /// <summary>
        /// The readonly is only aestethic and not for the functionality of serialization as discussed
        /// </summary>
        private readonly string _make;
        private readonly string _model;
        private readonly int _year;
        private Owner _owner = null; 

        //Having a default constructor that's "invalid" (ie private) allows serialization to actually work
        //Might be a reassuring the compiler thing not entirely sure why
        private Car() { } 


        public Car( string make, string model, int year )
        {
          _make = make;
          _model = model;
          _year = year;
        }

        public Owner Owner
        {
          get { return _owner; }
          set { _owner = value; }
        }

        public string Make
        { get { return _make; } }

        public string Model
        { get { return _model; } }

        public int Year
        { get { return _year; } }

        //note: this is private to control access;
        //the serializer can still access this constructor
        private Car( SerializationInfo info, StreamingContext ctxt)
        {
          _make = info.GetString("Make");
          _model = info.GetString("Model");
          _year = info.GetInt32("Year");
          _owner = (Owner)info.GetValue("Owner", typeof(Owner));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = 
           SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData( SerializationInfo info, 
           StreamingContext ctxt )
        {
          info.AddValue("Make", this._make);
          info.AddValue("Model", this._model);
          info.AddValue("Year", this._year);
          info.AddValue("Owner", this._owner, typeof(Owner));
        }
    }
}

