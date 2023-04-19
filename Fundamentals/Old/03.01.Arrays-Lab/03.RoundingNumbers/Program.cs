using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            foreach (double number in array)
            {
                int rounded = (int)Math.Round(number, MidpointRounding.AwayFromZero);
                Console.WriteLine("{0} => {1}", number, rounded);
            }

            //Това е моето:
            //double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine($"{numbers[i]} => {Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
            //}
        }
    }
}
