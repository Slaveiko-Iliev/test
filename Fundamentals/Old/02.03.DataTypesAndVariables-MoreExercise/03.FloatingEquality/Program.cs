using System;

namespace _03.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());

            bool isEqual = false;
            double eps = 0.000001;

            double diff = Math.Abs(numberA - numberB);
            if (diff < eps)
            {
                isEqual = true;
            }
            Console.WriteLine(isEqual);
        }
    }
}
