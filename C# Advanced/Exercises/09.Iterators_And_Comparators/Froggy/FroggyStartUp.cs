using System;
using System.Linq;

namespace Froggy
{
    class FroggyStartUp
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                       .Split(", ")
                       .Select(int.Parse)
                       .ToArray();

            var lake = new Lake(arr);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
