using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string[] allWordAndDefinition = Console.ReadLine().Split(" | ");


            foreach (var wordDefinition in allWordAndDefinition)
            {
                string word = string.Empty;
                string definition = string.Empty;

                word = wordDefinition.Split(": ")[0];
                definition = wordDefinition.Split(": ")[1];

                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, new List<string>());
                }

                dict[word].Add(definition);
            }

            string[] testWords = Console.ReadLine().Split(" | ");

            string command = Console.ReadLine();

            if (command == "Test")
            {
                foreach (var word in testWords)
                {
                    if (dict.ContainsKey(word))
                    {
                        Console.WriteLine($"{word}:");

                        Console.WriteLine($"-{string.Join(Environment.NewLine + "-", dict[word].OrderByDescending(x => x.Length))}");
                    }
                }
            }
            else
            {
                foreach (var item in dict.OrderBy(x => x.Key))
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
