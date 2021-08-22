﻿using System;
using System.Linq;

namespace _03._RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    arr[i] = 0;
                }

                Console.WriteLine($"{arr[i]} => {(int)Math.Round(arr[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
