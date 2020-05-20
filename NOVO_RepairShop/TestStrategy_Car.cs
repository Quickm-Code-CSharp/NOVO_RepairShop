using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOVO_RepairShop;

namespace Design_Patterns
{
    class TestStrategy_Car : TestStrategy_base
    {
        public TestStrategy_Car() : base()
        {

        }

        protected override bool TestAcceleration(IVehicle vehicle)
        {
            return base.TestAcceleration(vehicle);
        }

        protected override bool TestBrakes(IVehicle vehicle)
        {
            return base.TestBrakes(vehicle);
        }
    }
}
