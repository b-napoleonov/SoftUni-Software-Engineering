using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            List<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < numberOfElements; i++)
            {
                Box<string> current = new Box<string>(Console.ReadLine());
                list.Add(current);
            }

            Console.WriteLine(ListComparer(list, Console.ReadLine()));
        }

        static int ListComparer<T>(List<Box<T>> list, T item) where T : IComparable
        {
            return list.Count(b => b.Value.CompareTo(item) > 0);
        }
    }
}
