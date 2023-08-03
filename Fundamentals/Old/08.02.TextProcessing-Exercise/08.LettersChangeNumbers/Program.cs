using System.Text.RegularExpressions;

string[] input = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

double totalSum = 0;
string patternFirstChar = @"[A-Z](?:.+)";
string patternLastChar = @"(?:.+)[A-Z]";
Regex regexFirstChar = new Regex(patternFirstChar);
Regex regexLastChar = new Regex(patternLastChar);

//12/1=12, 12+2=14,  17*19=323, 323–7=316, 14+316=330

foreach (var item in input)
{
    double number = int.Parse(item.Substring(1, item.Length - 2));

    if (regexFirstChar.IsMatch(item))
    {
        number /= (item[0] - 64); 
    }
    else
    {
        number *= (item[0] - 96);
    }

    if (regexLastChar.IsMatch(item))
    {
        number -= (item[item.Length - 1] - 64);
    }
    else
    {
        number += (item[item.Length - 1] - 96);
    }

    totalSum += number;
}

Console.WriteLine($"{ totalSum:f2}");