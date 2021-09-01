using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._EvenLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using StreamReader reader = new StreamReader("text.txt");
            using StreamWriter writer = new StreamWriter("output.txt");

            string currentLine = await reader.ReadLineAsync();
            int counter = 0;

            while (currentLine != null)
            {
                if (counter % 2 == 0)
                {

                    currentLine = Replace(currentLine);
                    currentLine = Reverse(currentLine);

                    await writer.WriteLineAsync(currentLine);
                }

                counter++;
                currentLine = await reader.ReadLineAsync();
            }
        }

        private static string Reverse(string currentLine)
        {
            string[] words = currentLine.Split(' ');

            StringBuilder replaced = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                replaced.Append(words[words.Length - 1 - i]);
                replaced.Append(' ');
            }

            return replaced.ToString();
        }

        private static string Replace(string currentLine)
        {
            char[] charToReplace = new char[] { '-', ',', '.', '!', '?' };
            StringBuilder modifiedText = new StringBuilder();

            for (int i = 0; i < currentLine.Length; i++)
            {
                char current = currentLine[i];

                if (charToReplace.Contains(current))
                {
                    modifiedText.Append('@');
                }
                else
                {
                    modifiedText.Append(current);
                }
            }

            return modifiedText.ToString();
        }
    }
}
