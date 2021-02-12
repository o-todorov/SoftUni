using System;

namespace EqualityLogic
{
    class Person: IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name    = name;
            Age     = age;
        }

        public string  Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = (result = Name.CompareTo(other.Name)) != 0 ? result :
                             Age.CompareTo(other.Age);
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Age == person.Age;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;

            foreach (var ch in Name)
            {
                hashCode += ch * Age;
            }

            return hashCode % 1000;
        }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }
}
