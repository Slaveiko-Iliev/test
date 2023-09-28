using System;
using System.Linq;

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string input = string.Empty;
Action<int[], string> actionCalculation = MakeCalculation;
Action<int[]> actionPrint = numbers 
    => Console.WriteLine(string.Join(" ", numbers));


while ((input = Console.ReadLine()) != "end")
{
    if (input == "print")
    {
        actionPrint(numbers);
    }
    else
    {
        actionCalculation(numbers, input);
    }
}


void MakeCalculation(int[] numbers, string input)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        switch (input)
        {
            case "add":
                numbers[i] += 1;
                break;
            case "multiply":
                numbers[i] *= 2;
                break;
            case "subtract":
                numbers[i] -= 1;
                break;
        }
    }
}