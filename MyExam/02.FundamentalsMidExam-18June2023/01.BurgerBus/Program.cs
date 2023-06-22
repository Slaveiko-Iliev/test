using System;

namespace _01.BurgerBus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCities = int.Parse(Console.ReadLine());

            double totalProfit = 0;

            for (int countOfCities = 1; countOfCities <= numberOfCities; countOfCities++)
            {
                string cityName = Console.ReadLine();
                double income = double.Parse(Console.ReadLine());
                double expenses = double.Parse(Console.ReadLine());

                if (countOfCities % 3 == 0 && countOfCities % 5 != 0)
                {
                    expenses *= 1.5;
                }

                if (countOfCities % 5 == 0)
                {
                    income *= 0.9;
                }

                double profit = income - expenses;

                totalProfit += profit;

                Console.WriteLine($"In {cityName} Burger Bus earned {profit:f2} leva.");
            }

            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
        }
    }
}
