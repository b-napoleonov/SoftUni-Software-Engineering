using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDoubles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            List<Box<double>> list = new List<Box<double>>();

            for (int i = 0; i < numberOfElements; i++)
            {
                Box<double> current = new Box<double>(double.Parse(Console.ReadLine()));
                list.Add(current);
            }

            Console.WriteLine(CompareElements(list, double.Parse(Console.ReadLine())));
        }

        static int CompareElements<T>(List<Box<T>> list, T item) where T : IComparable
        {
            return list.Count(e => e.Value.CompareTo(item) > 0);
        }
    }
}
