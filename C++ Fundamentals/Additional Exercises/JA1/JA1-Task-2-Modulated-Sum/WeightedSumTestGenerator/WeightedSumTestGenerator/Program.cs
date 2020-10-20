using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightedSumTestGenerator
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            generateTest("test.001", 5, 10);
            generateTest("test.002", 50, 99);
            generateTest("test.003", 10, 5);
            generateTest("test.004", 99, 50);
            generateTest("test.005", 1, 50);
            generateTest("test.006", 50, 1);
            generateTest("test.007", 42, 13);
            generateTest("test.008", 13, 42);
            generateTest("test.009", 69, 13);
            generateTest("test.010", 13, 69);
        }

        static void generateTest(string testName, int n, int m)
        {
            List<int[]> arrays = new List<int[]>();
            
            for (int arrInd = 0; arrInd < n; arrInd++)
            {
                int[] arr = new int[m];
                for (int col = 0; col < m; col++)
                {
                    arr[col] = rand.Next(0, 101);
                }

                arrays.Add(arr);
            }

            int modulo = rand.Next(10, 101);

            StringBuilder inputBuilder = new StringBuilder();
            inputBuilder.AppendLine(n + " " + m);
            foreach (var arr in arrays)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    inputBuilder.Append(arr[i]);
                    if (i < arr.Length - 1)
                    {
                        inputBuilder.Append(" ");
                    }
                }

                inputBuilder.AppendLine();
            }
            inputBuilder.AppendLine(modulo + "");

            int[] result = new int[m];
            for (int arrInd = 0; arrInd < arrays.Count; arrInd++)
            {
                for (int i = 0; i < m; i++)
                {
                    result[i] += arrays[arrInd][i];
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                result[i] %= modulo;
            }

            System.IO.File.WriteAllText(testName + ".in.txt", inputBuilder.ToString());
            System.IO.File.WriteAllText(testName + ".out.txt", String.Join(" ", result) + System.Environment.NewLine);
        }
    }
}
