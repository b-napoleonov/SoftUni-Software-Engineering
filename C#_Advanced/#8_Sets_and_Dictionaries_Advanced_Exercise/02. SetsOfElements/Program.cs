using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstSetLenght = tokens[0];
            int secondSetLenght = tokens[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            firstSet = SetFiller(firstSetLenght, firstSet);
            secondSet = SetFiller(secondSetLenght, secondSet);

            foreach (var num in firstSet.Where(num => secondSet.Contains(num)))
            {
                Console.Write(num + " ");
            }
        }

        private static HashSet<int> SetFiller(int lenght, HashSet<int> set)
        {
            for (int i = 0; i < lenght; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }

            return set;
        }
    }
}
