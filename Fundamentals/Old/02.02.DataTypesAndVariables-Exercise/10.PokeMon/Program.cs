using System;

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

            while (currentPower >= distance)
            {
                currentPower -= distance;
                countOfTargets++;
                if (pokePower / currentPower == 2)
                {
                    if (currentPower / exhaustionFactor != 0)
                    {
                        currentPower /= exhaustionFactor;
                    }
                }
            }
            Console.WriteLine(currentPower);
            Console.WriteLine(countOfTargets);
        }
    }
}
