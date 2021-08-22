using System;

namespace _03_Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            double price = 0;
            double buffer = money;

            while (input != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        input = Console.ReadLine();
                        continue;
                }
                if (buffer >= price)
                {
                    buffer -= price;
                    Console.WriteLine($"Bought {input}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                    input = Console.ReadLine();
                    continue;
                }
                if (buffer == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${money - buffer:f2}. Remaining: ${buffer:f2}");
        }
    }
}
