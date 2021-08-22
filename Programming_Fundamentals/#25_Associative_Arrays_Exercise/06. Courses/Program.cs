using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] arr = input.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string courseName = arr[0].Trim();
                string name = arr[1].Trim();

                if (!dict.ContainsKey(courseName))
                {
                    dict.Add(courseName, new List<string>());
                }

                dict[courseName].Add(name);

                input = Console.ReadLine();
            }

            foreach (var(key, value) in dict.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{key}: {value.Count}");
                Console.WriteLine($"-- {string.Join(Environment.NewLine + "-- ", value.OrderBy(x => x))}");
            }
        }
    }
}
