using System;

namespace UniquePINCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimit1 = int.Parse(Console.ReadLine());
            int upperLimit2 = int.Parse(Console.ReadLine());
            int upperLimit3 = int.Parse(Console.ReadLine());

            for (int i = 2; i <= upperLimit1; i += 2)
            {
                for (int j = 2; j <= upperLimit2; j++)
                {
                    for (int k = 2; k <= upperLimit3; k += 2)
                    {
                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
