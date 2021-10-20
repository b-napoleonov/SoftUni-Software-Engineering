using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (row[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }

                    matrix[i, j] = row[j];
                }
            }

            bool isReached = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine().ToLower();

                if (command == "up")
                {
                    if (playerRow - 1 < 0)
                    {
                        matrix[playerRow, playerCol] = '-';

                        if (matrix[n - 1, playerCol] == 'F')
                        {
                            matrix[n - 1, playerCol] = 'f';
                            isReached = true;
                            break;
                        }

                        matrix[n - 1, playerCol] = 'f';
                        playerRow = n - 1;
                    }
                    else if (matrix[playerRow - 1, playerCol] == 'B')
                    {
                        if (playerRow - 2 < 0)
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[n - 1, playerCol] = 'f';
                            playerRow = n - 1;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerRow -= 2;
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }
                    else if (matrix[playerRow - 1, playerCol] == 'T')
                    {
                        continue;
                    }
                    else if (matrix[playerRow - 1, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[--playerRow, playerCol] = 'f';
                        isReached = true;
                        break;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[--playerRow, playerCol] = 'f';
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 >= matrix.GetLength(0))
                    {
                        matrix[playerRow, playerCol] = '-';

                        if (matrix[0, playerCol] == 'F')
                        {
                            matrix[0, playerCol] = 'f';
                            isReached = true;
                            break;
                        }

                        matrix[0, playerCol] = 'f';
                        playerRow = 0;
                    }
                    else if (matrix[playerRow + 1, playerCol] == 'B')
                    {
                        if (playerRow + 2 >= matrix.GetLength(0))
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[0, playerCol] = 'f';
                            playerRow = 0;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerRow += 2;
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }
                    else if (matrix[playerRow + 1, playerCol] == 'T')
                    {
                        continue;
                    }
                    else if (matrix[playerRow + 1, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[++playerRow, playerCol] = 'f';
                        isReached = true;
                        break;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[++playerRow, playerCol] = 'f';
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 < 0)
                    {
                        matrix[playerRow, playerCol] = '-';

                        if (matrix[playerRow, n - 1] == 'F')
                        {
                            matrix[playerRow, n - 1] = 'f';
                            isReached = true;
                            break;
                        }

                        matrix[playerRow, n - 1] = 'f';
                        playerCol = n - 1;
                    }
                    else if (matrix[playerRow, playerCol - 1] == 'B')
                    {
                        if (playerCol - 2 < 0)
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, n - 1] = 'f';
                            playerCol = n - 1;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerCol -= 2;
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }
                    else if (matrix[playerRow, playerCol - 1] == 'T')
                    {
                        continue;
                    }
                    else if (matrix[playerRow, playerCol - 1] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow, --playerCol] = 'f';
                        isReached = true;
                        break;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow, --playerCol] = 'f';
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 >= matrix.GetLength(1))
                    {
                        matrix[playerRow, playerCol] = '-';

                        if (matrix[playerRow, 0] == 'F')
                        {
                            matrix[playerRow, 0] = 'f';
                            isReached = true;
                            break;
                        }

                        matrix[playerRow, 0] = 'f';
                        playerCol = 0;
                    }
                    else if (matrix[playerRow, playerCol + 1] == 'B')
                    {
                        if (playerCol + 2 >= matrix.GetLength(1))
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[playerRow, 0] = 'f';
                            playerCol = 0;
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            playerCol += 2;
                            matrix[playerRow, playerCol] = 'f';
                        }
                    }
                    else if (matrix[playerRow, playerCol + 1] == 'T')
                    {
                        continue;
                    }
                    else if (matrix[playerRow, playerCol + 1] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow, ++playerCol] = 'f';
                        isReached = true;
                        break;
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[playerRow, ++playerCol] = 'f';
                    }
                }
            }

            Console.WriteLine(isReached ? "Player won!" : "Player lost!");

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
