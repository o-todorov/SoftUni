// Write a program that traverses a collection of names and returns the first name, whose sum of characters is equal to or larger than a given number N, which will be given on the first line. Use a function that accepts another function as one of its parameters. Start off by building a regular function to hold the basic logic of the program. Something along the lines of Func<string, int, bool>. Afterwards create your main function which should accept the first function as one of its parameters.

using System;
using System.Linq;

namespace _05._12.TriFunction
{
    class Program
    {
        public delegate int StringOperation(string str);
        static void Main(string[] args)
        {
            int strLen = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringOperation getCharSum = str => str.Select(ch=>(int)ch).Sum();
            Func<string, int, bool> isValid = (str, len) => getCharSum(str) >= len;

            string result = FindFirstValid(names, strLen, isValid);

            Console.WriteLine(result);
        }

        private static string FindFirstValid(string[] names, int strLen, Func<string, int, bool> isValid)
        {
            return names.FirstOrDefault(names => isValid(names, strLen));
        }
    }
}
