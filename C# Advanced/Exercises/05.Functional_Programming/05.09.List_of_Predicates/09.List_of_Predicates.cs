// Find all numbers in the range 1...N that are divisible by the numbers of a given sequence.
// On the first line, you will be given an integer N – which is the end of the range. 
// On the second line, you will be given a sequence of integers which are the dividers. 
// Use predicates/functions.

using System;
using System.Linq;
using System.Text;

namespace _05._09.List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse);

            Func<int, bool> isDivisibleByAll = i => dividers.All(d => i % d == 0);

            var sb = new StringBuilder();

            for (int i = 1; i <= range; i++)
            {
                if (isDivisibleByAll(i)) sb.Append(i).Append(" ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
