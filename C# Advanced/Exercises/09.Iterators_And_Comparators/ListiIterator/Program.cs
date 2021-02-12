using System;
using System.Linq;

namespace ListiIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var command = input.Split().Skip(1).ToArray();
            var listIterator = new ListyIterator<string>(command);

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listIterator.Print();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
