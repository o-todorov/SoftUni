using System;

namespace _04._03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            int pts = 4;
            double[][] points = new double[pts][];
            double[] center = new double[2] { 0, 0 };

            for (int i = 0; i < pts; i++)
            {
                points[i] = new double[3];
                points[i][0] = double.Parse(Console.ReadLine());
                points[i][1] = double.Parse(Console.ReadLine());
                points[i][2] = calcDist(points[i], center);
            }

            if (calcDist(points[0], points[1]) >= calcDist(points[2], points[3]))
            {
                printLine(points[0], points[1]);
            }
            else
            {
                printLine(points[2], points[3]);
            }
        }

        private static void printLine(double[] p1, double[] p2)
        {
            if (p1[2] <= p2[2])
            {
                printPoint(p1);
                printPoint(p2);
            }
            else
            {
                printPoint(p2);
                printPoint(p1);
            }
        }
        private static void printPoint(double[] p)
        {
            Console.Write($"({p[0]}, {p[1]})");
        }

        private static double calcDist(double[] p1, double[] p2)
        {
            double x = Math.Abs(p1[0] - p2[0]);
            double y = Math.Abs(p1[1] - p2[1]);

            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
