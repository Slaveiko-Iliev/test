using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new ();
            
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            string newInput = string.Empty;

            while ((newInput = Console.ReadLine()) != "End")
            {
                //Drive { carModel}                { amountOfKm}
                string[] command = newInput
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = command[1];
                double amountOfKm = double.Parse(command[2]);

                Car currentCar = cars.Find(car => car.Model == model);

                currentCar = currentCar.Drive(currentCar, amountOfKm);
                cars.Find(car => car.Model == model).TravelledDistance = currentCar.TravelledDistance;
            }

            //

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
