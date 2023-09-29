using System;
using System.Collections.Generic;
using System.Linq;

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

Func<List<int>, List<int>> reverseList = ReverseList;

List<int> reversedList = ReverseList(numbers);

int divisor = int.Parse(Console.ReadLine());

Predicate<int> divisibleMatch = x => x % divisor == 0;
Func<List<int>, Predicate<int>, List<int>> division = Division;

Console.WriteLine(string.Join(" ", Division(reversedList, divisibleMatch)));


static List<int> ReverseList (List<int> numbers)
{
    var reversedList = new List<int>();

    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        reversedList.Add(numbers[i]);
    }

    return reversedList;
}

static List<int> Division (List<int> reversedList, Predicate<int> divisibleMatch)
{
    List<int> result = new ();

    foreach (int number in reversedList)
    {
        if (!divisibleMatch(number))
        {
            result.Add(number);
        }
    }

    return result;
}