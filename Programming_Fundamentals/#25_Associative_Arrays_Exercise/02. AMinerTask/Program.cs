using System;
using System.Collections.Generic;

namespace _02._AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            string input = Console.ReadLine();
            

            while (input != "stop")
            {
                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, 0);
                }

                string current = input;
                input = Console.ReadLine();

                dict[current] += int.Parse(input);

                input = Console.ReadLine();
            }

            foreach (var (key, value) in dict)
            {
                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
