using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] currentInput = input.Split();
                
                if (currentInput[0] == "Add")
                {
                    numbers.Add(int.Parse(currentInput[1]));
                }
                else if (currentInput[0] == "Remove")
                {
                    numbers.Remove(int.Parse(currentInput[1]));
                }
                else if (currentInput[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(currentInput[1]));
                }
                else if (currentInput[0] == "Insert")
                {
                    numbers.Insert(int.Parse(currentInput[2]), int.Parse(currentInput[1]));
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
