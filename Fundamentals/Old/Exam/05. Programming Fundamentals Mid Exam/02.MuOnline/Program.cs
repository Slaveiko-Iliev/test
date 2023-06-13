using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeon = Console.ReadLine()
                .Split('|')
                .ToList();

            int initialHealth = 100;
            int initialBitcoins = 0;
            int countOfRoom = 0;
            bool isDied = false;

            for (int i = 0; i < dungeon.Count; i++)
            {
                countOfRoom ++;
                
                List<string> command = dungeon[i]
                    .Split()
                    .ToList();

                string currentCommand = command[0];
                int number = int.Parse(command[1]);

                if (currentCommand == "potion")
                {
                    if (initialHealth + number > 100)
                    {
                        Console.WriteLine($"You healed for {100 - initialHealth} hp.");
                        initialHealth = 100;
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                        
                    }
                    else
                    {
                        initialHealth += number;
                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                }
                else if (currentCommand == "chest")
                {
                    initialBitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    string nameOfMonster = command[0];

                    if (initialHealth - number > 0)
                    {
                        Console.WriteLine($"You slayed {nameOfMonster}.");
                        initialHealth -= number;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {nameOfMonster}.");
                        Console.WriteLine($"Best room: {countOfRoom}");
                        isDied = true;
                        break;
                    }
                }
            }
            if (isDied == false)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {initialBitcoins}");
                Console.WriteLine($"Health: {initialHealth}");
            }
        }
    }
}
