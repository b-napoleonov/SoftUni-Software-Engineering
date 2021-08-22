using System;

namespace _01_Sort_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            if (num1 > num2 && num1 > num3)
            {
                Console.WriteLine(num1);
                if (num2 >= num3)
                {
                    Console.WriteLine(num2);
                    Console.WriteLine(num3);
                }
                else if (num3 >= num2)
                {
                    Console.WriteLine(num3);
                    Console.WriteLine(num2);
                }
            }
            else if (num2 > num1 && num2 > num3)
            {
                Console.WriteLine(num2);
                if (num1 >= num3)
                {
                    Console.WriteLine(num1);
                    Console.WriteLine(num3);
                }
                else if (num3 >= num1)
                {
                    Console.WriteLine(num3);
                    Console.WriteLine(num1);
                }
            }
            else if (num3 > num1 && num3 > num2)
            {
                Console.WriteLine(num3);
                if (num1 >= num2)
                {
                    Console.WriteLine(num1);
                    Console.WriteLine(num2);
                }
                else if (num2 >= num1)
                {
                    Console.WriteLine(num2);
                    Console.WriteLine(num1);
                }
            }
        }
    }
}
