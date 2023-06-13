using System;

namespace _01.GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double food = double.Parse(Console.ReadLine());
            double hay = double.Parse(Console.ReadLine());
            double cover = double.Parse(Console.ReadLine());
            double guineasWeight = double.Parse(Console.ReadLine());
            bool isEnough = true;

            for (int i = 1; i <= 30; i++)
            {
                food -= 0.3;
                if (Math.Round(food) <= 0)
                {
                    isEnough = false;
                    break;
                }
                if (i % 2  == 0)
                {
                    hay -= (0.05 * food);
                    if (hay <= 0)
                    {
                        isEnough = false;
                        break;
                    }
                }
                if (i % 3 == 0)
                {
                    cover -= guineasWeight / 3;
                    if (cover <= 0)
                    {
                        isEnough = false;
                        break;
                    }
                }
            }
            if (isEnough)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {food:f2}, Hay: {hay:f2}, Cover: {cover:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}
