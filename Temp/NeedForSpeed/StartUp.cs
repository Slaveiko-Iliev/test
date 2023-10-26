using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(200, 100);
            Car car = new Car(200, 100);
            SportCar sportCar = new SportCar(200, 100);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(200, 100);

            vehicle.Drive(10);
            car.Drive(10);
            sportCar.Drive(10);
            raceMotorcycle.Drive(10);


            Console.WriteLine(vehicle.Fuel);
            Console.WriteLine(car.Fuel);
            Console.WriteLine(sportCar.Fuel);
            Console.WriteLine(raceMotorcycle.Fuel);
        }
    }
}
