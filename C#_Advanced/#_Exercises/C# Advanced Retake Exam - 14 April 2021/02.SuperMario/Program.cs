using System;
using System.Linq;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int dimensions = int.Parse(Console.ReadLine());

            if (dimensions == 0)
            {
                return;
            }

            char[][] matrix = new char[dimensions][];
            int marioRow = -1;
            int marioCol = -1;

            for (int i = 0; i < dimensions; i++)
            {
                string row = Console.ReadLine();
                char[] arr = row.ToArray();
                matrix[i] = arr;
            }

            for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'M')
                    {
                        marioRow = i;
                        marioCol = j;
                        break;
                    }
                }
            }

            bool isInTheMaze = true;

            while (isInTheMaze && lives > 0)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string moveCommand = input[0];

                int sRow = int.Parse(input[1]);
                int sCol = int.Parse(input[2]);

                matrix[sRow][sCol] = 'B';

                switch (moveCommand)
                {
                    case "W":

                        if (marioRow - 1 < 0)
                        {
                            lives--;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = 'X';
                                continue;
                            }
                        }
                        else if (matrix[marioRow - 1][marioCol] == 'B')
                        {
                            lives -= 3;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = '-';
                                matrix[--marioRow][marioCol] = 'X';
                                continue;
                            }

                            matrix[marioRow][marioCol] = '-';
                            matrix[--marioRow][marioCol] = 'M';
                        }
                        else if (matrix[marioRow - 1][marioCol] == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            matrix[--marioRow][marioCol] = '-';
                            isInTheMaze = false;
                            lives--;
                            continue;
                        }
                        else
                        {
                            matrix[marioRow][marioCol] = '-';
                            matrix[--marioRow][marioCol] = 'M';

                            lives--;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = 'X';
                                continue;
                            }
                        }

                        break;

                    case "S":

                        if (marioRow + 1 >= matrix.GetLength(0))
                        {
                            lives--;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = 'X';
                                continue;
                            }
                        }
                        else if (matrix[marioRow + 1][marioCol] == 'B')
                        {
                            lives -= 3;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = '-';
                                matrix[++marioRow][marioCol] = 'X';
                                continue;
                            }

                            matrix[marioRow][marioCol] = '-';
                            matrix[++marioRow][marioCol] = 'M';
                        }
                        else if (matrix[marioRow + 1][marioCol] == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            matrix[++marioRow][marioCol] = '-';
                            isInTheMaze = false;
                            lives--;
                            continue;
                        }
                        else
                        {
                            matrix[marioRow][marioCol] = '-';
                            matrix[++marioRow][marioCol] = 'M';

                            lives--;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = 'X';
                                continue;
                            }
                        }

                        break;

                    case "A":

                        if (marioCol - 1 < 0)
                        {
                            lives--;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = 'X';
                                continue;
                            }
                        }
                        else if (matrix[marioRow][marioCol - 1] == 'B')
                        {
                            lives -= 3;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = '-';
                                matrix[marioRow][--marioCol] = 'X';
                                continue;
                            }

                            matrix[marioRow][marioCol] = '-';
                            matrix[marioRow][--marioCol] = 'M';
                        }
                        else if (matrix[marioRow][marioCol - 1] == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            matrix[marioRow][--marioCol] = '-';
                            isInTheMaze = false;
                            lives--;
                            continue;
                        }
                        else
                        {
                            matrix[marioRow][marioCol] = '-';
                            matrix[marioRow][--marioCol] = 'M';

                            lives--;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = 'X';
                                continue;
                            }
                        }

                        break;

                    case "D":

                        if (marioCol + 1 >= matrix[marioRow].Length)
                        {
                            lives--;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = 'X';
                                continue;
                            }
                        }
                        else if (matrix[marioRow][marioCol + 1] == 'B')
                        {
                            lives -= 3;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = '-';
                                matrix[marioRow][++marioCol] = 'X';
                                continue;
                            }

                            matrix[marioRow][marioCol] = '-';
                            matrix[marioRow][++marioCol] = 'M';
                        }
                        else if (matrix[marioRow][marioCol + 1] == 'P')
                        {
                            matrix[marioRow][marioCol] = '-';
                            matrix[marioRow][++marioCol] = '-';
                            isInTheMaze = false;
                            lives--;
                            continue;
                        }
                        else
                        {
                            matrix[marioRow][marioCol] = '-';
                            matrix[marioRow][++marioCol] = 'M';

                            lives--;

                            if (lives <= 0)
                            {
                                matrix[marioRow][marioCol] = 'X';
                                continue;
                            }
                        }

                        break;
                }
            }

            Console.WriteLine(lives <= 0 ? 
                $"Mario died at {marioRow};{marioCol}." : 
                $"Mario has successfully saved the princess! Lives left: {lives}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
