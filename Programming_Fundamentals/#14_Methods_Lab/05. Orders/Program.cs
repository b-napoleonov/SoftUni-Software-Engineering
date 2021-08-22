using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine(OrderTotalPrice(product, quantity));
        }

        static string OrderTotalPrice(string product, int quantity)
        {
            double price = 0;

            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    break;
                case "water":
                    price = 1;
                    break;
                case "coke":
                    price = 1.40;
                    break;
                case "snacks":
                    price = 2;
                    break;
            }
            return $"{quantity * price:F2}";
        }
    }
}
