using System;
using System.Linq;

namespace _03._Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int[] arr2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] bufferArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    arr[i] = bufferArr[0];
                    arr2[i] = bufferArr[1];
                }
                else
                {
                    arr2[i] = bufferArr[0];
                    arr[i] = bufferArr[1];
                }
            }
            Console.WriteLine(string.Join(' ', arr));
            Console.WriteLine(string.Join(' ', arr2));
        }
    }
}

