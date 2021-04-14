using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Scheduling
    {
        static void Main(string[] args)
        {

            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse));

            int taskToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                var task = tasks.Peek();
                var thread = threads.Peek();

                if (task == taskToKill)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskToKill}");
                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();
                }

                threads.Dequeue();

            }

            Console.WriteLine(string.Join(" ",threads));
        }
    }
}
