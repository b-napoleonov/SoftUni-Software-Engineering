using System;
using System.Collections.Generic;

namespace _03._WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, new List<string>());
                }

                dict[word].Add(synonym);
            }

            foreach (var word in dict)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
