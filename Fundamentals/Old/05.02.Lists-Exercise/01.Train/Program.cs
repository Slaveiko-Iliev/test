using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagonsWithPassengers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacityOfWagon = int.Parse(Console.ReadLine());
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] currentCommand = command.Split();

                if (currentCommand[0] == "Add" )
                {
                    wagonsWithPassengers.Add(int.Parse(currentCommand[1]));
                }
                else
                {
                    for (int i = 0; i < wagonsWithPassengers.Count; i++)
                    {
                        if (wagonsWithPassengers[i] + int.Parse(currentCommand[0]) <= maxCapacityOfWagon)
                        {
                            wagonsWithPassengers[i] += int.Parse(currentCommand[0]);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagonsWithPassengers));
        }
    }
}
