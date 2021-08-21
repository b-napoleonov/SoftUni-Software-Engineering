using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            string presentation = Console.ReadLine();
            double totalMarkSum = 0;
            int presCounter = 0;

            while (presentation != "Finish")
            {
                double markSum = 0;
                for (int i = 0; i < n; i++)
                {
                    presCounter++;
                    double mark = double.Parse(Console.ReadLine());
                    markSum += mark;
                }
                totalMarkSum += markSum;
                Console.WriteLine($"{presentation} - {markSum / n:F2}.");

                presentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {totalMarkSum / presCounter:F2}.");
        }
    }
}
