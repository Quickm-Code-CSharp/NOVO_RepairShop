using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOVO_RepairShop;
namespace Design_Patterns
{
    class EventCommand_RemoveVehicle : IRepairShopEventCommand
    {
        public EventCommand_RemoveVehicle(IRepairShop shop)
        {
            Shop = shop;
        }
        private void InputData()
        {

        }
        
        public void Execute()
        {
            Shop.RemoveNextVehicle();
        }

        private void OutputData()
        {

        }

        IRepairShop Shop { get; set; }
    }
}
