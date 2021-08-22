using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .Take(3)
                .ToList()
                .ForEach(n => Console.Write(string.Join(" ", n) + " "));
        }
    }
}
