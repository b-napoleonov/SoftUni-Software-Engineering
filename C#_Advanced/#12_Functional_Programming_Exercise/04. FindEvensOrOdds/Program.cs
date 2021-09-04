using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Predicate<int> oddEven = command == "odd"
                ? number => number % 2 != 0
                : new Predicate<int>(number => number % 2 == 0);

            List<int> result = new List<int>();

            for (int n = boundaries[0]; n <= boundaries[1]; n++)
            {
                if (oddEven(n))
                {
                    result.Add(n);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
