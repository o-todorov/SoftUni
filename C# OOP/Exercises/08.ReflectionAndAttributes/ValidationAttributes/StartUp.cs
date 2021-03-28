using System;
using ValidationAttributes.Core;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 null,
                 -1
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);

            person = new Person(null, 15);
            isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);

            person = new Person("", 15);
            isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);

            person = new Person(" ", 15);
            isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);

            person = new Person("Peter", 15);
            isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);

            person = new Person("Peter", 12);
            isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);

            person = new Person("Peter", 90);
            isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);

            person = new Person("Peter", 1);
            isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);

            person = new Person("Peter", 120);
            isValidEntity = Validator.IsValid(person);
            Console.WriteLine(isValidEntity);

        }
    }
}
