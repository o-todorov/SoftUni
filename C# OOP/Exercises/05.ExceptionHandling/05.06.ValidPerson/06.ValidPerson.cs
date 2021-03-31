using System;

namespace _05._06.ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] persons = new string[][]
            {
                new string[]{"Petyr","Petrov","26" },
                new string[]{"Petyr","Petrov","-1" },
                new string[]{"Petyr","Petrov","121" },
                new string[]{"","Petrov","26" },
                new string[]{"Petyr","","26" },
                new string[]{null,"Petrov","26" },
                new string[]{"Petyr",null,"26" },
                new string[]{"Petyr","Petrov","26" }
            };

            foreach (var p in persons)
            {
                try
                {
                    Person person = new Person(p[0], p[1] as string, int.Parse(p[2]));
                    Console.WriteLine($"Person - {person.FirstName} {person.LastName} age: {person.Age}");
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    Console.WriteLine(aoore.Message);
                }
            }
        }
    }
}
