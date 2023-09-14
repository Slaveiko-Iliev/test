using System;
using System.Collections.Generic;
using System.Linq;

double[] numbers = Console.ReadLine()
    .Split(' ')
    .Select(double.Parse)
    .ToArray();

Dictionary<double, int> counts = new Dictionary<double, int>();

for (int i = 0; i < numbers.Length; i++)
{
    if (!counts.ContainsKey(numbers[i]))
    {
        counts.Add(numbers[i], 0);
    }

    counts[numbers[i]]++;
}

//foreach(var item in counts)
//{
//    Console.WriteLine($"{item.Key} - {item.Value} times");
//}

foreach (var (number, count) in counts)
{
    Console.WriteLine($"{number} - {count} times");
}