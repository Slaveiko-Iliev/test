

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double _defaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) : base (horsePower, fuel)
        {
        }

        public override double FuelConsumption => _defaultFuelConsumption;
    }
}
