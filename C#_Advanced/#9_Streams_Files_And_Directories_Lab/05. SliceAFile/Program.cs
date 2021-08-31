using System;
using System.IO;
using System.Threading.Tasks;

namespace _05._SliceFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int parts = 4;
            byte[] buffer = new byte[4096];
            int totalBytes = 0;

            using (FileStream fs = new FileStream("sliceMe.txt", FileMode.Open, FileAccess.Read))
            {
                int partSize = (int)Math.Ceiling((double)fs.Length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    int readBytes = 0;

                    using (FileStream ofs = new FileStream($"Part-{i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (readBytes < partSize && totalBytes < fs.Length)
                        {
                            int bytesToRead = Math.Min(buffer.Length, partSize - readBytes);
                            int bytes = await fs.ReadAsync(buffer, 0, bytesToRead);
                            await ofs.WriteAsync(buffer, 0, bytes);
                            readBytes += bytes;
                            totalBytes += bytes;
                        }
                    }
                }
            }
        }
    }
}
