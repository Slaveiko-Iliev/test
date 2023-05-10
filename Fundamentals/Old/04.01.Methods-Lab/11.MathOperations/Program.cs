using System;

namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string sign = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());

            double result = GetResult (firstNumber, sign, secondNumber);
            Console.WriteLine (result);
        }

        static double GetResult (double firstNumber, string sign, double secondNumber)
        {
            double result = 0;

            if (sign == "/")
            {
                result = firstNumber / secondNumber;
            }
            else if (sign == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (sign == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (sign == "-")
            {
                result = firstNumber - secondNumber;
            }
            return result;
        }
    }
}
