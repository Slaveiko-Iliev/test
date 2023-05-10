using System;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double firstFactorial = GetFactorial(firstNumber);
            double secondFactorial = GetFactorial(secondNumber);
            double divideFirstBySecond = firstFactorial / secondFactorial;
            Console.WriteLine($"{divideFirstBySecond:f2}");
        }

        static double GetFactorial(double number)
        {
            double factorial = 1;
            
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
