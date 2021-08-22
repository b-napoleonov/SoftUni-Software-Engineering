using System;
using System.Collections.Generic;

namespace _08._CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> dict = new SortedDictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] arr = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string company = arr[0].Trim();
                string id = arr[1].Trim();

                if (!dict.ContainsKey(company))
                {
                    dict.Add(company, new List<string>());
                }

                if (!dict[company].Contains(id))
                {
                    dict[company].Add(id);
                }

                input = Console.ReadLine();
            }

            foreach (var (key, value) in dict)
            {
                Console.WriteLine($"{key}");
                Console.WriteLine($"-- {string.Join(Environment.NewLine + "-- ", value)}");
            }
        }
    }
}
