using System;
using System.Linq;

namespace _08._CondenseArraytoNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j] + arr[j + 1];
                }
            }

            Console.WriteLine(arr[0]);
        }
    }
}
