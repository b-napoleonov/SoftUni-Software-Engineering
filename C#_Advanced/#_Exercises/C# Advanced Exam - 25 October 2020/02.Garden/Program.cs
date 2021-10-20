using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] garden = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                garden[i] = new int[cols];
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (row < 0 || row >= rows || col < 0 || col >= cols)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                else
                {
                    FlowerBloom(rows, cols, garden, row, col);
                }
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(' ', garden[i]));
            }
        }

        private static void FlowerBloom(int rows, int cols, int[][] garden, int row, int col)
        {
            garden[row][col] = 1;

            for (int i = 0; i < rows; i++)
            {
                if (i == row)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (j != col)
                        {
                            garden[i][j] += 1;
                        }
                    }
                }
                else
                {
                    garden[i][col] += 1;
                }
            }
        }
    }
}
