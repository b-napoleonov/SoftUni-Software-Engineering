using System;
using System.Linq;

namespace _6._JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jagged = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int i = 0; i < rows - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    jagged[i] = jagged[i].Select(x => x * 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jagged[i] = jagged[i].Select(x => x / 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x / 2).ToArray();
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                double value = double.Parse(commands[3]);

                if (row < 0 || row >= rows || col < 0 || col >= jagged[row].Length)
                {
                    input = Console.ReadLine();
                    continue;
                }

                switch (command)
                {
                    case "Add":

                        jagged[row][col] += value;

                        break;

                    case "Subtract":

                        jagged[row][col] -= value;

                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var element in jagged)
            {
                Console.WriteLine(string.Join(' ', element));
            }
        }
    }
}
