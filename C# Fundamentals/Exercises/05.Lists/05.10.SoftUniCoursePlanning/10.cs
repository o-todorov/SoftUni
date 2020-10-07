using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05._10.SoftUniCoursePlanning
{
    class Program
    {

        public static List<string> lessons;

        static void Main(string[] args)
        {
            lessons = Console.ReadLine().Split(", ").ToList();

            string line;

            while ((line = Console.ReadLine()) != "course start")
            {
                string[] commLine = line.Split(":").ToArray();

                switch (commLine[0])
                {
                    case "Add":
                        if (!lessons.Contains(commLine[1]))
                        {
                            lessons.Add(commLine[1]);
                        }
                        break;
                    case "Insert":
                        int IDX = int.Parse(commLine[2]);

                        if (lessons.Contains(commLine[1]) ||
                                IDX < 0 ||
                                IDX > lessons.Count) { break; }

                        lessons.Insert(IDX, commLine[1]);

                        break;
                    case "Remove":
                        int ind = lessons.IndexOf(commLine[1]);

                        if (ind != -1)
                        {
                            lessons.RemoveAt(ind);

                            if ((ind = lessons.IndexOf(string.Format($"{commLine[1]}-Exercise"))) != -1)
                            {
                                lessons.RemoveAt(ind);
                            }
                        }

                        break;
                    case "Swap":
                        int i = lessons.IndexOf(commLine[1]);
                        int j = lessons.IndexOf(commLine[2]);

                        if (i == -1 || j == -1) break;

                        if (i < j)
                        {
                            swapLessons(i, j);
                        }
                        else
                        {
                            swapLessons(j, i);
                        }

                        break;
                    case "Exercise":
                        addExercise(commLine[1]);

                        break;
                    default:
                        break;
                }

            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{lessons[i]}");
            }

        }

        private static void addExercise(string lesson)
        {
            int IDX = lessons.IndexOf(lesson);

            if (IDX == -1)
            {
                lessons.Add(lesson);
                IDX = lessons.Count;
            }
            else
            {
                if (lessons.Contains(string.Format($"{lesson}-Exercise")))
                {
                    return;
                }

                IDX++;
            }

            lessons.Insert(IDX, string.Format($"{lesson}-Exercise"));

        }

        private static void swapLessons(int IDX1, int IDX2)
        {
            int firstLength = (lessons[IDX1 + 1] == string.Format($"{lessons[IDX1]}-Exercise")) ? 2 : 1;

            var first = lessons.GetRange(IDX1, firstLength);


            int secondLength = 1;

            if (IDX2 < (lessons.Count - 1) && lessons[IDX2 + 1] == string.Format($"{lessons[IDX2]}-Exercise"))
            {
                secondLength = 2;
            }

            var second = lessons.GetRange(IDX2, secondLength);

            lessons.RemoveRange(IDX2, secondLength);

            lessons.InsertRange(IDX2, first);

            lessons.RemoveRange(IDX1, firstLength);

            lessons.InsertRange(IDX1, second);

        }
    }
}
