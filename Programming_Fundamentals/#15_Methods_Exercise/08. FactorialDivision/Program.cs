using System;

namespace _08._FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            decimal result1 = Factorial(first);
            decimal result2 = Factorial(second);

            decimal division = result1 / result2;
            Console.WriteLine($"{division:F2}");
        }

        static decimal Factorial(int first)
        {
            decimal result = 1;

            for (int i = 1; i <= first; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
