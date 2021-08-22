using System;

namespace _04._PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                PrintLine(i);
            }

            for (int i = number - 1; i >= 1; i--)
            {
                PrintLine(i);
            }
        }

        static void PrintLine(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
