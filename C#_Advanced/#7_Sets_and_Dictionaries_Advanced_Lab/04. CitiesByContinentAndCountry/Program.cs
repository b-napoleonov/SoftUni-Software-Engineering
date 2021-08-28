using System;
using System.Collections.Generic;

namespace _04._CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (dict.ContainsKey(continent) == false)
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                }
                if (dict[continent].ContainsKey(country) == false)
                {
                    dict[continent].Add(country, new List<string>());
                }

                dict[continent][country].Add(city);
            }

            foreach (var (key, value) in dict)
            {
                Console.WriteLine($"{key}:");

                foreach (var item in value)
                {
                    Console.WriteLine($"  {item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}
