using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialList = Console.ReadLine()
                .Split("!")
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                List<string> command = input
                    .Split(" ")
                    .ToList();
                string currentCommand = command[0];
                string item = command[1];

                if (currentCommand == "Urgent")
                {
                    if (!initialList.Contains(item))
                    {
                        initialList.Insert(0, item);
                    }
                }
                else if (currentCommand == "Unnecessary")
                {
                    if (initialList.Contains(item))
                    {
                        initialList.Remove(item);
                    }
                }
                else if (currentCommand == "Correct")
                {
                    string newItem = command[2];

                    if (initialList.Contains(item))
                    {
                        int indexOfItem = initialList.IndexOf(item);
                        initialList.Remove(item);
                        initialList.Insert(indexOfItem, newItem);
                    }
                }
                else if (currentCommand == "Rearrange")
                {
                    if (initialList.Contains (item))
                    {
                        initialList.Remove (item);
                        initialList.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", initialList));
        }
    }
}
