using System;

namespace _03._CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char finish = char.Parse(Console.ReadLine());

            Console.Write(InBetween(start, finish));
        }

        static string InBetween(char first, char second)
        {
            string current = "";

            if ((int)first > (int)second)
            {
                for (int i = (int)second + 1; i < (int)first; i++)
                {
                    current += $"{(char)i} ";
                }
            }
            else
            {
                for (int i = (int)first + 1; i < (int)second; i++)
                {
                    current += $"{(char)i} ";
                }
            }
            return current;
        }
    }
}
