using System.Runtime.CompilerServices;

namespace _04.PizzaCalories.Models
{
    public static class ExceptionMessages
    {
        public const string TypeOfDough = "Invalid type of dough.";
        public const string DoughWeight = "Dough weight should be in the range [1..200].";
        public const string PizzaNameLength = "Pizza name should be between 1 and 15 symbols.";
        public const string NumberOfToppings = "Number of toppings should be in range [0..10].";
    }
}
