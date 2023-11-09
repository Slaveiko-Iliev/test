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

        public Truck(double fuelQuantity, double fuelConsumption)
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
            FuelQuantity += liters * LeakageCorrection;
        }
    }
}
