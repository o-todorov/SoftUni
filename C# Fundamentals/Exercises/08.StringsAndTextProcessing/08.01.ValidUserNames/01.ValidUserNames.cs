using System;
using System.Linq;

namespace _08._01.ValidUserNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Where(s => s.Length >= 3 && s.Length <= 16)
                .Where(s => s.All(c => Char.IsLetterOrDigit(c) || c == '-' || c == '_')).ToArray();

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}
