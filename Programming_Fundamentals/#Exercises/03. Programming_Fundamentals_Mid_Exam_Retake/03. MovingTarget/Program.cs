using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MovingT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (arr[0] != "End")
            {
                string command = arr[0];
                int index = int.Parse(arr[1]);
                int value = int.Parse(arr[2]);

                switch (command)
                {
                    case "Shoot":

                        if (index >= 0 && index < list.Count)
                        {
                            list[index] -= value;

                            if (list[index] <= 0)
                            {
                                list.RemoveAt(index);
                            }
                        }
                        break;

                    case "Add":

                        if (index >= 0 && index < list.Count)
                        {
                            list.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;

                    case "Strike":

                        if (index + value < list.Count && index - value >= 0)
                        {
                            list.RemoveRange(index - value, 1 + (value * 2));
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        break;
                }

                arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join('|', list));
        }
    }
}
