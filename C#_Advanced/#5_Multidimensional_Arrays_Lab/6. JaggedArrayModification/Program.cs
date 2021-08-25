using System;
using System.Linq;

namespace _6._JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split();
                string command = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row < 0 || row >= rows || col < 0 || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
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

            foreach (var arr in jagged)
            {
                Console.WriteLine(string.Join(' ', arr));
            }
        }
    }
}
