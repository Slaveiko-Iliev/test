using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialChest = Console.ReadLine()
                .Split("|")
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                List<string> command = input
                    .Split()
                    .ToList();

                if (command[0] == "Loot")
                {
                    for (int i = 1; i < command.Count; i++)
                    {
                        string curentLoot = command[i];


                        if (!initialChest.Contains(curentLoot))
                        {
                            initialChest.Insert(0, curentLoot);
                        }
                    }
                }
                else if (command[0] == "Drop")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index <initialChest.Count)
                    {
                        string curentLoot = initialChest[index];
                        initialChest.RemoveAt(index);
                        initialChest.Add(curentLoot);
                    }
                }
                else if (command[0] == "Steal")
                {
                    int lastCount = int.Parse(command[1]);

                    if (lastCount < initialChest.Count)
                    {
                        int lootToSkip = initialChest.Count - lastCount;

                        Console.WriteLine(string.Join(", ", initialChest.Skip(lootToSkip).Take(lastCount)));

                        initialChest.RemoveRange(lootToSkip, lastCount);
                    }
                    else
                    {
                        Console.WriteLine(string.Join(", ", initialChest));
                        initialChest.RemoveRange(0, initialChest.Count);
                    }
                }
            }
            int sumOfItemsLength = 0;

            foreach (var loot in initialChest)
            {
                sumOfItemsLength += loot.Length;
            }

            double averageTreasureGain = (double)sumOfItemsLength / initialChest.Count;

            if (initialChest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                Console.WriteLine($"Average treasure gain: {averageTreasureGain:f2} pirate credits.");
            }
        }
    }
}
