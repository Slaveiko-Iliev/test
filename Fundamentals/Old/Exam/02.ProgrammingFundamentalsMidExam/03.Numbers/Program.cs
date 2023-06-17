using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace _03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select (int.Parse)
                .ToArray ();

            List<int> sortedNumbers = new List<int> ();
            int count = 0;
            double averageNumber = numbers.Average();

            Array.Sort(numbers);
            Array.Reverse (numbers);

            for (int i = 0; i < numbers.Length && count < 5; i++)
            {
                if (numbers[i] > averageNumber)
                {
                    sortedNumbers.Add(numbers[i]);
                    count++;
                }
            }

             sortedNumbers = sortedNumbers.OrderByDescending(x => x).ToList();

            if (count > 0)
            {
                Console.WriteLine(string.Join(" ", sortedNumbers));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
