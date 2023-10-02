using System;
using System.Collections.Generic;
using System.Linq;

List<string> guests = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input = string.Empty;

while ((input = Console.ReadLine()) != "Party!")
{
    guests = UpdatedGuests(guests, input);
}

Action<List<string>> print = Print;

print(guests);



void Print (List<string> guests)
{
    if (guests.Count == 0)
    {
        Console.WriteLine("Nobody is going to the party!");
    }
    else
    {
        Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
    }
}


static List<string> UpdatedGuests(List<string> guests, string input)
{
    string[] commandInfo = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = commandInfo[0];
    string action = commandInfo[1];
    string criteria = commandInfo[2];
    int criteriaInt = 0;
    if (action == "Length")
    {
        criteriaInt = int.Parse(commandInfo[2]);
    }

    List<string> updateGuests = new ();

    Func<string, string, bool> findMatchFirst = FindMatchFirst;
    Func<string, string, bool> findMatchLast = FindMatchLast;
    Func<string, int, bool> isMatchLength = IsMatchLength;

    foreach (string name in guests)
    {
        if (command == "Remove")
        {
            if (action == "StartsWith")
            {
                if (!findMatchFirst(name, criteria))
                {
                    updateGuests.Add(name);
                }
            }
            else if (action == "EndsWith")
            {
                if(!findMatchLast(name, criteria))
                {
                    updateGuests.Add(name);
                }
            }
            else
            {
                if (!isMatchLength(name, criteriaInt))
                {
                    updateGuests.Add(name);
                }
            }
        }
        else
        {
            if (action == "StartsWith")
            {
                if (findMatchFirst(name, criteria))
                {
                    updateGuests.Add(name);
                    updateGuests.Add(name);
                }
                else
                {
                    updateGuests.Add(name);
                }
            }
            else if (action == "EndsWith")
            {
                if (findMatchLast(name, criteria))
                {
                    updateGuests.Add(name);
                    updateGuests.Add(name);
                }
                else
                {
                    updateGuests.Add(name);
                }
            }
            else
            {
                if (isMatchLength(name, criteriaInt))
                {
                    updateGuests.Add(name);
                    updateGuests.Add(name);
                }
                else
                {
                    updateGuests.Add(name);
                }
            }
        }
    }

    return updateGuests;
}


static bool FindMatchFirst (string name, string startWith)
{
    if (name.Length < startWith.Length)
    {
        return false;
    }
    else
    {
        for (int i = 0; i < startWith.Length; i++)
        {
            if (name[i] != startWith[i])
            {
                return false;
            }
        }
    }
    return true;
}


static bool FindMatchLast(string name, string endWith)
{
    if (name.Length < endWith.Length)
    {
        return false;
    }
    else
    {
        for (int i = endWith.Length - 1; i >=0; i--)
        {
            int diff = name.Length - endWith.Length;

            if (name[i + diff] != endWith[i])
            {
                return false;
            }
        }
    }
    return true;
}


static bool IsMatchLength(string name, int length)
{
    if (name.Length != length)
    {
        return false;
    }

    return true;
}