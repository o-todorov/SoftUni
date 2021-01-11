using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> list = new Queue<string>(Console.ReadLine().Split(", "));

            while (true)
            {
                var input = Console.ReadLine().Split(" ", 2);
                string command = input[0];

                if (command == "Add")
                {
                    string song = input[1];

                    if (!list.ToArray().Any(s => s == song))
                    {
                        list.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Play")
                {
                    if (list.Count > 0)
                    {
                        list.Dequeue();
                    }

                    if (list.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        return;
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine($"{string.Join(", ", list.ToArray())}");
                }
            }


        }
    }
}
