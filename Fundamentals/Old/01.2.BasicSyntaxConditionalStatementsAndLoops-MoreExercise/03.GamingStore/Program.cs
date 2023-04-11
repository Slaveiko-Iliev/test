using System;

namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double price = 0;
            double totalSpent = 0;

            while (input != "Game Time")
            {
                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                if (input == "OutFall 4")
                {
                    price = 39.99;
                    if (currentBalance >= price)
                    {
                        Console.WriteLine($"Bought {input}");
                        currentBalance -= price;
                        totalSpent += price;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "CS: OG")
                {
                    price = 15.99;
                    if (currentBalance >= price)
                    {
                        Console.WriteLine($"Bought {input}");
                        currentBalance -= price;
                        totalSpent += price;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "Zplinter Zell")
                {
                    price = 19.99;
                    if (currentBalance >= price)
                    {
                        Console.WriteLine($"Bought {input}");
                        currentBalance -= price;
                        totalSpent += price;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "Honored 2")
                {
                    price = 59.99;
                    if (currentBalance >= price)
                    {
                        Console.WriteLine($"Bought {input}");
                        currentBalance -= price;
                        totalSpent += price;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "RoverWatch")
                {
                    price = 29.99;
                    if (currentBalance >= price)
                    {
                        Console.WriteLine($"Bought {input}");
                        currentBalance -= price;
                        totalSpent += price;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                    if (currentBalance >= price)
                    {
                        Console.WriteLine($"Bought {input}");
                        currentBalance -= price;
                        totalSpent += price;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                input = Console.ReadLine();

            }
            Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currentBalance:f2}");
        }
    }
}
