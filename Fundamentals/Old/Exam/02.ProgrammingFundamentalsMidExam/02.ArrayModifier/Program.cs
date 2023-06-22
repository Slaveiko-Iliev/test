using System;
using System.Linq;

namespace _02.ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input
                    .Split(' ')
                    .ToArray();

                string currentCommand = command[0];

                if (currentCommand == "swap")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);
                    int firstElement = numbers[firstIndex];
                    int secondElement = numbers[secondIndex];

                    numbers[firstIndex] = secondElement;
                    numbers[secondIndex] = firstElement;
                }
                else if (currentCommand == "multiply")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);

                    int multipliedElements = numbers[firstIndex] * numbers[secondIndex];
                    numbers[firstIndex] = multipliedElements;
                }
                else if (currentCommand == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                }

            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
