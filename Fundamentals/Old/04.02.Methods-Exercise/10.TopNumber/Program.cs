using System;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endValue = int.Parse(Console.ReadLine());

            for (int i = 1; i <= endValue; i++)
            {
                bool isDivisibleBy8 = GetIsDivisibleBy8(i);
                bool isOneOdd = GetIsOneOdd(i);
                if (isDivisibleBy8 && isOneOdd)
                {
                    Console.WriteLine(i);
                }
            }

        }

        private static bool GetIsDivisibleBy8(int i)
        {
            bool isDivisibleBy8 = false;
            int sumOfDigit = 0;
            while (i > 0)
            {
                int currentDigit = i % 10;
                sumOfDigit += currentDigit;
                i /= 10;
            }

            if (sumOfDigit % 8 == 0)
            {
                isDivisibleBy8 = true;
            }

            return isDivisibleBy8;
        }

        private static bool GetIsOneOdd(int i)
        {
            bool isOneOdd = false;

            while (i > 0)
            {
                int currentDigit = i % 10;
                if (currentDigit % 2 != 0)
                {
                    isOneOdd = true;
                    //break;
                }
                i /= 10;
            }
            return isOneOdd;
        }
    }
}
