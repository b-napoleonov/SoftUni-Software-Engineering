using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int barellSize = gunBarrelSize;
            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            int intelligenceValue = int.Parse(Console.ReadLine());
            int bulletCounter = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                barellSize--;
                bulletCounter++;
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (barellSize == 0 && bullets.Count > 0)
                {
                    barellSize = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }

            if (bullets.Count == 0 && locks.Count != 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - bulletCounter * bulletPrice}");
            }
        }
    }
}
