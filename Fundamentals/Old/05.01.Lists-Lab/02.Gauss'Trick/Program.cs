using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                numbers[i] += numbers[numbers.Count - 1 - i];
            }

            if (numbers.Count % 2 == 0)
            {
                numbers.RemoveRange(numbers.Count / 2, numbers.Count - numbers.Count / 2);
            }
            else
            {
                numbers.RemoveRange(numbers.Count / 2 + 1, numbers.Count - 1 - numbers.Count / 2);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
