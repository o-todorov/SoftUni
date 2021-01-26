// Write a program that reads the contents of two text files and merges them together into a third one.

using System;
using System.IO;

namespace _04._04.Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathOne = Path.Combine("data", "FileOne.txt");
            var pathTwo = Path.Combine("data", "FileTwo.txt");
            var output  = Path.Combine("data", "output.txt");

            var textOne = File.ReadAllLines(pathOne);
            var textTwo = File.ReadAllLines(pathTwo);
            string[] result = new string[textOne.Length + textTwo.Length];

            if (textOne.Length > textTwo.Length)
            {
                var t = textTwo;
                textTwo = textOne;
                textOne = t;
            }

            int counter = 0;

            for (int i = 0; i < textOne.Length; i++)
            {
                result[counter++] = textOne[i];
                result[counter++] = textTwo[i];
            }

            for (int i = textOne.Length; i < textTwo.Length; i++)
            {
                result[counter++] = textTwo[i];
            }

            File.WriteAllLines(output, result);
        }
    }
}
