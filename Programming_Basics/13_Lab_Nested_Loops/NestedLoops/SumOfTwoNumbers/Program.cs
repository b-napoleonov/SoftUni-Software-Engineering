using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = start; i <= finish; i++)
            {
                for (int j = start; j <= finish; j++)
                {
                    counter++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNumber})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
        }
    }
}
