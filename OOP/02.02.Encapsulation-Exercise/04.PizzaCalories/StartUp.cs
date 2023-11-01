using _04.PizzaCalories.Models;
using System.ComponentModel;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        public static void Main()
        {
            Dough dough = new Dough("White", "Chewy", 240);
            Console.WriteLine(dough.GetDoughCalories());
        }
    }
}
//Tip500 Chewy 100
//White Chewy 240