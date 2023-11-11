using _01.Vehicles.Models.Interfaces;

namespace _01.Vehicles.Models
{
    public class Bus : IVehicle
    {
        private const double DriveWirhPeople = 1.4;
        private double fuelQuantity;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
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

        public void Drive(double distance, bool IsPeopleInBus)
        {
            double currentFuelConsumption = (FuelConsumption + DriveWirhPeople) * distance;


            if (!IsPeopleInBus)
            {
                currentFuelConsumption = FuelConsumption * distance;
            }

            
            if (currentFuelConsumption <= FuelQuantity)
            {
                FuelQuantity -= currentFuelConsumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        public void Refuel(double liters)
        {
            if(TankCapacity >= fuelQuantity + liters)
            {
                FuelQuantity += liters;
            }
            else
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            
        }

    }
}
