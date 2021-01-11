using System;
using System.Collections.Generic;

namespace _01._08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> parentheses =new Queue<char>( Console.ReadLine().ToCharArray());

            Stack<char> stack = new Stack<char>();
            stack.Push(parentheses.Dequeue());
            var openChars = new Dictionary<char, int>() { { '{', 3 }, { '[', 2 }, { '(', 1 } };
            var closeChars = new Dictionary<char, char>() { { '}', '{' }, { ']', '[' }, { ')', '(' } };
            bool valid = true;

            while (parentheses.Count > 0)
            {
                var newChar = parentheses.Dequeue();

                if (openChars.ContainsKey(newChar))
                {
                    stack.Push(newChar);
                    //valid = AddOpenChar(newChar, stack, openChars);
                }
                else if (closeChars.ContainsKey(newChar))
                {
                    valid = CloseCharSuccess(newChar, stack, closeChars);
                    if (!valid) break;
                }
                else
                {
                    Console.WriteLine("Invalid character"!);
                }
            }

            if (stack.Count == 0 && valid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool CloseCharSuccess(char newChar, Stack<char> stack, Dictionary<char, char> closeChars)
        {
            if (stack.Count > 0 && closeChars[newChar] == stack.Peek())
            {
                stack.Pop();
                return true;
            }

            return false;
        }

        //private static bool AddOpenChar(char newChar, Stack<char> stack, Dictionary<char, int> openChars)
        //{
        //    if (stack.Count == 0 || openChars[newChar] <= openChars[stack.Peek()])
        //    {
        //        stack.Push(newChar);
        //        return true;
        //    }

        //    return false;
        //}
    }
}
