using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string _name;
        private double _points;

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
                if ()
            }
        }

        public int TimeToCatch => throw new NotImplementedException();
    }
}
