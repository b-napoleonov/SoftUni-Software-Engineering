using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MemoryG
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();
            int counter = 0;

            while (input != "end")
            {
                string firstIndex = input.Split()[0];
                string secondIndex = input.Split()[1];
                counter++;

                if ((int.Parse(firstIndex) < 0 || int.Parse(firstIndex) >= list.Count) ||
                    (int.Parse(secondIndex) < 0 || int.Parse(secondIndex) >= list.Count))
                {
                    string buffer = $"-{counter}a";
                    list.Insert(list.Count / 2, buffer);
                    list.Insert(list.Count / 2, buffer);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                else if (list[int.Parse(firstIndex)] == list[int.Parse(secondIndex)])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {list[int.Parse(firstIndex)]}!");

                    list.RemoveAt(Math.Max(int.Parse(firstIndex), int.Parse(secondIndex)));
                    list.RemoveAt(Math.Min(int.Parse(firstIndex), int.Parse(secondIndex)));

                }
                else if (list[int.Parse(firstIndex)] != list[int.Parse(secondIndex)])
                {
                    Console.WriteLine("Try again!");
                }
                if (list.Count == 0)
                {
                    Console.WriteLine($"You have won in {counter} turns!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (list.Count != 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(' ', list));
            }
        }
    }
}
