using System;

namespace _05._MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            string result = FindSign(num1, num2, num3);

            Console.WriteLine(result);
        }

        private static string FindSign(int num1, int num2, int num3)
        {

            int m = num1 * num2 * num3;

            if (m == 0)
            {
                return "zero";
            }
            else if (m > 0)
            {
                return "positive";
            }
            else
            {
                return "negative";
            }
        }
    }
}
