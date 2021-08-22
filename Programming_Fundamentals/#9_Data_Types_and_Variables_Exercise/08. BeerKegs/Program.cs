using System;

namespace _08._BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string biggest = "";
            double biggesVolume = 0;

            for (int i = 1; i <= n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double volume = Math.PI * radius * radius * height;

                if (volume > biggesVolume)
                {
                    biggest = model;
                    biggesVolume = volume;
                }
            }
            Console.WriteLine(biggest);
        }
    }
}
