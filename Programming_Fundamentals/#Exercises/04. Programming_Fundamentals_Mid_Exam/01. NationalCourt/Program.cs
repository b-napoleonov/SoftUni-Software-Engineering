using System;

namespace _01._NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEfficiency = int.Parse(Console.ReadLine());
            int secondEfficiency = int.Parse(Console.ReadLine());
            int thirdEfficiency = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int totalEfficiency = firstEfficiency + secondEfficiency + thirdEfficiency;
            int counter = 0;

            while (peopleCount > 0)
            {
                counter++;

                if (counter % 4 == 0)
                {
                    continue;
                }

                peopleCount -= totalEfficiency;
            }

            Console.WriteLine($"Time needed: {counter}h.");
        }
    }
}
