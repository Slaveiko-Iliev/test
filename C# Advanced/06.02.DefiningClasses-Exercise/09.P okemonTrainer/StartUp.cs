using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _09.P_okemonTrainer
{
    public class StartUp
    {
        public static void Main()
        {
            string input = string.Empty;
            Dictionary<string, Trainer> trainers = new();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] trainerInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = trainerInfo[0];
                string pokemonName = trainerInfo[1];
                string pokemonElement = trainerInfo[2];
                int pokemonHealth = int.Parse(trainerInfo[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName, 0);
                    
                    trainers.Add(trainerName, trainer) ;
                }

                trainers[trainerName].Pokemons.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var (name, trainer) in trainers)
                {
                    bool isThereAnElement = false;

                    foreach (var pokemon in trainer.Pokemons)
                    {
                        if (pokemon.Element == input)
                        {
                            isThereAnElement = true;
                            break;
                        }
                    }

                    if (isThereAnElement)
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(pokemon => pokemon.Health -= 10);
                    }

                    trainer.Pokemons = trainer.FindPokemonInTrouble(trainer.Pokemons);
                }
            }
            foreach (var trainer in trainers.OrderByDescending(trainer => trainer.Value.NumberOfBadges))
            {
                Console.WriteLine(trainer.Value.ToString());
            }
        }
    }
}
