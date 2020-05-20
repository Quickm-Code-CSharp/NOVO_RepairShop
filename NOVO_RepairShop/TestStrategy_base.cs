using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOVO_RepairShop;

namespace Design_Patterns
{
    class TestStrategy_base : ITestStrategy
    {
        public TestStrategy_base()
        {

        }

        public bool TestVehicle(IVehicle vehicle)
        {
            bool result = false;

            bool partA = TestAcceleration(vehicle);
            bool partB = TestBrakes(vehicle);

            Console.WriteLine("Test results: Acceleration: {0}, Brakes: {1}", partA, partB);

            result = (partA && partB);

            return result;
        }

        protected virtual bool TestAcceleration(IVehicle vehicle)
        {
            bool result = false;

            int delta = ComputeDeltaValue(vehicle);

            int lowPass = delta;
            int highPass = vehicle.UpperRangeLimit - delta;

            int testValue = vehicle.Accelerate();

            result = (testValue >= lowPass && testValue <= highPass);

            return result;
        }

        protected virtual bool TestBrakes(IVehicle vehicle)
        {
            bool result = false;

            int delta = ComputeDeltaValue(vehicle);

            int lowPass = -1 * vehicle.UpperRangeLimit + delta;
            int highPass = -1*delta;

            int testValue = vehicle.Brake();

            result = (testValue >= lowPass && testValue <= highPass);

            return result;
        }

        protected int ComputeDeltaValue(IVehicle vehicle)
        {
            int delta = 0;
            // Passing values are 10 -90 % of UpperRangeLimit 
            int maxValue = vehicle.UpperRangeLimit;

            delta = (int)Math.Round(0.10 * maxValue);

            return delta;
        }
    }
}
