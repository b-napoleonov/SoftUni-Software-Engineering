using System;

namespace _08._LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            foreach (string item in arr)
            {
                char firstLetter = item[0];
                double number = double.Parse(item[1..^1]);
                char lastLetter = item[^1];

                if (char.IsUpper(firstLetter))
                {
                    sum += number / (firstLetter - 64);
                }
                else
                {
                    sum += number * (firstLetter - 96);
                }
                if (char.IsUpper(lastLetter))
                {
                    sum -= lastLetter - 64;
                }
                else
                {
                    sum += lastLetter - 96;
                }
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
