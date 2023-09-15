using System;
using System.Collections.Generic;

int numberOfCompounds = int.Parse(Console.ReadLine());

SortedSet<string> compounds = new SortedSet<string>();

for (int i = 0; i < numberOfCompounds; i++)
{
    string[] currentCompounds = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    foreach (string compound in currentCompounds)
    {
        compounds.Add(compound);
    }
}

Console.WriteLine(string.Join(" ", compounds));