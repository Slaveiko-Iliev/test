using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int number = 1; number <= n; number++)
            {
                int currentNumber = number;
                int sumOfDigit = 0;
                while (currentNumber > 0)
                {
                    int lastDigit = currentNumber % 10;
                    sumOfDigit += lastDigit;
                    currentNumber /= 10;
                }
                if (sumOfDigit == 5 || sumOfDigit == 7 || sumOfDigit == 11)
                {
                    Console.WriteLine($"{number} -> True");
                }
                else
                {
                    Console.WriteLine($"{number} -> False");
                }
            }
        }
    }
}
