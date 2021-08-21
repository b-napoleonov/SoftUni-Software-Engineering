using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double minBudget = double.Parse(Console.ReadLine());
            double collectedMoney = 0;

            while (destination != "End")
            {
                string input = Console.ReadLine();
                while (input != "End")
                {
                    collectedMoney += double.Parse(input);
                    if (collectedMoney >= minBudget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                    input = Console.ReadLine();
                }
                destination = Console.ReadLine();
                minBudget = double.Parse(Console.ReadLine());
                collectedMoney = 0;
            }
        }
    }
}
