using System;
using System.Collections.Generic;
using System.Linq;
using GenericBoxOfInt;

namespace GenericSwapMethodIntegers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfBoxes = int.Parse(Console.ReadLine());
            List<Box<int>> list = new List<Box<int>>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                Box<int> current = new Box<int>(int.Parse(Console.ReadLine()));
                list.Add(current);
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(list, indexes[0], indexes[1]);
            Console.WriteLine(string.Join(Environment.NewLine, list));
        }

        static void Swap<T>(List<Box<T>> list, int index1, int index2)
        {
            Box<T> current = list[index1];
            list[index1] = list[index2];
            list[index2] = current;
        }
    }
}
