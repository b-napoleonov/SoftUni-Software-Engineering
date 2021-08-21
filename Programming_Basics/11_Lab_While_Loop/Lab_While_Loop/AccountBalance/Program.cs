using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalMoney = 0;

            while (input != "NoMoreMoney")
            {
                double money = double.Parse(input);
                if (money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    totalMoney += money;
                    Console.WriteLine($"Increase: {money:F2}");
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine($"Total: {totalMoney:F2}");
        }
    }
}
