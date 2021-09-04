using System;
using System.Linq;

namespace _07._PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesLength = int.Parse(Console.ReadLine());

            Predicate<int> length = e => e <= namesLength;

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(i => length(i.Length))
                .ToList()
                .ForEach(e => Console.WriteLine(e));
        }
    }
}
