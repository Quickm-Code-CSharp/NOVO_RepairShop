using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOVO_RepairShop
{
    public class Vehicle_base : IVehicle, IEquatable<IVehicle>
    {
        public Vehicle_base(string vehicleID)
        {
            ID = vehicleID;

            Generator = new Random();

        }
        public virtual int Accelerate()
        {
            int value = 0;

            value = Generator.Next(1, UpperRangeLimit);

            return value;
        }
        public virtual int Brake()
        {
            int value = 0;

            value = Generator.Next(-1 * UpperRangeLimit, -1);

            return value;
        }

        public override string ToString()
        {
            string result;

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Vehicle ID: {0} \n", ID);
            sb.AppendFormat("Vehicle Type: {0} \n", VehicleType);
            sb.AppendFormat("Doors: {0} \n", NumberofDoors);

            result = sb.ToString();


            return result;
        }

        public bool Equals(IVehicle other)
        {
            bool result = false;

            result =    this.NumberofDoors   == other.NumberofDoors &&
                        this.ID              == other.ID &&
                        this.UpperRangeLimit == other.UpperRangeLimit &&
                        this.VehicleType     == other.VehicleType;

            return result;
        }

        public int NumberofDoors { get; protected set; }
        public string ID { get; protected set; }
        public int UpperRangeLimit { get; protected set; }
        public int VehicleType { get; protected set; }

        protected Random Generator { get; }
    }
}
