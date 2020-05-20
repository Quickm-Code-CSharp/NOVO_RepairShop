using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NOVO_RepairShop;

namespace Design_Patterns
{
    interface ITestStrategy
    {
        bool TestVehicle(IVehicle vehicle);
    }
}
