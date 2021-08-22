using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                string inverted = " ";

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    inverted += input[i];
                }

                Console.WriteLine($"{input} = {inverted.Trim()}");

                input = Console.ReadLine();
            }
        }
    }
}
