using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._ListManipulationBasics
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

            while (input != "end")
            {
                string command = input.Split()[0];
                int number = int.Parse(input.Split()[1]);

                switch (command)
                {
                    case "Add":
                        {
                            numbers.Add(number);
                            break;
                        }

                    case "Remove":
                        {
                            numbers.Remove(number);
                            break;
                        }
                    case "RemoveAt":
                        {
                            numbers.RemoveAt(number);
                            break;
                        }
                    case "Insert":
                        {
                            int index = int.Parse(input.Split()[2]);

                            numbers.Insert(index, number);
                            break;
                        }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
