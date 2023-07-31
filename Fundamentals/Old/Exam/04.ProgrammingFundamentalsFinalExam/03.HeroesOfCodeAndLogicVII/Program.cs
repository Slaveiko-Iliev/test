int number = int.Parse(Console.ReadLine());

//List<Hero> heroes = new List<Hero>();

Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

for (int i = 0; i < number; i++)
{
    string[] heroesInfo = Console.ReadLine()
        .Split();

    string heroName = heroesInfo[0];
    int hitPoints = int.Parse(heroesInfo[1]);
    int manaPoints = int.Parse(heroesInfo[2]);

    heroes.Add(heroName, new List<int> ());
    heroes[heroName].Add(hitPoints);
    heroes[heroName].Add (manaPoints);
}

string input = string.Empty;

while ((input = Console.ReadLine()) != "End")
{
    string[] commandInfo = input
        .Split(" - ");

    string command = commandInfo[0];
    string heroName = commandInfo[1];

    if (command == "CastSpell")
    {
        int manaPointNeeded = int.Parse(commandInfo[2]);
        string spellName = commandInfo[3];

        if (heroes[heroName][1] >= manaPointNeeded)
        {
            int manaPointsLeft = heroes[heroName][1] - manaPointNeeded;
            heroes[heroName][1] -= manaPointNeeded;

            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {manaPointsLeft} MP!");
        }
        else
        {
            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
        }
    }
    else if (command == "TakeDamage")
    {
        int damage = int.Parse(commandInfo[2]);
        string attacker = commandInfo[3];

        if (heroes[heroName][0]  > damage)
        {
            int currentHP = heroes[heroName][0] - damage;

            heroes[heroName][0] -= damage;
            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currentHP} HP left!");
        }
        else
        {
            Console.WriteLine($"{heroName} has been killed by {attacker}!");
            heroes.Remove(heroName);
        }
    }
    else if (command == "Recharge")
    {
        int amount = int.Parse(commandInfo[2]);
        int amountRecovered = 200 - heroes[heroName][1];

        if (heroes[heroName][1] + amount <= 200)
        {
            heroes[heroName][1] += amount;
            Console.WriteLine($"{heroName} recharged for {amount} MP!");
        }
        else
        {
            heroes[heroName][1] = 200;
            Console.WriteLine($"{heroName} recharged for {amountRecovered} MP!");
        }
    }
    else if (command == "Heal")
    {
        int amount = int.Parse(commandInfo[2]);
        int amountRecovered = 100 - heroes[heroName][0];

        if (heroes[heroName][0] + amount <= 100)
        {
            heroes[heroName][0] += amount;
            Console.WriteLine($"{heroName} healed for {amount} HP!");
        }
        else
        {
            heroes[heroName][0] = 100;
            Console.WriteLine($"{heroName} healed for {amountRecovered} HP!");
        }
    }
}

foreach (var hero in heroes)
{
    Console.WriteLine(hero.Key);
    Console.WriteLine($"  HP: {hero.Value[0]}");
    Console.WriteLine($"  MP: {hero.Value[1]}");
}

