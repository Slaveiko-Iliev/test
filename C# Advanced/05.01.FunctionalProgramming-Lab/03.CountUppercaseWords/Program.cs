using System;
using System.Linq;

string[] inputArray = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string, bool> func = IsUpper;

string [] upperWords = inputArray.Where(x => IsUpper(x))
    .ToArray();

Console.WriteLine(string.Join(Environment.NewLine, upperWords));


bool IsUpper(string word)
{
    if (char.IsUpper(word[0]))
    {
        return true;
    }
    else
    {
        return false;
    }
}