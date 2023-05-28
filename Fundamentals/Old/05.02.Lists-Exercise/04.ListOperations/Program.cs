using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
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

            while ((command = Console.ReadLine()) != "End")
            {
                string[] currentCommand = command.Split();

                if (currentCommand[0] == "Add")
                {
                    int number = int.Parse(currentCommand[1]);

                    numbers.Add(number);
                }
                else if (currentCommand[0] == "Insert")
                {
                    int index = int.Parse(currentCommand[2]);
                    
                    if (index <0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        int number = int.Parse(currentCommand[1]);

                        numbers.Insert(index, number);
                    }
                }
                else if (currentCommand[0] == "Remove")
                {
                    int index = int.Parse(currentCommand[1]);

                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (currentCommand[1] == "left")
                {
                    int count = int.Parse(currentCommand[2]);

                    for (int i = 0; i < count; i++)
                    {
                        int firstNumber = numbers[0];
                        numbers.Add(firstNumber);
                        numbers.RemoveAt(0);
                    }
                }
                else if (currentCommand[1] == "right")
                {
                    int count = int.Parse(currentCommand[2]);

                    for (int i = 0; i < count; i++)
                    {

                        int lastNumber = numbers[numbers.Count - 1];
                        numbers.Insert(0, lastNumber);
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
