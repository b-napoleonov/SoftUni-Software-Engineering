using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> positives = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= 0)
                .Reverse()
                .ToList();

            if (positives.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(' ', positives));
            }
        }
    }
}
