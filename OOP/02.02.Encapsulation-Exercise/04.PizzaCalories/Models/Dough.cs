

using System.ComponentModel;

namespace _04.PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCalories = 2;
        private double grams;
        private string flourType;
        private string bakingTechnique;
        private readonly Dictionary<string, double> flourTypeModifiers = new Dictionary<string, double>()
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 }
        };
        private readonly Dictionary<string, double> flourTechniqueModifiers = new Dictionary<string, double>()
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "comemade", 1.0 }
        };

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        private string FlourType
        {
            get => flourType;
            init
            {
                if (!flourTypeModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessages.TypeOfDough);
                }
                flourType = value.ToLower();
            }
        }
        private string BakingTechnique
        {
            get => bakingTechnique;
            init
            {
                if (!flourTechniqueModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessages.TypeOfDough);
                }
                bakingTechnique = value.ToLower();
            }
        }
        public double Grams
        {
            get => this.grams;
            init
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ExceptionMessages.DoughWeight);
                }
                grams = value;
            }
        }

        public double GetDoughCalories() => Grams * BaseCalories * flourTypeModifiers[FlourType] * flourTechniqueModifiers[BakingTechnique];
    }
}
