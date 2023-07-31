using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

string[] participantsInput = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

Dictionary<string, int> listOfparticipants = new Dictionary<string, int>();

string patternForNameOfParticipant = @"[A-Za-z]";

string input = string.Empty;

while ((input = Console.ReadLine()) != "end of race")
{
    int totalDistanceInInput = 0;

    foreach (char character in input)
    {
        if (Char.IsDigit(character))
        {
            totalDistanceInInput += character - 48;
        }
    }

    Regex regexForName = new Regex(patternForNameOfParticipant);

    MatchCollection nameAsChars = regexForName.Matches(input);
    string nameAsString = string.Empty;

    foreach (Match match in nameAsChars)
    {
        nameAsString += match.Value;
    }

    if (!listOfparticipants.ContainsKey(nameAsString) && participantsInput.Contains(nameAsString))
    {
        listOfparticipants.Add(nameAsString, totalDistanceInInput);
    }
    else if (listOfparticipants.ContainsKey(nameAsString) && participantsInput.Contains(nameAsString))
    {
        listOfparticipants[nameAsString] += totalDistanceInInput;
    }
}

listOfparticipants = listOfparticipants.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


Console.WriteLine($"1st place: {listOfparticipants.Keys.ElementAt(0)}");
Console.WriteLine($"2nd place: {listOfparticipants.Keys.ElementAt(1)}");
Console.WriteLine($"3rd place: {listOfparticipants.Keys.ElementAt(2)}");