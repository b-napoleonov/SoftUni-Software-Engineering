using System;

namespace toyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            const double puzzlesPrice = 2.60;
            const double talkingDollsPrice = 3;
            const double teddyBearsPrice = 4.10;
            const double minionsPrice = 8.20;
            const double trucksPrice = 2;

            double excursionPrice = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int talkingDollsCount = int.Parse(Console.ReadLine());
            int teddyBearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double totalOrderPrice = (puzzlesPrice * puzzlesCount) + (talkingDollsPrice * talkingDollsCount) + (teddyBearsPrice * teddyBearsCount) + (minionsPrice * minionsCount) + (trucksPrice * trucksCount);

            if ((puzzlesCount + talkingDollsCount + teddyBearsCount + minionsCount + trucksCount) >= 50)
            {
                totalOrderPrice -= totalOrderPrice * 0.25; 
            }

            double rent = totalOrderPrice * 0.1;
            double moneyLeft = totalOrderPrice - rent;

            if (excursionPrice <= moneyLeft)
            {
                Console.WriteLine($"Yes! {moneyLeft - excursionPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {excursionPrice - moneyLeft:F2} lv needed.");
            }
        }
    }
}
