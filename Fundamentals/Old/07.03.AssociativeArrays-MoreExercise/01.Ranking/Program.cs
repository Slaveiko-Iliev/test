using System;

string input = string.Empty;

Dictionary<string, string> listOfContests = new Dictionary<string, string>();

while ((input = Console.ReadLine()) != "end of contests")
{
    string[] contestInfo = input.Split(":");
    string contest = contestInfo[0];
    string passwordForContest = contestInfo[1];

    if (!listOfContests.ContainsKey(contest))
    {
        listOfContests.Add(contest, passwordForContest);
    }

}

Dictionary<string, int> userContests = new Dictionary<string, int>();

Dictionary<string, Dictionary<string, int>> usersInfo = new Dictionary<string, Dictionary<string, int>>();

while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] result = input.Split("=>");
    string contest = result[0];
    string passwordForContest = result[1];
    string username = result[2];
    int points = int.Parse(result[3]);

    if (!listOfContests.ContainsKey(contest) || listOfContests[contest] != passwordForContest)
    {
        continue;
    }

    if (!usersInfo.ContainsKey(username))
    {
        usersInfo.Add(username, new Dictionary<string, int>());
    }

    if (!usersInfo[username].ContainsKey(contest))
    {
        usersInfo[username].Add(contest, points);
    }

    if (usersInfo[username].ContainsKey(contest) && usersInfo[username][contest] < points)
    {
        usersInfo[username][contest] = points;
    }
}

var bestCandidate = usersInfo.OrderByDescending(x => x.Value.Values.Sum()).First();

Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");

usersInfo = usersInfo.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value));

Console.WriteLine("Ranking: ");

foreach (var user in usersInfo)
{
    Console.WriteLine($"{user.Key}");

    foreach (var contest in user.Value)
    {
        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
    }
}


