using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class EqualityLogicStartUp
    {
        static void Main(string[] args)
        {
            var sortedSetPerson = new SortedSet<Person>();
            var hashSetPerson = new HashSet<Person>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();
                sortedSetPerson.Add(new Person(input[0], int.Parse(input[1])));
                hashSetPerson.Add(new Person(input[0], int.Parse(input[1])));
            }

            Console.WriteLine(sortedSetPerson.Count);
            Console.WriteLine(hashSetPerson.Count);
        }
    }
}
