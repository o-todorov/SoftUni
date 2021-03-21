
using Solid.Readers;

namespace Solid
{
    class StartUp
    {
        private const string inputTextFilePath = "../../../input.txt";
        static void Main(string[] args)
        {
            //IReader reader = new TextFileReader(inputTextFilePath);
            IReader reader = new ConsoleReader();
            IEngine engine = new Engine(reader);
            engine.Run();
        }


    }
}
