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
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string[] words = await File.ReadAllLinesAsync("words.txt");
            string[] text = await File.ReadAllLinesAsync("text.txt");
            string buffer = words[0];
            words = buffer.Split(' ');

            foreach (var word in words)
            {
                if (wordsCount.ContainsKey(word) == false)
                {
                    wordsCount.Add(word, 0);
                }

                foreach (var row in text)
                {
                    string[] current = row.Split(new char[] {' ', '-', '.', ',' });

                    foreach (var item in current)
                    {
                        if (word.ToLower() == item.ToLower())
                        {
                            wordsCount[word]++;
                        }
                    }
                }
            }

            foreach (var (key, value) in wordsCount.OrderByDescending(x => x.Value))
            {
                await File.AppendAllTextAsync("output.txt", $"{key} - {value} {Environment.NewLine}");
                //System.Console.WriteLine($"{key} - {value}");
            }
        }
    }
}
