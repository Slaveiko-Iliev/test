using System;
using System.Collections.Generic;
using System.Linq;

string input = Console.ReadLine();

Dictionary<char, int> characters = new ();

for (int i = 0; i < input.Length; i++)
{
    if (!characters.ContainsKey(input[i]))
    {
        characters[input[i]] = 0;
    }

    characters[input[i]]++;
}

Dictionary<char, int> orderedCharacters = characters.OrderBy(c => c.Key).ToDictionary(x => x.Key, x => x.Value);

foreach (var (symbol, count) in orderedCharacters)
{
    Console.WriteLine($"{symbol}: {count} time/s");
}