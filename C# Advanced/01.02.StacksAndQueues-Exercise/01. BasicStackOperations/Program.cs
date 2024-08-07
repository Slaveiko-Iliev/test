﻿//N, S and X, separated by a single space.

using System.Collections;

int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int numberToPush = input[0];
int numberToPop = input[1];
int findNumber = input[2];

int[] inputNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> numbersInStack = new Stack<int>();

for (int i = 0; i < numberToPush; i++)
{
    numbersInStack.Push(inputNumbers[i]);
}

for (int i = 0; i < numberToPop; i++)
{
    numbersInStack.Pop();
}

if (!numbersInStack.Any())
{
    Console.WriteLine("0");
}
else if (numbersInStack.Contains(findNumber))
{
    Console.WriteLine("true");
}
else
{
    Console.WriteLine(numbersInStack.Min());
}

