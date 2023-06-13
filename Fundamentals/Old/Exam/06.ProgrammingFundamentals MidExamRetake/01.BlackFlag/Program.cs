using System;
using System.Collections.Generic;

namespace _01.BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double actualPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                actualPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    actualPlunder += (dailyPlunder * 0.5);
                }

                if (i % 5 == 0)
                {
                    actualPlunder *= 0.7;
                }

            }

            double percentageOfPlunder = actualPlunder / expectedPlunder * 100;

            if (actualPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {actualPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {percentageOfPlunder:f2}% of the plunder.");
            }
        }
    }
}
