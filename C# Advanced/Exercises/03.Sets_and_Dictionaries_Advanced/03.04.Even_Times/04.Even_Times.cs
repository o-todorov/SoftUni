using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, bool> dict = new Dictionary<int, bool>();

            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(num))
                {
                    dict[num] = true;
                }
                else
                {
                    dict[num] = !dict[num];
                }
            }

            Console.WriteLine(dict.Where(i => i.Value == false).First().Key);
        }
    }
}
