using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> hitPowerAppliedSet = new List<int>();
            foreach (int drum in drumSet)
            {
                hitPowerAppliedSet.Add(drum);
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < hitPowerAppliedSet.Count; i++)
                {
                    double priceOfDrum = drumSet[i] * 3;

                    hitPowerAppliedSet[i] -= hitPower;

                    if (hitPowerAppliedSet[i] <= 0 && savings >= priceOfDrum)
                    {
                        hitPowerAppliedSet[i] = drumSet[i];
                        savings -= priceOfDrum;
                    }
                    else if (hitPowerAppliedSet[i] <= 0 && savings < priceOfDrum)
                    {
                        hitPowerAppliedSet.RemoveAt(i);
                        drumSet.RemoveAt(i);

                         i -= 1;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", hitPowerAppliedSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
