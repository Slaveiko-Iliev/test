string input = string.Empty;

Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

int dislikeCount = 0;

while ((input = Console.ReadLine()) != "Stop")
{
    string[] commandInfo = input
        .Split('-');

    string command = commandInfo[0];
    string guest = commandInfo[1];
    string meal = commandInfo[2];

    if (command == "Like")
    {
        if (!guests.ContainsKey(guest))
        {
            guests.Add(guest, new List<string>());
            guests[guest].Add(meal);
        }
        else
        {
            if (!guests[guest].Contains(meal))
            {
                guests[guest].Add(meal);
            }
        }
    }
    else if (command == "Dislike")
    {
        if (!guests.ContainsKey(guest))
        {
            Console.WriteLine($"{guest} is not at the party.");
            continue;
        }
        
        if (guests[guest].Contains (meal))
        {
            Console.WriteLine($"{guest} doesn't like the {meal}.");
            guests[guest].Remove(meal);
            dislikeCount ++;
        }
        else
        {
            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
        }
    }
}

foreach (var guest in guests)
{
    Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
}

Console.WriteLine($"Unliked meals: {dislikeCount}");