using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018_04_24_Parking_Feud
{
    class Parking_Feud
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                       .Split(" ")
                       .Select(int.Parse)
                       .ToArray();
            int cols = arr[1] + 2;                          // real matrix columns
            int entrance = int.Parse(Console.ReadLine());   // entrance number
            int path = 0;                                   // total distance
            string parkingSpot = string.Empty;

            while (true)
            {
                var input   = Console.ReadLine().Split();
                var dict = new Dictionary<int, string>();

                for (int i = 0; i < input.Length; i++)
                {
                    dict[i + 1] = input[i];
                }

                parkingSpot = dict[entrance];                   // Parking spot for curr car
                int spotRow = int.Parse(parkingSpot[1..]);      // Parking spot row
                int spotCol = parkingSpot[0] - 'A' + 1;         // Parking spot column
                int spotDriveWay = spotRow > entrance ? spotRow - 1 : spotRow; // Parking spot closest driveway to the entrance

                int dist = GetPath(cols, spotDriveWay, spotCol, entrance);  // Distance to the Parking spot 
                var filtered = dict.Where(k => k.Value == parkingSpot && k.Key != entrance); // Filter for existing conflict spots

                if (filtered.Count() == 0 || GetPath(cols, spotDriveWay, spotCol, filtered.First().Key ) >= dist)
                {
                    path += dist;
                    break;
                }
                else
                {
                    path += 2 * dist;
                }
            }

            Console.WriteLine($"Parked successfully at {parkingSpot}.");
            Console.WriteLine($"Total Distance Passed: {path}");
        }

        private static int GetPath(int cols, int spotDriveWay, int spotCol, int entry)
        {       // Calculate distance to the parking spot
            if (spotDriveWay == entry)          // if the parking spot driveway is same as the entry way
            {
                return spotCol;
            }
            else
            {                  // if the parking spot driveway is different than entry way
                int diffRows = Math.Abs(spotDriveWay - entry);      // Count of the whole rows to pass - plus up/down return
                int dist = diffRows * (cols - 1 + 2);               // Distance of the whole rows
                dist = diffRows % 2 == 0 ? dist + spotCol : dist + cols - spotCol - 1;  // plus distance to the parking spot

                return dist;
            }
        }
    }
}
