using System;
using System.Collections.Generic;

namespace Selling
{
    class Selling
    {
        static void Main(string[] args)
        {

            int size        = int.Parse(Console.ReadLine());
            char[,] matr    = new char[size, size];
            Position myPos  = new Position();
            List<Position>               colons      = new List<Position>();
            Dictionary<string, Position> moves       = new Dictionary<string, Position>()
            {
                {"up"       , new Position(-1, 0)    },
                {"down"     , new Position( 1, 0)    },
                {"left"     , new Position( 0, -1)   },
                {"right"    , new Position( 0, 1)    },
            };

            for (int i = 0; i < size; i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < size; j++)
                {
                    char ch = input[j];
                    matr[i, j] = ch;

                    if (ch == 'S')
                    {
                        myPos.Row = i;
                        myPos.Col = j;
                    }
                    else if (ch == 'O')
                    {
                        colons.Add(new Position(i, j));
                    }
                }
            }

            int money = 0;

            while (money < 50)
            {
                var move = moves[Console.ReadLine()];

                matr[myPos.Row, myPos.Col] = '-';

                myPos.Row += move.Row;
                myPos.Col += move.Col;

                if (OutOfField(myPos, matr, size))
                {
                    break;
                }

                char ch = matr[myPos.Row, myPos.Col];

                if (Char.IsDigit(ch))
                {
                    money += ch - '0';
                }
                else if (ch == 'O')
                {
                    if (myPos.Row == colons[0].Row && myPos.Col == colons[0].Col)
                    {
                        matr[colons[0].Row, colons[0].Col] = '-';
                        myPos = colons[1];
                    }
                    else
                    {
                        matr[colons[1].Row, colons[1].Col] = '-';
                        myPos = colons[0];
                    }
                }

                matr[myPos.Row, myPos.Col] = 'S';
            }

            if (money < 50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

            PrintMatrix(matr, size);
        }

        private static void PrintMatrix(char[,] matr, int size)
        {
            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    Console.Write(matr[i,j]);
                }

                Console.WriteLine();
            }
        }

        private static bool OutOfField(Position pos, char[,] matr, int size)
        {
            return pos.Row < 0 || pos.Col < 0 || pos.Row == size || pos.Col == size;
        }
    }

    public class Position
    {
        public int Row;
        public int Col;

        public Position()
        {
        }
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
