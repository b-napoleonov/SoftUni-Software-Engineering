using System;
using System.IO;
using System.Threading.Tasks;

namespace _02._LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] lines = await File.ReadAllLinesAsync("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                int letterCount = CountLetters(lines[i]);
                int puncCount = CountPunctuation(lines[i]);

                await File.AppendAllTextAsync("output.txt", $"Line {i + 1}: {lines[i]} ({letterCount})({puncCount}) {Environment.NewLine}");
            }
        }

        static int CountPunctuation(string line)
        {
            int count = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsPunctuation(line[i]))
                {
                    count++;
                }
            }

            return count;
        }

        static int CountLetters(string line)
        {
            int count = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsLetter(line[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
