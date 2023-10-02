using System;
using System.Collections.Generic;
using System.Linq;

List<string> guests = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input = string.Empty;
Func <List<string>, string, List<string>> startsWith = StartsWith;
Func <List<string>, string, List<string>> endsWith = EndsWith;
Func <List<string>, string, List<string>> length = Length;
Func <List<string>, string, List<string>> contains = Contains;

List<string> filters = new();

while ((input = Console.ReadLine()) != "Print")
{
    string[] commandInfo = input
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string command = commandInfo[0];
    string filterType = commandInfo[1];
    string parameter = commandInfo[2];


    if (command == "Add filter")
    {
        filters.Add($"{filterType};{parameter}");
    }
    else if (command == "Remove filter")
    {
        filters.Remove($"{filterType};{parameter}");
    }
}

foreach (string filterAsString in filters)
{
    string[] filter = filterAsString
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string filterType = filter[0];
    string parameter = filter[1];

    if (filterType == "Starts with")
    {
        guests = startsWith(guests, parameter);
    }
    else if (filterType == "Ends with")
    {
        guests = endsWith(guests, parameter);
    }
    else if (filterType == "Length")
    {
        guests = length(guests, parameter);
    }
    else if (filterType == "Contains")
    {
        guests = contains(guests, parameter);
    }
}

Console.WriteLine(string.Join(" ", guests));


static List<string> StartsWith (List<string> guests, string parameter)
{
    List<string> result = new ();

    foreach (string guest in guests)
    {
        if (!guest.StartsWith(parameter))
        {
            result.Add (guest);
        }
    }

    return result;
}


static List<string> EndsWith(List<string> guests, string parameter)
{
    List<string> result = new();

    foreach (string guest in guests)
    {
        if (!guest.EndsWith(parameter))
        {
            result.Add(guest);
        }
    }

    return result;
}


static List<string> Length(List<string> guests, string parameter)
{
    List<string> result = new();
    int length = int.Parse(parameter);

    foreach (string guest in guests)
    {
        if (guest.Length != length)
        {
            result.Add(guest);
        }
    }

    return result;
}


static List<string> Contains(List<string> guests, string parameter)
{
    List<string> result = new();

    foreach (string guest in guests)
    {
        if (!guest.Contains(parameter))
        {
            result.Add(guest);
        }
    }

    return result;
}
