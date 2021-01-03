using System;

namespace FillSpiralMatrix
{
    class FillSpiralMatrix
    {
        static void Main(string[] args)
        {
            int matrSize = int.Parse(Console.ReadLine());
            int[,] matr = new int[matrSize, matrSize];

            int counter = 1;
            int size = matrSize / 2;
            int row = 0;
            int col = 0;
            int rowSize = matrSize - 1;

            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < rowSize; j++, col++)
                {
                    matr[row, col] = counter++;
                }
                for (int j = 0; j < rowSize; j++, row++)
                {
                    matr[row, col] = counter++;
                }
                for (int j = 0; j < rowSize; j++, col--)
                {
                    matr[row, col] = counter++;
                }
                for (int j = 0; j < rowSize; j++, row--)
                {
                    matr[row, col] = counter++;
                }

                row++;
                col++;
                rowSize -= 2;
            }

            if(matrSize%2!=0) matr[row, col] = counter;


            PrintMatrix(matr, matrSize);
        }

        private static void PrintMatrix(int[,] matr, int matrSize)
        {
            for (int i = 0; i < matrSize; i++)
            {
                for (int j = 0; j < matrSize; j++)
                {
                    Console.Write($"{matr[i, j]}\t");
                }
                    Console.WriteLine();
            }
        }
    }
}
