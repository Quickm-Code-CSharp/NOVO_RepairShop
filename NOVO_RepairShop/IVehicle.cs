using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOVO_RepairShop
{
    public interface IVehicle
    {
        int Accelerate();
        int Brake();
        bool Equals(IVehicle vehicle);

        int NumberofDoors { get; }
        string ID { get; }
        int VehicleType { get; }
        int UpperRangeLimit { get; }
        
    }
}
