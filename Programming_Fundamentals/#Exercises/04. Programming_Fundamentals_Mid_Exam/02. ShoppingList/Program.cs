using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Go")
            {
                string command = commands[0];
                string item = commands[1];

                switch (command)
                {
                    case "Urgent":
                        if (!Contains(list, item))
                        {
                            list.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (Contains(list, item))
                        {
                            list.Remove(item);
                        }
                        break;
                    case "Correct":

                        string newItem = commands[2];

                        if (Contains(list, item))
                        {
                            list[list.IndexOf(item)] = newItem;
                        }
                        break;
                    case "Rearrange":
                        if (Contains(list, item))
                        {
                            list.Remove(item);
                            list.Add(item);
                        }
                        break;
                }

                commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(", ", list));
        }

        private static bool Contains(List<string> list, string item)
        {
            if (list.Contains(item))
            {
                return true;
            }

            return false;
        }
    }
}
