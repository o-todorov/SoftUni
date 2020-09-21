using System;

namespace _02._01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = string.Empty;

            string line;

            while (( line = Console.ReadLine()) != "END"){
                int i;
                float f;
                char ch;
                bool b;

                if (int.TryParse(line, out i)) type = "integer";
                else if (float.TryParse(line, out f)) type = "floating point";
                else if (bool.TryParse(line, out b)) type = "boolean";
                else if (char.TryParse(line, out ch)) type = "character";
                else  type = "string";

                Console.WriteLine($"{line} is {type} type");
            }
        }
    }
}
