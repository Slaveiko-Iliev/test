using _01.Vehicles.Models.Interfaces;

namespace _02.VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        public double FuelQuantity => throw new NotImplementedException();

        public double FuelConsumption => throw new NotImplementedException();

        public void Drive(double distance)
        {
            throw new NotImplementedException();
        }

        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }
    }
}
