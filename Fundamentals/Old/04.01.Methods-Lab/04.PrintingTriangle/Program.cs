using System;

namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            TriangleIncrease(number);
            TriangleDecreasing(number);
        }

        private static void TriangleIncrease(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintLine(i);
            }
        }

        private static void TriangleDecreasing(int number)
        {
            for (int i = number - 1; i >= 0; i--)
            {
                PrintLine (i);
            }
        }

        static void PrintLine(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
