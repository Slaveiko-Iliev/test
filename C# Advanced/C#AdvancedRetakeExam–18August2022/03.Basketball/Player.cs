using System;
using System.Text;
using System.Xml.Linq;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            PlayerName = name;
            Position = position;
            Rating = rating;
            Games = games;
            Retired = false;
        }

        public string PlayerName { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            
            return $"-Player: {PlayerName}{Environment.NewLine}" +
                $"--Position: {Position}{Environment.NewLine}" +
                $"--Rating: {Rating}{Environment.NewLine}" +
                $"--Games played:{Games}";
        }
    }
}
