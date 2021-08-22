using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._ListManipulationAdvanced
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
            bool isTrue = false;

            while (input != "end")
            {
                string command = input.Split()[0];

                switch (command)
                {
                    case "Add":
                        {
                            isTrue = true;
                            numbers.Add(int.Parse(input.Split()[1]));
                            break;
                        }

                    case "Remove":
                        {
                            isTrue = true;
                            numbers.Remove(int.Parse(input.Split()[1]));
                            break;
                        }
                    case "RemoveAt":
                        {
                            isTrue = true;
                            numbers.RemoveAt(int.Parse(input.Split()[1]));
                            break;
                        }
                    case "Insert":
                        {
                            isTrue = true;
                            numbers.Insert(int.Parse(input.Split()[2]), int.Parse(input.Split()[1]));
                            break;
                        }
                    case "Contains":
                        int number = int.Parse(input.Split()[1]);
                        if (numbers.Contains(number))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(' ', numbers.Where(n => n % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(' ', numbers.Where(n => n % 2 == 1)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":

                        string condition = input.Split()[1];
                        int num = int.Parse(input.Split()[2]);

                        switch (condition)
                        {
                            case "<":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n < num)));
                                break;
                            case ">":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n > num)));
                                break;
                            case ">=":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n >= num)));
                                break;
                            case "<=":
                                Console.WriteLine(string.Join(' ', numbers.Where(n => n <= num)));
                                break;
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            if (isTrue)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}
