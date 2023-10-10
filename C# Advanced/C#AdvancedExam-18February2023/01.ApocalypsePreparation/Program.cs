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

Dictionary<string, int> healingItem  = new ()
{
    {"MedKit", 100},
    {"Bandage", 40},
    {"Patch", 30}
};

while (textiles.Count > 0 && medicaments.Count > 0)
{
    int medicament = medicaments.Peek();
    int resources = textiles.Dequeue() + medicaments.Pop();

    if (resources > healingItem["MedKit"])
    {
        int medicamentToReturn = resources - healingItem["MedKit"];
        medicaments.Push(medicaments.Pop() + medicamentToReturn);
    }
}