using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class Peak : IPeak
    {
        private string _name;
        private int _elevation;

        public Peak(string name, int elevation, string difficultyLevel)
        {
            Name = name;
            Elevation = elevation;
            DifficultyLevel = difficultyLevel;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Peak name cannot be null or whitespace.");
                }
                _name = value;
            }
        }

        public int Elevation
        {
            get => _elevation;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Peak elevation must be a positive value.");
                }
                _elevation = value;
            }
        }

        public string DifficultyLevel { get; private set; }

        public override string ToString() => $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
    }
}
