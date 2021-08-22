using System;
using System.Linq;

namespace _07._EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int sum = 0;
            bool areEqual = true;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    areEqual = false;
                    break;
                }
                else
                {
                    sum += arr[i];
                }
            }
            if (areEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
