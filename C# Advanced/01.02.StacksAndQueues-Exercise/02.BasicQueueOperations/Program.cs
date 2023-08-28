//N, S and X, separated by a single space.

using System.Collections;

int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int numbersToAdd = input[0];
int numbersToRemove = input[1];
int findNumber = input[2];

int[] inputNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> numbersInStack = new ();

for (int i = 0; i < numbersToAdd; i++)
{
    numbersInStack.Enqueue(inputNumbers[i]);
}

for (int i = 0; i < numbersToRemove; i++)
{
    numbersInStack.Dequeue();
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

