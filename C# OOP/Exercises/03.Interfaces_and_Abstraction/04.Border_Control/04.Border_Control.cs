using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Border_Control
{
    public class Program
    {
        static void Main(string[] args)
        {
            string ID = Console.ReadLine();
            List<IUnit> passers = new List<IUnit>();

            while (ID.ToLower()!="end")
            {
                var info = ID.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                passers.Add(CreateUnit(info));

                ID = Console.ReadLine();
            }

            string fakeID = Console.ReadLine().Trim();

            passers.Where(p => p.Id.EndsWith(fakeID))
                   .ToList()
                   .ForEach(p => Console.WriteLine($"{p.Id}"));
        }

        private static IUnit CreateUnit(string[] info)
        {
            if (info.Length == 2)
            {
                return new Robot(info[0], info[1]);
            }
            else
            {
                return new Citizen(info[0], int.Parse(info[1]), info[2]);
            }
        }
    }
}
