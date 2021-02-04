using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            var family = new Family();
            
            for (int i = 0; i < peopleCount; i++)
            {
                Person person = ReadPersonFromConsole();
                family.AddMember(person);
            }

            var oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");

        }

        private static Person ReadPersonFromConsole()
        {
            string[] person = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name    = person[0];
            var age     = int.Parse(person[1]);

            return new Person(name, age);
        }
    }
}
