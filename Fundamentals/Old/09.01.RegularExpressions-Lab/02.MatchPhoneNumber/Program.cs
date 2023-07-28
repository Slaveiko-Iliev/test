using System.Text.RegularExpressions;

string pattern = @"\+359( |-)[2]\1\d{3}\1\d{4}\b";

string input = Console.ReadLine();

MatchCollection matches = Regex.Matches(input, pattern);

var matched = matches
    .Cast<Match>()
    .Select(x => x.Value.Trim())
    .ToArray();

Console.WriteLine(string.Join(", ", matched));