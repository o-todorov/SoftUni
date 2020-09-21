using System;
using System.Linq;

namespace _02._05.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int charCount = int.Parse(Console.ReadLine());
            string decripted = string.Empty;

            for (int i = 0; i < charCount; i++)
            {
                char ch = char.Parse(Console.ReadLine());
                ch += (char)key;
                decripted+=ch;
            }

            Console.WriteLine(decripted);
        }
    }
}
