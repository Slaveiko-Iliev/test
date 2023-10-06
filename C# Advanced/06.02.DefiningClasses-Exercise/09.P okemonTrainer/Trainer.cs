using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _09.P_okemonTrainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name, int numberOfBadges)
        {
            Name = name;
            NumberOfBadges = numberOfBadges;
            pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
    }
}
