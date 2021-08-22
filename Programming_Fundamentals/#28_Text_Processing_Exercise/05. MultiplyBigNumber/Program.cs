using System;
using System.Numerics;

namespace _05._MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger first = BigInteger.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            Console.WriteLine(first * second);
        }
    }
}
