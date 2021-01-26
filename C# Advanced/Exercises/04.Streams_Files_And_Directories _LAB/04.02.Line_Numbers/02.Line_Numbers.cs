// Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

using System;
using System.IO;

namespace _04._02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path     = Path.Combine("data", "Input.txt");
            string ouput    = Path.Combine("data", "Output.txt");

            using (TextReader reader = new StreamReader(path))
            {
                using (TextWriter writer = new StreamWriter(ouput))
                {
                    string line;
                    int counter = 1;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{counter++}. {line}");
                    }
                }
            }
        }
    }
}