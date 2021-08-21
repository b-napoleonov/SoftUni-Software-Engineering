using System;

namespace fishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            double price = 0;

            if (season == "Spring")
            {
                price = 3000;
                if (number <= 6)
                {
                    price *= 0.9;
                }
                else if (number <= 11)
                {
                    price *= 0.85;
                }
                else if (number >= 12)
                {
                    price *= 0.75;
                }
                if (number % 2 == 0)
                {
                    price *= 0.95;
                }
            }
            else if (season == "Summer")
            {
                price = 4200;
                if (number <= 6)
                {
                    price *= 0.9;
                }
                else if (number <= 11)
                {
                    price *= 0.85;
                }
                else if (number >= 12)
                {
                    price *= 0.75;
                }
                if (number % 2 == 0)
                {
                    price *= 0.95;
                }
            }
            else if (season == "Autumn")
            {
                price = 4200;
                if (number <= 6)
                {
                    price *= 0.9;
                }
                else if (number <= 11)
                {
                    price *= 0.85;
                }
                else if (number >= 12)
                {
                    price *= 0.75;
                }
            }
            else if (season == "Winter")
            {
                price = 2600;
                if (number <= 6)
                {
                    price *= 0.9;
                }
                else if (number <= 11)
                {
                    price *= 0.85;
                }
                else if (number >= 12)
                {
                    price *= 0.75;
                }
                if (number % 2 == 0)
                {
                    price *= 0.95;
                }
            }
            if (price <= budget)
            {
                Console.WriteLine($"Yes! You have {Math.Abs(price - budget):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(price - budget):F2} leva.");
            }
            
        }
    }
}
