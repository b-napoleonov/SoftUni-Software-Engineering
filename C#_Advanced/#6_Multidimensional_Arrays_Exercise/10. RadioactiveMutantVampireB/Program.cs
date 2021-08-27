using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._RadioactiveMutantVampireB
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

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            Queue<char> commands = new Queue<char>(Console.ReadLine());

            for (int i = 0; i < dimensions[0]; i++)
            {
                for (int j = 0; j < dimensions[1]; j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        int currentRow = i;
                        int currentCol = j;
                        matrix[i, j] = '.';

                        while (commands.Count > 0)
                        {
                            char current = commands.Dequeue();

                            switch (current)
                            {
                                case 'U':

                                    BunnySpread(matrix);

                                    if (currentRow - 1 >= 0)
                                    {
                                        currentRow--;

                                        if (matrix[currentRow, currentCol] == 'B')
                                        {
                                            PrintMatrix(matrix);
                                            Console.WriteLine($"dead: {currentRow} {currentCol}");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        PrintMatrix(matrix);
                                        Console.WriteLine($"won: {currentRow} {currentCol}");
                                        return;
                                    }

                                    break;

                                case 'D':

                                    BunnySpread(matrix);

                                    if (currentRow + 1 < matrix.GetLength(0))
                                    {
                                        currentRow++;

                                        if (matrix[currentRow, currentCol] == 'B')
                                        {
                                            PrintMatrix(matrix);
                                            Console.WriteLine($"dead: {currentRow} {currentCol}");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        PrintMatrix(matrix);
                                        Console.WriteLine($"won: {currentRow} {currentCol}");
                                        return;
                                    }

                                    break;

                                case 'L':

                                    BunnySpread(matrix);

                                    if (currentCol - 1 >= 0)
                                    {
                                        currentCol--;

                                        if (matrix[currentRow, currentCol] == 'B')
                                        {
                                            PrintMatrix(matrix);
                                            Console.WriteLine($"dead: {currentRow} {currentCol}");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        PrintMatrix(matrix);
                                        Console.WriteLine($"won: {currentRow} {currentCol}");
                                        return;
                                    }

                                    break;

                                case 'R':

                                    BunnySpread(matrix);

                                    if (currentCol + 1 < matrix.GetLength(1))
                                    {
                                        currentCol++;

                                        if (matrix[currentRow, currentCol] == 'B')
                                        {
                                            PrintMatrix(matrix);
                                            Console.WriteLine($"dead: {currentRow} {currentCol}");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        PrintMatrix(matrix);
                                        Console.WriteLine($"won: {currentRow} {currentCol}");
                                        return;
                                    }

                                    break;
                            }
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void BunnySpread(char[,] matrix)
        {
            Queue<int> bunnyNumber = new Queue<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnyNumber.Enqueue(row);
                        bunnyNumber.Enqueue(col);
                    }
                }
            }

            while (bunnyNumber.Count > 0)
            {
                int currentRowB = bunnyNumber.Dequeue();
                int currentColB = bunnyNumber.Dequeue();

                if (currentRowB + 1 < matrix.GetLength(0))
                {
                    matrix[currentRowB + 1, currentColB] = 'B';
                }
                if (currentRowB - 1 >= 0)
                {
                    matrix[currentRowB - 1, currentColB] = 'B';
                }
                if (currentColB + 1 < matrix.GetLength(1))
                {
                    matrix[currentRowB, currentColB + 1] = 'B';
                }
                if (currentColB - 1 >= 0)
                {
                    matrix[currentRowB, currentColB - 1] = 'B';
                }
            }
        }
    }
}
