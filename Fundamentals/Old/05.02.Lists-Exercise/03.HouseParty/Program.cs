using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> guestlist = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentCommand = Console.ReadLine().Split();
                string name = currentCommand[0];

                if (currentCommand[2] == "not")
                {
                    if (guestlist.Contains(name))
                    {
                        guestlist.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else if (currentCommand[2] == "going!")
                {
                    if (!guestlist.Contains(name))
                    {
                        guestlist.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
            }
            //foreach (var item in guestlist)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(string.Join(Environment.NewLine, guestlist));
        }
    }
}
