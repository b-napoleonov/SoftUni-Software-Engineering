using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            HashSet<int> dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            Func<HashSet<int>, int, bool> filter = (array, number)
                => array.All(n => number % n == 0);

            int[] divisibleNumbers = Enumerable.Range(1, range).Where(number => filter(dividers, number)).ToArray();

            Console.WriteLine(string.Join(' ', divisibleNumbers));
        }
    }
}

