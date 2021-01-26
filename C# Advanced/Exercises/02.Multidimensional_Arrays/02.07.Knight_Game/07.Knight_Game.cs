using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._07.Knight_Game
{
    class Program
    {               // Declare static members for easy access
        public static Dictionary<int, List<int>> knights = new Dictionary<int, List<int>>();
        public static int[,] chess;     // Matrix
        public static int parent;       // Helper for initialization of the knights
        public static int size;         // Matrix size
        public static int maxDeleted;
        static void Main(string[] args)
        {
            size    = int.Parse(Console.ReadLine());
            chess   = new int[size, size];
            int counter = 1;                    // Counter for knights ID's for access to them
            maxDeleted  = size * size;

            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < size; j++)
                {
                    if (input[j] != 'K')
                    {
                        chess[i, j] = 0;        // Fill the empty places with 0
                    }
                    else
                    {
                        chess[i, j] = counter;  // If knight -> put his ID in the matrix
                        knights.Add(counter++, new List<int>()); // Add the knight to the dictionary
                                                // Intitialize new List for his hits ( ID's of the other knights)
                        if (i > 0)              // Start check for hits after 0-row
                        {                       // Do only 4 checks for each knight which are on top of it
                                                // Next 4 checks are to be done when next knight is in order
                            parent = chess[i, j]; // Parent is the current knight
                            CheckKnight(i, j);
                        }
                    }
                }
            }

            knights = knights.Where(p => p.Value.Count > 0) // Clear zero - hit knights
                        .OrderByDescending(p => p.Value.Count)
                        .ToDictionary(p => p.Key, p => p.Value);
            int deleted = 0;

            FindDeleted(deleted,1);

            Console.WriteLine(maxDeleted);

        }

        private static void FindDeleted(int deleted, int level)
        {
            if (deleted >= maxDeleted)
            {
                return;
            }
            else if (!knights.Values.Any(v => v.Count > 0))
            {
                if (deleted <= maxDeleted)
                {
                    maxDeleted = deleted;
                    return;
                }
            }
            //Console.WriteLine($"level-{level}: {string.Join(",",knights.Where(k=>k.Value.Count>0).ToDictionary(k=>k.Key,k=>k.Value).Keys)}");

            foreach (var k in knights)
            {
                if (k.Value.Count == 0) continue;

                var arr = k.Value.ToArray();

                foreach (var hit in arr)
                {
                    knights[hit].Remove(k.Key);
                }

                knights[k.Key].Clear();
                deleted++;

                FindDeleted(deleted,level+1);

                knights[k.Key].AddRange(arr);

                foreach (var hit in arr)
                {
                    knights[hit].Add(k.Key);
                }

                deleted--;

            }

        }

        private static void CheckKnight(int r, int c) // Define places to check if they are hit
        {                                             // on the previous two rows
            Check(r - 2, c - 1);
            Check(r - 2, c + 1);
            Check(r - 1, c - 2);
            Check(r - 1, c + 2);
        }

        private static void Check(int r, int c)
        {
            if (r >= 0 && r < size && c >= 0 && c < size) // Validate the indexes
            {
                int kn = chess[r, c];

                if (kn > 0)
                {
                    knights[parent].Add(kn);    // Add other knight ID to curr knight's list
                    knights[kn].Add(parent);    // Add curr knight ID to the other's list
                }
            }
        }
    }

}
