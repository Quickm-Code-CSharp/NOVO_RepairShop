using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOVO_RepairShop;
namespace Design_Patterns
{
    class EventCommand_AddVehicle : IRepairShopEventCommand
    {
        public EventCommand_AddVehicle(IRepairShop shop)
        {
            Shop = shop;
        }
        private void InputData()
        {
            bool isIdValid = false;
            do
            {
                Console.WriteLine("Enter Vehicle ID:");
                VehicleID = Console.ReadLine();
                isIdValid = !String.IsNullOrEmpty(VehicleID);
                if (!isIdValid)
                {
                    Console.WriteLine("Error: Empty Vehicle ID returned, try again");
                }
                Console.WriteLine(Environment.NewLine);
            }
            while (!isIdValid);

            Console.WriteLine(Environment.NewLine);

            Console.Write("Enter vehicle type (1 - Car, 2- Motorcycle): ");
            ConsoleKeyInfo cki;
            bool valueEntry = false;
            do
            {
                cki = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(Environment.NewLine);
                valueEntry = (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.D2);
                if (!valueEntry)
                {
                    Console.WriteLine("Invalid vehicle type entry: {0}", cki.KeyChar);
                }
            }
            while (!valueEntry);

            VehicleType = int.Parse(cki.KeyChar.ToString());
        }

        public void Execute()
        {
            InputData();

            IVehicle vehicle = null;

            switch (VehicleType)
            {
                case 1:
                    vehicle = new CarVehicle(VehicleID);
                    break;

                case 2:
                    vehicle = new MotorcycleVehicle(VehicleID);
                    break;
                default:
                    Console.WriteLine("Error: Invalid vehicle type: {0}", VehicleType);
                    break;
            }

            Shop.AddVehicle(vehicle);


            OutputData();
        }

        private void OutputData()
        {

        }

        private string VehicleID   { get; set; }
        private int    VehicleType { get; set; }
        private IRepairShop Shop   { get; set; }
    }
}
