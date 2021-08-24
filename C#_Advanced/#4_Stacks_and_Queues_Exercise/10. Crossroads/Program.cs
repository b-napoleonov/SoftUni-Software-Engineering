using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int counter = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                int gD = greenDuration;
                int fW = freeWindowDuration;

                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    while (cars.Count > 0)
                    {
                        if (cars.Peek().Length <= gD)
                        {
                            gD -= cars.Peek().Length;
                            cars.Dequeue();
                            counter++;
                        }
                        else if (cars.Peek().Length <= gD + fW)
                        {
                            fW -= cars.Peek().Length - gD;
                            gD= 0;
                            cars.Dequeue();
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{cars.Peek()} was hit at {cars.Peek()[gD + fW]}.");
                            return;
                        }

                        if (gD <= 0)
                        {
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
