using System.Linq;
using System.Runtime.CompilerServices;

string input = string.Empty;

Dictionary<string, Dictionary<string,int>> contests = new Dictionary<string, Dictionary<string, int>>();
Dictionary<string, int> userPoints = new Dictionary<string, int>();

while ((input = Console.ReadLine()) != "no more time")
{
    string[] userContest = input.Split(" -> ");

    string username = userContest[0];
    string contest = userContest[1];
    int points = int.Parse(userContest[2]);



    if (!contests.ContainsKey(contest))
    {
        contests.Add(contest, new Dictionary<string, int>());
    }

    if (!contests[contest].ContainsKey(username))
    {
        contests[contest].Add(username, points);
    }
    else
    {
        if (contests[contest][username] < points)
        {
            contests[contest][username] = points;
        }
    }

    if (!userPoints.ContainsKey(username))
    {
        userPoints.Add(username, points);
    }
    else
    {
        userPoints[username] += points;
    }
}

int counter = 0;

foreach (var contest in contests)
{
    Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

    foreach (var username in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
    {
        counter ++;

        Console.WriteLine($"{counter}. {username.Key} <::> {username.Value}");
    }

    counter = 0;
}

Console.WriteLine("Individual standings:");

counter = 0;

foreach (var user in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    counter ++;
    Console.WriteLine($"{counter}. {user.Key} -> {user.Value}");
}
