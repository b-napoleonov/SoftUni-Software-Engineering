using System;

namespace _07_Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string type_Of_Day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
                return;
            }

            double price = 0;

            switch (type_Of_Day)
            {
                case "Weekday":
                    if (age >= 0 && age <= 18)
                    {
                        price = 12;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 18;
                    }
                    else
                    {
                        price = 12;
                    }
                    break;
                case "Weekend":
                    if (age >= 0 && age <= 18)
                    {
                        price = 15;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 20;
                    }
                    else
                    {
                        price = 15;
                    }
                    break;
                case "Holiday":
                    if (age >= 0 && age <= 18)
                    {
                        price = 5;
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 12;
                    }
                    else
                    {
                        price = 10;
                    }
                    break;
            }
            Console.WriteLine($"{price}$");
        }
    }
}
