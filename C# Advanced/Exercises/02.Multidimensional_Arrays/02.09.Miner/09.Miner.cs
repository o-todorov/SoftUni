using System;
using System.Linq;

namespace _02._09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int     fieldSize   = int.Parse(Console.ReadLine());
            string[] commands   = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field       = new char[fieldSize, fieldSize];
            int     coalCount   = 0;
            int     currRow     = 0, currCol = 0;

            for (int i = 0; i < fieldSize; i++)
            {
                char[] arr = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(char.Parse)
                                .ToArray();

                for (int j = 0; j < fieldSize; j++)
                {
                    field[i, j] = arr[j];
                    if (arr[j] == 's')
                    {
                        currRow = i;
                        currCol = j;
                    }else if (arr[j] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            int currCoals = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "up":
                        currRow = Math.Max(currRow - 1, 0);
                        break;
                    case "right":
                        currCol = Math.Min(currCol + 1, fieldSize - 1);
                        break;
                    case "down":
                        currRow = Math.Min(currRow + 1, fieldSize - 1);
                        break;
                    case "left":
                        currCol = Math.Max(currCol - 1, 0);
                        break;
                    default:
                        break;
                }

                if (field[currRow, currCol] == 'c')
                {
                    field[currRow, currCol] = '*';

                    if (++currCoals == coalCount)
                    {
                        Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                        return;
                    }
                }
                else if(field[currRow, currCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currRow}, {currCol})");
                    return;
                }
            }

            Console.WriteLine($"{coalCount - currCoals} coals left. ({currRow}, {currCol})");

        }
    }
}
