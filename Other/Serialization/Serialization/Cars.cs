using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Serialization
{
    [Serializable]
    public sealed class Cars : List<Car>, ISerializable
    {
        public Cars() : base()
        {
        }

        public Cars(int capacity) : base(capacity)
        {
        }

        public Cars(IEnumerable<Car> steps) : base(steps)
        {

        }

        private Cars(SerializationInfo info, StreamingContext context)
        {
            int count = info.GetInt32("NumOfCars");
            for (int ix = 0; ix < count; ix++)
            {
                string key = "Car_" + ix.ToString();
                Car car = (Car)info.GetValue(key, typeof(Car));
                this.Add(car);
            }
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("NumOfCars", this.Count);
            int ix = 0;
            foreach (Car car in this)
            {
                string key = "Car_" + ix.ToString();
                info.AddValue(key, car, typeof(Car));
                ix++;
            }
        }
    }
}
