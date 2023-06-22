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
            int rating = int.MinValue;
            int leftItem = priceRatings[entryPoint - 1];
            int rightItem = priceRatings[entryPoint + 1];

            if (typeOfItems == "cheap")
            {
                if (leftItem <= rightItem)
                {
                    position = "Left";
                    rating = leftItem;
                }
                else if (leftItem > rightItem)
                {
                    position = "Right";
                    rating = rightItem;
                }
            }
            else if (typeOfItems == "expensive")
            {
                if (leftItem >= rightItem)
                {
                    position = "Left";
                    rating = leftItem;
                }
                else if (leftItem < rightItem)
                {
                    position = "Right";
                    rating = rightItem;
                }
            }


            Console.WriteLine($"{position} - {rating}");
        }

    }
}
