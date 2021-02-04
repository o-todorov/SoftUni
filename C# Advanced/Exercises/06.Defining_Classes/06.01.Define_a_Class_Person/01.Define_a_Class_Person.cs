using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Peter";
            person.Age = 29;
            Console.WriteLine($"Person {person.Name} is aged {person.Age}");
            var p1 = new Person("Asen", 6);
            Console.WriteLine($"Person {p1.Name} is aged {p1.Age}");
        }
    }
}
