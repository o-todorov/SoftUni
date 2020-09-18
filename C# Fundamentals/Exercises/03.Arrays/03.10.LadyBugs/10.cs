using System;
using System.Linq;

namespace _03._10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {

            int fieldSize = int.Parse(Console.ReadLine());

            int[] bugPositions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] field = new int[fieldSize];

            for (int i = 0; i < bugPositions.Length; i++)
            {
                int pos = bugPositions[i];
                if (pos >= 0 && pos < fieldSize) field[pos] = 1;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] command = input.Split(" ");
                int bugPos = int.Parse(command[0]);

                if (bugPos >= 0 && bugPos < fieldSize && field[bugPos] == 1)
                {
                    int jump = int.Parse(command[2]);
                    if (command[1] == "left") jump = -jump;
                    int newpos = bugPos + jump;
                    field[bugPos] = 0;

                    while (newpos >= 0 && newpos < fieldSize)
                    {

                        if (field[newpos] == 0)
                        {
                            field[newpos] = 1;
                            break;
                        }

                        newpos += jump;
                    }
                }
                input = Console.ReadLine();

            }

            Console.WriteLine(string.Join(" ", field));


        }
    }
}
