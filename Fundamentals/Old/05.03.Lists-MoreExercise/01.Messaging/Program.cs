using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _01.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string word = Console.ReadLine();

            string message = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int sumOfCurrentDigit = 0;
                int number = numbers[i];

                while (number > 0)
                {
                    sumOfCurrentDigit += (number % 10);
                    number /= 10;
                }

                int positionOfWantedItem = sumOfCurrentDigit % word.Length;

                message += word[positionOfWantedItem];
                word = word.Remove(positionOfWantedItem, 1);
            }

            Console.WriteLine(message);
        }
    }

    //static char TakeCorrespondingElement(string word, int sumOfCurrentDigit)
    //{
    //    return element;
    //}
}
