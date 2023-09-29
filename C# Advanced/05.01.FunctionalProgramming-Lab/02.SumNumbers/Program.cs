using System;
using System.Linq;

int sum = 0;

int[] input = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .Select(x => sum += x)
    .ToArray();

Console.WriteLine(input.Length);
Console.WriteLine(sum);