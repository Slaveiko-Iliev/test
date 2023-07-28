using System.Text.RegularExpressions;

string pattern = @"(?<day>\d{2})(.|-|/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})";
string text = Console.ReadLine();

MatchCollection matchedDates = Regex.Matches(text, pattern);

foreach (Match match in matchedDates)
{
    var day = match.Groups["day"].Value;
    var month = match.Groups["month"].Value;
    var year = match.Groups["year"].Value;

    Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
}