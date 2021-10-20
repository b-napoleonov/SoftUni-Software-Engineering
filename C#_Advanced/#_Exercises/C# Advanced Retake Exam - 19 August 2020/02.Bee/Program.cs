using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];

                    if (row[j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }

            string command = string.Empty;
            int polinatedFlowers = 0;
            bool isInside = true;

            while (isInside && (command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":

                        if (beeRow - 1 < 0)
                        {
                            matrix[beeRow, beeCol] = '.';
                            isInside = false;
                        }
                        else if (matrix[beeRow - 1, beeCol] == '.')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[--beeRow, beeCol] = 'B';
                        }
                        else if (matrix[beeRow - 1, beeCol] == 'f')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[--beeRow, beeCol] = 'B';
                            polinatedFlowers++;
                        }
                        else
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[--beeRow, beeCol] = 'B';

                            if (beeRow - 1 < 0)
                            {
                                isInside = false;
                            }
                            else
                            {
                                matrix[beeRow, beeCol] = '.';

                                if (matrix[beeRow -1, beeCol] == 'f')
                                {
                                    polinatedFlowers++;
                                }

                                matrix[--beeRow, beeCol] = 'B';
                            }
                        }

                        break;

                    case "down":

                        if (beeRow + 1 >= matrix.GetLength(0))
                        {
                            matrix[beeRow, beeCol] = '.';
                            isInside = false;
                        }
                        else if (matrix[beeRow + 1, beeCol] == '.')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[++beeRow, beeCol] = 'B';
                        }
                        else if (matrix[beeRow + 1, beeCol] == 'f')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[++beeRow, beeCol] = 'B';
                            polinatedFlowers++;
                        }
                        else
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[++beeRow, beeCol] = 'B';

                            if (beeRow + 1 >= matrix.GetLength(0))
                            {
                                isInside = false;
                            }
                            else
                            {
                                matrix[beeRow, beeCol] = '.';

                                if (matrix[beeRow + 1, beeCol] == 'f')
                                {
                                    polinatedFlowers++;
                                }

                                matrix[++beeRow, beeCol] = 'B';
                            }
                        }

                        break;

                    case "left":

                        if (beeCol - 1 < 0)
                        {
                            matrix[beeRow, beeCol] = '.';
                            isInside = false;
                        }
                        else if (matrix[beeRow, beeCol - 1] == '.')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow, --beeCol] = 'B';
                        }
                        else if (matrix[beeRow, beeCol - 1] == 'f')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow, --beeCol] = 'B';
                            polinatedFlowers++;
                        }
                        else
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow, --beeCol] = 'B';

                            if (beeCol - 1 < 0)
                            {
                                isInside = false;
                            }
                            else
                            {
                                matrix[beeRow, beeCol] = '.';

                                if (matrix[beeRow, beeCol - 1] == 'f')
                                {
                                    polinatedFlowers++;
                                }

                                matrix[beeRow, --beeCol] = 'B';
                            }
                        }

                        break;

                    case "right":

                        if (beeCol + 1 >= matrix.GetLength(1))
                        {
                            matrix[beeRow, beeCol] = '.';
                            isInside = false;
                        }
                        else if (matrix[beeRow, beeCol + 1] == '.')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow, ++beeCol] = 'B';
                        }
                        else if (matrix[beeRow, beeCol + 1] == 'f')
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow, ++beeCol] = 'B';
                            polinatedFlowers++;
                        }
                        else
                        {
                            matrix[beeRow, beeCol] = '.';
                            matrix[beeRow, ++beeCol] = 'B';

                            if (beeCol + 1 >= matrix.GetLength(1))
                            {
                                isInside = false;
                            }
                            else
                            {
                                matrix[beeRow, beeCol] = '.';

                                if (matrix[beeRow, beeCol + 1] == 'f')
                                {
                                    polinatedFlowers++;
                                }

                                matrix[beeRow, ++beeCol] = 'B';
                            }
                        }

                        break;
                }
            }

            if (!isInside)
            {
                Console.WriteLine("The bee got lost!");
            }

            Console.WriteLine(polinatedFlowers < 5 ? 
                $"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more" : 
                $"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");

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
