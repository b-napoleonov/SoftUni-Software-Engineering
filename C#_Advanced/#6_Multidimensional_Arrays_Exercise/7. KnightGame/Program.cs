using System;

namespace _7._KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            char[,] matrix = MatrixReader(dimensions);

            int knightsInDanger = 0;
            int maxInDanger = 0;
            int knightRow = 0;
            int knightCol = 0;
            int removeCount = 0;

            while (true)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            knightsInDanger = InDangerChecker(dimensions, matrix, knightsInDanger, row, col);
                        }

                        if (knightsInDanger > maxInDanger)
                        {
                            maxInDanger = knightsInDanger;
                            knightRow = row;
                            knightCol = col;
                        }

                        knightsInDanger = 0;
                    }
                }

                if (maxInDanger > 0)
                {
                    matrix[knightRow, knightCol] = '0';
                    removeCount++;
                    maxInDanger = 0;
                }
                else
                {
                    Console.WriteLine(removeCount);
                    return;
                }
            }
        }

        private static char[,] MatrixReader(int n)
        {
            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row0 = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row0[j];
                }
            }

            return matrix;
        }

        private static int InDangerChecker(int n, char[,] matrix, int knightsInDanger, int row, int col)
        {
            if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == 'K')
            {
                knightsInDanger++;
            }
            if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == 'K')
            {
                knightsInDanger++;
            }
            if (row + 1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
            {
                knightsInDanger++;
            }
            if (row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
            {
                knightsInDanger++;
            }
            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
            {
                knightsInDanger++;
            }
            if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == 'K')
            {
                knightsInDanger++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
            {
                knightsInDanger++;
            }
            if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == 'K')
            {
                knightsInDanger++;
            }

            return knightsInDanger;
        }
    }
}
