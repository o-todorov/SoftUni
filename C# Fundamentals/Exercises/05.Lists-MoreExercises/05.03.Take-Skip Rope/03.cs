using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._03.Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();
            List<char> nonNumbers = new List<char>();

            foreach (var ch in input)
            {
                if (char.IsDigit(ch))
                {
                    numbers.Add(ch - '0');
                }
                else
                {
                    nonNumbers.Add(ch);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i += 2)
            {
                takeList.Add(numbers[i]);
            }

            for (int i = 1; i < numbers.Count; i += 2)
            {
                skipList.Add(numbers[i]);
            }

            StringBuilder sb = new StringBuilder();

            int idx = 0, count = nonNumbers.Count;

            for (int i = 0; i < takeList.Count && idx < count; i++)
            {
                int len = Math.Min(takeList[i], count - idx);

                sb.Append(nonNumbers.GetRange(idx, len).ToArray());

                idx += (takeList[i] + skipList[i]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
