using System;

namespace _03.ExactSumOfRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 1; i <= count; i++)
            {
                decimal input = decimal.Parse(Console.ReadLine());
                sum += input;
            }
            Console.WriteLine(sum);
        }
    }
}
