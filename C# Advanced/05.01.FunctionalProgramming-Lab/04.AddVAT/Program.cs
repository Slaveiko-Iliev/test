using System;
using System.Linq;

double[] input = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToArray();

double[] inputWithVAT = input
    .Select(x => x * 1.2)
    .Where( x =>
    {
        Console.WriteLine($"{x:f2}");
        return true;
    })
    .ToArray();
