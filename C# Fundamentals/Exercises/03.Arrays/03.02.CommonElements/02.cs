using System;
using System.Linq;

namespace _03._02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(" ").ToArray();
            string[] b = Console.ReadLine().Split(" ").ToArray();

            int countA = a.Length;
            int countB = b.Length;

            for (int i = 0; i < countB; i++)
            {
                for (int j = 0; j < countA; j++)
                {
                    if (a[j] == b[i]) Console.Write(a[j] + " ");
                }
            }

        }
    }
}
