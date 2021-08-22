using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                 .Split('@', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int jump = 0;

            while (input[0] != "Love!")
            {
                int jumpLength = int.Parse(input[1]);
                jump += jumpLength;


                if (jump < list.Count)
                {
                    if (list[jump] == 0)
                    {
                        Console.WriteLine($"Place {jump} already had Valentine's day.");

                        input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    list[jump] -= 2;

                    if (list[jump] == 0)
                    {
                        Console.WriteLine($"Place {jump} has Valentine's day.");
                    }
                }
                else
                {
                    jump = 0;

                    if (list[0] == 0)
                    {
                        Console.WriteLine($"Place {0} already had Valentine's day.");

                        input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    list[0] -= 2;

                    if (list[0] == 0)
                    {
                        Console.WriteLine($"Place 0 has Valentine's day.");
                    }
                }

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Cupid's last position was {jump}.");

            if (list.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                list.RemoveAll(x => x == 0);
                Console.WriteLine($"Cupid has failed {list.Count} places.");
            }
        }
    }
}
