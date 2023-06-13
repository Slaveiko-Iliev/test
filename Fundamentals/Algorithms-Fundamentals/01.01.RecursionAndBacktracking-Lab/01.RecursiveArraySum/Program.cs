using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int sumOfNumbers = GetSum(numbers, 0);
            Console.WriteLine(sumOfNumbers);
        }

        static int GetSum(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                return 0;
            }

            return numbers[index] + GetSum(numbers, index + 1);
        }
    }
}
