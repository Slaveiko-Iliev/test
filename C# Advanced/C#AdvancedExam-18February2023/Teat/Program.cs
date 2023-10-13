using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;

int[] textilesAsArray = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> textiles = new();

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

List<HealingItem> healingItems = new();

HealingItem healingItem1 = new HealingItem("MedKit", 100, 0);
HealingItem healingItem2 = new HealingItem("Bandage", 40, 0);
HealingItem healingItem3 = new HealingItem("Patch", 30, 0);

while (textiles.Count > 0 && medicaments.Count > 0)
{
    int resources = textiles.Dequeue() + medicaments.Pop();

    if (resources > healingItems.Where(healingItem => healingItem.Name = "MedKit"))
    {
        int medicamentToReturn = resources - healingItems["MedKit"][0];
        medicaments.Push(medicaments.Pop() + medicamentToReturn);
        healingItems["MedKit"][1]++;
        break;
    }

    bool isEqual = false;

    foreach (var (healingItem, info) in healingItems)
    {
        if (info[0] == resources)
        {
            healingItems[healingItem][1]++;
            isEqual = true;
            break;
        }
    }

    int medicament = medicaments.Peek();

    if (!isEqual)
    {
        medicaments.Push(medicament + 10);
    }
}



public class HealingItem
{
    private string name;
    private int resourcesNeeded;
    private int count;

    public HealingItem(string name, int resourcesNeeded, int count)
    {
        Name = name;
        ResourcesNeeded = resourcesNeeded;
        Count = count;
    }

    public string Name { get; set; }
    public int ResourcesNeeded { get; set; }
    public int Count { get; set; }

}