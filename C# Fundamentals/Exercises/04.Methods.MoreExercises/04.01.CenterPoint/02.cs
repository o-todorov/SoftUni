using System;
using System.ComponentModel.Design.Serialization;

namespace _04._02.CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] points = new double[2][];

            for (int i = 0; i < 2; i++)
            {
                points[i] = new double[3];
                points[i][0] = double.Parse(Console.ReadLine());
                points[i][1] = double.Parse(Console.ReadLine());
                points[i][2] = calcDist(points[i][0], points[i][1]);
            }

            int j = (points[1][2] < points[0][2]) ? 1 : 0;

            printPoint(points[j]);
        }

        private static double calcDist(double v1, double v2)
        {
            return Math.Sqrt(Math.Pow(v1, 2) + Math.Pow(v2, 2));
        }

        private static void printPoint(double[] p)
        {
            Console.WriteLine($"({p[0]}, {p[1]})");
        }

    }
}
