using System;
using System.Collections.Generic;
using System.Linq;

int[] countOfLists = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int firstListCount = countOfLists[0];
int secondListCount = countOfLists[1];

List<int> firstList = new List<int>();
List<int>secondList = new List<int>();

for (int i = 0; i < firstListCount; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    firstList.Add(currentNumber);
}

for (int i = 0; i < secondListCount; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    secondList.Add(currentNumber);
}

HashSet<int> appearInBothList = new HashSet<int>();

foreach (int number in firstList)
{
    if (secondList.Contains(number))
    {
        appearInBothList.Add(number);
    }
}

Console.WriteLine(string.Join(" ", appearInBothList));