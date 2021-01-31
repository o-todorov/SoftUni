// Write a program that traverses a given directory for all files with the given extension. Search through the first level of the directory only and write information about each found file in report.txt. The files should be grouped by their extension. Extensions should be ordered by the count of their files descending, then by name alphabetically. Files under an extension should be ordered by their size. report.txt should be saved on the Desktop. Ensure the desktop path is always valid, regardless of the user.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04._05_Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path     = Directory.GetCurrentDirectory();
            var files       = Directory.GetFiles(path);
            var extensions  = new Dictionary<string, Dictionary<string, FileInfo>>();

            foreach (var fileName in files)
            {
                var info = new FileInfo(fileName);

                if (!extensions.ContainsKey(info.Extension))
                {
                    extensions[info.Extension] = new Dictionary<string, FileInfo>();
                }

                extensions[info.Extension][info.Name] = info;
            }

            var result = extensions.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key);
            List<string> lines = new List<string>();

            foreach (var ext in result)
            {
                lines.Add($"{ext.Key}");

                foreach (var info in ext.Value.Values.OrderBy(f=>f.Length))
                {
                    lines.Add($"--{info.Name} - {info.Length / 1024.0:f3}kb");
                }
            }

            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");
            File.WriteAllLines(path, lines);
        }
    }
}
