using System;
using System.Text;

namespace _08._07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strength = 0;

            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += input[i++ + 1] - '1';
                    sb.Append('>');
                    continue;
                }

                if (strength > 0)
                {
                    strength--;
                    continue;
                }

                sb.Append(input[i]);
            }

            Console.WriteLine(sb.ToString());


        }
    }
}
