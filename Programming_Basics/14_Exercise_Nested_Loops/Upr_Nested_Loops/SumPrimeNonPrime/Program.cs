using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int primeSum = 0;
            int nonPrimeSum = 0;

            while (input != "stop")
            {
                int currentNum = int.Parse(input);
                bool prime = true;

                if (currentNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }

                for (int i = 2; i < currentNum; i++)
                {
                    if (currentNum % i == 0)
                    {
                        nonPrimeSum += currentNum;
                        prime = false;
                        break;
                    }
                }
                if (prime)
                {
                    primeSum += currentNum;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
