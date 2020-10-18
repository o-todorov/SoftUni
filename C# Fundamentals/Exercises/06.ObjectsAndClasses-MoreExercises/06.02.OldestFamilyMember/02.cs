using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int     count   = int.Parse(Console.ReadLine());
            Family  family  = new Family();

            for (int i = 0; i < count; i++)
            {
                family.AddMember(new Person(Console.ReadLine().Split()));
            }

            Console.WriteLine(family.GetOldestMember().ToString());
        }

        class Person
        {
            public string   Name;
            public int      Age;

            public Person(string[] person)
            {
                Name    = person[0];
                Age     = int.Parse(person[1]);
            }
            public override string ToString()
            {
                return $"{Name} {Age}";
            }
        }

        class Family
        {
            private List<Person> people;

            public Family()
            {
                people = new List<Person>();
            }
            public void AddMember(Person member)
            {
                people.Add(member);
            }

            public Person GetOldestMember()
            {

                return people.OrderBy(p => p.Age).Last();
            }
        }
    }
}
