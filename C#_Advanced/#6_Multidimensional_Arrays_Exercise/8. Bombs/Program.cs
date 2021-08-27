using System;
using System.Linq;
using System.Net.Http.Headers;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string[] coordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < coordinates.Length; i++)
            {
                int row = int.Parse(coordinates[i].Split(',')[0]);
                int col = int.Parse(coordinates[i].Split(',')[1]);
                int current = matrix[row, col];

                for (int bombRow = row - 1; bombRow <= row + 1; bombRow++)
                {
                    for (int bombCol = col - 1; bombCol <= col + 1; bombCol++)
                    {
                        if (bombRow >= 0 && bombRow < size && bombCol >= 0 && bombCol < size)
                        {
                            if (matrix[bombRow, bombCol] <= 0 || current < 0)
                            {
                                continue;
                            }

                            matrix[bombRow, bombCol] -= current;
                        }
                    }
                }
            }

            int aliveCells = 0;
            int sum = 0;

            foreach (var num in matrix)
            {
                if (num > 0)
                {
                    aliveCells++;
                    sum += num;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
