using System;
using System.Collections.Generic;
using System.Text;

namespace _06._09.Pokemon_Trainer
{
    class Trainer
    {
        private List<Pokemon> pokemons;

        public Trainer()
        {
            this.pokemons = new List<Pokemon>();
            BadgesCount = 0;
            Name = "Unknown";
        }
        public Trainer(string name):this()
        {
            Name = name;
        }

        public string Name { get; set; }
        public int BadgesCount { get; set; }
        public List<Pokemon> Pokemons 
        { 
            get => pokemons; 
            set => pokemons = value; 
        }
        public void AddPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }
    }
}
