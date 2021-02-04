using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                people.Add(ReadPersonFromConsole());
            }

            Func<Person, bool> agedAbove30 = person => person.Age > 30;
            Action<Person> printPerson = p => Console.WriteLine($"{p.Name} - {p.Age}");

            people.Where(agedAbove30)
                  .OrderBy(p => p.Name)
                  .ToList()
                  .ForEach(printPerson);
        }

        private static Person ReadPersonFromConsole()
        {
            string[] person = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = person[0];
            var age = int.Parse(person[1]);

            return new Person(name, age);
        }
    }
}
