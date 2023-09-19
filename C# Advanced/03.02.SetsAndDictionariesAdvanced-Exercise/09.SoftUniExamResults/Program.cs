using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, int> languagesInfo = new();
Dictionary<string, Dictionary<string, int>> usersSubmissions = new();
string input = string.Empty;

while ((input = Console.ReadLine()) != "exam finished")
{
    string[] submissionInfo = input
        .Split("-", StringSplitOptions.RemoveEmptyEntries);

    string username = submissionInfo[0];
    string language = submissionInfo[1];

    if (language == "banned")
    {
        usersSubmissions.Remove(username);
        continue;
    }

    int points = int.Parse(submissionInfo[2]);

    if (!usersSubmissions.ContainsKey(username))
    {
        usersSubmissions[username] = new Dictionary<string, int>();
    }

    if (!usersSubmissions[username].ContainsKey(language))
    {
        usersSubmissions[username][language] = points;
    }
    else
    {
        if (usersSubmissions[username][language] < points)
        {
            usersSubmissions[username][language] = points;
        }
    }

    if (!languagesInfo.ContainsKey(language))
    {
        languagesInfo[language] = 0;
    }

    languagesInfo[language]++;
}

Console.WriteLine("Results:");
foreach (var (user, languages) in usersSubmissions.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value))
{
    Console.WriteLine($"{user} | {languages.Values.Sum()}");
}

Console.WriteLine("Submissions:");
foreach (var (language, submissionsCount) in languagesInfo.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value))
{
    Console.WriteLine($"{language} - {submissionsCount}");
}