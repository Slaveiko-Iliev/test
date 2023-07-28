string input = string.Empty;

var dwarfs = new Dictionary<string, Dictionary<string, int>>();

while ((input = Console.ReadLine()) != "Once upon a time")
{
    string[] dwarfInfo = input.Split(" <:> ");


    string name = dwarfInfo[0];
    string color = dwarfInfo[1];
    int physics = int.Parse(dwarfInfo[2]);

    if (dwarfs.ContainsKey(color))
    {
        if (dwarfs[color].ContainsKey(name))
        {
            if (dwarfs[color][name] < physics)
            {
                dwarfs[color][name] = physics;
            }
        }
        else
        {
            dwarfs[color].Add(name, physics);
        }
    }
    else
    {
        dwarfs.Add(color, new Dictionary<string, int>());
        dwarfs[color].Add(name, physics);
    }

    
}

var orderedDwarfs = dwarfs.OrderByDescending(x => x.Value.Values).ThenByDescending(x => x.Key.Count()).ToDictionary(x => x.Key, x => x.Value);


foreach (var item in dwarfs)
{
    foreach (var items in dwarfs[item.Key])
    {
        Console.WriteLine($"({item.Key}) {items.Key} <-> {items.Value}");
    }
}

//"({hatColor}) {name} <-> {physics}"

