using System;
using System.Collections.Generic;
using System.Linq;

SortedDictionary<string, SortedSet<string>> sides = new();
string input = string.Empty;

while ((input = Console.ReadLine()) != "Lumpawaroo")
{
    if (input.Contains("|"))
    {
        string[] commandInfo = input
            .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        string forceSide = commandInfo[0];
        string forceUser = commandInfo[1];

        if (!sides.Values.Any(x => x.Contains(forceUser)))
        {
            if (!sides.ContainsKey(forceSide))
            {
                sides.Add(forceSide, new SortedSet<string>());
            }
        }

        sides[forceSide].Add(forceUser);
    }
    else
    {
        string[] commandInfo = input
            .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

        string forceUser = commandInfo[0];
        string forceSide = commandInfo[1];

        foreach (var (side, users) in sides)
        {
            if (users.Contains(forceUser))
            {
                users.Remove(forceUser);
                break;
            }
        }

        if (!sides.ContainsKey(forceSide))
        {
            sides.Add(forceSide, new SortedSet<string>());
        }

        sides[forceSide].Add(forceUser);

        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
    }
}

Dictionary<string, SortedSet<string>> orderedSides = sides
    .OrderByDescending(x => x.Value.Count)
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var side in sides)
{
    //if (users.Count == 0)
    //{
    //    continue;
    //}

    if (side.Value.Any())
    {
        Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

        foreach (var user in side.Value)
        {
            Console.WriteLine($"! {user}");
        }
    }
}