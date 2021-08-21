using System;

namespace operationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            var symbol = Console.ReadLine();

            double result = 0;
            string evenOdd = "";

            if (symbol == "+")
            {
                result = n1 + n2;
                if (result % 2 == 0)
                {
                    evenOdd = "even";
                }
                else
                {
                    evenOdd = "odd";
                }
                Console.WriteLine($"{n1} + {n2} = {result} - {evenOdd}");
            }
            else if (symbol == "-")
            {
                result = n1 - n2;
                if (result % 2 == 0)
                {
                    evenOdd = "even";
                }
                else
                {
                    evenOdd = "odd";
                }
                Console.WriteLine($"{n1} - {n2} = {result} - {evenOdd}");
            }
            else if (symbol == "*")
            {
                result = n1 * n2;
                if (result % 2 == 0)
                {
                    evenOdd = "even";
                }
                else
                {
                    evenOdd = "odd";
                }
                Console.WriteLine($"{n1} * {n2} = {result} - {evenOdd}");
            }
            else if (symbol == "/")
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    result = n1 / n2;
                    Console.WriteLine($"{n1} / {n2} = {result:F2}");
                }   
            }
            else if (symbol == "%")
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    result = n1 % n2;
                    Console.WriteLine($"{n1} % {n2} = {result}");
                }
            }
        }
    }
}
