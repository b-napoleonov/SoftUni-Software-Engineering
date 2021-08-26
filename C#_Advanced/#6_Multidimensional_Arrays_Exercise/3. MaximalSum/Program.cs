using System;
using System.Linq;

namespace _3._MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ArrConsoleRead();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = ArrConsoleRead();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int sum = 0;

                    for (int x = i; x < i + 3; x++)
                    {
                        for (int y = j; y < j + 3; y++)
                        {
                            sum += matrix[x, y];

                            if (sum > maxSum)
                            {
                                maxSum = sum;
                                startRow = i;
                                startCol = j;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startRow; row <= startRow + 2; row++)
            {
                for (int col = startCol; col <= startCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[] ArrConsoleRead()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
