using System;

namespace _04._TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            for (int i = 0; i < banWords.Length; i++)
            {
                text = text.Replace(banWords[i], new string('*', banWords[i].Length));
            }

            Console.WriteLine(text);
        }
    }
}
