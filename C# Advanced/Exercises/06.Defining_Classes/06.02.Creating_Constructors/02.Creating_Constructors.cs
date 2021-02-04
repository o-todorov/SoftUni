using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person1 = new Person();
            Console.WriteLine($"Person {person1.Name} is aged {person1.Age}");
            var person2 = new Person(31);
            Console.WriteLine($"Person {person2.Name} is aged {person2.Age}");
            var person3 = new Person("Peter", 45);
            Console.WriteLine($"Person {person3.Name} is aged {person3.Age}");

        }
    }
}
