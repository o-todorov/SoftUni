
using System;

namespace FoodShortage
{
    public abstract class Creature:IBirthable
    {
        private DateTime birthday;

        protected Creature(string name, DateTime birthday)
        {
            Name     = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public DateTime Birthday
        {
            get => birthday;

            set
            {
                if (value != null) birthday = value;
            }
        }
    }
}
