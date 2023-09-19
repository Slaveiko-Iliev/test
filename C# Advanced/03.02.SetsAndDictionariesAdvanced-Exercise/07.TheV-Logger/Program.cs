using System;
using System.Collections.Generic;
using System.Linq;

string input = string.Empty;

Dictionary<string, List<HashSet<string>>> vLogger = new();

while ((input = Console.ReadLine()) != "Statistics")
{
    string[] commandInfo = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries) ;

    string vloggername = commandInfo[0] ;
    string command = commandInfo[1] ;

    if (command == "joined")
    {
        if (!vLogger.ContainsKey(vloggername))
        {
            vLogger.Add(vloggername, new List<HashSet<string>>());
        }
        vLogger[vloggername].Add(new HashSet<string>());
        vLogger[vloggername].Add(new HashSet<string>());
    }
    else if (command == "followed")
    {
        string followed = commandInfo[2] ;

        if (vloggername == followed)
        {
            continue;
        }
        if (!vLogger.ContainsKey(vloggername) || !vLogger.ContainsKey(followed))
        {
            continue;
        }

        vLogger[followed][0].Add(vloggername);
        vLogger[vloggername][1].Add(followed);
    }
}

Dictionary<string, List<HashSet<string>>> orderedVLogger = vLogger.OrderByDescending(x => x.Value[0].Count).ThenBy(x => x.Value[1].Count).ToDictionary(x => x.Key, x => x.Value);

Console.WriteLine($"The V-Logger has a total of {orderedVLogger.Keys.Count} vloggers in its logs.");

Console.WriteLine($"1. {orderedVLogger.Keys.First()} : {orderedVLogger.Values.First()[0].Count} followers, {orderedVLogger.Values.First()[1].Count} following");

foreach (var follower in orderedVLogger.Values.First()[0].OrderBy(x => x))
{
    Console.WriteLine($"*  {follower}");
}

int count = 2;

foreach (var (user, info) in orderedVLogger)
{
    if (user == orderedVLogger.Keys.First())
    {
        continue;
    }
    
    Console.WriteLine($"{count}. {user} : {info[0].Count} followers, {info[1].Count} following");

    count++;
}