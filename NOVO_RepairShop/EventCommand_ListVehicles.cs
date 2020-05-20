using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NOVO_RepairShop;

namespace Design_Patterns
{
    class EventCommand_ListVehicles : IRepairShopEventCommand
    {
        public EventCommand_ListVehicles(IRepairShop shop)
        {
            Shop = shop;
        }
        private void InputData()
        {

        }

        public void Execute()
        {
            InputData();

            VehicleData = Shop.ListVehicles();

            OutputData();
        }

        private void OutputData()
        {
            Console.WriteLine("List of vehicles in shop");
            Console.WriteLine(VehicleData);
        }

        private IRepairShop Shop { get; set; }
        private string      VehicleData { get; set; }

    }
}
