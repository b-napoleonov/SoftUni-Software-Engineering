using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            foreach (var item in list)
            {
                if (!numbers.ContainsKey(item))
                {
                    numbers.Add(item, 0);
                }

                numbers[item]++;
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
