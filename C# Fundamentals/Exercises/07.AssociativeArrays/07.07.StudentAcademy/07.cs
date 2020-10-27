using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<double>>();

            int studCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studCount; i++)
            {
                string stName = Console.ReadLine();
                double stGrade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(stName))
                {
                    students[stName].Add(stGrade);
                }
                else
                {
                    students[stName] = new List<double>() { stGrade };
                }
            }

            foreach (var stud in students.ToDictionary(p => p.Key, p => p.Value.Average())
                                         .Where(p => p.Value >= 4.50)
                                         .OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{stud.Key} -> {stud.Value:f2}");
            }
        }

    }

}
