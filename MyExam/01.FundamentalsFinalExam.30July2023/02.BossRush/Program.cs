using System.Text.RegularExpressions;

int number = int.Parse(Console.ReadLine());

string pattern = @"(?:\|)(?<bossName>[A-Z]{4,})(?:\|):(?:#)(?<title>[a-zA-Z]+ [a-zA-Z]+)(?:#)";

for (int i = 0; i < number; i++)
{
    string bossInfo = Console.ReadLine();

    Regex regex = new Regex(pattern);
    

    if (Regex.IsMatch(bossInfo, pattern))
    {
        Match match = regex.Match(bossInfo);
        string bossName = match.Groups["bossName"].Value;
        string title = match.Groups["title"].Value;

        Console.WriteLine($"{bossName}, The {title}");
        Console.WriteLine($">> Strength: {bossName.Length}");
        Console.WriteLine($">> Armor: {title.Length}");
    }
    else
    {
        Console.WriteLine("Access denied!");
    }
}