using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "end")
            {
                var command = input.Split()[0];

                if (command == "Add")
                {
                    int people = int.Parse(input.Split()[1]);

                    wagons.Add(people);
                }
                else
                {
                    int passengers = int.Parse(input.Split()[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        bool isTrue = wagons[i] + passengers <= maxCapacity;

                        if (isTrue)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}