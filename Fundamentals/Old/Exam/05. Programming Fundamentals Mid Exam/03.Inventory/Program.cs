using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Craft!")
            {
                List<string> command = input
                    .Split(" - ")
                    .ToList();
                string currentCommand = command[0];
                string item = command[1];

                if(currentCommand == "Collect")
                {
                    if (!journal.Contains(item))
                    {
                        journal.Add(item);
                    }
                }
                else if(currentCommand == "Drop")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                    }
                }
                else if(currentCommand == "Combine Items")
                {
                    List<string> combineItems = command[1]
                        .Split(":")
                        .ToList();
                    
                    item = combineItems[0];
                    string newItem = combineItems[1];

                    if (journal.Contains(item) && !journal.Contains(newItem))
                    {
                        int indexOfItem = journal.IndexOf(item);

                        if (indexOfItem == journal.Count - 1)
                        {
                            journal.Add(newItem);
                        }
                        else
                        {
                            journal.Insert(indexOfItem + 1, newItem);
                        }
                    }
                }
                else if(currentCommand == "Renew")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                        journal.Add(item);
                    }
                }
            }
            
            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
