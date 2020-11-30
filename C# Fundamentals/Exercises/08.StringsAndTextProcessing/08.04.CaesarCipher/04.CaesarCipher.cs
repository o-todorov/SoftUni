using System;
using System.Linq;

namespace _08._04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var result = input.Select(ch=>(char)(ch+3));

            Console.WriteLine(string.Join("",result));
        }
    }
}
