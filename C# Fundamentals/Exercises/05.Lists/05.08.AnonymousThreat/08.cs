using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

            string line;

            while ((line = Console.ReadLine()) != "3:1")
            {
                string[] commLine = line.Split().ToArray();
                int a = int.Parse(commLine[1]);
                int b = int.Parse(commLine[2]);

                if (commLine[0] == "merge")
                {
                    if (a < 0) a = 0;

                    if (b >= words.Count) b = words.Count - 1;

                    if (a >= b) continue;

                    words[a] = string.Concat(words.GetRange(a, b - a + 1));

                    words.RemoveRange(a + 1, b - a);
                }
                else // commLine[0] = "divide"
                {
                    string word = words[a];
                    int partitionsCount = b;
                    int charCount = word.Length / partitionsCount;

                    words.RemoveAt(a);

                    List<string> range = new List<string>(partitionsCount);

                    int i = 0;

                    for (; i < partitionsCount; i++)
                    {
                        range.Add(word.Substring(i * charCount, charCount));
                    }

                    i *= charCount;

                    range[partitionsCount - 1] += word.Substring(i, word.Length - i);

                    words.InsertRange(a, range);

                }
            }

            Console.WriteLine(string.Join(" ", words));

        }
    }
}
