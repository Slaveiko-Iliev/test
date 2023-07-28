using System.Text.RegularExpressions;

string pattern = @"\b[A-Z][a-z]+\ {1}[A-Z][a-z]+\b";
string text = Console.ReadLine();

MatchCollection matches = Regex.Matches(text, pattern);

foreach (Match match in matches)
{
    Console.Write($"{match.Value} ");
}