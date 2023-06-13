using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace _07.EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine()
                .Split(' ').
                Select(int.Parse).
                ToArray();
            int[] array2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int sumOfElements = 0;
            bool areIdentical = true;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    areIdentical = false;
                    break;
                }
                sumOfElements += array1[i];
            }
            if (areIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumOfElements}");
            }
        }
    }
}
