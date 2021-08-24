using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Console.WriteLine(orders.Max());

            while (foodQuantity > 0)
            {
                if (foodQuantity - orders.Peek() >= 0)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    break;
                }

                if (orders.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    return;
                }
            }

            Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
        }
    }
}
