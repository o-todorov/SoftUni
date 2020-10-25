using System;
using System.Linq;

namespace _07._03.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                    .Split()
                    .Where(s => s.Length % 2 == 0)
                    .ToList()
                    .ForEach(s => { if (s.Length % 2 == 0) Console.WriteLine(s); });

        }
    }
}
