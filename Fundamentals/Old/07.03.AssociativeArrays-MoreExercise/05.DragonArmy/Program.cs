using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

int number = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, List<int>>> dragonArmy = new Dictionary<string, Dictionary<string, List<int>>>();

for (int i = 0; i < number; i++)
{
    string[] dragonInfo = Console.ReadLine()
        .Split();

    int damage = 0;
    int health = 0;
    int armor = 0;

    string type = dragonInfo[0];
    string name = dragonInfo[1];
    if (dragonInfo[2] != "null")
    {
        damage = int.Parse(dragonInfo[2]);
    }
    else
    {
        damage = 45;
    }
    if (dragonInfo[3] != "null")
    {
        health = int.Parse(dragonInfo[3]);
    }
    else
    {
        health = 250;
    }
    if (dragonInfo[4] != "null")
    {
        armor = int.Parse(dragonInfo[4]);
    }
    else
    {
        armor = 10;
    }

    List<int> currentDragonSkills = new List<int>{damage, health, armor };

    if (!dragonArmy.ContainsKey(type))
    {
        dragonArmy.Add(type, new Dictionary<string, List<int>>());
        dragonArmy[type].Add(name, currentDragonSkills);
    }
    else
    {
        if (!dragonArmy[type].ContainsKey(name))
        {
            dragonArmy[type].Add(name, currentDragonSkills);
        }
        else
        {
            dragonArmy[type][name] = currentDragonSkills;
        }
    }
}



foreach (var type in dragonArmy)
{
    double averageDamage = 0;
    double averageHealth = 0;
    double averageArmor = 0;

    foreach (var dragon in type.Value)
    {
        averageDamage += dragon.Value[0];
        averageHealth += dragon.Value[1];
        averageArmor += dragon.Value[2];
    }
    averageDamage /= type.Value.Count;
    averageHealth /= type.Value.Count;
    averageArmor /= type.Value.Count;

    Console.WriteLine($"{type.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

    foreach (var dragon in type.Value.OrderBy(x=>x.Key))
    {
        Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
    }
}

//"{Type}::({damage}/{health}/{armor})"

//"-{Name} -> damage: {damage}, health: {health}, armor: {armor}"