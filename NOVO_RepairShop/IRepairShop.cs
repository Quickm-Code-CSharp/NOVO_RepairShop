using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOVO_RepairShop
{
    interface IRepairShop
    {
        void    AddVehicle(IVehicle vehicle);
        void    TestNextVehicle();
        void    RemoveNextVehicle();
        string  ListVehicles();

        Queue<IVehicle> Vehicles { get;  }
        IVehicle        CurrentTestVehicle { get;  }
    }
}
