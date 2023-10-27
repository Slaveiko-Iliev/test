

namespace NeedForSpeed
{
    public class Vehicle
    {
		private int _hordePower;
		private double _fuel;
        private const double _defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower
		{
			get { return _hordePower; }
			set { _hordePower = value; }
		}
        public double Fuel
        {
            get { return _fuel; }
            set { _fuel = value; }
        }
        
        public virtual double FuelConsumption { get { return _defaultFuelConsumption; } }

        public virtual void Drive(double kilometers)
        {
            Fuel -= this.FuelConsumption * kilometers;
        }
    }
}

