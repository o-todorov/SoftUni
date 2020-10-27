using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string[] input;

            while ((input=Console.ReadLine().Split(" : "))[0] != "end")
            {
                string course   = input[0];
                string student  = input[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>() { student });
                }
                else
                {
                    courses[course].Add(student);
                }
            }

            foreach(var c in courses.OrderByDescending(c => c.Value.Count))
            {
                Console.WriteLine($"{c.Key}: {c.Value.Count}");

                c.Value.OrderBy(s=>s)
                        .ToList()
                        .ForEach(s => Console.WriteLine($"-- {s}"));
            }


        }
    }

    
}
