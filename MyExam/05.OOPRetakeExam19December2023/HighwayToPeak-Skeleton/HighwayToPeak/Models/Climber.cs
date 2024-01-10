using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string _name;
        private int _stamina;
        private List<string> _conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            _conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Climber's name cannot be null or whitespace.");
                }
                _name = value;
            }
        }

        public int Stamina
        {
            get => _stamina;
            protected set
            {
                _stamina = value;
                if (value < 0)
                {
                    _stamina = 0;
                }
                else if (value > 10)
                {
                    _stamina = 10;
                }
                
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => _conqueredPeaks.AsReadOnly();

        public void Climb(IPeak peak)
        {
            if (!this.ConqueredPeaks.Contains(peak.Name))
            {
                this._conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                this.Stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                this.Stamina -= 4;
            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                this.Stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");

            if (this.ConqueredPeaks.Count == 0)
            {
                sb.AppendLine("Peaks conquered: no peaks conquered");
            }
            else
            {
                sb.AppendLine($"Peaks conquered: {this.ConqueredPeaks.Count}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
