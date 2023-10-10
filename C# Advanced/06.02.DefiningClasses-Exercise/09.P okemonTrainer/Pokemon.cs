using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _09.P_okemonTrainer
{
    public class Pokemon
    {
        private string pokemonName;
        private string element;
        private int health;

        public Pokemon(string pokemonName, string element, int health)
        {
            PokemonName = pokemonName;
            Element = element;
            Health = health;
        }

        public string PokemonName { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }

        
    }
}

