using System;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            int volumeOfTank = 255;
            int sumOfQuantities = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                int quantitiesOfWater = int.Parse(Console.ReadLine());
                if (quantitiesOfWater > (volumeOfTank - sumOfQuantities))
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sumOfQuantities += quantitiesOfWater;
                }
            }
            Console.WriteLine(sumOfQuantities);
        }
    }
}
