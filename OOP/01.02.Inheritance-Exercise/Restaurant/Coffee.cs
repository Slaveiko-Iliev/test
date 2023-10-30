

using System.Threading;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double _coffeeMilliliters = 50;
        private const decimal _coffeePrice = 3.50m;


        public Coffee(string name, double caffeine) : base(name, _coffeePrice, _coffeeMilliliters)
        {
            Caffeine = caffeine;
        }
                
        public double Caffeine { get; private set; }
    }
}
