using System;
using System.Collections.Generic;
using System.Linq;

SortedDictionary<string, SortedSet<string>> sidesUsers = new();
string command;

while ((command = Console.ReadLine()) != "Lumpawaroo")
{
    if (command.Contains('|'))
    {
        string[] commandInfo = command
            .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        string side = commandInfo[0];
        string user = commandInfo[1];

        if (!sidesUsers.Values.Any(x => x.Contains(user)))
        {
            if (!sidesUsers.ContainsKey(side))
            {
                sidesUsers.Add(side, new SortedSet<string>());
            }
        }

        sidesUsers[side].Add(user);
    }
    else
    {
        string[] commandInfo = command
            .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

        string user = commandInfo[0];
        string side = commandInfo[1];

        foreach (var sideUsers in sidesUsers)
        {
            if (sideUsers.Value.Contains(user))
            {
                sideUsers.Value.Remove(user);
                break;
            }
        }

        if (!sidesUsers.ContainsKey(side))
        {
            sidesUsers.Add(side, new SortedSet<string>());
        }

        sidesUsers[side].Add(user);

        Console.WriteLine($"{user} joins the {side} side!");
    }
}

Dictionary<string, SortedSet<string>> orderedSides = sidesUsers
    .OrderByDescending(x => x.Value.Count)
    .ToDictionary(x => x.Key, x => x.Value);

foreach (var sideUsers in orderedSides)
{
    if (sideUsers.Value.Any())
    {
        Console.WriteLine($"Side: {sideUsers.Key}, Members: {sideUsers.Value.Count}");

        foreach (var user in sideUsers.Value)
        {
            Console.WriteLine($"! {user}");
        }
    }
}