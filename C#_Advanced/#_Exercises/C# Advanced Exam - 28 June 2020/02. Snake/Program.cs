using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int snakeRow = -1;
            int snakeCol = -1;
            int burrowRow = -1;
            int burrowCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (input[col] == 'B')
                    {
                        burrowRow = row;
                        burrowCol = col;
                    }
                }
            }

            int foodConsumed = 0;
            bool outOfBorder = true;

            while (outOfBorder && foodConsumed < 10)
            {
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "up":

                        if (snakeRow - 1 < 0)
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            outOfBorder = false;
                            continue;
                        }
                        else if (matrix[snakeRow - 1, snakeCol] == '-')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[--snakeRow, snakeCol] = 'S';
                        }
                        else if (matrix[snakeRow - 1, snakeCol] == '*')
                        {
                            foodConsumed++;
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[--snakeRow, snakeCol] = 'S';
                        }
                        else if (matrix[snakeRow - 1, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow - 1, snakeCol] = '.';
                            snakeRow = burrowRow;
                            snakeCol = burrowCol;
                            matrix[snakeRow, snakeCol] = 'S';
                        }

                        break;

                    case "down":

                        if (snakeRow + 1 >= matrix.GetLength(0))
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            outOfBorder = false;
                            continue;
                        }
                        else if (matrix[snakeRow + 1, snakeCol] == '-')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[++snakeRow, snakeCol] = 'S';
                        }
                        else if (matrix[snakeRow + 1, snakeCol] == '*')
                        {
                            foodConsumed++;
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[++snakeRow, snakeCol] = 'S';
                        }
                        else if (matrix[snakeRow + 1, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow + 1, snakeCol] = '.';
                            snakeRow = burrowRow;
                            snakeCol = burrowCol;
                            matrix[snakeRow, snakeCol] = 'S';
                        }

                        break;

                    case "left":

                        if (snakeCol - 1 < 0)
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            outOfBorder = false;
                            continue;
                        }
                        else if (matrix[snakeRow, snakeCol - 1] == '-')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, --snakeCol] = 'S';
                        }
                        else if (matrix[snakeRow, snakeCol - 1] == '*')
                        {
                            foodConsumed++;
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, --snakeCol] = 'S';
                        }
                        else if (matrix[snakeRow, snakeCol - 1] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, snakeCol - 1] = '.';
                            snakeRow = burrowRow;
                            snakeCol = burrowCol;
                            matrix[snakeRow, snakeCol] = 'S';
                        }

                        break;

                    case "right":

                        if (snakeCol + 1 >= matrix.GetLength(1))
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            outOfBorder = false;
                            continue;
                        }
                        else if (matrix[snakeRow, snakeCol + 1] == '-')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, ++snakeCol] = 'S';
                        }
                        else if (matrix[snakeRow, snakeCol + 1] == '*')
                        {
                            foodConsumed++;
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, ++snakeCol] = 'S';
                        }
                        else if (matrix[snakeRow, snakeCol + 1] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, snakeCol + 1] = '.';
                            snakeRow = burrowRow;
                            snakeCol = burrowCol;
                            matrix[snakeRow, snakeCol] = 'S';
                        }

                        break;
                }
            }

            Console.WriteLine(foodConsumed >= 10 ? "You won! You fed the snake." : "Game over!");
            Console.WriteLine($"Food eaten: {foodConsumed}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
