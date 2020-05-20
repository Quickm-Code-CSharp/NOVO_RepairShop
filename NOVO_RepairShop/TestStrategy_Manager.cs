using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOVO_RepairShop;


namespace Design_Patterns
{
    class TestStrategy_Manager
    {
        public TestStrategy_Manager()
        {
            CarStrategy   = new TestStrategy_Car();
            MotorStrategy = new TestStrategy_Motorcycle();
        }

        public bool TestVehicle(IVehicle vehicle)
        {
            bool result = false;

            switch ( vehicle.VehicleType)
            {
                case 1:
                    result = CarStrategy.TestVehicle(vehicle);
                    break;

                case 2:
                    result = MotorStrategy.TestVehicle(vehicle);
                    break;

                default:
                    Console.WriteLine("Error: Invalid VehicleType: {0} to test vehicle: {1}", vehicle.VehicleType, vehicle.ID);
                    break;
            }

            return result;
        }

        private ITestStrategy CarStrategy { get; set; }
        private ITestStrategy MotorStrategy { get; set; }
    }
}
