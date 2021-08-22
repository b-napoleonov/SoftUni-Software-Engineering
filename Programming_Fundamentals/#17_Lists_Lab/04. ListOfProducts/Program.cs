using System;
using System.Collections.Generic;

namespace _04._ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>(n);

            for (int i = 0; i < products.Capacity; i++)
            {
                products.Add(Console.ReadLine());
            }
            products.Sort();

            int counter = 1;

            foreach (var item in products)
            {
                Console.WriteLine($"{counter++}.{item}");
            }
        }
    }
}
