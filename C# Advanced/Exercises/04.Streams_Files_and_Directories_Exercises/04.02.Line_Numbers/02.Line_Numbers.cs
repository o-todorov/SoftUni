// Write a program that reads a text file and inserts line numbers in front of each of its lines and count all the letters and punctuation marks. The result should be written to another text file. Use the static class File.

using System;
using System.IO;
using System.Linq;

namespace _04._02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path     = Path.Combine("data", "text.txt");
            string ouput    = Path.Combine("data", "Output.txt");

            string[] lines  = File.ReadAllLines(path);
            string[] result = new string[lines.Length];
            int lineNum = 0;

            foreach (var line in lines)
            {
                int letters = line.Where(ch => !Char.IsPunctuation(ch) && !Char.IsWhiteSpace(ch)).Count();
                int punct   = line.Where(ch => Char.IsPunctuation(ch)).Count();
                result[lineNum++] = $"Line {lineNum}: {line} ({letters})({punct})";
            }

            File.WriteAllLines(ouput, result);

        }
    }
}
