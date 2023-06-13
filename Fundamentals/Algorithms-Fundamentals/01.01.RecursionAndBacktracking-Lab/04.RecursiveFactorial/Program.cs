using System;

namespace _04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int factorial = 1;

            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);

            //int number = int.Parse(Console.ReadLine());

            //int factorialOfN = RecursiveFactorial(number);

            //Console.WriteLine(factorialOfN);
        }

        //static int RecursiveFactorial(int number)
        //{
        //    if (number == 1)
        //    {
        //        return 1;
        //    }
            
        //    int factorialOfN = number * RecursiveFactorial(number - 1);

        //    return factorialOfN;
        //}
    }
}
