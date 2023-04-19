using System;

namespace _04.RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int number = 2; number <= N; number++)
            {
                bool IsPrime = true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        IsPrime = false;
                        break;
                    }
                }
                if (IsPrime)
                {
                    Console.WriteLine($"{number} -> true");
                }
                else
                {
                    Console.WriteLine($"{number} -> false");
                }
            }
            
        }
    }
}
