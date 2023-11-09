using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Models
{
    public class Car : IVehicle
    {
        private const double SummerCorrection = 0.9;
        
        public Car(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            if ((FuelConsumption + SummerCorrection) * distance <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumption + SummerCorrection) * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        public void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
