using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(" ")
                       .Select(int.Parse)
                       .ToList();

            string commandLine;

            while ((commandLine = Console.ReadLine()) != "end")
            {
                string[] command = commandLine.Split();

                switch (command[0])
                {
                    case "Delete":
                        int toDelete = int.Parse(command[1]);
                        list.RemoveAll(i => i == toDelete);
                        break;
                    case "Insert":
                        int pos = int.Parse(command[2]);
                        if (pos < 0 || pos > list.Count) break;

                        list.Insert(pos, int.Parse(command[1]));

                        break;
                    default:
                        Console.WriteLine("Command unknown");
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
