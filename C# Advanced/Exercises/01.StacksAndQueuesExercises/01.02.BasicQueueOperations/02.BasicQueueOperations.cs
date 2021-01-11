using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse).ToArray();

            int numsToAdd       = nums[0];
            int numsToDequeue   = nums[1];
            int numToFind       = nums[2];

            int[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numsToAdd; i++)
            {
                queue.Enqueue(input[i]);
            }

            for (int i = 0; i < numsToDequeue; i++)
            {
                queue.Dequeue();
            }

            int min = (queue.Count == 0) ? 0 : int.MaxValue;

            while (queue.Count > 0)
            {
                int i = queue.Dequeue();

                if (i == numToFind)
                {
                    Console.WriteLine("true");
                    return;
                }
                else
                {
                    if (i < min)
                    {
                        min = i;
                    }
                }
            }

            Console.WriteLine(min);

        }
    }
}
