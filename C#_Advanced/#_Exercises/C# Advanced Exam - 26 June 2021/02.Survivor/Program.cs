using System;
using System.IO.Pipes;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[][] matrix = new string[n][];

            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                matrix[i] = row;
            }

            int myTokens = 0;
            int enemyTokens = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Gong")
            {
                if (command.Contains("Find"))
                {
                    string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);

                    if (IsValid(matrix, row, col) && matrix[row][col] == "T")
                    {
                        myTokens++;
                        matrix[row][col] = "-";
                    }
                }
                else if (command.Contains("Opponent"))
                {
                    string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    string direction = input[3];

                    if (IsValid(matrix, row, col))
                    {
                        if (matrix[row][col] == "T")
                        {
                            enemyTokens++;
                            matrix[row][col] = "-";
                        }

                        switch (direction)
                        {
                            case "up":

                                if (row - 1 >= 0 && matrix[row - 1][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row - 1][col] = "-";
                                }
                                if (row - 2 >= 0 && matrix[row - 2][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row - 2][col] = "-";
                                }
                                if (row - 3 >= 0 && matrix[row - 3][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row - 3][col] = "-";
                                }

                                break;

                            case "down":

                                if (row + 1 < matrix.GetLength(0) && matrix[row + 1][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row + 1][col] = "-";
                                }
                                if (row + 2 < matrix.GetLength(0) && matrix[row + 2][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row + 2][col] = "-";
                                }
                                if (row + 3 < matrix.GetLength(0) && matrix[row + 3][col] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row + 3][col] = "-";
                                }

                                break;

                            case "left":

                                if (col - 1 >= 0 && matrix[row][col - 1] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col - 1] = "-";
                                }
                                if (col - 2 >= 0 && matrix[row][col - 2] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col - 2] = "-";
                                }
                                if (col - 3 >= 0 && matrix[row][col - 3] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col - 3] = "-";
                                }

                                break;

                            case "right":

                                if (col + 1 < matrix[row].Length && matrix[row][col + 1] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col + 1] = "-";
                                }
                                if (col + 2 < matrix[row].Length && matrix[row][col + 2] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col + 2] = "-";
                                }
                                if (col + 3 < matrix[row].Length && matrix[row][col + 3] == "T")
                                {
                                    enemyTokens++;
                                    matrix[row][col + 3] = "-";
                                }

                                break;
                        }
                    }
                }
            }

            PrintMatrix(matrix);
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");
        }

        private static bool IsValid(string[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }

        private static void PrintMatrix(string[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
