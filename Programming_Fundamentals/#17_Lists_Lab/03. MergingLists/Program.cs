using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> second = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>(first.Count + second.Count);

            for (int i = 0; i < result.Capacity; i++)
            {
                if (IsBigger(first.Count, i))
                {
                    result.Add(first[i]);
                }
                if (IsBigger(second.Count, i))
                {
                    result.Add(second[i]);
                }
            }
            Console.WriteLine(string.Join(' ', result));
        }

        private static bool IsBigger(int listCount, int i)
        {
            bool isTrue = true;

            if (listCount <= i)
            {
                isTrue = false;
            }

            return isTrue;
        }
    }
}
