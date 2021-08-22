using System;

namespace _02._PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                int current = 1;

                for (int col = 0; col <= row; col++)
                {
                    Console.Write($"{current} ");
                    current = current * (row - col) / (col + 1);
                }
                Console.WriteLine();
            }
        }
    }
}
