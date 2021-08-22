using System;
using System.Linq;

namespace _09._PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PalindromeIntegers(input);
        }

        static void PalindromeIntegers(string input)
        {
            while (input != "END")
            {
                if (input == string.Concat(input.Reverse()))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }
        }
    }
}
