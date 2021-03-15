
using System;

namespace FoodShortage
{
    public class Citizen :Creature, IIdentifiable,IBuyer
    {
        public Citizen(string name, int age, string id, DateTime birthday)
            : base(name, birthday)
        {
            Age  = age;
            Id   = id;
            Food = 0;
        }

        public int Age { get; set; }
        public string Id { get; set; }
        public int Food { get; set; }

        public virtual void BuyFood()
        {
            Food += 10; ;
        }
    }
}
