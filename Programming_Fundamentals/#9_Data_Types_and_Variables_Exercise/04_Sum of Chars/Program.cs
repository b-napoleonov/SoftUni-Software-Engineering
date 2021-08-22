using System;

namespace _04_Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= lines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                sum += (int)letter;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
