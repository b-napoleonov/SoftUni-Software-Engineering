using System;

namespace _7._KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row0 = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row0[j];
                }
            }

            int knightsInDanger = 0;
            int maxInDanger = int.MinValue;
            int row = 0;
            int col = 0;
            int removeCount = 0;

            while (true)
            {

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'K')
                        {
                            if (i + 1 < n && j + 2 < n)
                            {
                                if (matrix[i + 1, j + 2] == 'K')
                                {
                                    knightsInDanger++;
                                }
                            }
                            if (i + 2 < n && j + 1 < n)
                            {
                                if (matrix[i + 2, j + 1] == 'K')
                                {
                                    knightsInDanger++;
                                }
                            }
                            if (i + 1 < n && j - 2 >= 0)
                            {
                                if (matrix[i + 1, j - 2] == 'K')
                                {
                                    knightsInDanger++;
                                }
                            }
                            if (i + 2 < n && j - 1 >= 0)
                            {
                                if (matrix[i + 2, j - 1] == 'K')
                                {
                                    knightsInDanger++;
                                }
                            }
                            if (i - 1 >= 0 && j + 2 < n)
                            {
                                if (matrix[i - 1, j + 2] == 'K')
                                {
                                    knightsInDanger++;
                                }
                            }
                            if (i - 2 >= 0 && j + 1 < n)
                            {
                                if (matrix[i - 2, j + 1] == 'K')
                                {
                                    knightsInDanger++;
                                }
                            }
                            if (i - 1 >= 0 && j - 2 >= 0)
                            {
                                if (matrix[i - 1, j - 2] == 'K')
                                {
                                    knightsInDanger++;
                                }
                            }
                            if (i - 2 >= 0 && j - 1 >= 0)
                            {
                                if (matrix[i - 2, j - 1] == 'K')
                                {
                                    knightsInDanger++;
                                }
                            }
                        }

                        if (knightsInDanger > maxInDanger)
                        {
                            maxInDanger = knightsInDanger;
                            row = i;
                            col = j;
                        }

                        knightsInDanger = 0;
                    }
                }

                if (maxInDanger != 0)
                {
                    matrix[row, col] = '0';
                    removeCount++;
                    maxInDanger = 0;
                }
                else
                {
                    Console.WriteLine(removeCount);
                    return;
                }
            }
        }
    }
}
