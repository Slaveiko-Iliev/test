using System;
using System.Collections.Generic;

int countOfInput = int.Parse(Console.ReadLine());

Dictionary<int, int> numbers = new Dictionary<int, int>();

for (int i = 0; i < countOfInput; i++)
{
    int currentNumber = int.Parse(Console.ReadLine());

    if (!numbers.ContainsKey(currentNumber))
    {
        numbers.Add(currentNumber, 0);
    }

    numbers[currentNumber]++;
}

foreach (var (number, count) in numbers)
{
    if (count % 2 == 0)
    {
        Console.WriteLine(number);
        break;
    }
}