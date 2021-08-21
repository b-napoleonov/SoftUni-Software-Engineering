using System;

namespace newHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            const double rosesPrice = 5.0;
            const double dahliaPrice = 3.80;
            const double tulipsPrice = 2.80;
            const double narcissusPrice = 3;
            const double gladiolusPrice = 2.50;

            string flowerType= Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0;
            double discount = 1;

            if (flowerType == "Roses")
            {
                price = rosesPrice;
                if (count > 80)
                {
                    discount = 0.9;
                }
            }
            else if (flowerType == "Dahlias")
            {
                price = dahliaPrice;
                if (count > 90)
                {
                    discount = 0.85;
                }
            }
            else if (flowerType == "Tulips")
            {
                price = tulipsPrice;
                if (count > 80)
                {
                    discount = 0.85;
                }
            }
            else if ( flowerType == "Narcissus")
            {
                price = narcissusPrice;
                if (count < 120)
                {
                    discount = 1.15;
                }
            }
            else if (flowerType == "Gladiolus")
            {
                price = gladiolusPrice;
                if (count < 80)
                {
                    discount = 1.20;
                }
            }

            double totalPrice = (count * price) * discount;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {count} {flowerType} and {budget - totalPrice:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(budget - totalPrice):F2} leva more.");
            }
        }
    }
}
