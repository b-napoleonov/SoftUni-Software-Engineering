using System;

namespace _07._WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 0;

            for (int i = 1; i <= n; i++)
            {
                int pour = int.Parse(Console.ReadLine());

                if (capacity + pour > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                capacity += pour;
            }
            Console.WriteLine(capacity);
        }
    }
}
