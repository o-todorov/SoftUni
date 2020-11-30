using System;

namespace _08._03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int i = input.LastIndexOf(@"\") + 1;
            int j = input.LastIndexOf(".");

            Console.WriteLine($"File name: {input.Substring(i, j - i)}");
            Console.WriteLine($"File extension: {input.Substring(j + 1)}");

        }
    }
}

