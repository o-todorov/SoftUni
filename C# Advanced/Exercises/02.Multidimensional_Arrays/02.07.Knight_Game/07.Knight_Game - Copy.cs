using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02._07.Knight_Game
{
    class Program
    {
        public static Dictionary<int, Knight> knights = new Dictionary<int, Knight>();
        public static int[,] chess;
        public static Knight parent;
        public static int size;
        public static int minDeletedCount;
        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            chess = new int[size, size];
            minDeletedCount = size * size;
            int counter = 1;

            //foreach (var item in knights)
            //{
            //    Console.WriteLine($"{item.Key} - {string.Join(" ", item.Value.Hits)}");
            //}


            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < size; j++)
                {
                    if (input[j] != 'K')
                    {
                        chess[i, j] = 0;
                    }
                    else
                    {
                        chess[i, j] = counter;
                        knights.Add(counter, new Knight(counter));

                        if (i > 0)
                        {
                            parent = knights[counter];
                            CheckKnight(i, j);
                        }
                        counter++;
                    }
                }
            }

            knights = knights.Where(p => p.Value.Count > 0)
                .OrderBy(p => p.Value.Count)
                .ToDictionary(p => p.Key, p => p.Value);

            //PrintKnights(0, knights);

            foreach (var item in knights)
            {
                Console.WriteLine($"{item.Key} - {string.Join(" ",item.Value.Hits.Select(k=>k.ID))}");
            }

            int deleted = 0;
            int count = 0;

            while (true)
            {

                foreach (var item in knights)
                {
                    int first = item.Key;

                    if (item.Value.Count == 1)
                    {
                        int sec = item.Value.Hits[0].ID;

                        if (knights[sec].Count == 1)
                        {// If it's just a single couple - deletes 1 count
                            knights.Remove(first);
                            knights.Remove(sec);
                            deleted++;
                            count++;
                            Console.WriteLine($"removed-{first}");
                            Console.WriteLine($"removed-{sec}");
                        }
                        else if (knights[sec].Count == 2)
                        {// If there are two consecutive single elements at the end - deletes the second one
                            knights[sec].RemoveHit(first);
                            int third = knights[sec].Hits.First().ID;
                            knights[third].RemoveHit(sec);

                            if (knights[third].Count == 0)
                            {
                                knights.Remove(third);
                                Console.WriteLine($"removed-{third}");
                            }

                            knights.Remove(first);
                            knights.Remove(sec);
                            deleted++;
                            count++;
                            Console.WriteLine($"removed-{first}");
                            Console.WriteLine($"removed-{sec}");

                        }
                    }
                }

                if (count == 0) break;
                count = 0;
            }

            knights = knights.Where(p => p.Value.Count > 0)
                            .OrderBy(p => p.Value.Count)
                            .ToDictionary(p => p.Key, p => p.Value);

            FindCountToDelete(1, deleted, knights);

            Console.WriteLine(minDeletedCount);
            //PrintMatrix();
        }

        private static void PrintKnights(int level, Dictionary<int,List<int>> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {string.Join(" ", item.Value)}");
            }
        }

        private static void FindCountToDelete(int level,  int deleted, Dictionary<int, Knight> dict)
        {

        }

        private static void CheckKnight(int r, int c)
        {
            Check(r - 2, c - 1);
            Check(r - 2, c + 1);
            Check(r - 1, c - 2);
            Check(r - 1, c + 2);
        }

        private static void Check(int r, int c)
        {
            if (r >= 0 && r < size && c >= 0 && c < size)
            {
                int kn = chess[r, c];

                if (kn > 0)
                {
                    parent.AddHit(knights[kn]);
                    knights[kn].AddHit(parent);
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{chess[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
    class Knight
    {
        public int ID;
        //public List<int> Hits = new List<int>();
        public List<Knight> Hits = new List<Knight>();

        public Knight(int iD)
        {
            ID = iD;
        }

        public void AddHit(Knight newHit)
        {
            this.Hits.Add(newHit);
        }
        public void RemoveHit(int toRemove)
        {
            this.Hits.RemoveAt(this.Hits.FindIndex(k => k.ID == toRemove));
        }
        public int Count { get { return this.Hits.Count; } }
    }
}
