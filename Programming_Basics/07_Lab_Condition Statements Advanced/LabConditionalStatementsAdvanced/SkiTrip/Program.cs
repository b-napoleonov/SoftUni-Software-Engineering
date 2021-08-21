using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string feedback = Console.ReadLine();

            double price = 0;
            double discount = 0;

            switch (roomType)
            {
                case "room for one person":
                    price = 18;
                    break;
                case "apartment":
                    price = 25;
                    if (days < 10)
                    {
                        discount = 0.3;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.35;
                    }
                    else
                    {
                        discount = 0.5;
                    }
                    break;
                case "president apartment":
                    price = 35;
                    if (days < 10)
                    {
                        discount = 0.1;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 0.15;
                    }
                    else
                    {
                        discount = 0.2;
                    }
                    break;
            }
            double totalPrice = price * (days - 1);
            totalPrice -= discount * totalPrice;
            if (feedback == "positive")
            {
                totalPrice *= 1.25;
            }
            else
            {
                totalPrice *= 0.9;
            }
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
