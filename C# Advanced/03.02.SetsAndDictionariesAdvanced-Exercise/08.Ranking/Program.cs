using System;
using System.Collections.Generic;
using System.Linq;

string input = string.Empty;

Dictionary<string, string> passInfo = new();

while ((input = Console.ReadLine()) != "end of contests")
{
    string[] contestAndPass = input
        .Split(":", StringSplitOptions.RemoveEmptyEntries);
    string contest = contestAndPass[0];
    string pass = contestAndPass[1];

    if (!passInfo.ContainsKey(contest))
    {
        passInfo.Add(contest, pass);
    }
}

Dictionary<string, Dictionary<string, int>> usersContests = new();

while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] submission = input
        .Split("=>", StringSplitOptions.RemoveEmptyEntries);
    string contest = submission[0];
    string pass = submission[1];
    string username = submission[2];
    int points = int.Parse(submission[3]);

    if (!passInfo.ContainsKey(contest) || passInfo[contest] != pass)
    {
        continue;
    }

    if (!usersContests.ContainsKey(username))
    {
        usersContests[username] = new Dictionary<string, int>();
    }

    if (!usersContests[username].ContainsKey(contest))
    {
        usersContests[username][contest] = points;
    }
    
    if(usersContests[username][contest] < points)
    {
        usersContests[username][contest] = points;
    }
}

string bestCandidate = string.Empty;
int maxPoint = 0;

foreach (var (user, contests) in usersContests)
{
    int userPoints = 0;
    
    foreach (var (contest, points) in contests)
    {
        userPoints += points;
    }

    if (userPoints > maxPoint)
    {
        bestCandidate = user;
        maxPoint = userPoints;
    }
}

Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoint} points.");
Console.WriteLine("Ranking: ");

foreach (var (user, contests) in usersContests.OrderBy(x => x.Key))
{
    Console.WriteLine(user);

    foreach (var (contest, points) in contests.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {contest} -> {points}");
    }
}

