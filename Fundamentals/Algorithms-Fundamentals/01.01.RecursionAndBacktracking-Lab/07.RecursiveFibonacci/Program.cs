using System;

namespace _07.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(number));
        }

        private static int GetFibonacci(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            
            int fibonacciOfN = GetFibonacci(number - 1) + GetFibonacci(number - 2);
            
            
        }
    }
}
