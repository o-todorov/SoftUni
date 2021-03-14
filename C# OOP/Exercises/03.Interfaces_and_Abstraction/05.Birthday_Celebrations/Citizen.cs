
using System;

namespace BirthdayCelebrations
{
    public class Citizen :Creature, IIdentifiable
    {
        public Citizen(string name, int age, string id, DateTime birthday)
            : base(name, birthday)
        {
            Age = age;
            Id  = id;
        }

        public int Age { get; set; }
        public string Id { get; set; }

    }
}
