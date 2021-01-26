// Write a program that slice text file in 4 equal parts. 
// Name them:
//     • Part - 1.txt, Part - 2.txt, Part - 3.txt, Part - 4.txt

using System;
using System.IO;

namespace _04._05.Slice_A_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "sliceMe.txt");
            var text = File.ReadAllText(path);

            int countAll = text.Length;
            int countSingle = countAll / 4;

            for (int i = 0; i < 4; i++)
            {
                path = Path.Combine("data", $"Part - {i + 1}.txt");
                File.WriteAllText(path, text.Substring(i * countSingle, countSingle));
            }

        }
    }
}
