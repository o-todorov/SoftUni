using System;
using System.Linq;

namespace _05._01.Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printOnNewLine = str => Console.WriteLine(str);
            Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(printOnNewLine);

        }
    }
}
