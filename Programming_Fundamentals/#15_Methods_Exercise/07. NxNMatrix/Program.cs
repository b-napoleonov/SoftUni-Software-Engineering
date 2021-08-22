using System;

namespace _07._NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintMatrix(n);
        }

        static void PrintMatrix(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= n; col++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
