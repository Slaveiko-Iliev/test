using System;

int number = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

Func<string, int, bool> compare = CompareSumOfCharWithNum;
Func<string[], Func<string, int, bool>, int, string> findRightName = FindFirst;

Console.WriteLine(findRightName(names, compare, number));



static bool CompareSumOfCharWithNum(string name, int number)
{
    int sum = 0;

    foreach (char c in name)
    {
        sum += c;
    }

    if (sum >= number)
    {
        return true;
    }
    else
    {
        return false;
    }
}

static string FindFirst(string[] names, Func<string, int, bool> compare, int number)
{
    string result = string.Empty;

    foreach (string name in names)
    {
        if (compare(name, number))
        {
            result = name;
            break;
        }
    }

    return result;
}
