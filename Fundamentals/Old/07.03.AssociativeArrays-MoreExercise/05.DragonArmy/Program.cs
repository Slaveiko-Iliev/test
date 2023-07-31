//{type} {name} {damage} {health} {armor}

int number = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, List<int>>> dragonArmy = new Dictionary<string, Dictionary<string, List<int>>>();

for (int i = 0; i < number; i++)
{
    string[] dragonInfo = Console.ReadLine()
        .Split();

    string type = dragonInfo[0];
    string name = dragonInfo[1];
    if (dragonInfo[2] != "null")
    {
        int damage = int.Parse(dragonInfo[2]);
    }
    else
    {
        int damage = 250;
    }
    if (dragonInfo[3] != "null")
    {
        int health = int.Parse(dragonInfo[3]);
    }
    else
    {
        int health = 45;
    }
    if (dragonInfo[4] != "null")
    {
        int armor = int.Parse(dragonInfo[4]);
    }
    else
    {
        int armor = 10;
    }


}