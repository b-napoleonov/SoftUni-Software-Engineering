using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int currentNum = i;
                int counter = 0;

                for (int j = 1; j <= 4; j++)
                {
                    int lastDigit = currentNum % 10;
                    currentNum /= 10;

                    if (lastDigit == 0)
                    {
                        continue;
                    }

                    if (n % lastDigit == 0)
                    {
                        counter++;
                    }
                }
                if (counter == 4)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
