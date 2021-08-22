using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> list = input.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            input = Console.ReadLine();

            while (input != "Craft!")
            {
                if (input.Split(' ')[0] == "Combine")
                {
                    string buffer = input.Split(' ')[3];
                    string oldItem = buffer.Split(':')[0];
                    string newItem = buffer.Split(':')[1];

                    if (list.Contains(oldItem))
                    {
                        list.Insert(list.IndexOf(oldItem), newItem);
                        list.Remove(oldItem);
                        list.Insert(list.IndexOf(newItem), oldItem);
                    }
                }
                else
                {
                    string command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[0].ToString();
                    string item = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries)[1].ToString();

                    if (command == "Collect")
                    {
                        if (!Contain(list, item))
                        {
                            list.Add(item);
                        }
                    }
                    else if (command == "Drop")
                    {
                        if (Contain(list, item))
                        {
                            list.Remove(item);
                        }
                    }
                    else if (command == "Renew")
                    {
                        if (Contain(list, item))
                        {
                            list.Remove(item);
                            list.Add(item);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }

        private static bool Contain(List<string> list, string item)
        {
            return list.Contains(item);
        }
    }
}
