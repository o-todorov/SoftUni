using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string input;

            while ((input=Console.ReadLine()).ToUpper()!="END")
            {
                persons.Add(new Person(input.Split()));
            }

            persons.OrderBy(p => p.Age).ToList().ForEach(p => p.Print());

        }
    }

    class Person
    {
        public string   Name;
        public string   ID;
        public int      Age;

        public Person(string[] nameIdAge)
        {
            this.Name   = nameIdAge[0];
            this.ID     = nameIdAge[1];
            this.Age    = int.Parse(nameIdAge[2]);
        }

        public void Print()
        {
            Console.WriteLine($"{Name} with ID: {ID} is {Age} years old.");
        }
    }
}
