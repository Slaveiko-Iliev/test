using System.Text.RegularExpressions;

string input = Console.ReadLine();

string patternForSplit = @",\s*";
string patternForHealth = @"[^0-9+\-*\/.]";

//Regex findInfoForHealth = new Regex(patternForHealth);

string[] namesOfDemons = Regex.Split(input, patternForSplit);

Dictionary<string, List<double>> demons = new Dictionary<string, List<double>>();

foreach (string name in namesOfDemons)
{
    double health = 0;
    double damage = 0;

    var healthInfo = Regex.Matches(name, patternForHealth)
    .Cast<char>()
    .ToArray();

    //MatchCollection healthInfo = findInfoForHealth.Matches(name);
    //var list = healthInfo.Cast<Match>().Select(match => match.Value).ToList();

    //Console.WriteLine( string.Join("", list));

    foreach (var match in healthInfo)
    {
        health += match;
    }
    ;
}
