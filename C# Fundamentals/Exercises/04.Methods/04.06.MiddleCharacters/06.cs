using System;

namespace _04._06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(getStrMid(input));

        }

        private static string getStrMid(string input)
        {
            int len = input.Length;
            if (len % 2 == 0)
            {
                return input.Substring(len / 2 - 1, 2);
            }
            else
            {
                return input.Substring(len / 2 , 1);
            }
        }
    }
}
