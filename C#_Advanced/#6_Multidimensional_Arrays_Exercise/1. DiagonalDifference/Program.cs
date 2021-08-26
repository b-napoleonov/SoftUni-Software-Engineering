using System;
using System.Linq;

namespace _1._DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int primDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];

                    if (i == j)
                    {
                        primDiagonal += matrix[i, j];
                    }

                }
                secondaryDiagonal += matrix[i, n - 1 - i];
            }

            Console.WriteLine(Math.Abs(primDiagonal - secondaryDiagonal));
        }
    }
}
