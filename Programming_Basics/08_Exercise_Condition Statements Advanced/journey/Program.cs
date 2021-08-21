using System;

namespace journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0;
            string destination = "";
            string vacancy = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    price = budget * 0.3;
                    vacancy = "Camp";
                }
                else if (season == "winter")
                {
                    price = budget * 0.7;
                    vacancy = "Hotel";
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    price = budget * 0.4;
                    vacancy = "Camp";
                }
                else if (season == "winter")
                {
                    price = budget * 0.8;
                    vacancy = "Hotel";
                }
            }
            else
            {
                destination = "Europe";
                price = budget * 0.9;
                vacancy = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{vacancy} - {price:F2}");
        }
    }
}
