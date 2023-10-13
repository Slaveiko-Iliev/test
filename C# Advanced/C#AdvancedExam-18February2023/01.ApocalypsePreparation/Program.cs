using System;
using System.Collections.Generic;
using System.Linq;

int[] textilesAsArray = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> textiles  = new();

foreach (var textile in textilesAsArray)
{
    textiles.Enqueue(textile);
}

int[] medicamentsAsArray = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> medicaments = new();

foreach (var medicament in medicamentsAsArray)
{
    medicaments.Push(medicament);
}

Dictionary<string, int> healingItems  = new ()
{
    {"MedKit", 100},
    {"Bandage", 40},
    {"Patch", 30}
};

Dictionary<string, int> healingItemsCount = new()
{
    {"MedKit", 0},
    {"Bandage", 0},
    {"Patch", 0}
};

while (textiles.Count > 0 && medicaments.Count > 0)
{
    int medicament = medicaments.Peek();
    int resources = textiles.Dequeue() + medicaments.Pop();

    if (resources > healingItems["MedKit"])
    {
        int medicamentToReturn = resources - healingItems["MedKit"];
        medicaments.Push(medicaments.Pop() + medicamentToReturn);
        healingItemsCount["MedKit"]++;
        continue;
    }

    bool isEqual = false;

    foreach(var (healingItem, esourcesNeeded) in healingItems)
    {
        if (esourcesNeeded == resources)
        {
            healingItemsCount[healingItem] ++;
            isEqual = true;
            break;
        }
    }
        
    if (!isEqual)
    {
        medicaments.Push(medicament + 10);
    }
}

if (!textiles.Any() && !medicaments.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");       
}
else if (!textiles.Any())
{
    Console.WriteLine("Textiles are empty.");
}
else if (!medicaments.Any())
{
    Console.WriteLine("Medicaments are empty.");
}

foreach (var healingItem in healingItemsCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Where(x => x.Value > 0))
{
    Console.WriteLine($"{healingItem.Key} - {healingItem.Value}");
}

if (!textiles.Any() && medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}

if (textiles.Any() && !medicaments.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}
