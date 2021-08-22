using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._MirrorW
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([@#])(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";

            MatchCollection words = Regex.Matches(text, pattern);

            if (words.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                return;
            }
            else
            {
                Console.WriteLine($"{words.Count} word pairs found!");
            }

            List<string> list = new List<string>();

            foreach (Match word in words)
            {
                string firstWord = word.Groups["word1"].Value;
                string secondWord = word.Groups["word2"].Value;

                StringBuilder sb = new StringBuilder();

                for (int i = secondWord.Length - 1; i >= 0; i--)
                {
                    sb.Append(secondWord[i]);
                }

                if (firstWord == sb.ToString())
                {
                    list.Add(firstWord);
                    list.Add(secondWord);
                }
            }

            if (list.Count == 0)
            {
                Console.WriteLine("No mirror words!");
                return;
            }

            Console.WriteLine("The mirror words are:");

            for (int i = 0; i < list.Count; i += 2)
            {
                if (i < list.Count - 2)
                {
                    Console.Write($"{list[i]} <=> {list[i + 1]}, ");
                }
                else
                {
                    Console.Write($"{list[i]} <=> {list[i + 1]}");
                }
            }
        }
    }
}
