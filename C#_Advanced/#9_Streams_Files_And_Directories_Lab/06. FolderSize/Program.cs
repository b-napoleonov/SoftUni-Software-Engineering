using System;
using System.IO;
using System.Threading.Tasks;

namespace _06._FolderSize
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] fileNames = Directory.GetFiles("TestFolder");
            double totalSize = 0;

            foreach (var fileName in fileNames)
            {
                FileInfo info = new FileInfo(fileName);
                totalSize += info.Length;
            }

            totalSize = totalSize / 1024 / 1024;

            //Console.WriteLine(totalSize);

            await File.WriteAllTextAsync("output.txt", totalSize.ToString());
        }
    }
}
