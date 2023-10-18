using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> _players;
        
        public Team(string name, int openPosition, char group)
        {
            TeamName = name;
            OpenPositions = openPosition;
            Group = group;
            _players = new List<Player>();
        }

        public string TeamName { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public IReadOnlyCollection<Player> Players => _players;
        public int PlayerCount => Players.Count;


        public string AddPlayer(Player player)
        {
            if (player.PlayerName == null || player.PlayerName == string.Empty || player.Position == null || player.Position == string.Empty)
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                _players.Add(player);
                OpenPositions--;
                return $"Successfully added {player.PlayerName} to the team. Remaining open positions: {OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = _players.Find(x => x.PlayerName == name);
            if (player != null)
            {
                OpenPositions++;
            }

            return _players.Remove(player);
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;

            for (int i = 0; i < Players.Count; i++)
            {
                if (_players[i].Position == position)
                {
                    _players.Remove(_players[i]);
                    OpenPositions++;
                    count++;
                }
            }

            return count;
        }

        public Player RetirePlayer(string name)
        {
            Player player = _players.Find(x => x.PlayerName == name);

            if (player != null)
            {
                player.Retired = true;
                return player;
            }
            else { return null; }
        }

        public List<Player> AwardPlayers(int games)
        {
            List <Player> temp = new List<Player>();
            temp = Players.Where(x => x.Games >= games).ToList();
            return temp;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Active players competing for Team {team} from Group {group}:");

            foreach (Player player in Players)
            {
                if (player.Retired == false)
                {
                    sb.AppendLine(player.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

