using System;

namespace _05_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int sum = 0;
                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }
                switch (sum)
                {
                    case 5:
                    case 7:
                    case 11:
                        Console.WriteLine($"{i} -> True");
                        break;
                    default:
                        Console.WriteLine($"{i} -> False");
                        break;
                }
            }
        }
    }
}
