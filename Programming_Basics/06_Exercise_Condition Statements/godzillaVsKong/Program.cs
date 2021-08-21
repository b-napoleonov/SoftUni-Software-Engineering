using System;

namespace godzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfExtras = int.Parse(Console.ReadLine());
            double priceOfClothing = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;
            double clothing = numberOfExtras * priceOfClothing;

            if (numberOfExtras >= 150)
            {
                clothing *= 0.9;
            }
            if (decor + clothing > budget)
            {
                Console.WriteLine("Not enough money!");
                double moneyNeeded = (decor + clothing) - budget;
                Console.WriteLine($"Wingard needs {moneyNeeded:F2} leva more.");
            }
            else if (decor + clothing <= budget)
            {
                Console.WriteLine("Action!");
                double moneyLeft = budget - (decor + clothing);
                Console.WriteLine($"Wingard starts filming with {moneyLeft:F2} leva left.");
            }
        }
    }
}
