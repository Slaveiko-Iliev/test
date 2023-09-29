using System;
using System.Collections.Generic;
using System.Linq;

int endOfRange = int.Parse(Console.ReadLine());

int[] dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

List<Predicate<int>> predicates = new ();

foreach (int number in dividers)
{
    Predicate<int> predicate = x => x % number == 0;
    predicates.Add(predicate);
}

Console.WriteLine(string.Join(" ", FindMatch(endOfRange, predicates)));


static List<int> FindMatch(int endOfRange, List<Predicate<int>> predicates)
{
    List<int> result = new();

    for (int i = 1; i <= endOfRange; i++)
    {
        bool isMatch = true;

        foreach (Predicate<int> predicate in predicates)
        {
            if (!predicate(i))
            {
                isMatch = false;
                break;
            }
        }

        if (isMatch)
        {
            result.Add(i);
        }
    }
    return result;
}

