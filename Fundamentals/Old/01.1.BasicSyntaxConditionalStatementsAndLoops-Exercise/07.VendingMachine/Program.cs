using System;

namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sumOfMoney = 0;

            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Start")
                {
                    break;
                }
                double money = double.Parse(text);
                if (money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2)
                {
                    sumOfMoney += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts" && sumOfMoney >= 2)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sumOfMoney -= 2;
                }
                else if (product == "Nuts" && sumOfMoney < 2)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else if (product == "Water" && sumOfMoney >= 0.7)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sumOfMoney -= 0.7;
                }
                else if (product == "Wafer" && sumOfMoney < 0.7)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else if (product == "Crisps" && sumOfMoney >= 1.5)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sumOfMoney -= 1.5;
                }
                else if (product == "Crisps" && sumOfMoney < 1.5)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else if (product == "Soda" && sumOfMoney >= 0.8)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sumOfMoney -= 0.8;
                }
                else if (product == "Soda" && sumOfMoney < 0.8)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else if (product == "Coke" && sumOfMoney >= 1)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    sumOfMoney -= 1;
                }
                else if (product == "Coke" && sumOfMoney < 1)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sumOfMoney:f2}");
        }
    }
}
