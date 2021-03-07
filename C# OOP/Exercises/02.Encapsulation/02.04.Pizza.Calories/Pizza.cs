
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private List<Topping> toppings;
        private string name;
        private Dough dough;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        public Dough Dough { get => dough; set => dough = value; }
        public int ToppingsCount => toppings.Count;
        public double TotalCalories => Dough.Calories + toppings.Sum(t => t.Calories);
        public void AddTopping(string toppingType, double weight)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(new Topping(toppingType, weight));
        }

    }
}
