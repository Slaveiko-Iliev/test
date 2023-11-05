

using System.Runtime.CompilerServices;

namespace _04.PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCalories = 2;
        private double grams;
        private string toppingType;
        private readonly Dictionary<string, double> toppingModifiers = new Dictionary<string, double>()
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 },
        };

        public Topping(string toppingType, double grams)
        {
            ToppingType = toppingType;
            Grams = grams;
        }

        private string ToppingType
        {
            get => toppingType;
            init
            {
                if (!toppingModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value.ToLower();
            }
        }
        public double Grams
        {
            get => grams;
            init
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }

        public double GetToppingCalories() => Grams * BaseCalories * toppingModifiers[ToppingType];
    }
}
