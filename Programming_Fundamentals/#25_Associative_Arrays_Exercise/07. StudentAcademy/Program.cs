using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                }

                dict[name].Add(grade);
            }

            foreach (var (key, value) in dict
                .Where(y => y.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value.Average()))
            {
                Console.WriteLine($"{key} -> {value:f2}");
            }
        }
    }
}
