using System;
using System.Linq;

namespace _02.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            double sumOfCarOne = 0;
            double sumOfCarTwo = 0;

            sumOfCarOne = TakeTotalOfCarOne(numbers, sumOfCarOne);
            sumOfCarTwo = TakeTotalOfCarTwo(numbers, sumOfCarTwo);

            if (sumOfCarOne < sumOfCarTwo)
            {
                Console.WriteLine($"The winner is left with total time: {sumOfCarOne}");
            }
            else if (sumOfCarOne >= sumOfCarTwo)
            {
                Console.WriteLine($"The winner is right with total time: {sumOfCarTwo}");
            }
        }

        static double TakeTotalOfCarOne(int[] numbers, double sumOfCarOne)
        {
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                if (numbers[i] == 0)
                {
                    sumOfCarOne *= 0.8;
                }
                else
                {
                    sumOfCarOne += numbers[i];
                }
            }

            return sumOfCarOne;
        }

        static double TakeTotalOfCarTwo(int[] numbers, double sumOfCarTwo)
        {
            for (int i = numbers.Length - 1; i > numbers.Length / 2; i--)
            {
                
                if (numbers[i] == 0)
                {
                    sumOfCarTwo *= 0.8;
                }
                else
                {
                    sumOfCarTwo += numbers[i];
                }
            }

            return sumOfCarTwo;
        }
    }
}
