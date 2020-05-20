using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOVO_RepairShop;

namespace Design_Patterns
{
    class EventCommand_TestVehicle : IRepairShopEventCommand
    {
        public EventCommand_TestVehicle(IRepairShop shop)
        {
            Shop = shop;
            Mgr = new TestStrategy_Manager();
        }
        private void InputData()
        {

        }

        public void Execute()
        {
            Shop.TestNextVehicle();
        }

        private void OutputData()
        {

        }

        private IRepairShop Shop { get; set; }
        private TestStrategy_Manager Mgr { get; set; }
    }
}
