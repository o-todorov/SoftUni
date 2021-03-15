using System;
using System.Linq;

namespace WildFarm
{
    abstract class Animal:IFoodAsking
    {
        protected double weightIncrement;
        protected string[] foodAcceptable;
        protected Animal(string name, double weight)
        {
            Name        = name;
            Weight      = weight;
            FoodEaten   = 0;
        }
        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract string Ask();
        public void Feed(Food food)
        {
            if (foodAcceptable.Contains(food.GetType().Name))
            {
                FoodEaten   += food.Quantity;
                Weight      += food.Quantity * weightIncrement;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public abstract override string ToString();
    }
}
