using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            int bombNumber = int.Parse(input.Split()[0]);
            int power = int.Parse(input.Split()[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    if (i - power < 0)
                    {
                        numbers.RemoveRange(0, power + i + 1);
                        i = -1;
                    }
                    else if (power + i > numbers.Count)
                    {
                        numbers.RemoveRange(i - power, power + (numbers.Count - i));
                        i = -1;
                    }
                    else
                    {
                        numbers.RemoveRange(i - power, power + power + 1);
                        i = -1;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}

