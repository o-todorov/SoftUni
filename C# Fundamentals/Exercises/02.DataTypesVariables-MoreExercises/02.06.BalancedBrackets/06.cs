using System;

namespace _02._06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            char currChar = ')';
            bool isBalanced = true;

            for (int i = 0; i < lines; i++)
            {
                char ch = Console.ReadLine()[0];
                {
                    if (ch == currChar)
                    {
                        isBalanced = false;
                        break;
                    }

                    if (ch == '(') currChar = '(';
                    else if (ch == ')') currChar = ')';
                }

            }


            if (!isBalanced || currChar == '(')
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
                Console.WriteLine("BALANCED");
            }

        }
    }
}
