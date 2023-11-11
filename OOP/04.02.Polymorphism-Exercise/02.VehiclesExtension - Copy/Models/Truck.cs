using _01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models
{
    public class Truck : IVehicle
    {
        private const double SummerCorrection = 1.6;
        private const double LeakageCorrection = 0.95;
        private double fuelQuantity;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
            FuelQuantity += liters * LeakageCorrection;
        }
    }
}
