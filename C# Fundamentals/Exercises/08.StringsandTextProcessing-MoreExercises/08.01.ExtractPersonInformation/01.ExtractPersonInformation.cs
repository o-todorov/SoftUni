using System;

namespace _08._01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string  input   = Console.ReadLine();

                string  name    = GetSubStr(input, '@', '|');
                int     years   = int.Parse(GetSubStr(input, '#', '*'));
                Console.WriteLine($"{name} is {years} years old.");
            }

        }

        private static string GetSubStr(string input, char v1, char v2)
        {
            int i = input.IndexOf(v1) + 1;
            int j = input.IndexOf(v2);

            return input.Substring(i, j - i);
        }
    }
}

