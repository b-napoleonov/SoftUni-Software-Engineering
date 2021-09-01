using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _05._DirectoryTraversal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();
            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;

                if (filesByExtension.ContainsKey(extension) == false)
                {
                    filesByExtension.Add(extension, new List<FileInfo>());
                }

                filesByExtension[extension].Add(info);
            }

            using StreamWriter writer = 
                new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/report.txt");
            foreach (var (key, value) in filesByExtension.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                await writer.WriteLineAsync(key);

                foreach (var item in value.OrderBy(x => Math.Ceiling((double)x.Length / 1024)))
                {
                    await writer.WriteLineAsync($"--{item.Name} - {Math.Ceiling((double)item.Length / 1024)} kb");
                }
            }
        }
    }
}
