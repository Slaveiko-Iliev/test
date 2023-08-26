//N, S and X, separated by a single space.

using System.Collections;

int[] input = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int numberToPush = input[0];
int numberToPop = input[1];
int  findNumber = input[2];

int[] inputNumbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Stack<int> numbersInStack = new Stack<int>();

if (numberToPush > inputNumbers.Length)
{
    for (int i = 0; i < inputNumbers.Length; i++)
    {
        numbersInStack.Push(inputNumbers[i]);
    }
}
else
{
    for (int i = 0; i < numberToPush; i++)
    {
        numbersInStack.Push(inputNumbers[i]);
    }
}

if (numberToPop > numbersInStack.Count)
{
    for (int i = 0; i < numbersInStack.Count; i++)
    {
        numbersInStack.Pop();
    }
}
else
{
    for (int i = 0; i < numberToPop; i++)
    {
        numbersInStack.Pop();
    }
}

if (!numbersInStack.Any())
{
    Console.WriteLine("0");
}

if (numbersInStack.Contains(findNumber))
{
    Console.WriteLine("true");
}
else
{
    int smallest = int.MaxValue;

    for (int i = 0; i < numbersInStack.Count(); i++)
    {
        if (numbersInStack.Peek() < smallest)
        {
            smallest = numbersInStack.Peek();
        }
        numbersInStack.Pop() ;
    }
    if (numbersInStack.Count() > 0)
    {
        Console.WriteLine(smallest);
    }
}