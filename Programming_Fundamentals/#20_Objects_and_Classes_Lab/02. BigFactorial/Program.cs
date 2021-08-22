using System;
using System.Numerics;

namespace _02._BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger fact = 1;

            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }

            Console.WriteLine(fact);
        }
    }
}
