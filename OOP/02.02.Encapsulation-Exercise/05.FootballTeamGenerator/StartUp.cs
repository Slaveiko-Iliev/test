using _05.FootballTeamGenerator.Models;
using System.Numerics;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main()
        {
            Ligue ligue = new Ligue();
            
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {

                try
                { 
                    string[] commandInfo = input
                        .Split(";", StringSplitOptions.RemoveEmptyEntries);

                    string command = commandInfo[0];
                    string teamName = commandInfo[1];

                    if (command == "Team")
                    {
                        Team team = new(teamName);
                        ligue.AddTeam(team);
                    }
                    else if (command == "Add")
                    {
                        string playerName = commandInfo[2];
                        int endurance = int.Parse(commandInfo[3]);
                        int sprint = int.Parse(commandInfo[4]);
                        int dribble = int.Parse(commandInfo[5]);
                        int passing = int.Parse(commandInfo[6]);
                        int shooting = int.Parse(commandInfo[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        Team team = ligue.Teams.First(t => t.TeamName == teamName);

                        if (ligue.IsTeamExists(teamName))
                        {
                            team.AddPlayer(player);
                        }
                        else throw new ArgumentException($"Team {team.TeamName} does not exist.");
                    }
                    else if (command == "Remove")
                    {
                        string playerName = commandInfo[2];
                        Team team = ligue.Teams.First(t => t.TeamName == teamName);

                        if (ligue.IsTeamExists(teamName))
                        {
                            team.RemovePlayer(playerName);
                        }
                        else throw new ArgumentException($"Team {team.TeamName} does not exist.");
                    }
                    else if (command == "Rating")
                    {
                        Team team = ligue.Teams.First(t => t.TeamName == teamName);

                        if (ligue.IsTeamExists(teamName))
                        {
                            Console.WriteLine($"{teamName} - {team.TeamRating(teamName)}");
                        }
                        else throw new ArgumentException($"Team {team.TeamName} does not exist.");
                    }
                }
            
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
        }
    }
}
