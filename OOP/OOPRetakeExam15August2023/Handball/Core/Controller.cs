using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository _players;
        private TeamRepository _teams;

        public Controller()
        {
            _players = new PlayerRepository();
            _teams = new TeamRepository();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new();


            sb.AppendLine("***League Standings***");

            foreach (var team in _teams.Models.OrderByDescending(t => t.PointsEarned).ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!_teams.ExistsModel(teamName))
            {
                return $"Team with the name {teamName} does not exist in the {_teams.GetType().Name}.";
            }
            if (!_players.ExistsModel(playerName))
            {
                return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";
            }
            else
            {
                if (_players.GetModel(playerName).Team != null)
                {
                    return $"Player {playerName} has already signed with {_players.GetModel(playerName).Team}.";
                }
                else
                {
                    _players.GetModel(playerName).JoinTeam(teamName);
                    _teams.GetModel(teamName).SignContract(_players.GetModel(playerName));

                    return $"Player {playerName} signed a contract with {teamName}.";
                }
            }


        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = _teams.GetModel(firstTeamName);
            ITeam secondTeam = _teams.GetModel(secondTeamName);
            double batleExit = firstTeam.OverallRating - secondTeam.OverallRating;

            if (batleExit > 0)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return $"Team {firstTeamName} wins the game over {secondTeamName}!";
            }
            else if (batleExit < 0)
            {
                firstTeam.Lose();
                secondTeam.Win();
                return $"Team {secondTeamName} wins the game over {firstTeamName}!";
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return $"The game between {firstTeamName} and {secondTeamName} ends in a draw!";
            }
        }

        public string NewPlayer(string typeName, string name)
        {
            var subclassTypes = Assembly
               .GetAssembly(typeof(Player))
               .GetTypes()
               .Where(t => t.IsSubclassOf(typeof(Player)));
            if (!subclassTypes.Any(st => st.Name == typeName))
            {
                return $"{typeName} is invalid position for the application.";
            }
            if (_players.ExistsModel(name))
            {
                return $"{name} is already added to the {_players.GetType().Name} as {typeName}.";
            }
            else
            {
                IPlayer player;
                if (typeName == nameof(CenterBack))
                {
                    player = new CenterBack(name);
                }
                else if (typeName == nameof(ForwardWing))
                {
                    player = new ForwardWing(name);
                }
                else if (typeName == nameof(Goalkeeper))
                {
                    player = new Goalkeeper(name);
                }
                return $"{name} is filed for the handball league.";
            }

        }

        public string NewTeam(string name)
        {
            if (!_teams.ExistsModel(name))
            {
                ITeam team = new Team(name);
                _teams.AddModel(team);
                return $"{name} is successfully added to the {_teams.GetType().Name}.";
            }
            else
            {
                return $"{name} is already added to the {_teams.GetType().Name}.";
            }
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new();

            sb.AppendLine($"***{teamName}***");

            ITeam team = _teams.GetModel(teamName);

            foreach (var player in team.Players.OrderByDescending(pl => pl.Rating).ThenBy(pl => pl.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
