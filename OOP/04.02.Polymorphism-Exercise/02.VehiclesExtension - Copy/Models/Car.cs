using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Models
{
    public class Car : IVehicle
    {
        private const double SummerCorrection = 0.9;
        private double _fuelQuantity;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => _fuelQuantity;
            private set
            {
                if (TankCapacity < value)
                {
                    _fuelQuantity = 0;
                }
                else
                {
                    _fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

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
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity + liters > TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    FuelQuantity += liters;
                }
            }


        }
    }
}
