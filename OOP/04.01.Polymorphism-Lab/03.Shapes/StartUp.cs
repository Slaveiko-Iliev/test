using Shapes.Models;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Circle circle = new(5);
            Rectangle rectangle = new(5,5);

            Console.WriteLine($"{circle.CalculatePerimeter():f2}");
            Console.WriteLine($"{circle.CalculateArea():f2}");
            Console.WriteLine(circle.Draw());
            
            Console.WriteLine($"{rectangle.CalculatePerimeter():f2}");
            Console.WriteLine($"{rectangle.CalculateArea():f2}");
            Console.WriteLine(rectangle.Draw());
        } 
    }
}
