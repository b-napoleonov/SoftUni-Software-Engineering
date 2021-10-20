using System;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            string[,] matrix = new string[n, n];
            int firstPShips = 0;
            int secondPShips = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (row[j] == "<")
                    {
                        firstPShips++;
                    }
                    else if (row[j] == ">")
                    {
                        secondPShips++;
                    }

                    matrix[i, j] = row[j];
                }
            }

            int totalShips = firstPShips + secondPShips;

            for (int i = 0; i < commands.Length; i++)
            {
                if (firstPShips <= 0 || secondPShips <= 0)
                {
                    break;
                }

                int row = int.Parse(commands[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]);
                int col = int.Parse(commands[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);

                if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                {
                    continue;
                }

                if (matrix[row, col] == "<")
                {
                    matrix[row, col] = "X";
                    firstPShips--;
                }
                else if (matrix[row, col] == ">")
                {
                    matrix[row, col] = "X";
                    secondPShips--;
                }
                else if (matrix[row, col] == "#")
                {
                    matrix[row, col] = "X";

                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] == "<")
                        {
                            matrix[row - 1, col] = "X";
                            firstPShips--;
                        }
                        else if (matrix[row - 1, col] == ">")
                        {
                            matrix[row - 1, col] = "X";
                            secondPShips--;
                        }
                    }
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        if (matrix[row - 1, col - 1] == "<")
                        {
                            matrix[row - 1, col - 1] = "X";
                            firstPShips--;
                        }
                        else if (matrix[row - 1, col - 1] == ">")
                        {
                            matrix[row - 1, col - 1] = "X";
                            secondPShips--;
                        }
                    }
                    if (row - 1 >= 0 && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row - 1, col + 1] == "<")
                        {
                            matrix[row - 1, col + 1] = "X";
                            firstPShips--;
                        }
                        else if (matrix[row - 1, col + 1] == ">")
                        {
                            matrix[row - 1, col + 1] = "X";
                            secondPShips--;
                        }
                    }
                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] == "<")
                        {
                            matrix[row, col - 1] = "X";
                            firstPShips--;
                        }
                        else if (matrix[row, col - 1] == ">")
                        {
                            matrix[row, col - 1] = "X";
                            secondPShips--;
                        }
                    }
                    if (col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row, col + 1] == "<")
                        {
                            matrix[row, col + 1] = "X";
                            firstPShips--;
                        }
                        else if (matrix[row, col + 1] == ">")
                        {
                            matrix[row, col + 1] = "X";
                            secondPShips--;
                        }
                    }
                    if (row + 1 < matrix.GetLength(0) && col - 1 >= 0)
                    {
                        if (matrix[row + 1, col - 1] == "<")
                        {
                            matrix[row + 1, col - 1] = "X";
                            firstPShips--;
                        }
                        else if (matrix[row + 1, col - 1] == ">")
                        {
                            matrix[row + 1, col - 1] = "X";
                            secondPShips--;
                        }
                    }
                    if (row + 1 < matrix.GetLength(0) && col >= 0)
                    {
                        if (matrix[row + 1, col] == "<")
                        {
                            matrix[row + 1, col] = "X";
                            firstPShips--;
                        }
                        else if (matrix[row + 1, col] == ">")
                        {
                            matrix[row + 1, col] = "X";
                            secondPShips--;
                        }
                    }
                    if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row + 1, col + 1] == "<")
                        {
                            matrix[row + 1, col + 1] = "X";
                            firstPShips--;
                        }
                        else if (matrix[row + 1, col + 1] == ">")
                        {
                            matrix[row + 1, col + 1] = "X";
                            secondPShips--;
                        }
                    }
                }
            }

            if (secondPShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShips - firstPShips} ships have been sunk in the battle.");
            }
            else if (firstPShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShips - secondPShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPShips} ships left. Player Two has {secondPShips} ships left.");
            }
        }
    }
}
