using System;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());

            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            int highestValue = int.MinValue;
            int snowballValue = 0;


            for (int i = 0; i < numberOfSnowballs; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());

                snowballValue = (snowballSnow / snowballTime) * snowballQuality * snowballQuality;

                if (snowballValue > highestValue)
                {
                    highestValue = snowballValue;
                }
            }
            Console.WriteLine($"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})");
        }
    }
}
