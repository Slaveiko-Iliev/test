using System;

namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int testNumber = number;
            int sumOfproduct = 0;

            while (testNumber > 0)
            {
                int lastDigit = testNumber % 10;
                int product = 1;

                for (int i = 1; i <= lastDigit; i++)
                {
                    product *= i;
                }
                sumOfproduct += product;

                testNumber /= 10;
            }

            if (sumOfproduct == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
