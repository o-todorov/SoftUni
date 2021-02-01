using System;
using System.Linq;

namespace _05._02.Knights_of__Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Action<string> printOnNewLine = str => Console.WriteLine(str);
                Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(str => "Sir " + str)
                        .ToList()
                        .ForEach(printOnNewLine);

            }
        }
    }
}
