using System;

namespace _03_exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}
