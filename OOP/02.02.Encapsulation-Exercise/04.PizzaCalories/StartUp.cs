using _04.PizzaCalories.Models;
using System.ComponentModel;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        public static void Main()
        {
			try
			{
                string pizzaInfo = Console.ReadLine();
                string pizzaName = pizzaInfo.Replace("Pizza ", "");
                Pizza pizza = new Pizza(pizzaName);

                string[] doughInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string flourType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
                double grams = double.Parse(doughInfo[3]);
                Dough dough = new Dough(flourType, bakingTechnique, grams);
                pizza.PizzaDough = dough;

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string toppingType = toppingInfo[1];
                    grams = double.Parse(toppingInfo[2]);
                    Topping topping = new Topping(toppingType, grams);
                    pizza.AddToppings(topping);
                }

                Console.WriteLine(pizza.ToString());
            }
			catch (ArgumentException ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
    }
}
