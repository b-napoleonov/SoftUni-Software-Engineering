using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;

            while (clothes.Count > 0)
            {
                if (sum + clothes.Peek() < capacity)
                {
                    if (sum == 0)
                    {
                        counter++;
                    }

                    sum += clothes.Pop();
                }
                else if (sum + clothes.Peek() == capacity)
                {
                    sum = 0;
                    clothes.Pop();
                }
                else
                {
                    counter++;
                    sum = clothes.Pop();
                }
            }

            Console.WriteLine(counter);
        }
    }
}
