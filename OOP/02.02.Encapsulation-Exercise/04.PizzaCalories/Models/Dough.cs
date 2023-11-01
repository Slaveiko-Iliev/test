

using System.ComponentModel;

namespace _04.PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCalories = 2;
        private double grams;
        private string flourType;
        private string bakingTechnique;
        private Dictionary<string, double> flourModifiers = new Dictionary<string, double>()
        {
            { "White", 1.5 },
            { "Wholegrain", 1.0 },
            { "Crispy", 0.9 },
            { "Chewy", 1.1 },
            { "Homemade", 1.0 }
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
                if (!flourModifiers.ContainsKey(value))
                {
                    throw new ArgumentException(ExceptionMessages.TypeOfDough);
                }
                flourType = value;
            }
        }
        private string BakingTechnique
        {
            get => bakingTechnique;
            init
            {
                if (!flourModifiers.ContainsKey(value))
                {
                    throw new ArgumentException(ExceptionMessages.TypeOfDough);
                }
                bakingTechnique = value;
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

        public string GetDoughCalories() => $"{Grams * BaseCalories * flourModifiers[FlourType] * flourModifiers[BakingTechnique]:f2}";
    }
}
