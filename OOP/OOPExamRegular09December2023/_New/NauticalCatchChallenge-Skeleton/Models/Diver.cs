using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string _name;
        private int _oxygenLevel;
        private List<string> _catch;
        private double _competitionPoints;

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
                    throw new ArgumentException("Diver's name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public int OxygenLevel
        {
            get => _oxygenLevel;
            protected set
            {
                _oxygenLevel = value;
                if (OxygenLevel < 0)
                {
                    OxygenLevel = 0;
                }
            }
        }

        public IReadOnlyCollection<string> Catch => _catch.AsReadOnly();

        public double CompetitionPoints
        {
            get => Math.Round(_competitionPoints);
            private set
            {
                _competitionPoints = value;
            }
        }

        public bool HasHealthIssues { get; private set; }

        public void Hit(IFish fish)
        {
            this.OxygenLevel -= fish.TimeToCatch;
            _catch.Add(fish.Name);
            this.CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus() => this.HasHealthIssues = !this.HasHealthIssues;

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {_catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
