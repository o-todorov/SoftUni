using System;

namespace _04._02.VomelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            printVomelsCount(input);
        }

        private static void printVomelsCount(string input)
        {
            int vomelsCount = 0;

            foreach (char ch in input)
            {
                if ("aoeiuAOEIU".Contains(ch)) vomelsCount++;
            }

            Console.WriteLine(vomelsCount);
        }
    }
}
