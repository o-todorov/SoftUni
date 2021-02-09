using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Count_Method_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] arr = new string[count];

            for (int i = 0; i < count; i++)
            {
                arr[i]=Console.ReadLine();
            }

            // Next 2 lines are to be changed for another type
            var comparer = new Box<string>(Console.ReadLine());
            var list     = arr.Select(str => new Box<string>(str)).ToList();

            Console.WriteLine(GetCount(list, comparer));
        }

        public static int GetCount<T>(List<T> list, T comp)
            where T : IComparable
        {
            return list.Where(box => box.CompareTo(comp) > 0).Count();
        }
    }
}
