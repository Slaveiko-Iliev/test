using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Text;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string _name;
        private double _rating;
        private string _team;

        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                _name = value;
            }
        }

        public double Rating { get => _rating; protected set => _rating = value; }

        public string Team { get => _team; private set => _team = value; }


        public abstract void DecreaseRating();

        public abstract void IncreaseRating();

        public void JoinTeam(string name)
        {
            Team = name;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{GetType().Name}: {Name}");
            sb.AppendLine($"--Rating: {Rating}");

            return sb.ToString().TrimEnd();
        }
    }
}
