using System;

namespace _02_Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal num = decimal.Parse(Console.ReadLine());
            decimal result = 1.31m;
            Console.WriteLine($"{num * result:f3}");

        }
    }
}
