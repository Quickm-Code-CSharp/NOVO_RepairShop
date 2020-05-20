using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns;
namespace NOVO_RepairShop
{
    class Program
    {
        private const string CarID1                 = "Car1-234";
        private const string MotorID1               = "Motor1-456";
        private const char event_addVehicle         = 'a';
        private const char event_testNextVehicle    = 't';
        private const char event_listVehicles       = 'l';
        private const char event_removeNextVehicle  = 'r';
        private const char event_exit               = 'c';

        internal static IRepairShop             Shop { get; set; }
        internal static IRepairShopEventCommand Cmd_AddVehicle      { get; set; }
        internal static IRepairShopEventCommand Cmd_ListVehicles    { get; set; }
        internal static IRepairShopEventCommand Cmd_RemoveVehicle   { get; set; }
        internal static IRepairShopEventCommand Cmd_TestVehicle     { get; set; }
        internal static IRepairShopEventCommand Cmd_CloseShop       { get; set; }


        static void Main(string[] args)
        {
            InitRepairShop();
            CreateShopCommands();

            ProcessEvents();
            //Shop.RemoveNextVehicle();

            //Shop.TestNextVehicle();

        }

        private static void InitRepairShop()
        {
            IVehicle v1 = new CarVehicle(CarID1);
            IVehicle v2 = new MotorcycleVehicle(MotorID1);

            Shop = new NOVO_RepairShop();
            Shop.AddVehicle(v1);
            Shop.AddVehicle(v2);
        }

        private static void CreateShopCommands()
        {
            Cmd_AddVehicle    = new EventCommand_AddVehicle(Shop);
            Cmd_ListVehicles  = new EventCommand_ListVehicles(Shop);
            Cmd_RemoveVehicle = new EventCommand_RemoveVehicle(Shop);
            Cmd_TestVehicle   = new EventCommand_TestVehicle(Shop);
            Cmd_CloseShop     = new EventCommand_CloseShop(Shop);
        }

        private static void ProcessEvents()
        {

            ConsoleKeyInfo cki;
            char choice;
            bool isExitKey = false;

            // Prevent example from ending if CTL+C is pressed.
            Console.TreatControlCAsInput = true;

            DisplayMenuOptions();
            do
            {
               
                cki = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                choice = cki.KeyChar;
                if (ValidMenuOption(cki.KeyChar))
                {
                    ExecuteEvent(choice);
                    Console.WriteLine(Environment.NewLine); 
                }
                else {
                    Console.WriteLine("Invalid Entry: {0}", cki.Key);
                }

                isExitKey = (cki.Key == ConsoleKey.C);
                if (!isExitKey)
                {
                    DisplayMenuOptions();
                }

            } while (!isExitKey);
        }

        private static void DisplayMenuOptions()
        {
            Console.WriteLine("a - Add Vehicle to queue for testing");
            Console.WriteLine("t - Test the next vehicle");
            Console.WriteLine("l - List all the vehicles in the shop test results");
            Console.WriteLine("r - Remove next vehicle without testing");
            Console.WriteLine("c - Close the shop (exit the app)");
            Console.WriteLine("Choose menu option:");
        }

        private static bool ValidMenuOption(char choice)
        {
            bool valid = false;

            switch (choice)
            {
                case event_addVehicle:
                case event_testNextVehicle:
                case event_listVehicles:
                case event_removeNextVehicle:
                case event_exit:
                    valid = true;
                    break;
                default:
                    valid = false;
                    break;
            }

            return valid;
        }

        private static void ExecuteEvent(char choice)
        {
            switch(choice)
            {
                case event_addVehicle:
                    Cmd_AddVehicle.Execute();
                    break;

                case event_listVehicles:
                    Cmd_ListVehicles.Execute();
                    break;

                case event_testNextVehicle:
                    Cmd_TestVehicle.Execute();
                    break;

                case event_removeNextVehicle:
                    Cmd_RemoveVehicle.Execute();
                    break;

                case event_exit:
                    Cmd_CloseShop.Execute();
                    break;

                default:
                    Console.WriteLine("Error: Invalid menu choice: {0}", choice);
                    break;
            }
        }
    }
}
