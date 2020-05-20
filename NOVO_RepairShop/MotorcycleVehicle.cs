using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOVO_RepairShop
{
    public class MotorcycleVehicle :  Vehicle_base
    {
        public MotorcycleVehicle(string motorID) :  base(motorID)
        {
            NumberofDoors   = 2;
            UpperRangeLimit = 100;
            VehicleType     = 2;
        }

        public override int Accelerate() => base.Accelerate();
        public override int Brake()      => base.Brake();
    }
}
