using System;

namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int sumOfEven = GetSum(number, true);
            int sumOfOdd = GetSum(number, false);
            int multipleOfEvenAndOdds = sumOfEven * sumOfOdd;
            Console.WriteLine(multipleOfEvenAndOdds);
        }

        private static int GetSum(int number, bool isEven)
        {
            

            if (isEven)
            {
                int sumOfEven = 0;

                while (number > 0)
                {
                    int currentNumber = number % 10;

                    if (currentNumber % 2 == 0)
                    {
                        sumOfEven += currentNumber;
                    }
                    number /= 10;
                }
                return sumOfEven;
            }
            else
            {
                int sumOfOdd = 0;

                while (number > 0)
                {
                    int currentNumber = number % 10;

                    if (currentNumber % 2 != 0)
                    {
                        sumOfOdd += currentNumber;
                    }
                    number /= 10;
                }
                return sumOfOdd;
            }
        }

        //static void Main(string[] args)
        //{
        //    int number = Math.Abs(int.Parse(Console.ReadLine()));

        //    int sumOfEven = GetSumOfEvenDigits(number);
        //    int sumOfOdd = GetSumOfOddDigits(number);
        //    int multipleOfEvenAndOdds = GetMultipleOfEvenAndOdds(sumOfEven, sumOfOdd);
        //    Console.WriteLine(multipleOfEvenAndOdds);
        //}

        //private static int GetMultipleOfEvenAndOdds(int sumOfEven, int sumOfOdd)
        //{
        //    int multipleOfEvenAndOdds = sumOfEven * sumOfOdd;
        //    return multipleOfEvenAndOdds;
        //}

        //private static int GetSumOfEvenDigits(int number)
        //{
        //    int sumOfEven = 0;

        //    while (number > 0)
        //    {
        //        int currentNumber = number % 10;
        //        if (currentNumber % 2 == 0)
        //        {
        //            sumOfEven += currentNumber;
        //        }
        //        number /= 10;
        //    }
        //    return sumOfEven;
        //}

        //static int GetSumOfOddDigits(int number)
        //{
        //    int sumOfOdd = 0;

        //    while (number > 0)
        //    {
        //        int currentNumber = number % 10;
        //        if (currentNumber % 2 != 0)
        //        {
        //            sumOfOdd += currentNumber;
        //        }
        //        number /= 10;
        //    }
        //    return sumOfOdd;
        //}
    }
}
