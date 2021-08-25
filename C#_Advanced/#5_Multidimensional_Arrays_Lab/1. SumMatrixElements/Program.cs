using System;
using System.Linq;

namespace _1._SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = ArrConsoleRead();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = ArrConsoleRead();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                    sum += matrix[i, j];
                }
            }

            Console.WriteLine(matrixSize[0]);
            Console.WriteLine(matrixSize[1]);
            Console.WriteLine(sum);
        }

        private static int[] ArrConsoleRead()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
