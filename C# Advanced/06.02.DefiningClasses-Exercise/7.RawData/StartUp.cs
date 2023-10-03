using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.RawData
{
    public class StartUp
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<Car> cars = new ();

            for (int i = 0; i < number; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];

                float tire1Pressure = float.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                tires[0] = new Tire(tire1Pressure, tire1Age);
                float tire2Pressure = float.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                tires[1] = new Tire(tire2Pressure, tire2Age);
                float tire3Pressure = float.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                tires[2] = new Tire(tire3Pressure, tire3Age);
                float tire4Pressure = float.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);
                tires[3] = new Tire(tire4Pressure, tire4Age);

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            foreach (var car in cars)
            {
                if (car.Cargo.Type == command && car.Tires.Any(x => x.Pressure < 1))
                {
                    Console.WriteLine(car.Model);
                }
                else if (car.Cargo.Type == command && car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
