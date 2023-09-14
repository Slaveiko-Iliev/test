using System;
using System.Linq;

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] orderedNumbers = numbers.OrderByDescending(x => x).Take(3).ToArray();

Console.WriteLine(string.Join(" ", orderedNumbers));
