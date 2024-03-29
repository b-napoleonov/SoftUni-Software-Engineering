﻿using System;

namespace _7._PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jagged = new long[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = new long[i + 1];
                jagged[i][0] = 1;
                jagged[i][i] = 1;

                for (int j = 1; j < i; j++)
                {
                    jagged[i][j] = jagged[i - 1][j] + jagged[i - 1][j - 1];
                }

                Console.WriteLine(string.Join(' ', jagged[i]));
            }
        }
    }
}
