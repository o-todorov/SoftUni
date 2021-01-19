using System;
using System.Collections.Generic;

namespace _03._01.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                set.Add(Console.ReadLine());
            }

            foreach (var str in set)
            {
                Console.WriteLine(str);
            }
        }
    }
}
