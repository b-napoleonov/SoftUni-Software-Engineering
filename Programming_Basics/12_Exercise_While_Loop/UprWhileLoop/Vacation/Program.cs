using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int counter = 0;
            int daysCounter = 0;

            while (true)
            {
                daysCounter++;
                string action = Console.ReadLine();
                double saveSpendMoney = double.Parse(Console.ReadLine());

                switch (action)
                {
                    case "spend":
                        if (saveSpendMoney > availableMoney)
                        {
                            availableMoney = 0;
                        }
                        else
                        {
                            availableMoney -= saveSpendMoney;
                        }
                        counter++;
                        if (counter == 5)
                        {
                            Console.WriteLine("You can't save the money.");
                            Console.WriteLine(daysCounter);
                            return;
                        }
                        break;
                    case "save":
                        availableMoney += saveSpendMoney;
                        counter = 0;
                        if (availableMoney >= moneyNeeded)
                        {
                            Console.WriteLine($"You saved the money for {daysCounter} days.");
                            return;
                        }
                        break;
                }
            }
        }
    }
}
