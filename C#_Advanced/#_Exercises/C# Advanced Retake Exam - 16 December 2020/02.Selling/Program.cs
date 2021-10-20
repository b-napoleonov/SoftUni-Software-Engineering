using System;
using System.Data;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;
            int pillarRow = -1;
            int pillarCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (row[j] == 'S')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                    else if (row[j] == 'O')
                    {
                        pillarRow = i;
                        pillarCol = j;
                    }

                    matrix[i, j] = row[j];
                }
            }

            int money = 0;
            bool isIn = true;

            while (isIn && money < 50)
            {
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "up":

                        if (playerRow - 1 < 0)
                        {
                            isIn = false;
                            matrix[playerRow, playerCol] = '-';
                            continue;
                        }
                        else if (matrix[playerRow - 1, playerCol] == '-')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[--playerRow, playerCol] = 'S';
                        }
                        else if (char.IsDigit(matrix[playerRow - 1, playerCol]))
                        {
                            money += int.Parse(matrix[playerRow - 1, playerCol].ToString());
                            matrix[playerRow, playerCol] = '-';
                            matrix[--playerRow, playerCol] = 'S';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow - 1, playerCol] = '-';
                            playerRow = pillarRow;
                            playerCol = pillarCol;
                            matrix[playerRow, playerCol] = 'S';
                        }

                        break;

                    case "down":

                        if (playerRow + 1 >= matrix.GetLength(0))
                        {
                            isIn = false;
                            matrix[playerRow, playerCol] = '-';
                            continue;
                        }
                        else if (matrix[playerRow + 1, playerCol] == '-')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[++playerRow, playerCol] = 'S';
                        }
                        else if (char.IsDigit(matrix[playerRow + 1, playerCol]))
                        {
                            money += int.Parse(matrix[playerRow + 1, playerCol].ToString());
                            matrix[playerRow, playerCol] = '-';
                            matrix[++playerRow, playerCol] = 'S';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow + 1, playerCol] = '-';
                            playerRow = pillarRow;
                            playerCol = pillarCol;
                            matrix[playerRow, playerCol] = 'S';
                        }

                        break;

                    case "left":

                        if (playerCol - 1 < 0)
                        {
                            isIn = false;
                            matrix[playerRow, playerCol] = '-';
                            continue;
                        }
                        else if (matrix[playerRow, playerCol - 1] == '-')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, --playerCol] = 'S';
                        }
                        else if (char.IsDigit(matrix[playerRow, playerCol - 1]))
                        {
                            money += int.Parse(matrix[playerRow, playerCol - 1].ToString());
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, --playerCol] = 'S';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, playerCol - 1] = '-';
                            playerRow = pillarRow;
                            playerCol = pillarCol;
                            matrix[playerRow, playerCol] = 'S';
                        }

                        break;

                    case "right":

                        if (playerCol + 1 >= matrix.GetLength(1))
                        {
                            isIn = false;
                            matrix[playerRow, playerCol] = '-';
                            continue;
                        }
                        else if (matrix[playerRow, playerCol + 1] == '-')
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, ++playerCol] = 'S';
                        }
                        else if (char.IsDigit(matrix[playerRow, playerCol + 1]))
                        {
                            money += int.Parse(matrix[playerRow, playerCol + 1].ToString());
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, ++playerCol] = 'S';
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, playerCol + 1] = '-';
                            playerRow = pillarRow;
                            playerCol = pillarCol;
                            matrix[playerRow, playerCol] = 'S';
                        }

                        break;
                }
            }

            Console.WriteLine(isIn ? "Good news! You succeeded in collecting enough money!" : "Bad news, you are out of the bakery.");
            Console.WriteLine($"Money: {money}");

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
