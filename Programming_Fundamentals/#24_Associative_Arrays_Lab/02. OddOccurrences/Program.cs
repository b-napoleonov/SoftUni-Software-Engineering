using System;
using System.Collections.Generic;

namespace _02._OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var word in arr)
            {
                if (!counts.ContainsKey(word))
                {
                    counts.Add(word, 0);
                }

                counts[word]++;
            }

            foreach (var word in counts)
            {
                if (word.Value % 2 == 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}
