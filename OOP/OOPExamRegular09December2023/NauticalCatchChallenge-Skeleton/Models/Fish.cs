using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string _name;
        private double _points;

        public Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name should be determined.");
                }
                _name = value;
            }
        }

        public double Points
        {
            get => _points;
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Points must be a numeric value, between 1 and 10.");
                }
                _points = value;
            }
        }

        public int TimeToCatch { get; private set; }
        public override string ToString()
        {
            return $"{GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
