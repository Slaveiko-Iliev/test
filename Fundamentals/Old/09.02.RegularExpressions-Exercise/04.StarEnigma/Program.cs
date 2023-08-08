using System.Text.RegularExpressions;

int number = int.Parse(Console.ReadLine());

string paternCheckStar = @"[STARstar]";
string patternValidateMessage = @"@(?<planetName>[A-Za-z]+)[^@:!\->]*:(?<PlanetPopulation>\d+)[^@:!\->]*!(?<attackType>[A|D])![^@:!\->]*\->(?<soldierCount>\d+)";

Regex getDecryptionKey = new Regex(paternCheckStar);
Regex validateMessage = new Regex(patternValidateMessage);

int attackedPlanetsCount = 0;
int destroyedPlanetsCount = 0;

List<string> attackedPlanets = new List<string>();
List<string> destroyedPlanets = new List<string>();

for (int i = 0; i < number; i++)
{
    string encryptedMessage = Console.ReadLine();

    MatchCollection decryptionKeyAsMatch = Regex.Matches(encryptedMessage, paternCheckStar);
    int decryptionKey = decryptionKeyAsMatch.Count();

    string decryptedMessage = string.Empty;

    foreach (char ch in encryptedMessage)
    {
        decryptedMessage += (char)(ch- decryptionKey);
    }



    Match validMessage = Regex.Match(decryptedMessage, patternValidateMessage);

    if (validateMessage.IsMatch(decryptedMessage))
    {
        if (validMessage.Groups["attackType"].ToString() == "A")
        {
            attackedPlanetsCount ++;
            attackedPlanets.Add(validMessage.Groups["planetName"].ToString());
        }
        else if (validMessage.Groups["attackType"].ToString() == "D")
        {
            destroyedPlanetsCount ++;
            destroyedPlanets.Add(validMessage.Groups["planetName"].ToString());
        }
    }
}

Console.WriteLine($"Attacked planets: {attackedPlanetsCount}");
foreach (string planet in attackedPlanets.OrderBy(x => x))
{
    Console.WriteLine($"-> {planet}");
}

Console.WriteLine($"Destroyed planets: {destroyedPlanetsCount}");
foreach (string planet in destroyedPlanets.OrderBy(x => x))
{
    Console.WriteLine($"-> {planet}");
}