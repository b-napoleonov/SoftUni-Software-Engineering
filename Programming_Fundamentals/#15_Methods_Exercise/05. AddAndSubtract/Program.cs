using System;

namespace _05._AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third= int.Parse(Console.ReadLine());

            int result = Sum(first, second) - third;

            Console.WriteLine(result);
        }

        static int Sum(int first, int second)
        {
            int sum = first + second;

            return sum;
        }
    }
}
