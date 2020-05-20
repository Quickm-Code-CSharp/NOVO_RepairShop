using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NOVO_RepairShop;
namespace Design_Patterns
{
    class EventCommand_CloseShop : IRepairShopEventCommand
    {
        public EventCommand_CloseShop(IRepairShop shop)
        {
            Shop = shop;
        }
        private void InputData()
        {
            VehiclesInShop = Shop.Vehicles.Count();
        }

        public void Execute()
        {
            InputData();

            // do nothing

            OutputData();
        }

        private void OutputData()
        {
            Console.WriteLine("Shop: There are {0} vehicles in shop at closing", VehiclesInShop);
        }

        private IRepairShop Shop { get; set; }
        private int         VehiclesInShop { get; set; }
    }
}
