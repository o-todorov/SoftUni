using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] article = Console.ReadLine().Split(" ");

                students.Add(new Student(article[0], article[1], double.Parse(article[2])));
            }

            var res = students.OrderByDescending(st => st.Grade);

            foreach (var st in res)
            {
                Console.WriteLine(st.ToString());
            }
        }
    }


    class Student
    {
        public Student(string _FirstName, string _LastName, double _Grade)
        {
            this.FirstName = _FirstName;
            this.LastName = _LastName;
            this.Grade = _Grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} { LastName}: {Grade:f2}";
        }

    }

}
