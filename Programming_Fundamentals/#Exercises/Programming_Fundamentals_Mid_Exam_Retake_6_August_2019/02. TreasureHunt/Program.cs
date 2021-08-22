using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._TrHun
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                string[] arr = input.Split(' ');
                string command = arr[0];

                switch (command)
                {
                    case "Loot":

                        for (int i = 1; i < arr.Length; i++)
                        {
                            if (!list.Contains(arr[i]))
                            {
                                list.Insert(0, arr[i]);
                            }
                        }
                        break;
                    case "Drop":

                        int index = int.Parse(arr[1]);

                        if (index >= 0 && index < list.Count)
                        {
                            string current = list[index];
                            list.RemoveAt(index);
                            list.Add(current);
                        }
                        break;
                    case "Steal":

                        if (list.Count == 0)
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        int count = int.Parse(arr[1]);
                        List<string> stolen = new List<string>(list.Count);

                        for (int i = 0; i < count; i++)
                        {
                            stolen.Insert(0, list[list.Count - 1]);
                            list.RemoveAt(list.Count - 1);

                            if (list.Count == 0)
                            {
                                break;
                            }
                        }

                        Console.WriteLine(string.Join(", ", stolen));
                        break;
                }
                input = Console.ReadLine();
            }

            if (list.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
                return;
            }

            double allItemsLength = 0.0;

            for (int i = 0; i < list.Count; i++)
            {
                string current = list[i];
                allItemsLength += current.Length;
            }

            Console.WriteLine($"Average treasure gain: {allItemsLength / list.Count:f2} pirate credits.");
        }
    }
}
