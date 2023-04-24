using System;
using System.Linq;
using System.Xml;

namespace _08.MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int givenNumber = int.Parse(Console.ReadLine());

            for (int firstOfPair = 0; firstOfPair < array.Length - 1; firstOfPair++)
            {
                for (int secondOfPair = firstOfPair + 1; secondOfPair < array.Length; secondOfPair++)
                {
                    if (array[firstOfPair] + array[secondOfPair] == givenNumber)
                    Console.WriteLine($"{array[firstOfPair]} {array[secondOfPair]}");
                }
            }
            

        }
    }
}
