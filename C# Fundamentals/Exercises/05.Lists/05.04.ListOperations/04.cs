using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._04.ListOperations
{
    class Program
    {

        public static List<int> list;
        static void Main(string[] args)
        {
            list = Console.ReadLine().Split(" ")
                                   .Select(int.Parse)
                                   .ToList();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandLine = input.Split();
                string command = commandLine[0];

                switch (command)
                {
                    case "Add":
                        int toAdd = int.Parse(commandLine[1]);

                        list.Add(toAdd);

                        break;
                    case "Insert":
                        int pos = int.Parse(commandLine[2]);

                        if (pos < 0 || pos > list.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        list.Insert(pos, int.Parse(commandLine[1]));

                        break;
                    case "Remove":
                        int indToRemove = int.Parse(commandLine[1]);

                        if (indToRemove < 0 || indToRemove >= list.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        list.RemoveAt(indToRemove);
                        break;
                    case "Shift":
                        int step = int.Parse(commandLine[2]) % list.Count;

                        if (step == 0) break;

                        listShift(commandLine[1], step);

                        break;
                    default:
                        Console.WriteLine("Command unknown");
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", list));



        }

        private static void listShift(string shift, int step)
        {
            if (shift == "right")
            {
                step = list.Count  - step;
            }

            var range = list.GetRange(0, step);
            
            list.AddRange(range);
            list.RemoveRange(0, step);

        }
    }
}
