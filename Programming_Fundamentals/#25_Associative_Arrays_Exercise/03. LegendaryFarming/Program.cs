using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendary = new Dictionary<string, int> 
            {
                {"shards", 0 },
                {"fragments", 0 },
                {"motes", 0 },
            };
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            bool isTrue = false;
            bool isFound = false;

            while (!isFound)
            {
                List<string> list = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                for (int i = 0; i < list.Count; i += 2)
                {
                    int quantity = int.Parse(list[i]);
                    string material = list[i + 1].ToLower();

                    switch (material)
                    {
                        case "shards":

                            legendary["shards"] += quantity;

                            if (legendary["shards"] >= 250)
                            {
                                Console.WriteLine($"Shadowmourne obtained!");
                                legendary["shards"] -= 250;
                                isTrue = true;
                                isFound = true;
                            }
                            break;

                        case "fragments":

                            legendary["fragments"] += quantity;

                            if (legendary["fragments"] >= 250)
                            {
                                Console.WriteLine($"Valanyr obtained!");
                                legendary["fragments"] -= 250;
                                isTrue = true;
                                isFound = true;
                            }
                            break;

                        case "motes":

                            legendary["motes"] += quantity;

                            if (legendary["motes"] >= 250)
                            {
                                Console.WriteLine($"Dragonwrath obtained!");
                                legendary["motes"] -= 250;
                                isTrue = true;
                                isFound = true;
                            }
                            break;

                        default:
                            if (!junk.ContainsKey(material))
                            {
                                junk.Add(material, 0);
                            }

                            junk[material] += quantity;
                            break;
                    }

                    if (isTrue)
                    {
                        break;
                    }
                }
            }

            foreach (var (key, value) in legendary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{key}: {value}");
            }

            foreach (var (key, value) in junk)
            {
                Console.WriteLine($"{key}: {value}");
            }
        }
    }
}
