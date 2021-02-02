using System;
using System.Linq;

namespace _05._03.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> getMinValue = (int l, int r) => l < r ? l : r;

            int min = int.MaxValue;

            Console.ReadLine()
                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                       .Select(int.Parse)
                       .ToList()
                       .ForEach(i => min = getMinValue(i, min));

                       Console.WriteLine(min);
        }
    }
}
