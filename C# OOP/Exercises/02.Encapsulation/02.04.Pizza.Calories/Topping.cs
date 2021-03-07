
using System;
using System.Collections.Generic;
using Validators;

namespace PizzaCalories
{
    public class Topping
    {
        private static Dictionary<string, double> toppingTypes = new Dictionary<string, double>()
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}
        };

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight      = weight;
        }

        private string ToppingType
        {
            get => toppingType;
            set => toppingType = Validate(value, toppingTypes, $"Cannot place {value} on top of your pizza.");
        }
        private double Weight
        {
            get => weight;
            set
            {
                var message = $"{this.ToppingType} weight should be in the range [1..50].";
                weight = Validator.ValidateIsInRange(value, 1, 50, message);
            }
        }

        public double Calories => 2 * Weight * toppingTypes[ToppingType.ToLower()];
        private string Validate(string value, Dictionary<string, double> dict, string message)
        {
            {
                if (!dict.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(message);
                }

                return value;
            }
        }

    }

}
