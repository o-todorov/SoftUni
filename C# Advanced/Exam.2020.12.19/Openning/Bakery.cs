using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name        = name;
            Capacity    = capacity;
            data        = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; private set; }
        public int Count => data.Count;
        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            return data.RemoveAll(e => e.Name == name) > 0;
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age)
                       .FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(e => e.Name == name);
        }
        public string Report()
        {
            return $"Employees working at Bakery {Name}:" +
                    Environment.NewLine +
                    string.Join(Environment.NewLine, data);
        }
    }
}
