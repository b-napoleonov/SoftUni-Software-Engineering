using System;
using System.Linq;

namespace _06._EvenandOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int oddSum = 0;
            int evenSum = 0;

            foreach (int item in arr)
            {
                if (item % 2 == 0)
                {
                    evenSum += item;
                }
                else if (item % 2 == 1)
                {
                    oddSum += item;
                }
            }
            Console.WriteLine(evenSum - oddSum);
        }
    }
}
