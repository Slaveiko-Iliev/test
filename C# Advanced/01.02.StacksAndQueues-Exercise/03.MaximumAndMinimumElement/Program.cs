using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> numbersInStack = new();

int numberOfQueries = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfQueries; i++)
{
    int[] tokens = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    if (tokens[0] == 1)
    {
        numbersInStack.Push(tokens[1]);
    }
    else if (tokens[0] == 2)
    {
        numbersInStack.Pop();
    }
    else if (tokens[0] == 3)
    {
        if (numbersInStack.Any())
        {
            Console.WriteLine(numbersInStack.Max());
        }
    }
    else if (tokens[0] == 4)
    {
        if (numbersInStack.Any())
        {
            Console.WriteLine(numbersInStack.Min());
        }
    }
}

Console.WriteLine(string.Join(", ", numbersInStack));