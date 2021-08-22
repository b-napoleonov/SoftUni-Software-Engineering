using System;
using System.Linq;

namespace _07._MaxSequenceofEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int counter = 1;
            int bestStart = 0;
            int bestLength = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    counter++;
                    if (counter > bestLength)
                    {
                        bestLength = counter;
                        bestStart = arr[i];

                    }
                }
                else
                {
                    counter = 1;
                }
            }
            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(bestStart + " ");
            }
        }
    }
}
