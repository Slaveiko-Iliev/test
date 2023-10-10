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
        private string trainerName;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string trainerName, int numberOfBadges)
        {
            TrainerName = trainerName;
            NumberOfBadges = numberOfBadges;
            //Pokemons = pokemons;
            pokemons = new List<Pokemon>();
        }

        public string TrainerName { get; set; }
        public int NumberOfBadges { get; set; }
        //public List<Pokemon> Pokemons { get; set; }
        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }


        public override string ToString()
        {

            return $"{TrainerName} {NumberOfBadges} {Pokemons.Count}";
        }
        public List<Pokemon> FindPokemonInTrouble(List<Pokemon> pokemons)
        {
            List<Pokemon> result = new ();
            
            foreach (var pokemon in pokemons)
            {
                if (pokemon.Health > 0)
                {
                    result.Add(pokemon);
                }
            }

            return result;
        }
    }
}
