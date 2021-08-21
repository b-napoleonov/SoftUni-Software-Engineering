using System;

namespace ExcursionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double priceForAPerson = 0;

            if (numberOfPeople <= 5)
            {
                switch (season)
                {
                    case "spring":
                        priceForAPerson = 50;
                        break;
                    case "summer":
                        priceForAPerson = 48.50;
                        break;
                    case "autumn":
                        priceForAPerson = 60;
                        break;
                    case "winter":
                        priceForAPerson = 86;
                        break;
                }
            }
            else
            {
                switch (season)
                {
                    case "spring":
                        priceForAPerson = 48;
                        break;
                    case "summer":
                        priceForAPerson = 45;
                        break;
                    case "autumn":
                        priceForAPerson = 49.50;
                        break;
                    case "winter":
                        priceForAPerson = 85;
                        break;
                }
            }
            double totalPrice = priceForAPerson * numberOfPeople;

            if (season == "summer")
            {
                totalPrice *= 0.85; 
            }
            else if (season == "winter")
            {
                totalPrice *= 1.08;
            }
            Console.WriteLine($"{totalPrice:F2} leva.");
        }
    }
}
