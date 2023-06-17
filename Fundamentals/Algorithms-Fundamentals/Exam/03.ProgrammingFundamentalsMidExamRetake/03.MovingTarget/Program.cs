using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
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

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ");

                string currentCommand = command[0];
                int index = int.Parse(command[1]);

                if (currentCommand == "Shoot")
                {
                    int power = int.Parse(command[2]);

                    if (IsValidIndex(numbers, index))
                    {
                        numbers[index] -= power;

                        if (numbers[index] <= 0)
                        {
                            numbers.RemoveAt(index);
                        }
                    }
                }
                else if (currentCommand == "Add")
                {
                    int value = int.Parse(command[2]);

                    if (IsValidIndex(numbers, index))
                    {
                        numbers.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (currentCommand == "Strike")
                {
                    int radius = int.Parse(command[2]);
                    
                    if (IsValidIndex(numbers, index - radius) && IsValidIndex(numbers, index + radius))
                    {
                        numbers.RemoveRange(index - radius, 2 * radius + 1);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
            }
            Console.WriteLine(string.Join("|", numbers));
        }
        static bool IsValidIndex(List<int> numbers, int index)
        {
            bool isValid;

            if (index >= 0 && index < numbers.Count)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
