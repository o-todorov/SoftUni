using System;
using System.IO;
namespace Solid.Readers
{
    class TextFileReader:IReader
    {
        private string[] lines;
        private int position;
        public TextFileReader(string path = "log.txt")
        {
            RearLines(path);
        }

        public string ReadLine()
        {
            if (position == lines.Length )
            {
                return null;
            }

            return lines[position++];
        }

        private void RearLines(string path)
        {
            using (TextReader reader = new StreamReader(path))
            {
                lines = reader.ReadToEnd().Split(Environment.NewLine);
            }
        }
    }
}
