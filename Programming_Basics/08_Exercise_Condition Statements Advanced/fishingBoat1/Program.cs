    using System;

    namespace fishingBoat1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int budget = int.Parse(Console.ReadLine());
                string season = Console.ReadLine();
                int fishermen = int.Parse(Console.ReadLine());

                double price = 0.0;

                switch (season)
                {
                    case "Spring":
                        price = 3000;
                        break;

                    case "Summer":
                        price = 4200;
                        break;

                    case "Autumn":
                        price = 4200;
                        break;

                    case "Winter":
                        price = 2600;
                        break;
                }

                if (fishermen <= 6)
                {
                    price -= price * 0.1;
                }
                else if (fishermen <= 11)
                {
                    price -= price * 0.15;
                }
                else
                {
                    price -= price * 0.25;
                }

                if (season != "Autumn" && fishermen % 2 == 0)
                {
                    price -= price * 0.05;
                }


                double money = Math.Abs(price - budget);

                if (price > budget)
                {
                    Console.WriteLine("Not enough money! You need {0:f2} leva.", money);
                }
                else if (budget >= price)
                {
                    Console.WriteLine("Yes! You have {0:f2} leva left.", money);
                }
            }
        }
    }
