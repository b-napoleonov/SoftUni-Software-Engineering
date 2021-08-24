using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._CupsandBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    wastedWater += bottles.Pop() - cups.Dequeue();
                }
                else
                {
                    int currenttCup = cups.Peek();

                    while (currenttCup > 0)
                    {
                        if (currenttCup - bottles.Peek() > 0)
                        {
                            currenttCup -= bottles.Pop();
                        }
                        else
                        {
                            wastedWater += bottles.Pop() - currenttCup;
                            cups.Dequeue();
                            currenttCup = 0;
                        }
                    }
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
