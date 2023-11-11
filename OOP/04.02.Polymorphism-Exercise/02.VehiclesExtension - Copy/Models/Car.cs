using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Models
{
    public class Car : IVehicle
    {
        private const double SummerCorrection = 0.9;
        private double fuelQuantity;

        public Car (double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value > TankCapacity) { value = 0; }
                fuelQuantity = value;
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; init; }

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
