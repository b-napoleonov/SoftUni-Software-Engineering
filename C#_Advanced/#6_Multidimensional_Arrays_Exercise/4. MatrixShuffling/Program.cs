using System;
using System.Linq;

namespace _4._MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] row = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                switch (command)
                {
                    case "swap":

                        int row1 = 0;
                        int col1 = 0;
                        int row2 = 0;
                        int col2 = 0;

                        if (int.TryParse(commands[1], out row1) && 
                            int.TryParse(commands[2], out col1) &&
                            int.TryParse(commands[3], out row2) &&
                            int.TryParse(commands[4], out col2))
                        {
                            if (row1 >= 0 && row1 < matrix.GetLength(0) &&
                                col1 >= 0 && col1 < matrix.GetLength(1) &&
                                row2 >= 0 && row2 < matrix.GetLength(0) &&
                                col2 >= 0 && col2 < matrix.GetLength(1))
                            {
                                string current = matrix[row1, col1];
                                matrix[row1, col1] = matrix[row2, col2];
                                matrix[row2, col2] = current;

                                for (int i = 0; i < matrix.GetLength(0); i++)
                                {
                                    for (int j = 0; j < matrix.GetLength(1); j++)
                                    {
                                        Console.Write(matrix[i, j] + " ");
                                    }

                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

                input = Console.ReadLine();
            }
            
        }
    }
}
