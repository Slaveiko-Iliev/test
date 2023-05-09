using System;
using System.Diagnostics;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfProduct = Console.ReadLine();

            double price;

            switch(nameOfProduct)
            {
                case "coffee":
                    price = 1.5;
                    CalculateFinalPrice(price);
                    break;
                case "water":
                    price = 1;
                    CalculateFinalPrice(price);
                    break;
                case "coke":
                    price = 1.4;
                    CalculateFinalPrice(price);
                    break;
                case "snacks":
                    price = 2;
                    CalculateFinalPrice(price);
                    break;
            }
        }

        private static void CalculateFinalPrice(double price)
        {
            int quantittyOfProduct = int.Parse(Console.ReadLine());
            double finalPrice = price * quantittyOfProduct;
            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
