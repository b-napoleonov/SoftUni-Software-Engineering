using System;

namespace Sequence2kPlus1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int nextN = 1;

            while (nextN <= n)
            {
                Console.WriteLine(nextN);
                nextN = (nextN * 2) + 1;
            }
        }
    }
}
