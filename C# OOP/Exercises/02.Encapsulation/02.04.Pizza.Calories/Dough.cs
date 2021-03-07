using System;
using System.Collections.Generic;
using Validators;

namespace PizzaCalories
{

    public class Dough
    {
        private static Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            {"white", 1.5},
            {"wholegrain", 1.0},
        };
        private static Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0}
        };
        public Dough(string flourType,string bakingTechnique,double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        private string flourType;
        private double weight;
        private string bakingTechnique;
        private string FlourType
        {
            get => flourType;
            set => flourType = Validate(value, flourTypes, "Invalid type of dough.");
        }
        private string BakingTechnique
        {
            get => bakingTechnique;
            set => bakingTechnique = Validate(value, bakingTechniques, "Invalid type of dough.");
        }
        private double Weight
        {
            get => weight;
            set => weight = Validator.ValidateIsInRange(value, 1, 200, "Dough weight should be in the range [1..200].");
        }
        public double Calories => 2 * Weight * flourTypes[FlourType.ToLower()] * bakingTechniques[BakingTechnique.ToLower()];
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
