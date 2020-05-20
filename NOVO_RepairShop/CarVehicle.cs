using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOVO_RepairShop
{
    public class CarVehicle : Vehicle_base
    {
        public CarVehicle(string motorID) : base(motorID)
        {
            NumberofDoors   = 4;
            UpperRangeLimit = 50;
            VehicleType     = 1;
        }

        public override int Accelerate() => base.Accelerate();
        public override int Brake()      => base.Brake();

    }
}
