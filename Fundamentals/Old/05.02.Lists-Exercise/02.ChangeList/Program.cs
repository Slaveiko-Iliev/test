using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] currentCommand = command.Split();

                if (currentCommand[0] == "Delete")
                {
                    int number = int.Parse(currentCommand[1]);

                    numbers.RemoveAll(x => x == number);
                }
                else
                {
                    int element = int.Parse(currentCommand[1]);
                    int index = int.Parse(currentCommand[2]);

                    numbers.Insert(index, element);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
