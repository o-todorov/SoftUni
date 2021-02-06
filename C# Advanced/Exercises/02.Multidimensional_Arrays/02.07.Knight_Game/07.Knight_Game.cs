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
        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            chess = new int[size, size];
            int counter = 1;                    // Counter for knights ID's for access to them

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
                        chess[i, j] = counter;  // If knight - put his ID
                        knights.Add(counter++, new List<int>()); // Add the knight to the dictionary
                                                                 // Intitialize new List for his hits ( ID's of the other knights)
                        if (i > 0)  // Start check for hits after 0-row
                        {           // Do only 4 checks for each knight which are on top of it
                                    // Next 4 checks are to be done when next knight is in order
                            parent = chess[i, j]; // Parent is the current knight
                            CheckKnight(i, j);
                        }
                    }
                }
            }

            knights = knights.Where(p => p.Value.Count > 0) // Clear zero - hit knights
                        .ToDictionary(p => p.Key, p => p.Value);
            int deleted = 0;

            while (knights.Count() > 0) // One delete per cycle
            {
                int maxHits = knights.Max(x => x.Value.Count);
                var curr = knights.First(k => k.Value.Count == maxHits); // Top knigh with max hits

                List<int> hits = curr.Value; // List of top knight hits

                foreach (var hit in hits)
                {
                    knights[hit].Remove(curr.Key);      // Remove current from the list of each his hit

                    if (knights[hit].Count == 0)    // Remove the knight if become 0-hit
                    {
                        knights.Remove(hit);
                    }
                }

                knights.Remove(curr.Key);               // Remove top knight from the dictionary
                deleted++;                          // Increase counter for deleted knights
            }

            Console.WriteLine(deleted);

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
