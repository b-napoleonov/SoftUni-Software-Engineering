using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            List<Pokemon> pokemons = new List<Pokemon>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Trainer currentTrainer = new Trainer(trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.Exists(t => t.Name == trainerName))
                {
                    trainers.Add(currentTrainer);
                }
                trainers.First(t => t.Name == trainerName).Pokemons.Add(currentPokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(t => t.Badges)));
        }
    }
}
