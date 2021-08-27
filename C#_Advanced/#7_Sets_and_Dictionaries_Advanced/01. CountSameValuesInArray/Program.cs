using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> repeatedValues = new Dictionary<double, int>();
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var num in numbers)
            {
                if (repeatedValues.ContainsKey(num) == false)
                {
                    repeatedValues.Add(num, 0);
                }

                repeatedValues[num]++;
            }

            foreach (var (key, value) in repeatedValues)
            {
                Console.WriteLine($"{key} - {value} times");
            }
        }
    }
}
