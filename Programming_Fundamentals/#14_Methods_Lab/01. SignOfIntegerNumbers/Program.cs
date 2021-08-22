using System;

namespace _01._SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(SignFinder(number));
        }

        static string SignFinder(int num)
        {
            string text = "";
            if (num > 0)
            {
                text = $"The number {num} is positive.";
            }
            else if (num < 0)
            {
                text = $"The number {num} is negative.";
            }
            else
            {
                text = $"The number {num} is zero.";
            }

            return text;
        }
    }
}
