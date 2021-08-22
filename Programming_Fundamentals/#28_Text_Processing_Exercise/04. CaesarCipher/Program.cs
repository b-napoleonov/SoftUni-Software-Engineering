using System;
using System.Text;

namespace _04._CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder encrypted = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                encrypted.Append((char)(input[i] + 3));
            }

            Console.WriteLine(encrypted);
        }
    }
}
