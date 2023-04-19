using System;
using System.Linq;

namespace _05.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' '). Select(int.Parse).ToArray();

            

            for (int i = 0; i < numbers.Length; i++)
            {
                int greater = 0;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        greater = numbers [i];
                    }
                    else
                    {
                        greater = 0;
                        break;
                    }
                }
                if (greater > 0)
                {
                    Console.Write($"{greater} ");
                }
            }
            Console.WriteLine(numbers [numbers.Length - 1]);
        }
    }
}
