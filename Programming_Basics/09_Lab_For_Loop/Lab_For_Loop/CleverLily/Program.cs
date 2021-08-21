using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            int toysCount = 0;
            double birthdayMoney = 0;
            int counter = 1;
            int brother = 0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    birthdayMoney += 10 * counter;
                    counter++;
                    brother++;
                }
                else
                {
                    toysCount++;
                }
            }
            double totalMoneySaved = birthdayMoney - brother + toysCount * toysPrice;
            if (totalMoneySaved >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {totalMoneySaved - washingMachinePrice:F2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - totalMoneySaved:F2}");
            }
        }
    }
}
