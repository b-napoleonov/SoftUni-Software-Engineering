using System;

namespace _06_Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int num = number;
            int sum = 0;

            while (number > 0)
            {
                int currentNumber = number % 10;

                int factorial = 1;

                for (int i = 1; i <= currentNumber; i++)
                {
                    factorial *= i;
                }
                sum += factorial;

                number /= 10;
            }
            if (sum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
