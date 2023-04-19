using System;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());

            int[] train = new int[numberOfWagons];
            int sumOfPassengers = 0;


            for (int i = 0; i < numberOfWagons; i++)
            {
                train [i] = int.Parse(Console.ReadLine());
                sumOfPassengers += train[i];
            }
            foreach (int passengers in train)
            {
                Console.Write($"{passengers} ");
            }
            Console.WriteLine();
            Console.WriteLine(sumOfPassengers);
        }
    }
}
