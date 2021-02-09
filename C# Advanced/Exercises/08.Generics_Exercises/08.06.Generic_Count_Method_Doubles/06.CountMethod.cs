using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Count_Method_Doubles
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

                    // Next 2 lines are to be changed for another type
            var comparer    = CreateBox(double.Parse(Console.ReadLine()));
            var list        = CreateListOfBox(arr.Select(double.Parse).ToArray());

                    // Next 2 lines are for for string type instead
            //var comparer    = CreateBox(Console.ReadLine());
            //var list        = CreateListOfBox(arr);

            Console.WriteLine(GetCount(list, comparer));
        }

        private static List<Box<T>> CreateListOfBox<T>(T[] arr )
            where T : IComparable
        {
            return new List<Box<T>>(arr.Select(v => new Box<T>(v)));
        }

        private static Box<T> CreateBox<T>(T v)
            where T:IComparable
        {
            return new Box<T>(v);
        }

        public static int GetCount<T>(List<T> list, T comp)
            where T : IComparable
        {
            return list.Where(box => box.CompareTo(comp) > 0).Count();
        }
    }
}
