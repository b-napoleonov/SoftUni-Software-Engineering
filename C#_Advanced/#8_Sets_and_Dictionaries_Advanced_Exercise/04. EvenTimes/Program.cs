using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int current = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(current) == false)
                {
                    numbers.Add(current, 0);
                }

                numbers[current]++;
            }

            Console.WriteLine(numbers.First(x => x.Value % 2 == 0).Key);
        }
    }
}
