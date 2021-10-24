using System;

namespace _02.BattleOfFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];
            int armyRow = -1;
            int armyCol = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = Console.ReadLine();

                matrix[i] = row.ToCharArray();
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'A')
                    {
                        armyRow = i;
                        armyCol = j;
                        break;
                    }
                }
            }

            bool isReached = false;
            while (!isReached && armor > 0)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                matrix[spawnRow][spawnCol] = 'O';

                switch (command)
                {
                    case "up":

                        if (armyRow - 1 < 0)
                        {
                            armor--;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = 'X';
                                continue;
                            }
                        }
                        else if (matrix[armyRow - 1][armyCol] == '-')
                        {
                            armor--;

                            if (armor <= 0)
                            {
                                matrix[--armyRow][armyCol] = 'X';
                                continue;
                            }

                            matrix[armyRow][armyCol] = '-';
                            matrix[--armyRow][armyCol] = 'A';
                        }
                        else if (matrix[armyRow - 1][armyCol] == 'O')
                        {
                            armor -= 3;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[--armyRow][armyCol] = 'X';
                                continue;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[--armyRow][armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow - 1][armyCol] == 'M')
                        {
                            armor--;
                            matrix[armyRow][armyCol] = '-';
                            matrix[--armyRow][armyCol] = '-';
                            isReached = true;
                        }

                        break;

                    case "down":

                        if (armyRow + 1 >= matrix.GetLength(0))
                        {
                            armor--;

                            if (armor <= 0)
                            {
                                matrix[++armyRow][armyCol] = 'X';
                                continue;
                            }
                        }
                        else if (matrix[armyRow + 1][armyCol] == '-')
                        {
                            armor--;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = 'X';
                                continue;
                            }

                            matrix[armyRow][armyCol] = '-';
                            matrix[++armyRow][armyCol] = 'A';
                        }
                        else if (matrix[armyRow + 1][armyCol] == 'O')
                        {
                            armor -= 3;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[++armyRow][armyCol] = 'X';
                                continue;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[++armyRow][armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow + 1][armyCol] == 'M')
                        {
                            armor--;
                            matrix[armyRow][armyCol] = '-';
                            matrix[++armyRow][armyCol] = '-';
                            isReached = true;
                        }

                        break;

                    case "left":

                        if (armyCol - 1 < 0)
                        {
                            armor--;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = 'X';
                                continue;
                            }
                        }
                        else if (matrix[armyRow][armyCol - 1] == '-')
                        {
                            armor--;

                            if (armor <= 0)
                            {
                                matrix[armyRow][--armyCol] = 'X';
                                continue;
                            }

                            matrix[armyRow][armyCol] = '-';
                            matrix[armyRow][--armyCol] = 'A';
                        }
                        else if (matrix[armyRow][armyCol - 1] == 'O')
                        {
                            armor -= 3;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[armyRow][--armyCol] = 'X';
                                continue;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[armyRow][--armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow][armyCol - 1] == 'M')
                        {
                            armor--;
                            matrix[armyRow][armyCol] = '-';
                            matrix[armyRow][--armyCol] = '-';
                            isReached = true;
                        }

                        break;

                    case "right":

                        if (armyCol + 1 >= matrix[armyRow].Length)
                        {
                            armor--;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = 'X';
                                continue;
                            }
                        }
                        else if (matrix[armyRow][armyCol + 1] == '-')
                        {
                            armor--;

                            if (armor <= 0)
                            {
                                matrix[armyRow][++armyCol] = 'X';
                                continue;
                            }

                            matrix[armyRow][armyCol] = '-';
                            matrix[armyRow][++armyCol] = 'A';
                        }
                        else if (matrix[armyRow][armyCol + 1] == 'O')
                        {
                            armor -= 3;

                            if (armor <= 0)
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[armyRow][++armyCol] = 'X';
                                continue;
                            }
                            else
                            {
                                matrix[armyRow][armyCol] = '-';
                                matrix[armyRow][++armyCol] = 'A';
                            }
                        }
                        else if (matrix[armyRow][armyCol + 1] == 'M')
                        {
                            armor--;
                            matrix[armyRow][armyCol] = '-';
                            matrix[armyRow][++armyCol] = '-';
                            isReached = true;
                        }

                        break;
                }
            }

            Console.WriteLine(isReached ? 
                $"The army managed to free the Middle World! Armor left: {armor}" : 
                $"The army was defeated at {armyRow};{armyCol}.");

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
