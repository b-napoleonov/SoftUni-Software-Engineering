﻿using System;

namespace _11_Multiplication_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine($"{n} X {multiplier} = {n * multiplier}");
                multiplier++;
            } while (multiplier < 11);
        }
    }
}
