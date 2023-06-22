using System;
using System.Linq;

namespace _03.TheAngryCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] priceRatings = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();

            string position = string.Empty;
            int sumPriceRatings = int.MinValue;
            


            if (typeOfItems == "cheap")
            {
                sumPriceRatings = GetCheapSum(priceRatings, entryPoint, ref position);
            }
            else if (typeOfItems == "expensive")
            {
                sumPriceRatings = GetExpensiveSum(priceRatings, entryPoint, ref position);
            }

            
            Console.WriteLine($"{position} - {sumPriceRatings}");
        }

        static int GetExpensiveSum(int[] priceRatings, int entryPoint, ref string position)
        {
            int leftSum = 0;
            int rightSum = 0;

            for (int i = entryPoint - 1; i >= 0; i--)
            {
                if (priceRatings[i] >= priceRatings[entryPoint])
                {
                    leftSum += priceRatings[i];
                }
            }

            for (int i = entryPoint + 1; i < priceRatings.Length; i++)
            {
                if (priceRatings[i] >= priceRatings[entryPoint])
                {
                    rightSum += priceRatings[i];
                }
            }

            if (leftSum >= rightSum)
            {
                position = "Left";
                return leftSum;
            }
            else
            {
                position = "Right";
                return rightSum;
            }
        }

        static int GetCheapSum(int[] priceRatings, int entryPoint, ref string position)
        {
            int leftSum = 0;
            int rightSum = 0;

            for (int i = entryPoint - 1; i >= 0; i--)
            {
                if (priceRatings[i] < priceRatings[entryPoint])
                {
                    leftSum += priceRatings[i];
                }
            }

            for (int i = entryPoint + 1; i < priceRatings.Length; i++)
            {
                if (priceRatings[i] < priceRatings[entryPoint])
                {
                    rightSum += priceRatings[i];
                }
            }

            if (leftSum >= rightSum)
            {
                position = "Left";
                return leftSum;
            }
            else
            {
                position = "Right";
                return rightSum;
            }
        }
    }
}
