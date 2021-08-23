using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._BasicQueueOperations
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

            Queue<int> numbers = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            for (int i = 0; i < popElements; i++)
            {
                numbers.Dequeue();
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
