using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string _name;
        private int _oxygenLevel;
        private List<string> _catch;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            _catch = new List<string>();
            CompetitionPoints = 0;
            HasHealthIssues = false;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Diver's name cannot be null or empty.\"");
                }
                _name = value;
            }
        }

        public int OxygenLevel
        {
            get => _oxygenLevel;
            protected set //ToDo
            {
                _oxygenLevel = value;
                if (_oxygenLevel < 0)
                {
                    _oxygenLevel = 0;
                }
            }
        }

        public IReadOnlyCollection<string> Catch => _catch.AsReadOnly();

        public double CompetitionPoints { get; private set; } // ? rounded to the first decimal place.

        public bool HasHealthIssues { get; private set; }

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            this._catch.Add(fish.Name);
            this.CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            if (this.HasHealthIssues)
            {
                this.HasHealthIssues = false;
            }
            else
            {
                this.HasHealthIssues = true;
            }
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {_catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
