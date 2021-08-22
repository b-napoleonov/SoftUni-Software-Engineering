using System;

namespace _01._Problem_One
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int i = 1; i <= countOfOrders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                double orderPrice = (days * capsuleCount) * pricePerCapsule;
                totalPrice += orderPrice;

                Console.WriteLine($"The price for the coffee is: ${orderPrice:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
