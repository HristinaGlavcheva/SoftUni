using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string inputInfo = Console.ReadLine();

            while (inputInfo != "Tournament")
            {
                string[] inputInfoArgs = inputInfo
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputInfoArgs[0];
                string pokemonName = inputInfoArgs[1];
                string pokemonElement = inputInfoArgs[2];
                int pokemonHealth = int.Parse(inputInfoArgs[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                Trainer currentTrainer = trainers[trainerName];

                //<=> currentTraine = trainers.FirstOrDefault(x => x.Key == trainer.Name).Value;

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                currentTrainer.Pokemons.Add(pokemon);

                inputInfo = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string element = command;
                
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            trainers = trainers
                .OrderByDescending(t => t.Value.NumberOfBadges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
