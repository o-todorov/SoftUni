using System;
using System.Text;

namespace _08._06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var sb = new StringBuilder();

            char ch = input[0];
            sb.Append(ch);

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == ch)
                {
                    continue;
                }

                ch = input[i];
                sb.Append(ch);
            }

            Console.WriteLine(sb.ToString());


        }
    }
}
