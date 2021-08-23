using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input != "Paid")
                {
                    names.Enqueue(input);
                }
                else
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
