using System;
using System.Numerics;

namespace _10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int countOfTargets = 0;
            int currentPower = pokePower;
            double percent = (double)pokePower * 0.50;
            while (currentPower >= distance)
            {
                currentPower -= distance;
                countOfTargets++;
                if (currentPower == percent && exhaustionFactor != 0)
                    {
                    currentPower /= exhaustionFactor;
                }
            }
            Console.WriteLine(currentPower);
            Console.WriteLine(countOfTargets);

            //int pokePower = int.Parse(Console.ReadLine());
            //int distance = int.Parse(Console.ReadLine());
            //int exhaustionFactor = int.Parse(Console.ReadLine());

            //int countOfTargets = 0;
            //int currentPower = pokePower;

            //while (currentPower >= distance)
            //{
            //    currentPower -= distance;
            //    countOfTargets++;
            //    if (pokePower / currentPower == 2 && pokePower % currentPower == 0 && exhaustionFactor != 0)
            //    {
            //            currentPower /= exhaustionFactor;
            //    }
            //}
            //Console.WriteLine(currentPower);
            //Console.WriteLine(countOfTargets);
        }
    }
}
