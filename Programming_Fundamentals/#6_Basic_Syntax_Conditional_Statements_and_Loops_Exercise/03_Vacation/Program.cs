using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            decimal priceForOne = 0;
            decimal totalPrice = 0;

            switch (typeOfGroup)
            {
                case "Students":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOne = 8.45M;
                            break;
                        case "Saturday":
                            priceForOne = 9.80M;
                            break;
                        case "Sunday":
                            priceForOne = 10.46M;
                            break;
                    }
                    break;
                case "Business":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOne = 10.90M;
                            break;
                        case "Saturday":
                            priceForOne = 15.60M;
                            break;
                        case "Sunday":
                            priceForOne = 16M;
                            break;
                    }
                    break;
                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            priceForOne = 15M;
                            break;
                        case "Saturday":
                            priceForOne = 20M;
                            break;
                        case "Sunday":
                            priceForOne = 22.50M;
                            break;
                    }
                    break;
            }
            totalPrice = priceForOne * numberOfPeople;
            if (typeOfGroup == "Students" && numberOfPeople >= 30)
            {
                totalPrice *= 0.85M;
            }
            else if (typeOfGroup == "Business" && numberOfPeople >= 100)
            {
                totalPrice = (numberOfPeople - 10) * priceForOne;
            }
            else if (typeOfGroup == "Regular" && (numberOfPeople >= 10 && numberOfPeople <= 20))
            {
                totalPrice *= 0.95M;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
