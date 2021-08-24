using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> circle = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                circle.Enqueue(Console.ReadLine());
            }

            int index = 0;

            for (int i = 0; i < n; i++)
            {
                long petrol = 0;
                bool isEnough = true;

                for (int j = 0; j < n; j++)
                {
                    string currentPump = circle.Dequeue();
                    long[] pumpValue = currentPump
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToArray();

                    long currentPetrol = pumpValue[0];
                    long distance = pumpValue[1];
                    petrol += currentPetrol;

                    if (petrol >= distance)
                    {
                        petrol -= distance;
                    }
                    else
                    {
                        isEnough = false;
                    }

                    circle.Enqueue(currentPump);
                }

                if (isEnough)
                {
                    index = i;
                    break;
                }

                circle.Enqueue(circle.Dequeue());
            }

            Console.WriteLine(index);
        }
    }
}
