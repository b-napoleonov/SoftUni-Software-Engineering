using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double> > dict = new Dictionary<string, List<double>>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] arr = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string product = arr[0];
                double price = double.Parse(arr[1]);
                int quantity = int.Parse(arr[2]);

                if (!dict.ContainsKey(product))
                {
                    dict.Add(product, new List<double> { 0, 0 });
                }

                dict[product][0] = price;
                dict[product][1] += quantity;

                input = Console.ReadLine();
            }

            foreach (var (key, value) in dict)
            {
                Console.WriteLine($"{key} -> {value[0] * value[1]:f2}");
            }
        }
    }
}
