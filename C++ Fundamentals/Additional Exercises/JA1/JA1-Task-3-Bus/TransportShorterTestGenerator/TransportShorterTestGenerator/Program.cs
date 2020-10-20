using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportShorterTestGenerator
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            GenerateTest("test.001", 4, 17);
            GenerateTest("test.002", 10, 43);
            GenerateTest("test.003", 1, 22);
            GenerateTest("test.004", 20, 7);
            GenerateTest("test.005", 13, 0);

            GenerateTest("test.006", 12, 1);
            GenerateTest("test.007", 1, 105);
            GenerateTest("test.008", 7, 61);
            GenerateTest("test.009", 7, 666);
            GenerateTest("test.010", 5, 1000);
        }

        static void GenerateTest(string testName, int arrivalTimesCount, int answerTimeMinutes)
        {
            HashSet<int> arrivalTimesMinutes = new HashSet<int>();
            
            int trainTimeMinutes = rand.Next(answerTimeMinutes, 1440);
            int answerArrivalTimeMinutes = trainTimeMinutes - answerTimeMinutes;

            arrivalTimesMinutes.Add(answerArrivalTimeMinutes);
            
            while (arrivalTimesMinutes.Count < arrivalTimesCount)
            {
                int minutes = GetRandomDayMinutes();
                while (arrivalTimesMinutes.Contains(minutes) || trainTimeMinutes - minutes <= answerTimeMinutes)
                {
                    minutes = GetRandomDayMinutes();
                }

                arrivalTimesMinutes.Add(minutes);
            }

            var arrivalTimesList = new List<string>();
            foreach (var time in arrivalTimesMinutes)
            {
                arrivalTimesList.Add(FormatMilTime(time));
            }

            Shuffle(arrivalTimesList);

            System.IO.File.WriteAllText(testName + ".in.txt", 
                arrivalTimesList.Count + System.Environment.NewLine +
                string.Join(" ", arrivalTimesList) + System.Environment.NewLine + 
                FormatMilTime(trainTimeMinutes) + System.Environment.NewLine);

            System.IO.File.WriteAllText(testName + ".out.txt", (arrivalTimesList.IndexOf(FormatMilTime(answerArrivalTimeMinutes)) + 1) + System.Environment.NewLine);
        }

        static string FormatMilTime(int minutes)
        {
            int milHours = minutes / 60;
            int milMinutes = minutes % 60;

            return string.Format("{0:D2}{1:D2}", milHours, milMinutes);
        }

        static int GetMinDifference(int number, ICollection<int> numbers)
        {
            return numbers.Min(n => (number - n >= 0) ? (number - n) : int.MaxValue);
        }

        private static int GetRandomDayMinutes()
        {
            return rand.Next(0, 1440);
        }

        static void Shuffle<T>(List<T> list)
        {
            for (int repeats = 0; repeats < 10; repeats++)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int otherInd = rand.Next(0, list.Count);
                    var swap = list[i];
                    list[i] = list[otherInd];
                    list[otherInd] = swap;
                }
            }
        }
    }
}
