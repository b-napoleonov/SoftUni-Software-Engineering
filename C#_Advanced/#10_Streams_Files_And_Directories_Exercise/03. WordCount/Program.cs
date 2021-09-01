using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03._WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            string[] words = await File.ReadAllLinesAsync("words.txt");
            string text = await File.ReadAllTextAsync("text.txt");
            string[] splitted = text.Split(new char[] { '-', ',', '.', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < splitted.Length; j++)
                {
                    if (words[i].ToLower() == splitted[j].ToString().ToLower())
                    {
                        if (wordCount.ContainsKey(words[i]) == false)
                        {
                            wordCount.Add(words[i], 0);
                        }

                        wordCount[words[i]]++;
                    }
                }
            }

            foreach (var (key, value) in wordCount.OrderByDescending(x => x.Value))
            {
                await File.AppendAllTextAsync("actualResult.txt", $"{key} - {value} {Environment.NewLine}");
            }
        }
    }
}
