using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine()
                .Split('|');

            List<int> finalArrayAsList = new List<int>();

            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                int[] currentArray = inputArray[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                finalArrayAsList.AddRange(currentArray);
            }

            Console.WriteLine(string.Join(" ", finalArrayAsList));
        }
    }
}
