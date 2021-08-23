using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int pushElements = arr[0];
            int popElements = arr[1];
            int element = arr[2];

            Stack<int> numbers = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            for (int i = 0; i < popElements; i++)
            {
                numbers.Pop();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(numbers.Count);
                return;
            }
            else if (numbers.Contains(element))
            {
                Console.WriteLine("true");
                return;
            }

            Console.WriteLine(numbers.Min());
        }
    }
}
