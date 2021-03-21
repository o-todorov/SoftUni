using System.IO;
using System.Linq;

namespace Solid.Appenders
{
    class LogFile : ILogFile
    {
        private const string path = "log.txt";
        public int Size => File.ReadAllText(path)
                               .Where(ch => char.IsLetter(ch))
                               .Sum(ch => ch);

        public void Write(string record)
        {
            using (TextWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(record);
            }
        }
    }
}
