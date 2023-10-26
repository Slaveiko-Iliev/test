using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Snake snake = new Snake(name);
            Lizard lizard = new Lizard(name);
            Gorilla gorilla = new Gorilla(name);
            Bear bear = new Bear(name);

            Console.WriteLine(snake.Name);
            Console.WriteLine(lizard.Name);
            Console.WriteLine(gorilla.Name);
            Console.WriteLine(bear.Name);
        }
    }
}