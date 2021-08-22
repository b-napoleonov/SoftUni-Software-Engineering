using System;
using System.Linq;

namespace _02._PrintNumbersinReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.Write(string.Join(' ', numbers.Reverse()));
        }
    }
}
