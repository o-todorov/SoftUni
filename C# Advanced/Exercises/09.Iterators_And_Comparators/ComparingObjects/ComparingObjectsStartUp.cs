using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    class ComparingObjectsStartUp
    {
        static void Main(string[] args)
        {
            string[] arr;
            List<Person> people = new List<Person>();

            while ((arr = Console.ReadLine().Split())[0] != "END")
            {
                people.Add(new Person(arr[0], int.Parse(arr[1]), arr[2]));
            }

            int index = int.Parse(Console.ReadLine());
            var personToCompare = people[index - 1];
            var eq = people.Where(p => p.CompareTo(personToCompare) == 0);
            int equalTo = eq.Count();
            int notEqualTo = people.Count - equalTo;

            if (equalTo <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{ equalTo} { notEqualTo} {people.Count}");
            }
        }
    }
}
