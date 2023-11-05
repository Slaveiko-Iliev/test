namespace _05.FootballTeamGenerator.Models
{
    public class Ligue
    {
        private List<Team> _teams;

        public Ligue()
        {
            _teams = new List<Team>();
        }

        public void AddTeam(Team team)
        {
            if (!_teams.Contains(team))
            {
                _teams.Add(team);
            }
        }

        public IReadOnlyList <Team> Teams => _teams;
        public bool IsTeamExists(string teamName)
        {
            return _teams.Contains(_teams.FirstOrDefault(t => t.TeamName == teamName));
        }
    }
}
