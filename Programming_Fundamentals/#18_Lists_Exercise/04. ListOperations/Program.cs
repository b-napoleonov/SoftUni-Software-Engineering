using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._ListOperations
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

            while (input != "End")
            {
                string command = input.Split()[0];

                switch (command)
                {
                    case "Add":

                        int number = int.Parse(input.Split()[1]);
                        numbers.Add(number);

                        break;

                    case "Insert":

                        int index = int.Parse(input.Split()[2]);

                        if (IndexCheck(numbers, index))
                        {
                            int num = int.Parse(input.Split()[1]);
                            numbers.Insert(index, num);
                        }

                        break;

                    case "Remove":

                        int ind = int.Parse(input.Split()[1]);

                        if (IndexCheck(numbers, ind))
                        {
                            numbers.RemoveAt(ind);
                        }

                        break;

                    case "Shift":

                        string direction = input.Split()[1];
                        int count = int.Parse(input.Split()[2]);

                        switch (direction)
                        {
                            case "left":
                                for (int i = 0; i < count; i++)
                                {
                                    numbers.Add(numbers[0]);
                                    numbers.RemoveAt(0);
                                }
                                break;

                            case "right":
                                for (int i = 0; i < count; i++)
                                {
                                    numbers.Insert(0, numbers[numbers.Count - 1]);
                                    numbers.RemoveAt(numbers.Count - 1);
                                }
                                break;
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static bool IndexCheck(List<int> numbers, int index)
        {
            bool isTrue = true;

            if (index >= numbers.Count || index < 0)
            {
                Console.WriteLine("Invalid index");
                isTrue = false;
            }

            return isTrue;
        }
    }
}
