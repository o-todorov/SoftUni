using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._09.PokemonDontGo
{
    class Program
    {
        public static List<int> pokemones;

        static void Main(string[] args)
        {
            pokemones = Console.ReadLine().Split(" ")
                                               .Select(int.Parse)
                                               .ToList();

            int sumOfRemoved = 0;

            while (true)
            {
                int IDX = int.Parse(Console.ReadLine());
                int pokeValue = 0;

                if (IDX < 0)
                {
                    pokeValue = pokemones[0];
                    pokemones[0] = pokemones[pokemones.Count - 1];
                }
                else if (IDX >= pokemones.Count)
                {
                    pokeValue = pokemones[pokemones.Count - 1];
                    pokemones[pokemones.Count - 1] = pokemones[0];
                }
                else
                {
                    pokeValue = pokemones[IDX];
                    pokemones.RemoveAt(IDX);
                }

                sumOfRemoved += pokeValue;

                if (pokemones.Count == 0)
                {
                    break;
                }

                for (int i = 0; i < pokemones.Count; i++)
                {
                    if (pokemones[i] <= pokeValue)
                    {
                        pokemones[i] += pokeValue;
                    }
                    else
                    {
                        pokemones[i] -= pokeValue;
                    }
                }
            }

            Console.WriteLine(sumOfRemoved);

        }
    }
}
