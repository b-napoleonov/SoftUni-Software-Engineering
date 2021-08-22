using System;
using System.Linq;

namespace _06._EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            if (arr.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                leftSum = arr.Take(i).Sum();

                rightSum = arr.Skip(i + 1).Sum();

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
