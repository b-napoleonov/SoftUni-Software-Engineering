using System;
using System.IO;
using System.Threading.Tasks;

namespace _01._OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] linesRead = await File.ReadAllLinesAsync("input.txt");

            for (int i = 0; i < linesRead.Length; i++)
            {
                if (i % 2 == 1)
                {
                    await File.AppendAllTextAsync("output.txt", linesRead[i] + "\r \n");
                }
            }
        }
    }
}
