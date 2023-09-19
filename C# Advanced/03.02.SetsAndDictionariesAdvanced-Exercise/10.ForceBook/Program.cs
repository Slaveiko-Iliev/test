using System;
using System.Collections.Generic;
using System.Linq;

string input = string.Empty;
Dictionary<string, List<string>> forceSides = new ();
Dictionary<string, string> users = new ();

while ((input = Console.ReadLine()) != "Lumpawaroo")
{
    //string[] commandSplit = input
    //    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (input.Contains("|"))
    {

        string[] commandInfo = input
            .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        string forceSide = commandInfo[0];
        string forceUser = commandInfo[1];

        if (!forceSides.ContainsKey(forceSide))
        {
            forceSides.Add(forceSide, new List<string>());
        }

        if (!forceSides[forceSide].Contains(forceUser))
        {
            forceSides[forceSide].Add(forceUser);
        }

        if (!users.ContainsKey(forceUser))
        {
            users.Add(forceUser, forceSide);
        }
    }
    else
    {
        string[] commandInfo = input
            .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

        string forceUser = commandInfo[0];
        string forceSide = commandInfo[1];

        if (users.ContainsKey(forceUser))
        {
            string currentSide = users[forceUser];
            forceSides[currentSide].Remove(forceUser);
            forceSides[forceSide].Add(forceUser);
            users[forceUser] = forceSide;

            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
        }
        else if (!users.ContainsKey(forceUser))
        {
            users.Add(forceUser, forceSide);

            if (!forceSides.ContainsKey(forceSide))
            {
                forceSides.Add(forceSide, new List<string>());
            }

            if (!forceSides[forceSide].Contains(forceUser))
            {
                forceSides[forceSide].Add(forceUser);
            }

            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
        }

    }
}

foreach (var (side, forceUsers) in forceSides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
{
    if (forceUsers.Count == 0)
    {
        continue;
    }

    Console.WriteLine($"Side: {side}, Members: {forceUsers.Count}");

    foreach (var user in forceUsers.OrderBy(x=> x))
    {
        Console.WriteLine($"! {user}");
    }
}