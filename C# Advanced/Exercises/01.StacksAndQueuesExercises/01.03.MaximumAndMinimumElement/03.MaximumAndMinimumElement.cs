using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queriesCount = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queriesCount; i++)
            {
                string query = Console.ReadLine();

                switch (query[0])
                {
                    case '1':
                        stack.Push(int.Parse(query.Split()[1]));
                        break;
                    case '2':
                        if (stack.Count > 0) stack.Pop();
                        break;
                    case '3':
                        if (stack.Count > 0) Console.WriteLine(stack.ToArray().Max());
                        break;
                    case '4':
                        if (stack.Count > 0) Console.WriteLine(stack.ToArray().Min());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ",stack.ToArray()));

        }
    }
}
