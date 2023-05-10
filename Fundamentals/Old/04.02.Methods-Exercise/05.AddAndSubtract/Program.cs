using System;
using System.Collections.Generic;

namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sumOfFirstTwo = GetSum(firstNumber, secondNumber);
            int quotientOfSumAndThird = GetQuotient(sumOfFirstTwo, thirdNumber);

            Console.WriteLine(quotientOfSumAndThird);
        }

        private static int GetSum(int firstNumber, int secondNumber)
        {
            int sumOfFirstTwo = firstNumber + secondNumber;
            return sumOfFirstTwo;
        }

        private static int GetQuotient(int sumOfFirstTwo, int thirdNumber)
        {
            int quotientOfSumAndThird = sumOfFirstTwo - thirdNumber;
            return quotientOfSumAndThird;
        }
    }
}
