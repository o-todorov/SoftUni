using System;
using System.Linq;
using System.Text;

namespace _08._03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "find")
            {
                var sb = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    sb.Append((char)(input[i] - nums[i % nums.Length]));
                }

                string item         = GetSubStr(sb.ToString(), '&', '&');
                string coordinates  = GetSubStr(sb.ToString(), '<', '>');
                Console.WriteLine($"Found {item} at {coordinates}");

                input = Console.ReadLine();
            }
        }
        private static string GetSubStr(string input, char v1, char v2)
        {
            int i = input.IndexOf(v1) + 1;
            int j = input.IndexOf(v2, i);

            return input.Substring(i, j - i);
        }

    }
}
