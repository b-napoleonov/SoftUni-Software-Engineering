using System;

namespace _07_Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double coins = 0;
            double price = 0;

            while (input != "Start")
            {
                switch (input)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2":
                        coins += double.Parse(input);
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {input}");
                        break;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            double sum = 0;
            while (input != "End")
            {
                switch (input)
                {
                    case "Nuts":
                        price = 2.0;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                sum += price;
                if (coins < sum)
                {
                    Console.WriteLine("Sorry, not enough money");
                    sum -= price;
                }
                else if (sum != 0)
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {coins - sum:f2}");
        }
    }
}
