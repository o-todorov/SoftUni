using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesTestGenerator
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            GenerateTest("test.001", 10, 10);
            GenerateTest("test.002", 20, 20);
            GenerateTest("test.003", 30, 5);
            GenerateTest("test.004", 40, 2);
            GenerateTest("test.005", 50, 50);

            GenerateTest("test.006", 100, 100);
            GenerateTest("test.007", 200, 1000);
            GenerateTest("test.008", 300, 100000);
            GenerateTest("test.009", 400, 10000000);
            GenerateTest("test.010", 500, 1000000000);
        }

        static void GenerateTest(string testName, int measurementsCount, int maxMeasurement)
        {
            List<int> measurements1 = new List<int>();
            List<int> measurements2 = new List<int>();
            List<int> lifetime = new List<int>();
            for (int i = 0; i < measurementsCount; i++)
            {
                int measurement = rand.Next(1, maxMeasurement);
                int damage = rand.Next(1, measurement + 1);
                measurements1.Add(measurement);
                measurements2.Add(measurement - damage);
                lifetime.Add(measurement / damage);
            }

            string input = measurements1.Count + System.Environment.NewLine +
                String.Join(" ", measurements2) + System.Environment.NewLine + 
                String.Join(" ", measurements1) + System.Environment.NewLine;
            string output = String.Join(" ", lifetime) + System.Environment.NewLine;

            System.IO.File.WriteAllText(testName + ".in.txt", input);
            System.IO.File.WriteAllText(testName + ".out.txt", output);
        }
    }
}
