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

Dictionary<string, int> userInfo = new Dictionary<string, int>();

while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] result = input.Split("=>");
    string contest = result[0];
    string passwordForContest = result[1];
    string username = result[2];
    int points = int.Parse(result[3]);

    if (!listOfContests.ContainsKey (contest) && listOfContests[contest] ==passwordForContest)
    {
        if(!userInfo.ContainsKey(username))
        {
            userInfo.Add(username, points);
        }
    }
}
