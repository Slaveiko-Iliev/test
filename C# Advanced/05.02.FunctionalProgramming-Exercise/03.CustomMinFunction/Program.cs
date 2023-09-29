using System;
using System.Collections.Generic;
using System.Linq;

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

Func<List<int>, int> minNum = FindMinNumber;

Console.WriteLine(minNum(numbers));

static int FindMinNumber(List<int> numbers)
{
    int minNum = int.MaxValue;

    foreach (int number in numbers)
    {
        if (number < minNum)
        {
            minNum = number;
        }
    }
    return minNum;
}