using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
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
                    case "Delete":
                        list.RemoveAll(n => n == number);
                        break;
                    case "Insert":
                        int position = int.Parse(input.Split()[2]);
                        list.Insert(position, number);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', list));
        }
    }
}
