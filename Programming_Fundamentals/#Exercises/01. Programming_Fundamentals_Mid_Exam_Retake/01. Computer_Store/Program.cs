using System;

namespace _01._CompSto
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalPrice = 0.0;
            double taxes = 0.0;

            while (input != "special" && input != "regular")
            {
                double partPrice = double.Parse(input);

                if (partPrice >= 0)
                {
                    totalPrice += partPrice;
                    taxes += partPrice * 0.2;
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }

                input = Console.ReadLine();
            }

            double totalWithTaxes = totalPrice + taxes;

            if (input == "special")
            {
                totalWithTaxes -= totalWithTaxes * 0.1;
            }

            if (totalPrice > 0)
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:F2}$");
                Console.WriteLine($"Taxes: {taxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalWithTaxes:F2}$");
            }
            else
            {
                Console.WriteLine("Invalid order!");
            }
        }
    }
}
