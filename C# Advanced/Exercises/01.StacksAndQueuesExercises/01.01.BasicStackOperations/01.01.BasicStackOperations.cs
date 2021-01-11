using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._01.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse).ToArray();

            int numsToPush  = nums[0];
            int numsToPop   = nums[1];
            int numToFind   = nums[2];

            int[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numsToPush; i++)
            {
                stack.Push(input[i]);
            }

            if (numsToPop > stack.Count)
            {
                numsToPop = stack.Count;
            }

            for (int i = 0; i < numsToPop; i++)
            {
                stack.Pop();
            }

            int min = int.MaxValue;
            bool found = false;

            if (stack.Count == 0)
            {
                min = 0;
            }
            else
            {
                while (stack.Count > 0)
                {
                    int i = stack.Pop();

                    if (i == numToFind)
                    {
                        found = true;
                        break;
                    }

                    if (i < min)
                    {
                        min = i;
                    }
                }
            }

            if (found)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(min);
            }
        }
    }
}
