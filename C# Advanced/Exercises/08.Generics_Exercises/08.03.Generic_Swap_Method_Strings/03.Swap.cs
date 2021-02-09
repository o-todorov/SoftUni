using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._03.Generic_Swap_Method_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            string[] arr = new string[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = Console.ReadLine();
            }

            int[] indexes = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();
            // Next line is the only one to be changed for different type than string
            var list = CreateList(arr.Select(s => new Box<string>(s)));

            SwapIndexes(list, indexes[0], indexes[1]);

            list.ForEach(v => Console.WriteLine(v.ToString()));
        }

        private static List<T> CreateList<T>(IEnumerable<T> arr)
        {
            return new List<T>(arr);
        }
        public static void SwapIndexes<T>(List<T>list,int first,int second)
        {
            T item = list[first];
            list[first] = list[second];
            list[second] = item;
        }
    }
}
