using System;
using System.Collections.Generic;

namespace _05._CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> words = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char key = text[i];

                if (words.ContainsKey(key) == false)
                {
                    words.Add(key, 0);
                }

                words[key]++;
            }

            foreach (var (key, value) in words)
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
        }
    }
}
