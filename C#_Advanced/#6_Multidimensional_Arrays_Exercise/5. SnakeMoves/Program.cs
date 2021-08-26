using System;
using System.Linq;
using System.Transactions;

namespace _5._SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[dimensions[0], dimensions[1]];

            string snake = Console.ReadLine();
            int currentPositive = 0;
            int currentNegative = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int colP = 0; colP < matrix.GetLength(1); colP++)
                    {
                        if (currentNegative == snake.Length)
                        {
                            currentNegative = 0;
                        }

                        matrix[row, colP] = snake[currentNegative++];
                    }

                    currentPositive = currentNegative;
                }
                else
                {
                    for (int colN = matrix.GetLength(1) - 1; colN >= 0; colN--)
                    {
                        if (currentPositive == snake.Length)
                        {
                            currentPositive = 0;
                        }

                        matrix[row, colN] = snake[currentPositive++];
                    }
                    currentNegative = currentPositive;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
