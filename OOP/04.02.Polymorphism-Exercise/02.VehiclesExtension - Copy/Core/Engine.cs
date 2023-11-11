using _01.Vehicles.Core.Interfaces;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace _01.Vehicles.Core
{
    public class Engine : IEngine
    {
        public Engine()
        {
        }
        
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(carInfo[3]));

            string[] BusInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle bus = new Bus(double.Parse(BusInfo[1]), double.Parse(BusInfo[2]), double.Parse(BusInfo[3]));


            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] commandInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandInfo[1] == "Car")
                {
                    if (commandInfo[0] == "Drive")
                    {
                        car.Drive(double.Parse(commandInfo[2]));
                    }
                    else car.Refuel(double.Parse(commandInfo[2]));
                }
                else if (commandInfo[1] == "Truck")
                {
                    if (commandInfo[0] == "Drive")
                    {
                        truck.Drive(double.Parse(commandInfo[2]));
                    }
                    else truck.Refuel(double.Parse(commandInfo[2]));
                }
                else
                {
                    if (commandInfo[0] == "Drive")
                    {
                        bus.Drive(double.Parse(commandInfo[2]), true);
                    }
                    else if(commandInfo[0] == "DriveEmpty")
                    {
                        bus.Drive(double.Parse(commandInfo[2]), false);
                    }
                    else truck.Refuel(double.Parse(commandInfo[2]));
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
/* Drive Car 9
 * Drive Car 30
 * Refuel Car 50
 * Drive Truck 10
 */
