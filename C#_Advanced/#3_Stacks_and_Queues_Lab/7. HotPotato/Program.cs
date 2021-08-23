using System;
using System.Collections.Generic;

namespace _7._HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> children = new Queue<string>(Console.ReadLine().Split());

            int n = int.Parse(Console.ReadLine());

            while (children.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    children.Enqueue(children.Dequeue());
                }

                Console.WriteLine($"Removed {children.Dequeue()}");
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
