int countOfTeams = int.Parse(Console.ReadLine());

List<Team> teams = new List<Team>();

for (int i = 0; i < countOfTeams; i++)
{
    List<string> members = new List<string>();

    string[] createTeam = Console.ReadLine()
        .Split("-");

    string creator = createTeam[0];
    string teamName = createTeam[1];

    bool isCreated = false;

    foreach (Team team in teams)
    {
        if (team.TeamName == teamName)
        {
            isCreated = true;
            Console.WriteLine($"Team {teamName} was already created!");
            break;
        }

        if (team.Creator == creator)
        {
            isCreated = true;
            Console.WriteLine($"{creator} cannot create another team!");
            break;
        }
    }

    if (!isCreated)
    {
        Team team = new Team(teamName, creator, members);
        team.Members.Add(creator);
        teams.Add(team);
        Console.WriteLine($"Team {teamName} has been created by {creator}!");
    }
}

string endCommand = string.Empty;



while ((endCommand = Console.ReadLine()) != "end of assignment")
{
    string[] joinMember = endCommand.Split("->");

    string user = joinMember[0];
    string teamName = joinMember[1];

    bool isJoined = false;
    bool isTeamExist = false;

    foreach (Team team in teams)
    {
        foreach (string member in team.Members)
        {
            if (member == user)
            {
                isJoined = true;
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
            }
        }

        if (team.TeamName == teamName && !isJoined)
        {
            team.Members.Add(user);
            isJoined = true;
        }

        if (team.TeamName == teamName)
        {
            isTeamExist = true;
        }
    }

    if (!isTeamExist)
    {
        Console.WriteLine($"Team {teamName} does not exist!");
    }
}

List<Team> validTeam = teams
    .Where(x => x.Members.Count > 1)
    .OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName)
    .ToList();

List<Team> invalidTeam = teams
    .Where(x => x.Members.Count <= 1)
    .OrderBy(x => x.TeamName)
    .ToList();

//foreach (Team team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName))
//{
//    if (team.Members.Count > 1)
//    {
//        Console.WriteLine($"{team.TeamName}");
//        Console.WriteLine($"- {team.Creator}");

//        foreach (string member in team.Members.OrderBy(x => x))
//        {
//            if (member != team.Creator)
//            {
//                Console.WriteLine($"-- {member}");
//            }
//        }
//    }
//}

foreach (Team team in validTeam)
{
    Console.WriteLine($"{team.TeamName}");
    Console.WriteLine($"- {team.Creator}");

        foreach (string member in team.Members.OrderBy(x => x))
        {
            if (member != team.Creator)
            {
                Console.WriteLine($"-- {member}");
            }
        }
}

Console.WriteLine("Teams to disband:");


foreach (Team team in invalidTeam)
{
    Console.WriteLine($"{team.TeamName}");
}


public class Team
{
    public Team(string teamName, string creator, List<string> members)
    {
        this.TeamName = teamName;
        this.Creator = creator;
        this.Members = members;
    }

    public string TeamName { get; set; }

    public string Creator { get; set; }

    public List<string> Members { get; set; }

}