using System.Runtime.ConstrainedExecution;

namespace _01.Vehicles.Models.Interfaces
{
    public interface IVehicle
    {


        public double FuelQuantity { get; }
        public double FuelConsumption { get;}

        public void Drive(double distance);
        public void Refuel(double liters);
    }
}