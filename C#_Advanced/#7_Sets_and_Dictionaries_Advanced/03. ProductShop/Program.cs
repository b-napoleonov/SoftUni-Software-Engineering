using System;
using System.Collections.Generic;

namespace _03._ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> foodShops = new SortedDictionary<string, Dictionary<string, double>>();
            string line;

            while ((line = Console.ReadLine()) != "Revision")
            {
                string[] tokens = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (foodShops.ContainsKey(shop) == false)
                {
                    foodShops.Add(shop, new Dictionary<string, double>());
                }

                foodShops[shop].Add(product, price);
            }

            foreach (var (key, value) in foodShops)
            {
                Console.WriteLine($"{key}->");

                foreach (var item in value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
