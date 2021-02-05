using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._09.Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            var trainers = new Dictionary<string, Trainer>();

            while ((input = Console.ReadLine().Split())[0] != "Tournament")
            {
                string  trainer     = input[0];
                string  pokeName    = input[1];
                string  pokElement  = input[2];
                int     pokHealth   = int.Parse(input[3]);
                var pokemon = new Pokemon(pokeName, pokElement, pokHealth);

                if (!trainers.ContainsKey(trainer))
                {
                    trainers[trainer] = new Trainer(trainer);
                }

                trainers[trainer].AddPokemon(new Pokemon(pokeName, pokElement, pokHealth));
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers.Values)
                {
                    if( trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.BadgesCount ++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons = trainer.Pokemons
                                                  .Where(p => p.Health > 0)
                                                  .ToList();
                    }
                }
            }

            Action<Trainer> printTrainer = tr => Console.WriteLine($"{tr.Name} {tr.BadgesCount} {tr.Pokemons.Count}"); 

            trainers.Values
                    .OrderByDescending(t => t.BadgesCount)
                    .ToList()
                    .ForEach(printTrainer);
        }
    }
}
