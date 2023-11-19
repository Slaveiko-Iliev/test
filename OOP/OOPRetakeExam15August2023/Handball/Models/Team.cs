using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string _name;
        private int _pointsEarned;
        private List<IPlayer> _players;

        public Team(string name)
        {
            Name = name;
            _pointsEarned = 0;
            _players = new List<IPlayer>();
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                _name = value;
            }
        }

        public int PointsEarned => _pointsEarned;

        public double OverallRating
        {
            get
            {
                if (Players.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return Math.Round(Players.Average(p => p.Rating), 2);
                }
            }
        }

        public IReadOnlyCollection<IPlayer> Players => this._players.AsReadOnly();

        public void Draw()
        {
            _pointsEarned += 1;

            Players.FirstOrDefault(p => p.GetType().Name == nameof(Goalkeeper)).IncreaseRating();
        }

        public void Lose()
        {
            foreach (var player in Players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            if (!_players.Contains(player))
            {
                _players.Add(player);
            }
        }

        public void Win()
        {
            _pointsEarned += 3;

            foreach (var player in Players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            var playersName = Players.Select(p => p.Name).ToList();

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            if (Players.Count == 0)
            {
                sb.AppendLine("--Players: none");
            }
            else
            {
                sb.AppendLine($"--Players: {string.Join(", ", playersName)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
