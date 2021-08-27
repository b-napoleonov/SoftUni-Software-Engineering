using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Queue<string> commands = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            char[,] matrix = new char[size, size];
            int coalCount = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];

                    if (matrix[i, j] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 's')
                    {
                        int currentRow = i;
                        int currentCol = j;

                        while (commands.Count > 0)
                        {
                            string current = commands.Dequeue();

                            switch (current)
                            {
                                case"left":

                                    if (currentCol - 1 < 0)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        currentCol--;

                                        if (matrix[currentRow, currentCol] == 'e')
                                        {
                                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                                            return;
                                        }
                                        else if (matrix[currentRow, currentCol] == 'c')
                                        {
                                            coalCount--;
                                            matrix[currentRow, currentCol] = '*';

                                            if (coalCount == 0)
                                            {
                                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                                return;
                                            }
                                        }
                                    }

                                    break;

                                case "right":

                                    if (currentCol + 1 >= size)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        currentCol++;

                                        if (matrix[currentRow, currentCol] == 'e')
                                        {
                                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                                            return;
                                        }
                                        if (matrix[currentRow, currentCol] == 'c')
                                        {
                                            coalCount--;
                                            matrix[currentRow, currentCol] = '*';

                                            if (coalCount == 0)
                                            {
                                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                                return;
                                            }
                                        }
                                    }

                                    break;

                                case "up":

                                    if (currentRow - 1 < 0)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        currentRow--;

                                        if (matrix[currentRow, currentCol] == 'e')
                                        {
                                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                                            return;
                                        }
                                        if (matrix[currentRow, currentCol] == 'c')
                                        {
                                            coalCount--;
                                            matrix[currentRow, currentCol] = '*';

                                            if (coalCount == 0)
                                            {
                                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                                return;
                                            }
                                        }
                                    }

                                    break;

                                case "down":

                                    if (currentRow + 1 >= size)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        currentRow++;

                                        if (matrix[currentRow, currentCol] == 'e')
                                        {
                                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                                            return;
                                        }
                                        if (matrix[currentRow, currentCol] == 'c')
                                        {
                                            coalCount--;
                                            matrix[currentRow, currentCol] = '*';

                                            if (coalCount == 0)
                                            {
                                                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                                                return;
                                            }
                                        }
                                    }

                                    break;
                            }
                        }

                        Console.WriteLine($"{coalCount} coals left. ({currentRow}, {currentCol})");
                        return;
                    }
                }
            }
        }
    }
}
