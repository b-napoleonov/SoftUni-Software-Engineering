using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothesByColor = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = clothesByColor[0];
                string[] clothes = clothesByColor[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    if (wardrobe[color].ContainsKey(cloth) == false)
                    {
                        wardrobe[color].Add(cloth, 0);
                    }

                    wardrobe[color][cloth]++;
                }

            }

            string[] search = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string searchColor = search[0];
            string searchCloth = search[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var (key, value) in item.Value)
                {
                    if (item.Key == searchColor && key == searchCloth)
                    {
                        Console.WriteLine($"* {key} - {value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {key} - {value}");
                }
            }
        }
    }
}
