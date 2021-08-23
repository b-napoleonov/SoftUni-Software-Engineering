using System;
using System.Collections.Generic;

namespace _8._TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        string car = string.Empty;

                        if (cars.TryDequeue(out car))
                        {
                            Console.WriteLine($"{car} passed!");
                            counter++;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
