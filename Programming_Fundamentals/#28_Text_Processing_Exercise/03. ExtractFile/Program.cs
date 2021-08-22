using System;
using System.IO;

namespace _03._ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullPath = Console.ReadLine();

            string filename = Path.GetFileNameWithoutExtension(fullPath);
            string extension = Path.GetExtension(fullPath).Replace(".", "");

            Console.WriteLine($"File name: {filename}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
