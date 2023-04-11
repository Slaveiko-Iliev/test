using System;

namespace _02.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int countOfLetter = text.Length;
            int number = int.Parse(text);
            int sumOfDigit = 0;

            for (int i = 0; i < countOfLetter; i++)
            {
                int lastDigit = number % 10;
                sumOfDigit += lastDigit;
                number = number / 10;
            }
            Console.WriteLine(sumOfDigit);
        }
    }
}
