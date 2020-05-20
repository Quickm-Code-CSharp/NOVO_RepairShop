using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Design_Patterns;

namespace NOVO_RepairShop
{
    public class NOVO_RepairShop : IRepairShop
    {

        public NOVO_RepairShop()
        {
            Vehicles = new Queue<IVehicle>();
            Mgr = new TestStrategy_Manager();
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (vehicle !=  null)
            {
                if (IsUniqueVehicle(vehicle))
                {
                    Vehicles.Enqueue(vehicle);
                    Console.WriteLine("Vehicle: {0} added to test queue", vehicle.ID);
                    Console.WriteLine("Shop: {0} vehicles in queue", Vehicles.Count);
                }

                else
                {
                    Console.WriteLine("Error: Shop already has vehicle: {0}", vehicle.ID);
                }
            }
        }
        public void TestNextVehicle()
        {
            if (Vehicles.Count > 0)
            {
                CurrentTestVehicle = Vehicles.Dequeue();
                Console.WriteLine("Vehicle: {0} removed from test queue for testing", CurrentTestVehicle.ID);

                // test interface
                bool passTest = Mgr.TestVehicle(CurrentTestVehicle);
                Console.WriteLine("Test: Vehicle: {0}, Pass: {1}", CurrentTestVehicle.ID, passTest);

                // Requirement: if test fails vehicle is re-added to end of queue.
                if(!passTest)
                {
                    AddVehicle(CurrentTestVehicle);
                    Console.WriteLine("Test: Vehicle: {0} failed test re-added to queue", CurrentTestVehicle.ID);
                }
            }
        }
        public void RemoveNextVehicle()
        {
            if (Vehicles.Count > 0)
            {
                // do nothing with vehicle
                IVehicle v = Vehicles.Dequeue();
                Console.WriteLine("Vehicle: {0} removed from test queue without testing", v.ID);
                Console.WriteLine("Shop: {0} vehicles in queue", Vehicles.Count);
            }
        }

        public string ListVehicles()
        {
            string result;

            StringBuilder sb = new StringBuilder();
            
            foreach (IVehicle v in Vehicles)
            {
                sb.AppendLine(v.ToString());
            }

            result = sb.ToString();

            return result;
        }

        public bool IsUniqueVehicle(IVehicle vehicle)
        {
            bool result = true;

            foreach (IVehicle v in Vehicles)
            {
                if (v.Equals(vehicle))
                {
                    result = false;
                    break;
                }
            }


            return result;
        }

        public Queue<IVehicle> Vehicles { get; private set; }
        public IVehicle        CurrentTestVehicle { get; private set; }
        private TestStrategy_Manager  Mgr { get; set; }
    }
}
