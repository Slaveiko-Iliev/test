using System;

namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double raisedBase = GetraisedBase(number, power);
            Console.WriteLine(raisedBase);
        }

        private static double GetraisedBase(double number, double power)
        {
            double raisedBase = 1;


            for (int i = 0; i < power; i++)
            {
                raisedBase *= number;
            }

            return raisedBase;
        }
    }
}
