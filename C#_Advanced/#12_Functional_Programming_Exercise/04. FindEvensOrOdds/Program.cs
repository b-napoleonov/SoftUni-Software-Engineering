using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bound = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();

            for (int i = bound[0]; i <= bound[1]; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> odd = n => n % 2 != 0;
            Predicate<int> even = n => n % 2 == 0;

            switch (Console.ReadLine())
            {
                case "odd":

                    numbers = numbers.Where(n => odd(n)).ToList();

                    break;

                case "even":

                    numbers = numbers.Where(n => even(n)).ToList();

                    break;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
