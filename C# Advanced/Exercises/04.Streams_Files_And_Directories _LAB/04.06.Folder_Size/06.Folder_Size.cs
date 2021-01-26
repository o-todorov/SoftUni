// You are given a folder named "TestFolder". Get the size of all files in the folder, which are NOT directories. The result should be written to another text file in Megabytes.

using System;
using System.IO;

namespace _04._06.Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var path    = Path.Combine("data", "TestFolder");
            var files   = Directory.GetFiles(path);
            double sum    = 0.0;

            foreach (var file in Directory.GetFiles(path))
            {
                FileInfo info = new FileInfo(file);
                sum += info.Length;
            }

            File.WriteAllText(Path.Combine("data","Output.txt"), (sum/1024/1024).ToString());
        }
    }
}
