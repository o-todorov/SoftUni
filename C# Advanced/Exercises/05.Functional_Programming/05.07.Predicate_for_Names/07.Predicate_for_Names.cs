// Write a program that filters a list of names according to their length. On the first line, you will be given an integer n, representing a name's length. On the second line, you will be given some names as strings separated by space. Write a function that prints only the names whose length is less than or equal to n.

using System;
using System.Linq;

namespace _05._07.Predicate_for_Names
{
    class Program
    {

        static void Main(string[] args)
        {
            int maxNameLenght = int.Parse(Console.ReadLine());
            Func<string, bool> isValidName = name => name.Length <= maxNameLenght;

            Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Where(isValidName)
                    .ToList()
                    .ForEach(name => Console.WriteLine(name));
        }
    }
}
