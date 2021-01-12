using System;
using System.Collections.Generic;
using System.Text;

namespace _01._09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int opsCount = int.Parse(Console.ReadLine());
            Stack<string> memo = new Stack<string>();
            var sb = new StringBuilder();

            for (int i = 0; i < opsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", 2);

                switch (input[0])
                {
                    case "1":
                        memo.Push(sb.ToString());
                        sb.Append(input[1]);
                        break;
                    case "2":
                        memo.Push(sb.ToString());
                        int charsToErase = int.Parse(input[1]);
                        sb.Remove(sb.Length - charsToErase, charsToErase);
                        break;
                    case "3":
                        int idx = int.Parse(input[1]) - 1;
                        Console.WriteLine(sb[idx]); ;
                        break;
                    case "4":
                        sb=new StringBuilder(memo.Pop());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
