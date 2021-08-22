using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            list.Sort();

            double average = list.Average();

            List<int> result = new List<int>(5);

            foreach (int number in list)
            {
                if (number > average)
                {
                    result.Add(number);
                }
            }

            result.Sort();
            result.Reverse();

            if (result.Count > 5)
            {
                int num = result.Count - 5;

                result.RemoveRange(5, num);
            }

            if (result.Count > 0)
            {
                Console.WriteLine(string.Join(' ', result));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
