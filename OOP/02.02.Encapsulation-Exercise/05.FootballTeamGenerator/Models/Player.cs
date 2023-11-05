using System;

namespace _05.FootballTeamGenerator.Models
{
    public class Player
    {
        private string _playerName;
        private List<double> _playerSkils;
        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            PlayerName = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            _playerSkils = new List<double>() { Endurance, Sprint, Dribble, Passing, Shooting};
        }
        
        public string PlayerName
        {
            get => _playerName;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage.EmptyName);
                }
                _playerName = value;
            }
        }
        private int Endurance
        {
            get => _endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
                }
                _endurance = value;
            }
        }
        private int Sprint
        {
            get => _sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
                }
                _sprint = value;
            }
        }
        private int Dribble
        {
            get => _dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
                }
                _dribble = value;
            }
        }
        private int Passing
        {
            get => _passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
                }
                _passing = value;
            }
        }
        private int Shooting
        {
            get => _shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
                }
                _shooting = value;
            }
        }
        public double OverallSkillsLevel()
        {
            double overallSkills = _playerSkils.Sum() / _playerSkils.Count;

            return Math.Round(overallSkills);
        } 
    }
}
