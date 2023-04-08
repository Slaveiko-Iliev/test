using System;

namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Предложеното решение не е само за нечетни числа?
            
            int n = int.Parse(Console.ReadLine());
            int oddSum = default(int);

                for (int i = 1; 0 < n; i += 2)
                {
                    oddSum += i;
                    n--;
                    Console.WriteLine(i);
                }

            Console.WriteLine($"Sum: {oddSum}");
        }
    }
}
