using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToList();
            string input = string.Empty;

            int CupidsLastPosition = 0;
            int countOfFailed = 0;

            while ((input = Console.ReadLine()) != "Love!")
            {
                List<string> command = input
                    .Split(" ")
                    .ToList();
                
                int CupidsJump = int.Parse(command[1]);

                CupidsLastPosition += CupidsJump;

                if (!IsValidIndex(neighborhood, CupidsLastPosition))
                {
                    CupidsLastPosition = 0;
                }

                if (neighborhood[CupidsLastPosition] == 0)
                {
                    Console.WriteLine($"Place {CupidsLastPosition} already had Valentine's day.");
                    continue;
                }

                neighborhood[CupidsLastPosition] -= 2;

                if (neighborhood[CupidsLastPosition] == 0)
                {
                    Console.WriteLine($"Place {CupidsLastPosition} has Valentine's day.");
                }
            }
            Console.WriteLine($"Cupid's last position was {CupidsLastPosition}.");

            

            foreach ( int neededHearts  in neighborhood )
            {
                if (neededHearts > 0 )
                {
                    countOfFailed++;
                }
            }

            if (countOfFailed == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {countOfFailed} places.");
            }

        }
        static bool IsValidIndex(List<int> neighborhood, int CupidsLastPosition)
        {
            if (CupidsLastPosition >= 0 && CupidsLastPosition < neighborhood.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
