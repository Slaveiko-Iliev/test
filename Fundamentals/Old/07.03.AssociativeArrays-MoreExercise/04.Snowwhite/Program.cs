using System.Xml.Linq;

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

var sortedDwarfs = new Dictionary<string, int>();

foreach (var kvp in dwarfs.OrderByDescending(x => x.Value.Count()))
{
    string hatColor = kvp.Key;

    foreach (var dwarf in kvp.Value)
    {
        string name = dwarf.Key;
        int physics = dwarf.Value;

        sortedDwarfs.Add(($"({hatColor}) {name} <-> "), physics);
    }
}

foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
{
    Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
}


