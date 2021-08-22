using System;

namespace _07._RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeats = int.Parse(Console.ReadLine());

            Console.WriteLine(StringRepeater(input, repeats));
        }

        static string StringRepeater(string input, int repeats)
        {
            string result = "";

            for (int i = 0; i < repeats; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
