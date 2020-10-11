using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();

            StringBuilder input = new StringBuilder( Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            foreach (var str in numbers)
            {
                int digitNumbers = 0;

                foreach (var ch in str)
                {
                    digitNumbers += ch - '0';
                }

                int IDX = digitNumbers % input.Length ;

                sb.Append(input[IDX]);
                input.Remove(IDX,1);
            }

            Console.WriteLine(sb.ToString());

        }
    }
}
