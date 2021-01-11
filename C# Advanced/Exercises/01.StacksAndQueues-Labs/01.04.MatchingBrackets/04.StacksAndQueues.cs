using System;
using System.Collections.Generic;

namespace _01._04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
            string expression = Console.ReadLine();
            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    brackets.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int n = brackets.Pop();
                    Console.WriteLine(expression.Substring(n, i - n + 1));
                }
            }

        }
    }
}
