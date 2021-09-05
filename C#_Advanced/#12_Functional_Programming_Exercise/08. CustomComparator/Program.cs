using System;
using System.Linq;

namespace _08._CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> comparator = (first, second) =>
            (first % 2 == 0 && second % 2 != 0) ? -1 :
            (first % 2 != 0 && second % 2 == 0) ? 1 :
            first.CompareTo(second);

            Array.Sort(numbers, new Comparison<int>(comparator));
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
