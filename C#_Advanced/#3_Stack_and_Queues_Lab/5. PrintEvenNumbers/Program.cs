using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> que = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            List<int> numbers = new List<int>(que.Count);

            foreach (var item in que)
            {
                if (item % 2 == 0)
                {
                    numbers.Add(item);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
