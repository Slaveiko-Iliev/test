using System;

namespace _03.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int fibonacciSum = GetFibonacci(number);

            Console.WriteLine(fibonacciSum);

            //int[] fibonacciArray = new int[number];

            //if (number <= 2)
            //{
            //    Console.WriteLine(1);
            //}
            //else
            //{
            //    fibonacciArray[0] = 1;
            //    fibonacciArray[1] = 1;

            //    for (int i = 2; i < fibonacciArray.Length; i++)
            //    {
            //        fibonacciArray[i] = fibonacciArray[i - 1] + fibonacciArray[i - 2];
            //    }

            //    Console.WriteLine(fibonacciArray[fibonacciArray.Length - 1]);
            //}
            


        }

        private static int GetFibonacci(int number)
        {
            if (number == 2 || number == 1)
            {
                return 1;
                
            }
            
            int fibonacciSumN = GetFibonacci(number - 1) + GetFibonacci(number - 2);
            
            return fibonacciSumN;
        }
    }
}
