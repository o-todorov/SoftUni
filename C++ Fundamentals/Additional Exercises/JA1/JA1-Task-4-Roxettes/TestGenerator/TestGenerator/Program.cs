using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenerator
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            generateTest("test.001", 1, new List<int>() { 2 }, 100);
            generateTest("test.002", 10, new List<int>() { 2 }, 200);
            generateTest("test.003", 30, new List<int>() { 2, 4, 6, 8, 10 }, 300);
            generateTest("test.004", 100, new List<int>() { 6, 8 }, 800);
            generateTest("test.005", 5000, new List<int>() { 6, 8 }, 10000);
            generateTest("test.006", 20000, new List<int>() { 10, 20, 30 });
            generateTest("test.007", 65534, new List<int>() { 2, 6, 8, 10 });
            generateTest("test.008", 30000, new List<int>() { 50, 52, 54 });
            generateTest("test.009", 40000, new List<int>() { 10, 12, 30});
            generateTest("test.010", 65534, new List<int>() { 2, 32, 64});
        }

        static void generateTest(string testName, int valuesToDuplicateCount, List<int> duplicationFactors, int maxCode = 0xFFFFF)
        {
            Console.WriteLine("generating test " + testName);
            int minCode = 0x00001;

            HashSet<int> toDuplicate = new HashSet<int>();
            while (toDuplicate.Count < valuesToDuplicateCount + 1)
            {
                toDuplicate.Add(rand.Next(minCode, maxCode + 1));
            }

            int unique = toDuplicate.First();
            toDuplicate.Remove(unique);

            List<int> inputValues = new List<int>() { unique };
            inputValues.Capacity = valuesToDuplicateCount * duplicationFactors.Max();

            int duplicatedSoFar = 0;
            foreach(var d in toDuplicate)
            {
                Console.CursorLeft = 0;
                double percent = ((duplicatedSoFar * 100) / (double)toDuplicate.Count);
                Console.Write(percent);
                int duplicationFactor = duplicationFactors[rand.Next(0, duplicationFactors.Count)];
                
                for(int i = 0; i < duplicationFactor; i++)
                {
                    inputValues.Add(d);
                }

                duplicatedSoFar++;
            }
            Console.WriteLine();

            for (int repeats = 0; repeats < 10; repeats++)
            {
                for (int i = 0; i < inputValues.Count; i++)
                {
                    int otherInd = rand.Next(0, inputValues.Count);
                    int swap = inputValues[i];
                    inputValues[i] = inputValues[otherInd];
                    inputValues[otherInd] = swap;
                }
            }

            StringBuilder inputBuilder = new StringBuilder();
            foreach (var v in inputValues)
            {
                inputBuilder.Append(v.ToString("X5").ToLower());
            }

            inputBuilder.AppendLine('.'.ToString());

            Console.WriteLine("Writing test i/o files");
            System.IO.File.WriteAllText(testName + ".in.txt", inputBuilder.ToString());
            System.IO.File.WriteAllText(testName + ".out.txt", unique.ToString("X5").ToLower() + System.Environment.NewLine);
        }
    }
}
