using System;
using System.Collections.Generic;
using System.Linq;

namespace CocktailParty
{
    class Cocktail
    {
        private List< Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name            = name;
            Capacity        = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients     = new  List<Ingredient>();
        }

        public string Name { get; }
        public int Capacity { get; }
        public int MaxAlcoholLevel { get; }
        public int CurrentAlcoholLevel => ingredients.Sum(c => c.Alcohol);
        public void Add(Ingredient ingredient)
        {
            int finalAlcohol = CurrentAlcoholLevel + ingredient.Alcohol * ingredient.Quantity;

            if (!ingredients.Any(i=> i.Name == ingredient.Name) &&
                ingredients.Count < Capacity &&
                finalAlcohol <= MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }

        }
        public bool Remove(string name)
        {
            return ingredients.RemoveAll(i => i.Name == name) > 0;
        }
        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(i => i.Name == name);
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(a => a.Alcohol * a.Quantity)
                              .FirstOrDefault();
        }
        public string Report()
        {
            return $"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}" +
                                Environment.NewLine +
                                string.Join(Environment.NewLine, ingredients)
                                .Trim();
                    
        }
    }
}
