using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.CarSalesman
{
    public class StartUp
    {
        public static void Main()
        {
            List<Engine> engines = new();
            int numberOfEngine = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngine; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries) ;

                string model = engineInfo[0] ;
                int power = int.Parse(engineInfo[1]) ;
                int displacement = 0;
                string efficiency = string.Empty;

                string pattern = @"\d";
                Regex regex = new Regex(pattern) ;

                if (engineInfo.Length > 2 && regex.IsMatch(engineInfo[2]))
                {
                    displacement = int.Parse(engineInfo[2]) ;
                }
                else if (engineInfo.Length > 2 && !regex.IsMatch(engineInfo[2]))
                {
                    efficiency = engineInfo[2];
                }

                if (engineInfo.Length == 4)
                {
                    efficiency = engineInfo[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);

                //if (displacement != 0)
                //{
                //    engine.Displacement = displacement ;
                //}

                //if (efficiency != string.Empty)
                //{
                //    engine.Efficiency = efficiency ;
                //}

                engines.Add(engine);
            }
            
            int numberOfCar = int.Parse (Console.ReadLine()) ;
            List<Car> cars = new();

            for (int i = 0; i < numberOfCar; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                Engine engine = engines.Find(engine => engine.Model == carInfo[1]);
                int weight = 0;
                string color = string.Empty;

                string pattern = @"\d";
                Regex regex = new Regex(pattern);

                if (carInfo.Length > 2 && regex.IsMatch(carInfo[2]))
                {
                    weight = int.Parse(carInfo[2]);
                }
                else if (carInfo.Length > 2 && !regex.IsMatch(carInfo[2]))
                {
                    color = carInfo[2];
                }

                if (carInfo.Length == 4)
                {
                    color = carInfo[3];
                }

                Car car = new Car(model, engine, weight, color);

                //if (weight != 0)
                //{
                //    car.Weight = weight;
                //}
                //if (color != string.Empty)
                //{
                //    car.Color = color;
                //}

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
