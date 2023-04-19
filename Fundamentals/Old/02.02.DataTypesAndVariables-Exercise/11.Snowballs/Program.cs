using System;
using System.Numerics;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfSnowballs = int.Parse(Console.ReadLine());
            BigInteger maxSnowballValue = 0;
            int maxSnowballSnow = 0;
            int maxSnowballTime = 0;
            int maxSnowballQuality = 0;


            for (int i = 0; i < numOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowballValue > maxSnowballValue)
                {
                    maxSnowballValue = snowballValue;
                    maxSnowballSnow = snowballSnow;
                    maxSnowballTime = snowballTime;
                    maxSnowballQuality = snowballQuality;
                }

            }


            Console.WriteLine($"{maxSnowballSnow} : {maxSnowballTime} = {maxSnowballValue} ({maxSnowballQuality})");






            //int numberOfSnowballs = int.Parse(Console.ReadLine());

            //int snowballSnow = 0;
            //int snowballTime = 0;
            //int snowballQuality = 0;
            //int highestValue = int.MinValue;
            //double snowballValue = 0;


            //for (int i = 0; i < numberOfSnowballs; i++)
            //{
            //    snowballSnow = int.Parse(Console.ReadLine());
            //    snowballTime = int.Parse(Console.ReadLine());
            //    snowballQuality = int.Parse(Console.ReadLine());

            //    snowballValue = Math.Pow(snowballSnow / snowballTime, snowballQuality);

            //    if (snowballValue > highestValue)
            //    {
            //        highestValue = (int)snowballValue;
            //    }
            //}
            //Console.WriteLine($"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})");
        }
    }
}
