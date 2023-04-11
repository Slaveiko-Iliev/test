using System;

namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfKegs = int.Parse(Console.ReadLine());

            string bigestKeg = string.Empty;
            double maxVolume = 0;
            
            for (int i = 0; i < countOfKegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius,2) * height;
                if (volume >= maxVolume)
                {
                    bigestKeg = model;
                    maxVolume = volume;
                }
            }

            Console.WriteLine(bigestKeg);
        }
    }
}
