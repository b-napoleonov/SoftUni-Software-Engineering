using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MaximumandMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int query = numbers[0];

                switch (query)
                {
                    case 1:

                        int toPush = numbers[1];
                        stack.Push(toPush);

                        break;

                    case 2:

                        int buffer = 0;

                        stack.TryPop(out buffer);

                        break;

                    case 3:

                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        else
                        {
                            continue;
                        }

                        break;

                    case 4:

                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        else
                        {
                            continue;
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
