using System;
using System.Linq;

namespace _06._ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = e => e % n != 0;

            Console.WriteLine(string.Join(' ', numbers.Where(n => isDivisible(n)).Reverse()));
        }
    }
}
