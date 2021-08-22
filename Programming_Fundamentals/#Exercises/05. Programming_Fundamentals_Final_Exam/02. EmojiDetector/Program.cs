using System;
using System.Text.RegularExpressions;

namespace _02._EmojiDet
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(\:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            long coolThreshold = 1;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    coolThreshold *= int.Parse(text[i].ToString());
                }
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");

            MatchCollection mathes = Regex.Matches(text, pattern);

            Console.WriteLine($"{mathes.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in mathes)
            {
                int coolness = 0;

                for (int i = 0; i < match.Groups["emoji"].Length; i++)
                {
                    coolness += match.Groups["emoji"].Value[i];
                }

                if (coolness >= coolThreshold)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
