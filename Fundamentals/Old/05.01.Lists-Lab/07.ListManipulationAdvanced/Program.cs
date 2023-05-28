using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
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
            bool isChanged = false;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] currentInput = input.Split();
                bool isEven;

                if (currentInput[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(currentInput[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (currentInput[0] == "PrintEven")
                {
                    isEven = true;
                    List<int> even = GetEvenOrOdd(numbers, isEven);
                    Console.WriteLine(string.Join(" ", even));
                }else if (currentInput[0] == "PrintOdd")
                {
                    isEven = false;
                    List<int> even = GetEvenOrOdd(numbers, isEven);
                    Console.WriteLine(string.Join(" ", even));
                }
                else if (currentInput[0] == "GetSum")
                {
                    int sumOfNumbers = GetSum(numbers);
                    Console.WriteLine(sumOfNumbers);
                }
                else if (currentInput[0] == "Filter")
                {
                    List<int> filteredList = new List<int>();

                    foreach (int number in numbers)
                    {
                        if (currentInput[1] == "<" &&  number < int.Parse(currentInput[2]))
                        {
                            filteredList.Add(number);
                        }
                        else if (currentInput[1] == ">" && number > int.Parse(currentInput[2]))
                        {
                            filteredList.Add(number);
                        }
                        else if (currentInput[1] == ">=" && number >= int.Parse(currentInput[2]))
                        {
                            filteredList.Add(number);
                        }
                        else if (currentInput[1] == "<=" && number <= int.Parse(currentInput[2]))
                        {
                            filteredList.Add(number);
                        }
                    }
                    if (filteredList.Count > 0)
                    {
                        Console.WriteLine(string.Join(" ", filteredList));
                    }
                }
                else if (currentInput[0] == "Add")
                {
                    numbers.Add(int.Parse(currentInput[1]));
                    isChanged = true;
                }
                else if (currentInput[0] == "Remove")
                {
                    numbers.Remove(int.Parse(currentInput[1]));
                    isChanged = true;
                }
                else if (currentInput[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(currentInput[1]));
                    isChanged = true;
                }
                else if (currentInput[0] == "Insert")
                {
                    numbers.Insert(int.Parse(currentInput[2]), int.Parse(currentInput[1]));
                    isChanged = true;
                }
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static List<int> GetEvenOrOdd (List<int> numbers, bool isEven)
        {
            List<int> evenOrOdd = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (isEven)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        evenOrOdd.Add(numbers[i]);
                    }
                }
                else
                {
                    if (numbers[i] % 2 != 0)
                    {
                        evenOrOdd.Add(numbers[i]);
                    }
                }
            }

            return evenOrOdd;
        }

        static int GetSum (List<int> numbers)
        {
            int sum = 0;
            
            foreach (int item in numbers)
            {
                sum += item;
            }

            return sum;
        }
    }
}
