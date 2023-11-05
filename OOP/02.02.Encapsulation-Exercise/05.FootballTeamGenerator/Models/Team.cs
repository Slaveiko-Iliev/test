using System;

namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private string _teamName;
        private List<Player> _players;

        public Team(string teamName)
        {
            TeamName = teamName;
            _players = new List<Player>();
        }

        public string TeamName
        {
            get => _teamName;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage.EmptyName);
                }
                _teamName = value;
            }
        }
        public double Rating => Math.Round(_players.Average(p => p.OverallSkillsLevel()));

        public void AddPlayer(Player player)
        {
            if (!_players.Contains(player))
            {
                _players.Add(player);
            }
        }
        public void RemovePlayer(string playerName)
        {
            Player player = _players.FirstOrDefault(p => p.PlayerName == playerName);


            if (!_players.Contains(player))
            {
                throw new ArgumentException($"Player {playerName} is not in {TeamName} team.");
            }
            else
            {
                _players.Remove(player);
            }
        }

        public double TeamRating(string teamName)
        {
            double rating = 0;

            foreach (Player player in _players)
            {
                rating += player.OverallSkillsLevel();
            }

            return rating;
        }
    }
}
