using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._01.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int emplCount = int.Parse(Console.ReadLine());
            Employee[] employees = new Employee[emplCount];
            List<Department> departments = new List<Department>();

            for (int i = 0; i < emplCount; i++)
            {
                string[] emp = Console.ReadLine().Split();
                employees[i] = new Employee(emp[0], double.Parse(emp[1]), emp[2]);

                Department d;

                if ((d = departments.Find(d => d.Name == employees[i].Department)) != null)
                {
                    d.AddSalary(employees[i].Salary);
                }
                else
                {
                    departments.Add(new Department(employees[i].Department, employees[i].Salary));
                }
            }

            Department highSalDep = departments.OrderBy(d => d.AveSalary)
                                                .Last();

            Console.WriteLine($"Highest Average Salary: {highSalDep.Name}");

            employees.Where(e => e.Department == highSalDep.Name)
                    .OrderByDescending(e => e.Salary)
                    .ToList()
                    .ForEach(e => Console.WriteLine(e.ToString()));

        }


    }

    class Employee
    {
        public string Name;
        public double Salary;
        public string Department;

        public Employee(string _Name, double _Salary, string _Department)
        {
            this.Name       = _Name;
            this.Salary     = _Salary;
            this.Department = _Department;
        }
        public override string ToString()
        {
            return $"{Name} {Salary:f2}";
        }
    }

    class Department
    {
        public  string  Name;
        private int     count;
        private double  salaries;
        public Department(string _name, double _salary)
        {
            this.Name       = _name;
            this.salaries   = _salary;
            this.count      = 1;
        }
        public double AveSalary
        {
            get
            {
                return salaries / count;
            }
        }
        public void AddSalary(double salary)
        {
            salaries += salary;
            count++;
        }
    }
}
