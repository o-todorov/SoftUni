// Write a program that reads a text file and prints on the console its even lines. Line numbers start from 0. Use StreamReader. Before you print the result replace {"-", ",", ".", "!", "?"} with "@" and reverse the order of the words.

using System;
using System.IO;
using System.Linq;

namespace _04._01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "text.txt");

            using (TextReader reader = new StreamReader(path))
            {
                bool IsEvenLine = true;
                char[] toReplace = new char[] { '-', ',', '.', '!', '?' };
                string input;
                char[] line;

                while ((input = reader.ReadLine()) != null)
                {
                    if (IsEvenLine)
                    {
                        line = input.ToCharArray();

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (toReplace.Contains(line[i])){
                                line[i] = '@';
                            }
                        }

                        var reverced = new string(line).Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                       .Reverse();
                        Console.WriteLine(string.Join(" ",reverced));
                    }

                    IsEvenLine = !IsEvenLine;
                }

            }

        }
    }
}
