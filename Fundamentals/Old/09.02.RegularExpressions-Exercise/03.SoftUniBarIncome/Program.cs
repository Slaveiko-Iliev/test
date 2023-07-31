using System.Text.RegularExpressions;

string pattern = @"(?:%)(?<customer>[A-Z][a-z]+)(?:%)(?:.*)(?:<)(?<product>\w+)(?:>)(?:.*)(?:\|)(?<count>\d+)(?:\|)(?:\D*)(?<price>\d+(\.\d{1,2})?)(?:\$)";

string input = string.Empty;
double totalIncome = 0;

Regex validateOrder = new Regex(pattern);

while ((input = Console.ReadLine()) != "end of shift")
{
    if (validateOrder.IsMatch(input))
    {
        Match validOrder = validateOrder.Match(input);

        double total = double.Parse(validOrder.Groups["count"].Value) * double.Parse(validOrder.Groups["price"].Value);

        totalIncome += total;

        Console.WriteLine($"{validOrder.Groups["customer"].Value}: {validOrder.Groups["product"].Value} - {total:f2}");
    }


}

Console.WriteLine($"Total income: {totalIncome:f2}");